using Models.Flow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Flow
{
    public class FlowFormMapper : AbstractMapper<FlowForm>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FlowForm Find(int Id)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT * FROM FLOW_Form WHERE FormId = @FormId
            ");
            DHelper.AddInParameter(comm, "@FormId", SqlDbType.Int, Id);

            return Load(DHelper.ExecuteDataTable(comm));
        }
     
        /// <summary>
        /// 根据结点ID查表单信息
        /// </summary>
        /// yand    16.08.31
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public List<FlowForm> FindByNodeID(int nodeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ff.FormId, FlowId, Name, Link, Sort, Status, IsOpen, IsHandler 
                FROM FLOW_Form AS ff 
	            LEFT JOIN FLOW_FormWithNode AS fwn
                    ON fwn.FormId = ff.FormId
                WHERE fwn.nodeId = @NodeId ORDER BY ff.Sort
            ");

            DHelper.AddInParameter(comm, "@NodeId", SqlDbType.Int, nodeId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据角色Id查询表单信息
        /// </summary>
        /// wangpf  16.09.11
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<FlowForm> FindByRole(int roleId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ff.FormId, FlowId, Name, Link, Sort, Status
                FROM FLOW_Form AS ff 
	            LEFT JOIN FLOW_FormWithRole AS fwr
                    ON fwr.FormId = ff.FormId
                WHERE fwr.RoleId = @RoleId ORDER BY ff.Sort
            ");

            DHelper.AddInParameter(comm, "@RoleId", SqlDbType.Int, roleId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据角色获取已办列表
        /// </summary>
        /// yand    16.09.12
        /// <param name="roleId"></param>
        /// <returns></returns>
        public  List<FlowForm> FindByRoleId(int roleId)
        {

            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT ffwr.FormId, ff.Name, ff.Link FROM FLOW_FormWithRole AS ffwr
	                LEFT JOIN FLOW_Form AS ff ON ffwr.FormId = ff.FormId
                WHERE ffwr.RoleId = @RoleId ORDER BY ff.Sort
            ");

            DHelper.AddParameter(comm, "@RoleId", SqlDbType.Int, roleId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }
    }
}
