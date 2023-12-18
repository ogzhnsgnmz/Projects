using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModels;

public class PasswordChangeViewModel
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Mevcut Şifre alanı boş bırakalamaz!")]
    [Display(Name = "Eski Şifre:")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
    public string? PasswordOld { get; set; } = null!;
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Yeni Şifre alanı boş bırakalamaz!")]
    [Display(Name = "Yeni Şifre:")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
    public string? PasswordNew { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare(nameof(PasswordNew), ErrorMessage = "Şifre aynı değildir!")]
    [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakalamaz!")]
    [Display(Name = "Yeni Şifre Tekrar:")]
    [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olabilir.")]
    public string? PasswordNewConfirm { get; set; } = null!;
}