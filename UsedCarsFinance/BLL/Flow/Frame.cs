using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Flow;

namespace BLL.Flow
{
    public class Frame
    {

        /// <summary>
        /// 框架页信息
        /// </summary>
        /// qiy     16.04.29
        /// qiy     16.05.09
        /// yand    16.08.29(取消menu通过表单获取)
        /// wangpf  16.09.11 代码注释,修改表单获取逻辑
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public object GetFrameAllInfo(int instanceId)
        {
            var _action = new Action();
            var _instance = new Instance();
            var _form = new Form();

            // 根据实例Id获取当前操作的节点Id
            int nodeId = _instance.Get(instanceId).CurrentNode.Value;

            // 根据当前节点Id获取当前所有操作的行为
            var actions = _action.GetByNode(nodeId);

            // 根据当前节点Id获取当前所有操作的表单
            var forms = _form.GetForms(nodeId);

            return new
            {
                Actions = actions,
                FormInfo = forms,
                XMLData = _instance.GetXMLData(instanceId),
                InOpinion = (new User.Role().Get(new User.User().CurrentUser().RoleId).Power <= 3)
            };
        }

        /// <summary>
        /// 框架页信息
        /// </summary>
        /// qiy     16.05.09
        /// wangpf  16.09.11 流程表单获取来源修改
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public object GetFrameInfo(int instanceId)
        {
            var _form = new Form();
            var _instance = new Instance();
            var user = new User.User().CurrentUser();

            return new
            {
                //FormInfo = _form.GetRoleMenus(user.RoleId),
                Menus = _form.GetRoleMenus(user.RoleId),
                XMLData = _instance.GetXMLData(instanceId)
            };
        }
    }
}
