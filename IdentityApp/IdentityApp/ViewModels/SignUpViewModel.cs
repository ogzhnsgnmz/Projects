using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace IdentityApp.ViewModels;

public class SignUpViewModel
{
    [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakalamaz!")]
    [Display(Name = "Kullanıcı Adı:")]
    public string UserName { get; set; } = null!;
    [EmailAddress(ErrorMessage = "Email formatı yanlıştır!")]
    [Required(ErrorMessage = "Email alanı boş bırakalamaz!")]
    [Display(Name = "Email :")]
    public string EMail { get; set; } = null!;
    [Required(ErrorMessage = "Telefon alanı boş bırakalamaz!")]
    [Display(Name = "Telefon:")]
    public string Phone { get; set; } = null!;
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Şifre alanı boş bırakalamaz!")]
    [Display(Name = "Şifre:")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Şifre aynı değildir!")]
    [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakalamaz!")]
    [Display(Name = "Şifre Tekrar:")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
    public string PasswordConfirm { get; set; } = null!;

    public SignUpViewModel()
    {
            
    }

    public SignUpViewModel(string password, string phone, string eMail, string userName, string passwordConfirm)
    {
        Password = password;
        Phone = phone;
        EMail = eMail;
        UserName = userName;
        PasswordConfirm = passwordConfirm;
    }
}
