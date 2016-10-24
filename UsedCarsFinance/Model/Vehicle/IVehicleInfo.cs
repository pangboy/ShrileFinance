using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Vehicle
{
	public interface IVehicleInfo
	{
		string MakeCode { get; set; }
		string FamilyCode { get; set; }
		string YearCode { get; set; }
		string VehicleKey { get; set; }
	}
    public class VehicleDescInfo
    {
        [Alias("brand")]
        public string MakeDesc { get; set; }
        public string FamilyDesc { get; set; }
         [Alias("Year")]
        public string YearDesc { get; set; }
        [Alias("SpecialName")]
        public string VehicleDesc { get; set; }
    }

    public class CarHomeInfo
    {
        public string CarBrand { get; set; }
        public string Series { get; set; }
        public string Vehicle { get; set; }
    }
}
