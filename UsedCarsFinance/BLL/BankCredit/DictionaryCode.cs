using Models.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.BankCredit;
using Models;
using System.Collections.Specialized;

namespace BLL.BankCredit
{
    /// <summary>
    /// DictionaryCode类（BLL.Sys）
    /// </summary>
    /// zouql 2016-07-05
    public class DictionaryCode
    {
        /// <summary>
        /// 实例化静态数据访问类
        /// </summary>
        private readonly static DAL.BankCredit.DictionaryCodeMapper dic = new DAL.BankCredit.DictionaryCodeMapper();
        /// <summary>
        /// 获取字典代码表
        /// </summary>
        /// zouql 2016-07-05
        /// <returns>字典代码表</returns>
        public DataTable PageList(Pagination pagination, NameValueCollection filter)
        {
            return dic.PageList(pagination, filter);
        }
        /// <summary>
        /// 获取字典代码实体
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="code"></param>
        /// <param name="dictionaryTypeId"></param>
        /// <returns></returns>
        public DictionaryCodeInfo Get(string code, int dictionaryTypeId)
        {
            return dic.Get(code, dictionaryTypeId);
        }
        /// <summary>
        /// 创建新字典代码行
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="dictionaryCode"></param>
        /// <returns>创建结果</returns>
        public bool Create(DictionaryCodeInfo dicInfo, out string message)
        {
            message = string.Empty;
            bool b = false;
            if (this.CheckSeed(dicInfo))
            {
                b = dic.Create(dicInfo) > 0;
            }
            else
            {
                message = string.Format("字典编号:{0} 已被使用.", dicInfo.Code);
            }
            return b;
        }

        /// <summary>
        /// 通过字典代码修改字典代码表
        /// </summary>
        /// zouql 2016-07-05
        /// <param name="dictionaryCode"></param>
        /// <returns>修改结果</returns>
        public bool Modify(DictionaryCodeInfo dicInfo)
        {
            var dictionary = Get(dicInfo.Code, dicInfo.DictionaryTypeId);
            // 字典代码不存在，返回false；
            if (dictionary == null)
            {
                return false;
            }
            dictionary.DictionaryTypeId = dicInfo.DictionaryTypeId;
            dictionary.Name = dicInfo.Name;
            dictionary.ParentCode = dicInfo.ParentCode;
            // 调用数据访问层执行修改
;            return dic.Modify(dictionary) > 0;
        }
        /// <summary>
		/// 检查种子是否已被使用
		/// </summary>
		/// zouql 2016-07-05
		/// <param name="value"></param>
		/// <returns>不存在返回true</returns>
		private bool CheckSeed(DictionaryCodeInfo value)
        {
            var dictionary = Get(value.Code, value.DictionaryTypeId);
            return dictionary == null ? true : false;
        }
        /// <summary>
        /// 下拉框
        /// </summary>
        /// zouql 16.07.06
        /// <returns></returns>
        public List<ComboInfo> GetComList()
        {
            return dic.GetComList();
        }

        /// <summary>
        /// 根据数据元获取数据字典集合
        /// </summary>
        /// yaoy    16.09.26
        /// <param name="metaCode"></param>
        /// <returns></returns>
        public List<DictionaryCodeInfo> List(int metaCode)
        {
            return dic.List(metaCode);
        }
    }
}
