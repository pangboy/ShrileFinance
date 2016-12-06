namespace Application.ViewModels.OrganizationViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BigEventViewModel:IEntityViewModel
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 大事件流水号
        /// </summary>
        [Display(Name = "大事件流水号"), Required, MaxLength(60)]
        public string BigEventNumber { get; set; }

        /// <summary>
        /// 大事件描述
        /// </summary>
        [Display(Name = "大事描述"), Required, MaxLength(250)]
        public string BigEventDescription { get; set; }
    }
}
