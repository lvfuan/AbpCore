using System.ComponentModel.DataAnnotations;

namespace AbpCore.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}