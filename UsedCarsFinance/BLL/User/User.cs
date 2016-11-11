using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Application;
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
        /// 获取当前用户实例
        /// </summary>
        /// qiy		15.11.19
        /// <returns></returns>
        public UserInfo CurrentUser()
        {
            return GetUser(CurrentUserId);
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
