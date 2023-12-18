using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();

            //şifrenin içerisinde kullanıcı adı olmasın
            if(password!.ToLower().Contains(user.UserName!.ToLower()))
                errors.Add(new() { Code = "PasswordContainUserName", Description = "Şifre alanı kullanıcı adı içeremez" });

            if (password!.ToLower().StartsWith("1234"))
                errors.Add(new() { Code = "PasswordContain1234", Description = "Şifre alanı ardışık sayı içeremez" });

            if(errors.Any())
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            return Task.FromResult(IdentityResult.Success);
        }
    }
}