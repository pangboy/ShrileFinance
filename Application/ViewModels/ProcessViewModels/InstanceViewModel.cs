namespace Application.ViewModels.ProcessViewModels
{
    using System;
    using Core.Entities.Flow;

    public class InstanceViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Flow { get; set; }

        public string CurrentNode { get; set; }

        public string CurrentUser { get; set; }

        public string ProcessUser { get; set; }

        public DateTime ProcessTime { get; set; }

        public string StartUser { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime DateTime { get; set; }

        public InstanceStatusEnum Status { get; set; }
    }
}
