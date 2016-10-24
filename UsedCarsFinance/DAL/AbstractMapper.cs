using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 抽象映射器, 提供通用的方法
    /// </summary>
    /// qiy		15.11.12
    /// qiy		16.03.07	修改
    /// <typeparam name="Model">实体类</typeparam>
    public abstract class AbstractMapper<Model> where Model : new()
    {
        private DataHelper.SQLHelper _DHelper;
        //缓存实体实例, 提高查找效率
        //protected Dictionary<int, Model> loadedMap = new Dictionary<int, Model>();

        /// <summary>
        /// 数据库帮助类
        /// </summary>
        /// qiy		15.11.13
        protected DataHelper.SQLHelper DHelper { get { return _DHelper; } }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// qiy		15.11.13
        /// qiy     16.07.01    修改默认构造函数
        protected AbstractMapper() : this(new DataHelper.SQLHelper()) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// qiy     16.07.01
        /// <param name="dHelper">数据帮助类</param>
        protected AbstractMapper(DataHelper.SQLHelper dHelper)
        {
            //实例化DHelper
            _DHelper = dHelper;
        }

        /// <summary>
        /// 通过标识查找
        /// "SELECT COLUMNS FROM TABLE WHERE ID = @ID"
        /// </summary>
        /// qiy		15.11.12
        /// <param name="id">标识</param>
        /// <returns></returns>
        protected Model AbstractFind(string findStatement, int id)
        {
            //缓存中查找实例
            //if (loadedMap.ContainsKey(id)) return loadedMap[id];

            //构造执行器
            SqlCommand comm = DHelper.GetSqlCommand(findStatement);
            DHelper.AddParameter(comm, "@ID", SqlDbType.Int, id);

            //执行查询
            DataTable dt = DHelper.ExecuteDataTable(comm);

            //加载实例
            return Load(dt);
        }

        /// <summary>
        /// 加载数据到实例
        /// </summary>
        /// qiy		15.11.12
        /// <param name="dr">数据行</param>
        /// <returns></returns>
        protected virtual Model Load(DataRow dr)
        {
            //int id = default(int);

            //尝试获取标识, 加载缓存
            //if (!dr.IsNull(0)
            //	&& int.TryParse(dr[0].ToString(), out id)
            //	&& !default(int).Equals(id)
            //	&& loadedMap.ContainsKey(id)
            //)
            //{
            //	return loadedMap[id];
            //}

            //通过反射加载
            Model result = ConvertHelper.Data2Model<Model>(dr);

            //加入缓存中
            //if (!default(int).Equals(id)) loadedMap.Add(id, result);

            return result;
        }
        /// <summary>
        /// 加载首行数据, 若不存在则返回默认值
        /// </summary>
        /// qiy		15.11.12
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        protected Model Load(DataTable dt)
        {
            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : default(Model);
        }

        /// <summary>
        /// 加载多行数据, 返回列表
        /// </summary>
        /// qiy		15.11.12
        /// <param name="drs">数据行</param>
        /// <returns></returns>
        protected List<Model> LoadAll(DataRowCollection drs)
        {
            List<Model> result = new List<Model>();

            foreach (DataRow dr in drs)
            {
                result.Add(Load(dr));
            }

            return result;
        }
    }
}
