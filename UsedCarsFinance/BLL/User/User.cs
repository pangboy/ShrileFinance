using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Models.User;

namespace BLL.User
{
    public class User
    {
        //声明对映射类的全局实例, 通过缓存提高效率
        private readonly static DAL.User.UserInfoMapper userMapper = new DAL.User.UserInfoMapper();
        private readonly static DAL.User.RelationMapper relationMapper = new DAL.User.RelationMapper();

        private const string DEFAULT_PASSWORD = "123456";

        /// <summary>
        /// 获取当前用户标识
        /// </summary>
        /// qiy		15.11.19
        public static int CurrentUserId
        {
            get { return Convert.ToInt32(HttpContext.Current.User.Identity.Name); }
        }



        /// <summary>
        /// 获取用户
        /// </summary>
        /// qiy		15.11.12
        /// <param name="userId">标识</param>
        /// <returns></returns>
        public UserInfo GetUser(int userId)
        {
            if (default(int).Equals(userId)) return null;

            UserInfo user = userMapper.Find(userId);

            if (user != null && default(int).Equals(user.RoleId))
            {
                user.RoleId = GetRole(userId);
            }

            return user;
        }

        /// <summary>
        /// 用户选项
        /// </summary>
        /// qiy     16.05.31
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public List<Models.ComboInfo> Option(int? roleId)
        {
            return userMapper.Option(roleId);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// qiy		15.11.13
        /// qiy		16.03.07    增加多角色的绑定
        /// <param name="value">用户实体</param>
        /// <returns></returns>
        public bool Add(UserInfo value)
        {
            //设置初始值
            value.Password = MD5Crypto(DEFAULT_PASSWORD);
            value.Status = UserInfo.StatusEnum.正常;
            value.RegisterDate = DateTime.Now;

            userMapper.Insert(value);

            bool result = !default(int).Equals(value.UserId)
                && BindRole(value);

            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// qiy		15.11.13
        /// qiy		16.03.07
        /// <param name="value">用户实体</param>
        /// <returns></returns>
        public bool Modify(UserInfo value)
        {
            UserInfo user = GetUser(value.UserId);

            if (user == null) return false;

            user.Name = value.Name;
            user.RoleId = value.RoleId;
            user.Email = value.Email;
            user.Mobile = value.Mobile;
            user.Remarks = value.Remarks;

            return userMapper.Update(user) && BindRole(value);
        }

        /// <summary>
        /// 用MD5的方式加密字符串
        /// </summary>
        /// qiy		15.11.17
        /// <param name="text">要加密的字符串</param>
        /// <returns></returns>
        private string MD5Crypto(string text)
        {
            string hash = string.Empty;

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                //计算哈希值
                hash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
            }

            return hash;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// qiy		15.11.19
        /// <param name="username">用户名</param>
        /// <param name="password">密码(明文)</param>
        /// <returns></returns>
        public bool SignIn(string username, string password, out string message)
        {
            //返回加密后的密码
            string password_md5 = MD5Crypto(password);

            //根据用户名和密码查找用户
            UserInfo user = userMapper.FindByAccount(username, password_md5);

            message = "用户名或密码错误!";
            if (user == null) return false;

            message = "用户已停用!";
            if (user.Status == UserInfo.StatusEnum.停用) return false;

            if (FormsAuthentication.IsEnabled)
            {
                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), true);

                return true;
            }
            else
            {
                throw new Exception("不支持Forms认证方式");
            }
        }
        /// <summary>
        /// 用户注销
        /// </summary>
        /// qiy		15.11.19
        /// <returns></returns>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// 获取当前用户实例
        /// </summary>
        /// qiy		15.11.19
        /// <returns></returns>
        public UserInfo CurrentUser()
        {
            return GetUser(CurrentUserId);
        }

        /// <summary>
        /// 重置密码为123456
        /// </summary>
        /// qiy		15.11.17
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public bool ResetPassword(int userId, out string message)
        {
            message = "重置失败!";
            return ModifyPassword(userId, DEFAULT_PASSWORD);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// qiy		15.11.17
        /// qiy		16.03.07
        /// <param name="userId">用户标识</param>
        /// <param name="password">密码(明文)</param>
        /// <returns></returns>
        private bool ModifyPassword(int userId, string password)
        {
            UserInfo user = GetUser(userId);

            if (user == null) return false;

            //返回加密后的密码
            user.Password = MD5Crypto(password);

            return userMapper.Update(user);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// yaoy    15.11.26
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ModifyPassword(int userId, string old_password, string new_password, out string message)
        {
            UserInfo user = userMapper.Find(userId);

            //验证密码是否正确
            message = "旧密码错误，请重新输入!";
            if (user.Password != MD5Crypto(old_password)) return false;

            message = "修改失败!";
            return ModifyPassword(userId, new_password);
        }

        /// <summary>
        /// 启用帐号
        /// </summary>
        /// qiy		15.11.17
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public bool Enable(int userId)
        {
            UserInfo user = GetUser(userId);

            if (user == null) return false;

            //返回加密后的密码
            user.Status = UserInfo.StatusEnum.正常;

            return userMapper.Update(user);
        }
        /// <summary>
        /// 停用帐号
        /// </summary>
        /// qiy		15.11.17
        /// <param name="userId">用户标识</param>
        /// <returns></returns>
        public bool Disable(int userId)
        {
            UserInfo user = GetUser(userId);

            if (user == null) return false;

            //返回加密后的密码
            user.Status = UserInfo.StatusEnum.停用;

            return userMapper.Update(user);
        }

        /// <summary>
        /// 检查用户名是否重复
        /// </summary>
        /// qiy		15.11.25
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool CheckUsername(string username)
        {
            return userMapper.FindByUsername(username) == 0;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// qiy		15.11.17
        /// <param name="page">分页信息</param>
        /// <param name="filter">筛选条件</param>
        /// <returns></returns>
        public DataTable List(Models.Pagination page, NameValueCollection filter)
        {
            return userMapper.List(page, filter);
        }



        /// <summary>
        /// 获取用户所拥有的角色
        /// </summary>
        /// <param name="userId">标识</param>
        /// <returns></returns>
        private int GetRole(int userId)
        {
            List<int> roles = relationMapper.FindByUser(userId);

            return roles.Count > 0 ? roles[0] : default(int);
        }

        /// <summary>
        /// 绑定角色到用户
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private bool BindRole(UserInfo value)
        {
            relationMapper.DeleteByUser(value.UserId);

            List<int> roles = new List<int>(1) { value.RoleId };
            return relationMapper.InserByUser(value.UserId, roles) > 0;
        }
    }
}
