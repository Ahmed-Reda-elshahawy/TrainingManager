using System.ComponentModel.DataAnnotations;

namespace TrainingManager.BLL.ViewModels.User
{
    public record LoginVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
