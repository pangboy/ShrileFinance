using Models.Vehicle;

namespace Models.Finance
{
	/// <summary>
	/// 融资申请-车辆信息
	/// </summary>
	/// qiy		16.03.31
	public class VehicleInfo : IVehicleInfo
	{
		public string MakeCode { get; set; }
		public string FamilyCode { get; set; }
		public string YearCode { get; set; }
		public string VehicleKey { get; set; }
		public string BuyCarPrice { get; set; }
		public string RegisterCity { get; set; }
		public string SallerName { get; set; }
		public string PlateNo { get; set; }
		public string FrameNo { get; set; }
		public string EngineNo { get; set; }
		public string RegisterDate { get; set; }
		public string RunningMiles { get; set; }
		public string FactoryDate { get; set; }
		public string BuyCarYears { get; set; }
		public string Color { get; set; }

        public string NewCarPlateNo { get; set; }
        public string NewCarFrameNo { get; set; }
        public string NewCarEngineNo { get; set; }
        public decimal? Mileage { get; set; }
    }
}
