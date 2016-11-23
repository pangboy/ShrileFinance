namespace Infrastructure
{
    using System.Collections.Generic;

    public static class Helper
    {
        /// <summary>
        /// 根据角色标识转换为角色名称 [已弃用]
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <returns></returns>
        public static string RoleIdToName(string roleId)
        {
            var dic = new Dictionary<string, string> {
                { "BB42BEE1-05A4-E611-80C5-507B9DE4A488", "系统管理员" },
                { "BC42BEE1-05A4-E611-80C5-507B9DE4A488", "管理员" },
                { "BD42BEE1-05A4-E611-80C5-507B9DE4A488", "初审员" },
                { "BE42BEE1-05A4-E611-80C5-507B9DE4A488", "复审员" },
                { "BF42BEE1-05A4-E611-80C5-507B9DE4A488", "运营" },
                { "C042BEE1-05A4-E611-80C5-507B9DE4A488", "运营复审" },
                { "C142BEE1-05A4-E611-80C5-507B9DE4A488", "财务" },
                { "C242BEE1-05A4-E611-80C5-507B9DE4A488", "总经理" },
                { "C342BEE1-05A4-E611-80C5-507B9DE4A488", "客户经理" },
                { "C442BEE1-05A4-E611-80C5-507B9DE4A488", "渠道经理" }
            };

            return dic[roleId];
        }
    }
}
