using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Flow
{
    /// <summary>
    /// 流程数据
    /// </summary>
    /// qiy     16.04.29
    /// <typeparam name="T">业务数据类型</typeparam>
    public class FlowData<T>
    {
        public FlowData FlowInfo { get; set; }
        public T BData { get; set; }
    }

    /// <summary>
    /// 流程使用的相关数据
    /// </summary>
    /// qiy     16.04.29
    /// yand    16.08.29
    public class FlowData
    {
        public int? InstanceId { get; set; }
        public int ActionId { get; set; }
        public int? FindUserValue { get; set; }
        public string InOpinion { get; set; }
        public string ExOpinion { get; set; }
        public string InstanceData { get; set; }
        public string BusinessData { get; set; }
    }
}
