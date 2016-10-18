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
//    public class LogMapper : AbstractMapper<FlowLogInfo>
//    {
//        //查询并加入缓存
//        public FlowLogInfo Find(int id)
//        {
//            string findStatement =
//                "SELECT LG_ID,IT_ID,ND_ID,AT_ID,ProcessUser,ProcessTime FROM FLOW_Log WHERE LG_ID= @ID";

//            return AbstractFind(findStatement, id);
//        }
       

//        //插入
//        public bool Insert(FlowLogInfo value)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//             INSERT INTO FLOW_Log (IT_ID,ND_ID,AT_ID,ProcessUser,ProcessTime,Content)
//             VALUES (@IT_ID,@ND_ID,@AT_ID,@ProcessUser,@ProcessTime,@Content) SELECT SCOPE_IDENTITY()
//             ");
//			DHelper.AddParameter(comm, "@IT_ID", SqlDbType.Int, value.InstanceId);
//			DHelper.AddParameter(comm, "@ND_ID", SqlDbType.Int, value.NodeId);
//			DHelper.AddParameter(comm, "@AT_ID", SqlDbType.Int, value.ActionId);
//			DHelper.AddParameter(comm, "@ProcessUser", SqlDbType.Int, value.ProcessUser);
//			DHelper.AddParameter(comm, "@ProcessTime", SqlDbType.DateTime, value.ProcessTime);
//			DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, value.Content);

//            return Convert.ToInt32(DHelper.ExecuteScalar(comm))>0;
//        }

//        /// <summary>
//        /// 根据流程日志中的流程实例ID,节点ID找到操作过流程该步骤的用户
//        /// </summary>
//        /// wangpf  15.11.26
//        /// <param name="instanceId">流程实例ID</param>
//        /// <param name="nodeId">节点ID</param>
//        /// <returns></returns>
//        public int FindUserByFlowLog(int instanceId, int nodeId)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//                SELECT ui.UI_ID
//                FROM Flow_Log fl
//                LEFT JOIN USER_UserInfo ui ON fl.ProcessUser = ui.UI_ID
//                WHERE fl.IT_ID = @IT_ID and fl.ND_ID = @ND_ID ORDER BY fl.ProcessTime DESC
//            ");
//            DHelper.AddParameter(comm, "@IT_ID", SqlDbType.Int, instanceId);
//            DHelper.AddParameter(comm, "@ND_ID", SqlDbType.Int, nodeId);

//            return Convert.ToInt32(DHelper.ExecuteScalar(comm));
//        }

//        //更新
//        public bool Update(FlowLogInfo value)
//        {
//            SqlCommand comm = DHelper.GetSqlCommand(@"
//             UPDATE FLOW_Log SET
//                 IT_ID = @IT_ID,ND_ID = @ND_ID,AT_ID = @AT_ID,ProcessUser = @ProcessUser,ProcessTime = @ProcessTime
//             WHERE
//                 LG_ID = @LG_ID 
//             ");
//            DHelper.AddParameter(comm, "@LG_ID", SqlDbType.BigInt, value.LogId);

//			DHelper.AddParameter(comm, "@IT_ID", SqlDbType.Int, value.InstanceId);
//			DHelper.AddParameter(comm, "@ND_ID", SqlDbType.Int, value.NodeId);
//			DHelper.AddParameter(comm, "@AT_ID", SqlDbType.Int, value.ActionId);
//			DHelper.AddParameter(comm, "@ProcessUser", SqlDbType.Int, value.ProcessUser);
//			DHelper.AddParameter(comm, "@ProcessTime", SqlDbType.DateTime, value.ProcessTime);
//			DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, value.Content);

//            return DHelper.ExecuteNonQuery(comm) > 0;
//        }
//    }
//}
