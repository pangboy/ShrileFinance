using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models.Flow;

namespace DAL.Flow
{
    public class ActionMapper : AbstractMapper<ActionInfo>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// qiy		16.03.08
        /// wangpf  16.08.29    查询结果添加字段:BusinessMethod
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionInfo Find(int id)
        {
            string findStatement =
               @"SELECT ActionId, NodeId, Transfer, Name, Type, AllocationType, Description, Method ,BusinessMethod 
                 FROM FLOW_Action WHERE ActionId = @ID";

            return AbstractFind(findStatement, id);
        }

        /// <summary>
        /// 根据节点ID查询行为信息
        /// </summary>
        /// yand    15.12.03
        /// qiy		16.03.08
        /// <param name="nodeId">节点ID</param>
        /// <returns></returns>
        public List<ActionInfo> FindByNode(int nodeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ActionId, NodeId, Transfer, Name, Type, AllocationType, Description, Method FROM FLOW_Action WHERE NodeId = @NodeId
            ");

            DHelper.AddParameter(comm, "@NodeId", SqlDbType.Int, nodeId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 插入[未使用]
        /// </summary>
        /// qiy		16.03.08
        /// <param name="value"></param>
        /// <returns></returns>
        public void Insert(ActionInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
				INSERT INTO FLOW_Action (NodeId, Transfer, Name, Type, AllocationType, Description, Method)
				VALUES (@NodeId, @Transfer, @Name, @Type, @AllocationType, @Description, @Method) SELECT SCOPE_IDENTITY()
             ");
            DHelper.AddParameter(comm, "@NodeId", SqlDbType.Int, value.NodeId);
            DHelper.AddParameter(comm, "@Transfer", SqlDbType.Int, value.Transfer);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.AllocationType);
            DHelper.AddParameter(comm, "@Description", SqlDbType.NVarChar, value.Description);
            DHelper.AddParameter(comm, "@Method", SqlDbType.VarChar, value.Method);

            value.ActionId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新[未使用]
        /// </summary>
        /// qiy		16.03.08
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Update(ActionInfo value)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
             UPDATE FLOW_Action SET
                Node = @NodeId,
				Transfer = @Transfer, 
				Name = @Name, 
				Type = @Type, 
                AllocationType = @AllocationType, 
				Description = @Description, 
				Method = @Method 
             WHERE ActionId = @ActionId 
             ");
            DHelper.AddParameter(comm, "@ActionId", SqlDbType.Int, value.ActionId);

            DHelper.AddParameter(comm, "@NodeId", SqlDbType.Int, value.NodeId);
            DHelper.AddParameter(comm, "@Transfer", SqlDbType.Int, value.Transfer);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, value.Name);
            DHelper.AddParameter(comm, "@Type", SqlDbType.TinyInt, value.AllocationType);
            DHelper.AddParameter(comm, "@Description", SqlDbType.NVarChar, value.Description);
            DHelper.AddParameter(comm, "@Method", SqlDbType.VarChar, value.Method);

            return DHelper.ExecuteNonQuery(comm) > 0;
        }
    }
}
