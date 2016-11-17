namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using System.Collections.Generic;

    public class ProcessPostedViewModel
    {
        public Guid InstanceId { get; set; }

        public Guid ActionId { get; set; }

        public string InternalOpinion { get; set; }

        public string ExnernalOpinion { get; set; }

        public IEnumerable<string> Data { get; set; }
    }
}
