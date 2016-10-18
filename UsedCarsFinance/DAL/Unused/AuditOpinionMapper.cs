//using Model;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DAL.Flow
//{
//    public class AuditOpinionMapper : AbstractMapper<AuditOpinionInfo>
//    {
//        //查询并加入缓存
//        public AuditOpinionInfo Find(int id)
//		{
//			string findStatement =
//				"SELECT LG_ID,Opinion,Content FROM FLOW_AuditOpinion WHERE LG_ID= @ID";

//			return AbstractFind(findStatement, id);
//		}
        
//        //插入
//        public int Insert(AuditOpinionInfo value)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//             INSERT INTO FLOW_AuditOpinion (Opinion,Content)
//             VALUES (@Opinion,@Content) SELECT SCOPE_IDENTITY()
//             ");
//            Save(value, comm);

//            return (int)DHelper.ExecuteScalar(comm);
//        }
//        //更新
//        public bool Update(AuditOpinionInfo value)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//             UPDATE FLOW_AuditOpinion SET
//                 Opinion = @Opinion,Content = @Content
//             WHERE
//                 LG_ID = @LG_ID 
//             ");
//            Save(value, comm);

//            return DHelper.ExecuteNonQuery(comm) > 0;
//        }

//        /// <summary>
//        /// 查询所有意见
//        /// </summary>
//        /// yaoy    15.11.30
//        /// <returns></returns>
//        public List<AuditOpinionInfo> List()
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//                SELECT fao.LG_ID,fao.Opinion,fao.Content 
//                    FROM FLOW_Instance AS fis 
//                LEFT JOIN  FLOW_Log AS flo ON flo.IT_ID=fis.IT_ID
//                LEFT JOIN FLOW_AuditOpinion AS fao ON flo.LG_ID=fao.LG_ID
//            ");
//            DataTable dt = DHelper.ExecuteDataTable(comm);

//            List<AuditOpinionInfo> list = ConvertHelper.Data2List<AuditOpinionInfo>(dt);

//            return list;

//        }
//        /// <summary>
//        /// 查询意见实体
//        /// </summary>
//        /// yaoy    15.11.30
//        /// <param name="LG_ID"></param>
//        /// <returns></returns>
//        public AuditOpinionInfo GetById(int LG_ID)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//                SELECT fao.LG_ID,fao.Opinion,fao.Content 
//                    FROM FLOW_Instance AS fis 
//                LEFT JOIN  FLOW_Log AS flo ON flo.IT_ID=fis.IT_ID
//                LEFT JOIN FLOW_AuditOpinion AS fao ON flo.LG_ID=fao.LG_ID
//                WHERE(flo.LG_ID IS NULL OR flo.LG_ID = @LG_ID)
//            ");
//            DHelper.AddParameter(comm, "@LG_ID", SqlDbType.Int, LG_ID);

//            DataTable dt = DHelper.ExecuteDataTable(comm);

//            return Load(dt);
//        }
//        //保存通用参数
//        protected override void Save(AuditOpinionInfo value, SqlCommand comm)
//        {
//            DHelper.AddParameter(comm, "@LG_ID", SqlDbType.BigInt, value.LogId);
//            DHelper.AddParameter(comm, "@Opinion", SqlDbType.NVarChar, value.Opinion);
//            DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, value.Content);
//        }

//        //table真实主键ID
//        protected override string NameOfID
//        {
//            get { return "LG_ID"; }
//        }

//        /// <summary>
//        /// 查找审核意见通过实例ID
//        /// </summary>
//        /// yand    15.12.07
//        /// <param name="Instance_id"></param>
//        /// <returns></returns>
//        public DataTable FindByInstance_id(int Instance_id)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//                SELECT fao.Opinion,fao.Content,fn.Name,Username FROM FLOW_AuditOpinion fao 
//                    LEFT JOIN FLOW_Log fl on fl.LG_ID=fao.LG_ID
//                    LEFT JOIN FLOW_Instance fi on fl.IT_ID = fi.IT_ID
//                    LEFT JOIN FLOW_Node fn on fn.ND_ID=fl.ND_ID
//                    LEFT JOIN USER_UserInfo uui on fi.CurrentUser = uui.UI_ID
//                WHERE fao.LG_ID IN( SELECT LG_ID FROM FLOW_Log WHERE IT_ID =IT_ID)
//            ");
//            DHelper.AddParameter(comm, "@IT_ID", SqlDbType.Int, Instance_id);

//            DataTable dt = DHelper.ExecuteDataTable(comm);

//            return dt;
//        }

//    }
//}
