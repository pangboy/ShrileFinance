using Model.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
    public class FactoryModel
    {
        /// <summary>
        /// 工厂模式
        /// TODO 补充完所有的信息记录的方法
        /// </summary>
        /// <param name="intoTypeID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static BaseValidate Create(int intoTypeID, MessageInfo data)
        {
            switch (intoTypeID)
            {
                case 1:
                    return new JKRValidate(data);
                default:
                    throw new ApplicationException();
            }
        }
    }
}
