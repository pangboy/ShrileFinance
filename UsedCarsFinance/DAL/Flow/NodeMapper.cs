using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;
using Models.Flow;

namespace DAL.Flow
{
    public class NodeMapper : AbstractMapper<NodeInfo>
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// qiy		16.03.08
        /// <param name="id"></param>
        /// <returns></returns>
        public NodeInfo Find(int id)
        {
            string findStatement =
                "SELECT NodeId, FlowId, RoleId, Name, Description FROM FLOW_Node WHERE NodeId = @ID";

            return AbstractFind(findStatement, id);
        }

        /// <summary>
        /// 查询节点选项
        /// </summary>
        /// qiy     16.05.09
        /// <param name="flowId">流程标识</param>
        /// <returns></returns>
        public List<ComboInfo> Option(Guid? flowId)
        {
            List<ComboInfo> list = new List<ComboInfo>();

            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT Id, Name FROM FLOW_Node WHERE (@FlowId IS NULL OR FlowId = @FlowId)
            ");
            DHelper.AddParameter(comm, "@FlowId", SqlDbType.UniqueIdentifier, flowId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ComboInfo(dr[0].ToString(), dr[1].ToString()));
            }

            return list;
        }

        /// <summary>
        /// 插入[未使用]
        /// </summary>
        /// qiy		16.03.08
        /// <param name="value"></param>
        /// <returns></returns>
        public void Insert(NodeInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FLOW_Node (FlowId, RoleId, Name, Description)
				VALUES (@FlowId, @RoleId, @Name, @Description) SELECT SCOPE_IDENTITY()
             ");
            DHelper.AddParameter(comm, "@FlowId", SqlDbType.Int, value.FlowId);
            DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, value.RoleId);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@Description", SqlDbType.NVarChar, value.Description);

            value.NodeId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新[未使用]
        /// </summary>
        /// qiy		16.03.08
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Update(NodeInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				UPDATE FLOW_Node SET
					FlowId = @FlowId, 
					RoleId = @RoleId, 
					Name = @Name, 
					Description = @Description 
				WHERE NodeId = @NodeId 
             ");
            DHelper.AddParameter(comm, "@NodeId", SqlDbType.Int, value.NodeId);

            DHelper.AddParameter(comm, "@FlowId", SqlDbType.Int, value.FlowId);
            DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, value.RoleId);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@Description", SqlDbType.NVarChar, value.Description);

            return DHelper.ExecuteNonQuery(comm) > 0;
        }
    }
}
