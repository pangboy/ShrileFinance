using System.Collections.Generic;

namespace Models.Credit
{
	/// <summary>
	/// 授信主体信息
	/// </summary>
	/// qiy		16.03.29
	public class CreditInfo
	{
		public int CreditId { get; set; }
		public string Name { get; set; }
		public TypeEnum Type { get; set; }
		public decimal LineOfCredit { get; set; }
		public List<Models.Produce.ProduceInfo> Produces { get; set; }
		public string Remarks { get; set; }

        public ProcessUserInfo ProcessUser { get; set; }


        public enum TypeEnum
		{
			渠道授信 = 1
		}
	}
}
