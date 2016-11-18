namespace Application.ViewModels.ProcessViewModels
{
    using System;

    public class ProcessPostedViewModel
    {
        public Guid InstanceId { get; set; }

        public Guid ActionId { get; set; }

        public string InternalOpinion { get; set; }

        public string ExnernalOpinion { get; set; }

        public string Data { get; set; }
    }
}
