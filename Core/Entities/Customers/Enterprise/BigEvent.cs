namespace Core.Entities.Customers.Enterprise
{
    public class BigEvent : Entity
    {
        /// <summary>
        /// 大事件流水号
        /// </summary>
        public string BigEventNumber { get; set; }

        /// <summary>
        /// 大事件描述
        /// </summary>
        public string BigEventDescription { get; set; }
    }
}
