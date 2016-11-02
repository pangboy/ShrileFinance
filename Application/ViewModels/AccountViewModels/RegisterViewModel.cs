namespace Application.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        [Required]
        [StringLength(64)]
        public string Id { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "用户名")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "手机")]
        public string Phone { get; set; }
    }
}
