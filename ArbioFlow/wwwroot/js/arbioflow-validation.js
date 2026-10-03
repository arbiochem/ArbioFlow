(function () {
    'use strict';

    // ---------- Utilitaires ----------
    const arrondi = (x) => Math.round(x * 1000) / 1000;
    const fmt = (x) => String(arrondi(x)).replace('.', ',');

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
            fmt(qte)
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

    // Met la ligne à jour après une validation réussie.
    //  - tout est livré  -> ligne verrouillée, statut "Livrée"
    //  - reste à livrer  -> ligne reste active, statut "Partiel",
    //                       la quantité préparée devient le reste à livrer
    function marquerValidee(root, tr, qte) {
        const commandee = parseFloat(tr.dataset.commandee);
        const livre = arrondi((parseFloat(tr.dataset.livre) || 0) + qte);
        const reste = Math.max(arrondi(commandee - livre), 0);
        const complet = reste <= 0;

        tr.dataset.livre = livre;

        const resteCell = tr.querySelector('.af-reste');
        if (resteCell) resteCell.textContent = fmt(reste);

        const statut = tr.querySelector('.af-statut');
        const input = tr.querySelector('.af-qte-input');
        const btn = tr.querySelector('.af-btn-valider');

        if (complet) {
            tr.dataset.valide = '1';
            tr.classList.add('ligne-validee');

            if (statut) {
                statut.className = 'af-statut af-statut-complet';
                statut.textContent = 'Livrée';
            }
            if (input) {
                input.value = 0;
                input.dataset.original = '0';
                input.max = 0;
                input.classList.remove('modifie', 'invalide', 'is-invalid');
                input.disabled = true;
            }
            if (btn) { btn.disabled = true; btn.textContent = 'Livrée'; }
        } else {
            if (statut) {
                statut.className = 'af-statut af-statut-partiel';
                statut.textContent = 'Partiel';
            }
            if (input) {
                input.max = reste;
                input.value = reste;
                input.dataset.original = String(reste);
                input.classList.remove('modifie', 'invalide', 'is-invalid');
                input.disabled = false;
            }
            if (btn) { btn.disabled = false; btn.textContent = 'Valider'; }
        }

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
        const livre = parseFloat(tr.dataset.livre) || 0;
        const resteAvant = arrondi(commandee - livre);

        if (isNaN(qte) || qte <= 0 || qte > resteAvant) {
            input.classList.add('is-invalid');
            return 'Quantité invalide pour ' + tr.dataset.ligne +
                ' (reste à livrer : ' + fmt(resteAvant) + ')';
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
                alert('Toutes les lignes sont déjà livrées.');
                return;
            }
            if (!confirm('Valider ' + lignes.length + ' ligne(s) avec les quantités saisies ?')) return;

            btnTout.disabled = true;
            const ancienTexte = btnTout.textContent;
            const erreurs = [];

            for (let i = 0; i < lignes.length; i++) {
                btnTout.textContent = 'Validation ' + (i + 1) + '/' + lignes.length + '…';
                const res = await validerLigne(root, lignes[i]);
                if (res !== true) erreurs.push(res);
            }

            const nbValidees = lignes.length - erreurs.length;

            if (erreurs.length > 0) {
                alert(erreurs.length + ' ligne(s) non validée(s) :\n\n' + erreurs.join('\n'));
            }

            if (nbValidees > 0) {
                btnTout.textContent = 'Actualisation…';
                if (window.afActualiserListe) await window.afActualiserListe();
            }

            btnTout.textContent = ancienTexte;
            btnTout.disabled = false;
        }
    });

    // =====================================================
    // Informations de livraison : sauvegarde automatique champ par champ
    // =====================================================
    const DELAI_SAISIE = 700;      // ms sans frappe avant d'enregistrer (texte / observations)
    const DUREE_MESSAGE = 2000;    // ms d'affichage de "✓ Enregistré"

    let fileSauvegardes = Promise.resolve();   // une requête à la fois (évite les doublons de ligne en base)
    const minuteurs = new WeakMap();           // anti-rebond par champ
    const masquages = new WeakMap();           // masquage du message par section

    function afficherEtat(section, texte, erreur) {
        const s = section.querySelector('.af-save-status');
        if (!s) return;
        clearTimeout(masquages.get(section));
        s.textContent = texte;
        s.classList.toggle('erreur', !!erreur);
        s.classList.add('visible');
        masquages.set(section, setTimeout(function () {
            s.classList.remove('visible', 'erreur');
            s.textContent = '';          // le texte part aussi, même si le CSS n'est pas chargé
        }, erreur ? 4000 : DUREE_MESSAGE));
    }

    function sauvegarderChamp(champ) {
        const root = champ.closest('.af-lignes');
        const section = champ.closest('.af-livraison');
        if (!root || !section) return;

        // Rien à faire si la valeur n'a pas changé depuis la dernière sauvegarde / le chargement
        const reference = champ.dataset.saved !== undefined ? champ.dataset.saved : champ.defaultValue;
        if (reference === champ.value) return;

        const valeur = champ.value;
        champ.dataset.saved = valeur;

        const payload = {
            doPiece: root.dataset.piece,
            champ: champ.dataset.field,
            valeur: valeur
        };

        fileSauvegardes = fileSauvegardes.then(async function () {
            try {
                const resp = await fetch(section.dataset.url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'RequestVerificationToken': getToken(root)
                    },
                    body: JSON.stringify(payload)
                });
                if (!resp.ok) throw new Error(await resp.text());
                afficherEtat(section, '✓ Enregistré', false);
            } catch (err) {
                delete champ.dataset.saved;    // on retentera à la prochaine modification
                afficherEtat(section, '⚠ Échec de l\u2019enregistrement', true);
                console.error('[AF] Livraison non enregistrée :', err);
            }
        });
    }

    // Listes, dates, heures : dès que la valeur change
    document.addEventListener('change', function (e) {
        const champ = e.target.closest('.af-livraison [data-field]');
        if (!champ) return;
        clearTimeout(minuteurs.get(champ));
        sauvegarderChamp(champ);
    });

    // Texte libre : pendant la frappe, avec un petit délai
    document.addEventListener('input', function (e) {
        const champ = e.target.closest('.af-livraison [data-field]');
        if (!champ || (champ.type !== 'text' && champ.type !== 'textarea')) return;
        clearTimeout(minuteurs.get(champ));
        minuteurs.set(champ, setTimeout(function () { sauvegarderChamp(champ); }, DELAI_SAISIE));
    });
})();