using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Model.Flow;

namespace DAL.Flow
{
	public class InstanceMapper : AbstractMapper<InstanceInfo>
	{
		/// <summary>
		/// 查找
		/// </summary>
		/// qiy		16.03.08
		/// <param name="id"></param>
		/// <returns></returns>
		public InstanceInfo Find(int id)
		{
			string findStatement =
				"SELECT InstanceId, FlowId, CurrentNode, CurrentUser, ProcessUser, ProcessTime, StartUser, StartTime, EndTime, Status, InstanceData " +
                "FROM FLOW_Instance WHERE InstanceId = @ID";

			return AbstractFind(findStatement, id);
		}

		/// <summary>
		/// 插入
		/// </summary>
		/// qiy		16.03.08
		/// <param name="value"></param>
		public void Insert(InstanceInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"INSERT INTO FLOW_Instance " +
				"(FlowId, StartUser, StartTime, EndTime, InstanceData, Status) VALUES " +
				"(@FlowId, @StartUser, @StartTime, NULL, NULL, @Status) SELECT SCOPE_IDENTITY()"
			);
			DHelper.AddParameter(comm, "@FlowId", SqlDbType.Int, value.FlowId);
			DHelper.AddParameter(comm, "@StartUser", SqlDbType.Int, value.StartUser);
			DHelper.AddParameter(comm, "@StartTime", SqlDbType.DateTime, value.StartTime);
			DHelper.AddParameter(comm, "@Status", SqlDbType.TinyInt, value.Status);

			value.InstanceId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// qiy		16.03.08
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Update(InstanceInfo value)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				@"UPDATE FLOW_Instance SET 
					CurrentNode = @CurrentNode, 
					CurrentUser = @CurrentUser, 
					ProcessUser = @ProcessUser, 
					ProcessTime = @ProcessTime, 
					EndTime = @EndTime,
					Status = @Status
				WHERE InstanceId = @InstanceId 
             ");
			DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, value.InstanceId);

			DHelper.AddParameter(comm, "@CurrentNode", SqlDbType.Int, value.CurrentNode);
			DHelper.AddParameter(comm, "@CurrentUser", SqlDbType.Int, value.CurrentUser);
			DHelper.AddParameter(comm, "@ProcessUser", SqlDbType.Int, value.ProcessUser);
			DHelper.AddParameter(comm, "@ProcessTime", SqlDbType.DateTime, value.ProcessTime);
			DHelper.AddParameter(comm, "@EndTime", SqlDbType.DateTime, value.EndTime);
			DHelper.AddParameter(comm, "@Status", SqlDbType.TinyInt, value.Status);

