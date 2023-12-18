using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class ForgetPasswordViewModel
{
    [EmailAddress(ErrorMessage = "Email formatı yanlıştır!")]
    [Required(ErrorMessage = "Email alanı boş bırakalamaz!")]
    [Display(Name = "Email:")]
    public string EMail { get; set; } = null!;
}