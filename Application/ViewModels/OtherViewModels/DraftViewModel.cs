namespace Application.ViewModels.OtherViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class DraftViewModel
    {
        [Required]
        [StringLength(400)]
        public string PageLink { get; set; }

        [Required]
        public string PageData { get; set; }
    }
}