            return DHelper.ExecuteNonQuery(comm) > 0;
		}

        /// <summary>
        /// 查询数据
        /// </summary>
        /// qiy		16.03.08
        /// <param name="instanceId">实例标识</param>
        /// <returns></returns>
        public string FindData(int instanceId)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"SELECT InstanceData FROM FLOW_Instance WHERE InstanceId = @InstanceId"
			);
			DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

			return Convert.ToString(DHelper.ExecuteScalar(comm));
		}

        /// <summary>
        /// 查询XML关系数据
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public string FindXMLData(int instanceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                "SELECT KeyXML FROM FLOW_Instance WHERE InstanceId = @InstanceId"
            );
            DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);

            return Convert.ToString(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新临时数据
        /// </summary>
        /// yaoy    16.07.25
        /// <param name="instanceId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int ModifyTempData(int instanceId, string data)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                "UPDATE FLOW_Instance SET InstanceData = @InstanceData WHERE InstanceId = @InstanceId"
             );
            DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);
            DHelper.AddParameter(comm, "@InstanceData", SqlDbType.NVarChar, data);

            return Convert.ToInt32(DHelper.ExecuteNonQuery(comm));
        }

		/// <summary>
		/// 更新数据
		/// </summary>
		/// qiy		16.03.08
        /// yand    16.07.25（增加keyXML字段）
        /// yaoy    16.07.27 (删除更新InstanceData字段)
		/// <param name="instanceId">实例标识</param>
		/// <param name="data">数据</param>
        /// <param name = "KeyXML">XML数据</param>
		public void UpdateData(int instanceId,string KeyXML)
		{
			SqlCommand comm = DHelper.GetSqlCommand(
				"UPDATE FLOW_Instance SET KeyXML = @KeyXML WHERE InstanceId = @InstanceId"
             );
			DHelper.AddParameter(comm, "@InstanceId", SqlDbType.Int, instanceId);
            DHelper.AddParameter(comm, "@KeyXML", SqlDbType.Xml, KeyXML);

			DHelper.ExecuteNonQuery(comm);
		}


		/// <summary>
		/// 查询未完成列表
		/// </summary>
		/// yand    15.11.25
        /// qiy     16.04.25    重新实现
        /// yand    16.07.25    增加客户姓名车牌号的筛选
		/// <param name="page"></param>
		/// <param name="filters"></param>
		/// <returns></returns>
		public DataTable FindDoingList(Model.Pagination page, NameValueCollection filters)
		{
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT tmp.rownum,tmp.Name, fi.InstanceId, tmp.VehicleKey,tmp.PlateNo,
                    fi.FlowId, fw.Name AS FlowName, 
                    fi.CurrentNode, fn.Name AS CurrentNodeName,fi.KeyXML,
                    fi.CurrentUser, dbo.GetUser(fi.CurrentUser) AS CurrentUserName, fi.ProcessUser, dbo.GetUser(fi.ProcessUser) AS ProcessUserName, fi.ProcessTime, 
                    fi.StartUser, dbo.GetUser(fi.StartUser) AS StartUserName, fi.StartTime, fi.EndTime, fi.Status, dbo.Dic(9, fi.Status) AS StatusDesc  
                FROM FLOW_Instance AS fi 
                    RIGHT JOIN (
                        SELECT TOP (@End) ROW_NUMBER() OVER (ORDER BY InstanceId DESC) AS rownum, InstanceId,fai.Name, fvi.VehicleKey,fvi.PlateNo FROM FLOW_Instance as fi
						LEFT JOIN FANC_ApplicantInfo AS fai ON  fai.FinanceId = fi.KeyXML.value('FinanceId[1]', 'Int')
						LEFT JOIN FANC_VehicleInfo AS fvi ON fvi .FinanceId =fai.FinanceId
                        WHERE Status = 1 
                            AND (fai.Type IS NULL OR fai.Type=1)
						    AND (@MainInfo IS NULL OR (fai.Name LIKE '%'+ @MainInfo+'%' OR fvi.PlateNo LIKE '%'+ @MainInfo+'%'))
                            AND (@FlowId IS NULL OR FlowId = @FlowId)
                            AND (@CurrentNode IS NULL OR CurrentNode = @CurrentNode)
                            AND (@CurrentRole IS NULL OR CurrentNode IN (SELECT NodeId FROM FLOW_Node WHERE RoleId = @CurrentRole))
                            AND (CurrentUser IS NULL OR CurrentUser = @CurrentUser)
                            AND (@BeginTime IS NULL OR DATEDIFF(day, StartTime, @BeginTime) <= 0) AND (@EndTime IS NULL OR DATEDIFF(day, StartTime, @EndTime) >= 0) 
                    ) AS tmp ON fi.InstanceId = tmp.InstanceId 
                    LEFT JOIN FLOW_WorkFlow AS fw ON fi.FlowId = fw.FlowId
                    LEFT JOIN FLOW_Node AS fn ON fi.CurrentNode = fn.NodeId
                WHERE tmp.rownum > @Begin
            ");
            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);
            DHelper.AddInParameter(comm, "@FlowId", SqlDbType.Int, filters["FlowId"]);
            DHelper.AddInParameter(comm, "@CurrentNode", SqlDbType.Int, filters["CurrentNode"]);
            DHelper.AddInParameter(comm, "@CurrentRole", SqlDbType.Int, filters["CurrentRole"]);
            DHelper.AddInParameter(comm, "@CurrentUser", SqlDbType.Int, filters["CurrentUser"]);
            DHelper.AddInParameter(comm, "@BeginTime", SqlDbType.DateTime, filters["BeginTime"]);
            DHelper.AddInParameter(comm, "@EndTime", SqlDbType.DateTime, filters["EndTime"]);
            DHelper.AddInParameter(comm, "@MainInfo", SqlDbType.NVarChar, filters["MainInfo"]);


            SqlCommand commPage = DHelper.GetSqlCommand(@"
				SELECT COUNT(*) FROM FLOW_Instance as fi
						LEFT JOIN FANC_ApplicantInfo AS fai ON  fai.FinanceId = fi.KeyXML.value('FinanceId[1]', 'Int')
						LEFT JOIN FANC_VehicleInfo AS fvi ON fvi .FinanceId =fai.FinanceId
                WHERE Status = 1 
                    AND (fai.Type IS NULL OR fai.Type=1)
                    AND (@MainInfo IS NULL OR (fai.Name LIKE '%'+ @MainInfo+'%'OR fvi.PlateNo LIKE '%'+ @MainInfo+'%'))
                    AND (@FlowId IS NULL OR FlowId = @FlowId)
                    AND (@CurrentNode IS NULL OR CurrentNode = @CurrentNode)
                    AND (@CurrentRole IS NULL OR CurrentNode IN (SELECT NodeId FROM FLOW_Node WHERE RoleId = @CurrentRole))
                    AND (CurrentUser IS NULL OR CurrentUser = @CurrentUser)
                    AND (@BeginTime IS NULL OR DATEDIFF(day, StartTime, @BeginTime) <= 0) AND (@EndTime IS NULL OR DATEDIFF(day, StartTime, @EndTime) >= 0) 
			");

            DHelper.AddInParameter(commPage, "@FlowId", SqlDbType.Int, filters["FlowId"]);
            DHelper.AddInParameter(commPage, "@CurrentNode", SqlDbType.Int, filters["CurrentNode"]);
            DHelper.AddInParameter(commPage, "@CurrentRole", SqlDbType.Int, filters["CurrentRole"]);
            DHelper.AddInParameter(commPage, "@CurrentUser", SqlDbType.Int, filters["CurrentUser"]);
            DHelper.AddInParameter(commPage, "@BeginTime", SqlDbType.DateTime, filters["BeginTime"]);
            DHelper.AddInParameter(commPage, "@EndTime", SqlDbType.DateTime, filters["EndTime"]);
            DHelper.AddInParameter(commPage, "@MainInfo", SqlDbType.NVarChar, filters["MainInfo"]);

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return DHelper.ExecuteDataTable(comm);
		}

        /// <summary>
        /// 查询已办列表
        /// </summary>
        /// yand    15.11.27
        /// qiy     16.04.29    重新实现
        /// yand    16.07.25    添加主要信息筛选
        /// <param name="page"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public DataTable FindDoneList(Model.Pagination page, NameValueCollection filters)
		{
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT tmp.rownum,tmp.Name,tmp.PlateNo, tmp.VehicleKey,tmp.PlateNo,fi.InstanceId, 
                    fi.FlowId, fw.Name AS FlowName, 
                    fi.CurrentNode, fn.Name AS CurrentNodeName,fi.KeyXML,
                    fi.CurrentUser, dbo.GetUser(fi.CurrentUser) AS CurrentUserName, fi.ProcessUser, dbo.GetUser(fi.ProcessUser) AS ProcessUserName, fi.ProcessTime, 
                    fi.StartUser, dbo.GetUser(fi.StartUser) AS StartUserName, fi.StartTime, fi.EndTime, fi.Status, dbo.Dic(9, fi.Status) AS StatusDesc
                FROM FLOW_Instance AS fi
                    RIGHT JOIN (
                        SELECT TOP(@End) ROW_NUMBER() OVER(ORDER BY InstanceId DESC) AS rownum, InstanceId,fai.Name,fvi.PlateNo, fvi.VehicleKey FROM FLOW_Instance AS fi
	                            LEFT JOIN FANC_ApplicantInfo AS fai ON  fai.FinanceId = fi.KeyXML.value('FinanceId[1]', 'Int')
						        LEFT JOIN FANC_VehicleInfo AS fvi ON fvi .FinanceId =fai.FinanceId
                        WHERE InstanceId IN(SELECT InstanceId FROM FLOW_Log WHERE ProcessUser = @CurrentUser)
                            AND (fai.Type IS NULL OR fai.Type=1)
                            AND (@MainInfo IS NULL OR (fai.Name LIKE '%'+ @MainInfo+'%'OR fvi.PlateNo LIKE '%'+ @MainInfo+'%'))
                            AND(@FlowId IS NULL OR FlowId = @FlowId)
                            AND(@CurrentNode IS NULL OR CurrentNode = @CurrentNode)
                            AND(@BeginTime IS NULL OR DATEDIFF(day, StartTime, @BeginTime) <= 0) AND(@EndTime IS NULL OR DATEDIFF(day, StartTime, @EndTime) >= 0)
                            AND(@Status IS NULL OR Status = @Status)
            	    ) AS tmp ON fi.InstanceId = tmp.InstanceId
                    LEFT JOIN FLOW_WorkFlow AS fw ON fi.FlowId = fw.FlowId
                    LEFT JOIN FLOW_Node AS fn ON fi.CurrentNode = fn.NodeId
                WHERE tmp.rownum > @Begin
            ");
            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, page.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, page.End);

            DHelper.AddInParameter(comm, "@FlowId", SqlDbType.Int, filters["FlowId"]);
            DHelper.AddInParameter(comm, "@CurrentNode", SqlDbType.Int, filters["CurrentNode"]);
            DHelper.AddInParameter(comm, "@CurrentUser", SqlDbType.Int, filters["CurrentUser"]);
            DHelper.AddInParameter(comm, "@BeginTime", SqlDbType.DateTime, filters["BeginTime"]);
            DHelper.AddInParameter(comm, "@EndTime", SqlDbType.DateTime, filters["EndTime"]);
            DHelper.AddInParameter(comm, "@Status", SqlDbType.TinyInt, filters["Status"]);
            DHelper.AddInParameter(comm, "@MainInfo", SqlDbType.NVarChar, filters["MainInfo"]);

            SqlCommand commPage = DHelper.GetSqlCommand(@"
				SELECT COUNT(*) FROM FLOW_Instance  as fi
						LEFT JOIN FANC_ApplicantInfo AS fai ON  fai.FinanceId = fi.KeyXML.value('FinanceId[1]', 'Int')
						LEFT JOIN FANC_VehicleInfo AS fvi ON fvi .FinanceId =fai.FinanceId
                WHERE InstanceId IN(SELECT InstanceId FROM FLOW_Log WHERE ProcessUser = @CurrentUser)
                    AND (fai.Type IS NULL OR fai.Type=1)
                    AND (@MainInfo IS NULL OR (fai.Name LIKE '%'+ @MainInfo+'%'OR fvi.PlateNo LIKE '%'+ @MainInfo+'%'))
                    AND(@FlowId IS NULL OR FlowId = @FlowId)
                    AND(@CurrentNode IS NULL OR CurrentNode = @CurrentNode)
                    AND(@BeginTime IS NULL OR DATEDIFF(day, StartTime, @BeginTime) <= 0) AND(@EndTime IS NULL OR DATEDIFF(day, StartTime, @EndTime) >= 0)
                    AND(@Status IS NULL OR Status = @Status)
			");

            DHelper.AddInParameter(commPage, "@FlowId", SqlDbType.Int, filters["FlowId"]);
            DHelper.AddInParameter(commPage, "@CurrentNode", SqlDbType.Int, filters["CurrentNode"]);
            DHelper.AddInParameter(commPage, "@CurrentUser", SqlDbType.Int, filters["CurrentUser"]);
            DHelper.AddInParameter(commPage, "@BeginTime", SqlDbType.DateTime, filters["BeginTime"]);
            DHelper.AddInParameter(commPage, "@EndTime", SqlDbType.DateTime, filters["EndTime"]);
            DHelper.AddInParameter(commPage, "@Status", SqlDbType.TinyInt, filters["Status"]);
            DHelper.AddInParameter(commPage, "@MainInfo", SqlDbType.NVarChar, filters["MainInfo"]);

            page.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return DHelper.ExecuteDataTable(comm);
        }
	}
}
