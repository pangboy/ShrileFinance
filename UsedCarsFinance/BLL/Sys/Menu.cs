using System;
using System.Collections.Generic;
using System.Data;
using Application;
using Models;
using Models.Sys;

namespace BLL.Sys
{
	public class Menu
	{
		//声明对映射类的全局实例, 通过缓存提高效率
		private readonly static DAL.Sys.MenuMapper menuMapper = new DAL.Sys.MenuMapper();
		private readonly static DAL.User.PermissionsMapper permissionsMapper = new DAL.User.PermissionsMapper();
        private AccountAppService service;

        public Menu(AccountAppService service)
        {
            this.service = service;
        }

        /// <summary>
        /// 仅获取授权的菜单树
        /// </summary>
        /// yand    15.11.23
        /// qiy		15.11.27	考虑安全性, 角色标识从当前用户中获取.
        /// qiy		15.12.25	优化查询
        /// <returns></returns>
        public List<MenuInfo> GetOnlyAuthorization()
		{
            string roleId = service.CurrentRole().Name;

			List<MenuInfo> result = GetWithPermissions(roleId);

			for (int i = 0; i < result.Count; i++)
			{
				if (!result[i].HasPermission)
				{
					result.Remove(result[i--]);
				}
			}

			return BuildStruct(result);
		}

		/// <summary>
		/// 根据角色获取菜单树
		/// </summary>
		/// yaoy    15.11.25
		/// qiy		15.12.25	优化查询方式
		/// <param name="roleId"></param>
		/// <returns></returns>
		public List<MenuInfo> GetByRole(string roleId)
		{
			List<MenuInfo> menus = GetWithPermissions(roleId);

			return BuildStruct(menus);
		}


		/// <summary>
		/// 获取带有权限信息的菜单列表
		/// </summary>
		/// qiy		15.12.28
		/// <param name="roleId">角色标识(可选)</param>
		/// <returns></returns>
		private List<MenuInfo> GetWithPermissions(string roleId)
		{
			List<MenuInfo> menus = menuMapper.FindALL();
			List<int> permissions = !string.IsNullOrEmpty(roleId) ? permissionsMapper.FindByRole(roleId) : new List<int>(0);

			foreach (MenuInfo menu in menus)
			{
				menu.HasPermission = permissions.Contains(menu.MenuId);
			}

			return menus;
		}

		/// <summary>
		/// 将列表构造为关系结构
		/// </summary>
		/// yand    15.11.24
		/// <param name="allMenus"></param>
		/// <returns></returns>
		private List<MenuInfo> BuildStruct(List<MenuInfo> allMenus)
		{
			List<MenuInfo> result = new List<MenuInfo>();

			foreach (MenuInfo item in allMenus)
			{
				if (!item.ParentId.HasValue)
				{
					item.Children = new List<MenuInfo>();

					foreach (MenuInfo children in allMenus)
					{
						if (children.ParentId.HasValue && children.ParentId.Value == item.MenuId)
							item.Children.Add(children);
					}

					result.Add(item);
				}
			}

			return result;
		}

		/// <summary>
		/// 通过标识查询菜单信息
		/// </summary>
		/// yand    15.11.24
		/// <param name="menuId"></param>
		/// <returns></returns>
		public MenuInfo Get(int menuId)
		{
			return menuMapper.Find(menuId);
		}

		/// <summary>
		/// 获取菜单列表
		/// </summary>
		/// yand    15.11.23
		/// <returns></returns>
		public DataTable List()
		{
			return menuMapper.MenuList();
		}

		/// <summary>
		/// 添加菜单
		/// </summary>
		/// yand    15.11.23
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Add(MenuInfo value)
		{
			menuMapper.Insert(value);

			return value.MenuId > 0;
		}

		/// <summary>
		/// 更新菜单
		/// </summary>
		/// yand    15.11.24
		/// <returns></returns>
		public bool Modify(MenuInfo value)
		{
			MenuInfo menu = Get(value.MenuId);

			if (menu == null) return false;

			menu.Name = value.Name;
			menu.Link = value.Link;
			menu.ParentId = value.ParentId;
			menu.Sort = value.Sort;

			return menuMapper.Update(menu);
		}

		/// <summary>
		/// 获取一级菜单选项
		/// </summary>
		/// yand    15.11.24
		/// <returns></returns>
		public List<ComboInfo> GetParentOptions()
		{
			List<ComboInfo> Result = menuMapper.GetPanrent();

			return Result;
		}

		/// <summary>
		/// 删除菜单
		/// </summary>
		/// yand    15.11.24
		/// <param name="menuId"></param>
		/// <returns></returns>
		public bool Delete(int menuId,out string message)
		{
			message = "该菜单被其它菜单所引用, 无法删除！";
            if (menuMapper.CountChildren(menuId) > 0) return false;

			permissionsMapper.DeleteByMenu(menuId);

			menuMapper.Delete(menuId);

			return true;
		}
	}
}
