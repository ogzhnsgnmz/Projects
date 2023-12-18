using System.ComponentModel.DataAnnotations;

namespace IdentityApp.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "Role isim alanı boş bırakalamaz!")]
        [Display(Name = "Role İsmi:")]
        public string Name { get; set; } = null!;
    }
}
