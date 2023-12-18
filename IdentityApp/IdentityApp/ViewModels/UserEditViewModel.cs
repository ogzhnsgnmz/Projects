using IdentityApp.Models;
using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class UserEditViewModel
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
    [DataType(DataType.Date)]
    public string Phone { get; set; } = null!;
    [Display(Name = "Doğum tarihi:")]
    public DateTime? BirthDate { get; set; }
    [Display(Name = "Şehir:")]
    public string? City { get; set; }

    [Display(Name = "Resim:")]
    public IFormFile? Picture { get; set; }

    [Display(Name = "Profil resmi:")]
    public Gender? Gender { get; set; }

    public UserEditViewModel()
    {
        
    }

    public UserEditViewModel(string phone, string eMail, string userName)
    {
        Phone = phone;
        EMail = eMail;
        UserName = userName;
    }
}
