using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Role isim alanı boş bırakalamaz!")]
        [Display(Name = "Role İsmi:")]
        public string Name { get; set; }
    }
}
