using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class SignInViewModel
{
    [EmailAddress(ErrorMessage = "Email formatı yanlıştır!")]
    [Required(ErrorMessage = "Email alanı boş bırakalamaz!")]
    [Display(Name = "Email:")]
    public string EMail { get; set; } = null!;
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre alanı boş bırakalamaz!")]
    [Display(Name = "Şifre:")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Beni Hatırla:")]
    public bool RememberMe { get; set; }

    public SignInViewModel()
    {
        
    }

    public SignInViewModel(string password, string email)
    {
        Password = password;
        EMail = email;
    }
}
