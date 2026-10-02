(function () {
    'use strict';

    // ---------- Utilitaires ----------
    function getToken(root) {
        const t = root.querySelector('input[name="__RequestVerificationToken"]');
        return t ? t.value : '';
    }

    function majCompteur(root) {
        const total = root.querySelectorAll('tbody tr[data-ligne]');
        const ok = root.querySelectorAll('tbody tr[data-ligne][data-valide="1"]');
        const c = root.querySelector('.af-compteur');
        if (c) c.textContent = ok.length;
        return { total: total.length, ok: ok.length };
    }

    function ajouterHistorique(root, tr, qte, validateur) {
        const body = root.querySelector('.af-histo-body');
        if (!body) return;

        const vide = body.querySelector('.af-histo-vide');
        if (vide) vide.style.display = 'none';

        const now = new Date();
        const dateStr = now.toLocaleDateString('fr-FR') + ' ' +
            now.toLocaleTimeString('fr-FR', { hour: '2-digit', minute: '2-digit' });

        const cells = [
            root.dataset.piece || '',
            tr.dataset.ligne,
            dateStr,
            validateur,
            tr.dataset.design || '',
            String(qte).replace('.', ',')
        ];

        const row = document.createElement('tr');
        cells.forEach(function (txt, i) {
            const td = document.createElement('td');
            td.textContent = txt;
            if (i === 5) td.className = 'text-end';
            row.appendChild(td);
        });
        body.insertBefore(row, vide || null);
    }

    function marquerValidee(root, tr, qte) {
        const commandee = parseFloat(tr.dataset.commandee);
        const reste = Math.max(commandee - qte, 0);

        tr.dataset.valide = '1';

        const resteCell = tr.querySelector('.af-reste');
        if (resteCell) resteCell.textContent = String(reste).replace('.', ',');

        const statut = tr.querySelector('.af-statut');
        if (statut) {
            statut.textContent = 'Livrée';
            statut.classList.remove('af-statut-attente');
            statut.classList.add('af-statut-valide');
        }

        const input = tr.querySelector('.af-qte-input');
        if (input) input.disabled = true;

        const btn = tr.querySelector('.af-btn-valider');
        if (btn) { btn.disabled = true; btn.textContent = 'Livrée'; }

        majCompteur(root);
    }

    // ---------- Validation d'une ligne ----------
    // Retourne true si OK, sinon un message d'erreur (string)
    async function validerLigne(root, tr) {
        if (tr.dataset.valide === '1') return true;

        const table = root.querySelector('.af-table');
        const input = tr.querySelector('.af-qte-input');
        const qte = parseFloat(input.value);
        const commandee = parseFloat(tr.dataset.commandee);

        if (isNaN(qte) || qte < 0 || qte > commandee) {
            input.classList.add('is-invalid');
            return 'Quantité invalide pour ' + tr.dataset.ligne;
        }
        input.classList.remove('is-invalid');

        const btn = tr.querySelector('.af-btn-valider');
        if (btn) btn.disabled = true;

        try {
            const resp = await fetch(table.dataset.url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': getToken(root)
                },
                body: JSON.stringify({
                    doPiece: root.dataset.piece,
                    arRef: tr.dataset.ligne,
                    qtePreparee: qte,
                    designation: tr.dataset.design || ''
                })
            });

            if (!resp.ok) {
                const msg = await resp.text();
                if (btn) btn.disabled = false;
                return tr.dataset.ligne + ' : ' + (msg || 'Erreur serveur');
            }

            marquerValidee(root, tr, qte);
            ajouterHistorique(root, tr, qte, root.dataset.validateur || '');
            return true;
        } catch (e) {
            if (btn) btn.disabled = false;
            return tr.dataset.ligne + ' : erreur réseau';
        }
    }

    // ---------- Événements (délégation : fonctionne avec la vue partielle chargée en AJAX) ----------
    document.addEventListener('click', async function (e) {
        // Valider une ligne
        const btnLigne = e.target.closest('.af-btn-valider');
        if (btnLigne) {
            const root = btnLigne.closest('.af-lignes');
            const tr = btnLigne.closest('tr[data-ligne]');
            const res = await validerLigne(root, tr);
            if (res !== true) alert(res);
            return;
        }

        // Tout valider
        const btnTout = e.target.closest('.af-btn-tout-valider');
        if (btnTout) {
            const root = btnTout.closest('.af-lignes');
            const lignes = Array.from(
                root.querySelectorAll('tbody tr[data-ligne]:not([data-valide="1"])'));

            if (lignes.length === 0) {
                alert('Toutes les lignes sont déjà validées.');
                return;
            }
            if (!confirm('Valider ' + lignes.length + ' ligne(s) avec les quantités saisies ?')) return;

            btnTout.disabled = true;
            const ancienTexte = btnTout.textContent;
            const erreurs = [];

            // Séquentiel pour garder l'ordre dans l'historique et éviter les conflits d'écriture
            for (let i = 0; i < lignes.length; i++) {
                btnTout.textContent = 'Validation ' + (i + 1) + '/' + lignes.length + '…';
                const res = await validerLigne(root, lignes[i]);
                if (res !== true) erreurs.push(res);
            }

            btnTout.textContent = ancienTexte;
            btnTout.disabled = false;

            if (erreurs.length > 0) {
                alert(erreurs.length + ' ligne(s) non validée(s) :\n\n' + erreurs.join('\n'));
            }
        }
    });
})();