using Models.Flow;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Flow
{
    public class LogMapper : AbstractMapper<LogInfo>
    {
        /// <summary>
        /// 获取记录列表通过流程实例
        /// </summary>
        /// qiy     16.05.04
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public List<LogInfo> FindByInstanceId(int instanceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT LogId, InstanceId, NodeId, ActionId, ProcessUser, ProcessTime, Content  FROM FLOW_Log WHERE InstanceId = @InstanceId
            ");
            DHelper.AddInParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }
        /// <summary>
        /// 查找实例处理者排除当前操作者
        /// </summary>
        /// yand    16.09.11
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public List<LogInfo> FindByUserId(int instanceId,int userId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT distinct(ProcessUser),LogId, InstanceId, NodeId, ActionId, ProcessTime, Content  FROM FLOW_Log WHERE InstanceId = @InstanceId AND ProcessUser!=@ProcessUser
            ");
            DHelper.AddInParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);
            DHelper.AddInParameter(comm, "@ProcessUser", SqlDbType.Int, userId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据实例ID获取最后一次日志信息
        /// </summary>
        /// yaoy    16.09.08
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public List<LogInfo> FindTopByInstanceId(int instanceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT TOP(2) LogId, InstanceId, NodeId, ActionId, ProcessUser, ProcessTime, Content  
                    FROM FLOW_Log WHERE InstanceId = @InstanceId
                ORDER BY LogId DESC
            ");
            DHelper.AddInParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return LoadAll(dt.Rows);
        }

        /// <summary>
        /// 查找内部意见列表   
        /// </summary>
        /// yaoy    16.04.29
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public DataTable FindInOpinion(int instanceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT fl.LogId,dbo.GetUser(fl.ProcessUser) AS ProcessUser,fl.ProcessTime,fl.InOpinion,fl.Content,fn.Name,uro.Name AS RoleName FROM FLOW_Log AS fl
                    LEFT JOIN FLOW_Node AS fn ON fn.NodeId = fl.NodeId
                    LEFT JOIN USER_Relation AS ur ON fl.ProcessUser = ur.UserId
                    LEFT JOIN USER_Role AS uro ON uro.UR_ID = ur.RoleId 
                WHERE InOpinion IS NOT NULL AND  fl.InstanceId = @InstanceId
            ");
            DHelper.AddInParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 查找外部意见列表
        /// </summary>
        /// yaoy    16.04.29
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public DataTable FindExOpinion(int instanceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
               SELECT fl.LogId,dbo.GetUser(fl.ProcessUser) AS ProcessUser,fl.ProcessTime,fl.ExOpinion,fl.Content,fn.Name,uro.Name AS RoleName FROM FLOW_Log AS fl
                    LEFT JOIN FLOW_Node AS fn ON fn.NodeId = fl.NodeId
                    LEFT JOIN USER_Relation AS ur ON fl.ProcessUser = ur.UserId
                    LEFT JOIN USER_Role AS uro ON uro.UR_ID = ur.RoleId 
               WHERE ExOpinion IS NOT NULL AND fl.InstanceId = @InstanceId
            ");
            DHelper.AddInParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// qiy     16.04.29
        /// <param name="value"></param>
        public void Insert(LogInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FLOW_Log (InstanceId, NodeId, ActionId, ProcessUser, ProcessTime, Content, InOpinion, ExOpinion) 
				VALUES (@InstanceId, @NodeId, @ActionId, @ProcessUser, @ProcessTime, @Content, @InOpinion, @ExOpinion) SELECT SCOPE_IDENTITY()
            ");

            DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, value.InstanceId);
            DHelper.AddParameter(comm, "@NodeId", SqlDbType.Int, value.NodeId);
            DHelper.AddParameter(comm, "@ActionId", SqlDbType.Int, value.ActionId);
            DHelper.AddParameter(comm, "@ProcessUser", SqlDbType.Int, value.ProcessUser);
            DHelper.AddParameter(comm, "@ProcessTime", SqlDbType.DateTime, value.ProcessTime);
            DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, value.Content);
            DHelper.AddParameter(comm, "@InOpinion", SqlDbType.NVarChar, value.InOpinion);
            DHelper.AddParameter(comm, "@ExOpinion", SqlDbType.NVarChar, value.ExOpinion);

            value.LogId = Convert.ToInt64(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 根据流程实例ID删除最后一次日志记录
        /// </summary>
        /// yaoy    16.09.13
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public int Delete(int instanceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
			    DELETE FROM FLOW_Log WHERE LogId = (
                SELECT TOP(1) LogId FROM FLOW_Log WHERE InstanceId = @InstanceId
                ORDER BY LogId DESC)
            ");

            DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}
