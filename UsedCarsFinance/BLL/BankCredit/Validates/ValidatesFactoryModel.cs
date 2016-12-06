using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit.Validates
{
  public class ValidatesFactoryModel
    {
        /// <summary>
        /// 工厂模式
        /// </summary>
        /// <param name="intoTypeID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static BaseValidate Create(int infoTypeID, MessageInfo data)
        {
            // 个人infoTypeId集合
            var infoTypeIds = new List<int> { 33, 34, 36, 37, 38, 39, 40, 41 };
            if (infoTypeIds.Contains(infoTypeID))
            {
                return new PersonalBaseValidate(infoTypeID, data);
            }

            if (infoTypeID == 1)
            {
                return new JKRGKValidate(infoTypeID, data);
            }
            else if(infoTypeID == 2)
            {
                return new JKRZBValidate(infoTypeID, data);
            }
            else if (infoTypeID == 3|| infoTypeID == 4|| infoTypeID == 5|| infoTypeID == 6|| infoTypeID == 7)
            {
                return new JKRCWValidates(infoTypeID, data);
            }
            else if (infoTypeID == 10 || infoTypeID == 11 || infoTypeID == 12 || infoTypeID == 13 || infoTypeID == 14|| infoTypeID == 15 || infoTypeID == 16 || infoTypeID == 17 || infoTypeID == 18 || infoTypeID == 19||
                infoTypeID == 20 || infoTypeID == 21 || infoTypeID == 22 || infoTypeID == 23 || infoTypeID == 24 || infoTypeID == 25 || infoTypeID == 26 || infoTypeID == 27 || infoTypeID == 28 || infoTypeID == 29 || infoTypeID == 30 || infoTypeID == 31)
            {
                return new DKYWValidate(infoTypeID, data);
            }
            else if (infoTypeID == 8|| infoTypeID == 9 )
            {
                return new JKRGZValidate(infoTypeID, data);
            }
            else
            {
                throw new ApplicationException();
            }
        }
    }
}
