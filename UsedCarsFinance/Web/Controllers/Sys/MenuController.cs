using Model;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using Model.Sys;

namespace Web.Controllers.Sys
{
	public class MenuController : ApiController
	{
		private static readonly BLL.Sys.Menu _menu = new BLL.Sys.Menu();

		/// <summary>
		/// 仅获取授权的菜单树(首页菜单)
		/// </summary>
		/// yand    15.11.23
		/// <returns></returns>
		[HttpGet]
		public List<MenuInfo> GetOnlyAuthorization()
		{
			List<MenuInfo> menuInfo = _menu.GetOnlyAuthorization();

			return menuInfo;
		}

		/// <summary>
		/// 获取菜单树(权限分配)
		/// </summary>
		/// yaoy    15.11.26
		/// qiy		15.12.29
		/// <returns></returns>
		[HttpGet]
		public List<MenuInfo> Tree(int roleId)
		{
			List<MenuInfo> menus = _menu.GetByRole(roleId);

			return menus;
		}

		/// <summary>
		/// 获取菜单列表
		/// </summary>
		/// yand    15.11.23
		/// <returns></returns>
		[HttpGet]
		public DataTable List()
		{
			return _menu.List();
		}

		/// <summary>
		/// 根据标识查询菜单
		/// </summary>
		/// yand    15.11.24
		/// <param name="menuId"></param>
		/// <returns></returns>
		public MenuInfo Get(int menuId)
		{
			return _menu.Get(menuId);
		}

		/// <summary>
		/// 查询父级菜单
		/// </summary>
		/// yand    15.11.24
		/// <returns></returns>
		public List<ComboInfo> GetParent()
		{
			return _menu.GetParentOptions();
		}


		/// <summary>
		/// 添加菜单
		/// </summary>
		/// yand    15.11.23
		/// <param name="value"></param>
		/// <returns></returns>
		public IHttpActionResult Post(MenuInfo value)
		{
			return _menu.Add(value) ? (IHttpActionResult)Ok() : BadRequest("保存失败");
		}

		/// <summary>
		/// 更新菜单
		/// </summary>
		/// yand    15.11.24
		/// <param name="menuId"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public IHttpActionResult Put(MenuInfo value)
		{
			return _menu.Modify(value) ? (IHttpActionResult)Ok() : BadRequest("更新失败");
		}

		/// <summary>
		/// 删除菜单
		/// </summary>
		/// yand    15.11.24
		/// <param name="menuId"></param>
		/// <returns></returns>
		[HttpGet]
		public IHttpActionResult Delete(int menuId)
		{
			string message;

			return _menu.Delete(menuId, out message) ? (IHttpActionResult)Ok() : BadRequest(message);
		}
	}
}
