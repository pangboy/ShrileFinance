using System;
using System.Collections.Generic;
using Model;
using Model.Vehicle;

namespace BLL.Vehicle
{
	/// <summary>
	/// 车型选项接口
	/// </summary>
	/// qiy		16.03.31
	public interface IVehicleOption
	{
		void Get(IVehicleInfo vehicle);
		/// <summary>
		/// 品牌选项
		/// </summary>
		/// qiy		16.03.31
		/// <returns></returns>
		List<ComboInfo> MakeOption();

		/// <summary>
		/// 车系选项
		/// </summary>
		/// qiy		16.03.31
		/// <param name="MakeCode">品牌编号</param>
		/// <returns></returns>
		List<ComboInfo> FamilyOption(string MakeCode);

		/// <summary>
		/// 年款选项
		/// </summary>
		/// qiy		16.03.31
		/// <param name="MakeCode">品牌编号</param>
		/// <param name="FamilyCode">车系编号</param>
		/// <returns></returns>
		List<ComboInfo> YearOption(string MakeCode, string FamilyCode);

		/// <summary>
		/// 车型选项
		/// </summary>
		/// qiy		16.03.31
		/// <param name="MakeCode">品牌编号</param>
		/// <param name="FamilyCode">车系编号</param>
		/// <param name="YearCode">年款编号</param>
		/// <returns></returns>
		List<ComboInfo> VehicleOption(string MakeCode, string FamilyCode, string YearCode);
	}
}
