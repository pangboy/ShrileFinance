namespace Core.Entities
{
    using System;
    using Interfaces;

    /// <summary>
    /// 用户
    /// </summary>
    public class User : Entity, IAggregateRoot
    {
        /// <summary>
        /// 默认密码
        /// </summary>
        private const string DEFAULT_PASSWORD = "123456";

        public User()
        {
            CreatedTime = DateTime.Now;
            Activated = true;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool Activated { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public void Enable()
        {
            Activated = true;
        }

        /// <summary>
        /// 禁用
        /// </summary>
        public void Disable()
        {
            Activated = false;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        public void ResetPassword()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        public void ModifyPassword(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
