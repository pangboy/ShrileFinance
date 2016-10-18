using Model.Flow;
using System.Collections.Generic;

namespace BLL.Flow
{
    /// <summary>
    /// 流程表单业务类
    /// </summary>
    /// wangpf  16.09.11
    public class Form
    {
        private static readonly DAL.Flow.FlowFormMapper formMapper = new DAL.Flow.FlowFormMapper();

        /// <summary>
        ///  获取当前节点所有的流程表单
        /// </summary>
        /// wangpf  16.09.11
        /// <param name="nodeId">节点Id</param>
        /// <returns></returns>
        public List<FlowForm> GetForms(int nodeId)
        {
            return formMapper.FindByNodeID(nodeId);
        }

        /// <summary>
        /// 获取角色所有的流程表单
        /// </summary>
        /// wangpf  16.09.11
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<FlowForm> GetRoleMenus(int roleId)
        {
            return formMapper.FindByRole(roleId);
        }
    }
}
