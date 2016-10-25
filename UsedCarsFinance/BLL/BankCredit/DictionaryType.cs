using DAL.BankCredit;
using Models;
using Models.BankCredit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BankCredit
{
    public class DictionaryType
    {
        private static readonly DAL.BankCredit.DictionaryTypeMapper dictionaryTypeMapper = new DAL.BankCredit.DictionaryTypeMapper();

        /// <summary>
        /// 查找单个
        /// </summary>
        /// yangj    16.07.01
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        public DictionaryTypeInfo Find(int dictionaryTypeId)
        {
            return dictionaryTypeMapper.Find(dictionaryTypeId);
        }

        /// <summary>
        /// 查找字典类型列表
        /// </summary>
        /// yangj    16.07.01
        /// <param name="dictionaryTypeId">字典类型ID</param> 
        /// <returns></returns>
        public DataTable List(Models.Pagination page, NameValueCollection filter)
        {
            return dictionaryTypeMapper.List(page, filter);
        }

        /// <summary>
        /// 下拉框列表
        /// </summary>
        /// yangj    16.07.01
        /// <param name="dictionaryTypeId">字典类型ID</param>
        /// <returns></returns>
        public List<ComboInfo> GetComList()
        {
            return dictionaryTypeMapper.GetComList();
        }

        /// <summary>
        /// 增加一条字典类型
        /// </summary>
        /// yangj    16.07.01
        /// <param name="value">字典类型实体</param>
        /// <returns></returns>
        public bool Add(DictionaryTypeInfo value)
        {
            dictionaryTypeMapper.Insert(value);

            return value.DictionaryTypeId > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// yangj    16.07.01
        /// <param name="value">字典类型实体</param>
        /// <returns></returns>
        public bool Modify(DictionaryTypeInfo value)
        {
            int i = dictionaryTypeMapper.Update(value);
            return  i> 0;
        }
    }
}
