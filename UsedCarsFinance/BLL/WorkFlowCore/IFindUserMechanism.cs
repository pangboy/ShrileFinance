using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkFlowCore
{
    public interface IFindUserMechanism
    {
        /// <summary>
        /// 寻找用户
        /// </summary>
        /// <returns></returns>
        int FindUser();
    }
}
