using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class ResetPasswordViewModel
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre alanı boş bırakalamaz!")]
    [Display(Name = "Yeni Şifre:")]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Şifre aynı değildir!")]
    [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakalamaz!")]
    [Display(Name = "Yeni Şifre Tekrar:")]
    public string PasswordConfirm { get; set; } = null!;
}
