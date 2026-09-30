using System.ComponentModel.DataAnnotations;

namespace ArbioFlow.Models;

public class InscriptionViewModel
{
    [Required(ErrorMessage = "Le login est obligatoire.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Le login doit contenir entre 3 et 50 caractères.")]
    [Display(Name = "Login")]
    public string Login { get; set; } = "";

    [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
    [DataType(DataType.Password)]
    [Display(Name = "Mot de passe")]
    public string MotDePasse { get; set; } = "";

    [Required(ErrorMessage = "Veuillez confirmer le mot de passe.")]
    [Compare(nameof(MotDePasse), ErrorMessage = "Les mots de passe ne correspondent pas.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirmation")]
    public string ConfirmationMotDePasse { get; set; } = "";
}