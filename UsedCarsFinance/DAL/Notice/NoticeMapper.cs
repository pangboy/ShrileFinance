using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models.Notice;

namespace DAL.Notice
{
    public class NoticeMapper : AbstractMapper<NoticeInfo>
    {
        /// <summary>
        /// 查找单个
        /// </summary>
        /// zouql   16.08.29
        /// <param name="id">标识</param>
        /// <returns>通知</returns>
        public NoticeInfo Find(int id)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT 
                    NR_ID,UserId,Content,[Time],Title,case [IsRead] WHEN 0 THEN N'否' ELSE N'是' END as IsRead,NoticeType
                FROM 
                    Notice_Notice
                WHERE 
                    NR_ID=@NR_ID
            ");

            // 变量赋值
            DHelper.AddParameter(comm, "@NR_ID", SqlDbType.Int, id);

            var dt = DHelper.ExecuteDataTable(comm);

            return Load(dt.Rows[0]);
        }

        /// <summary>
        /// 根据用户ID查询未读信息数
        /// </summary>
        /// yand    16.09.10
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable FindByUserId(int userId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT  NR_ID,UserId,Content,[Time],Title,case [IsRead] WHEN 0 THEN N'否' ELSE N'是' END as IsRead,NoticeType 
                FROM  Notice_Notice WHERE UserId=@UserId AND IsRead =0 AND NoticeType = @NoticeType
            ");

            // 变量赋值
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);
            DHelper.AddParameter(comm, "@NoticeType", SqlDbType.NVarChar, "系统提示");

            DataTable dt = DHelper.ExecuteDataTable(comm);
            return dt;
        }

        /// <summary>
        /// 查找集合
        /// </summary>
        /// zouql   16.08.29
        /// <param name="userId">用户标识</param>
        /// <param name="isRead">是否已读</param>
        /// <param name="pagination">分页</param>
        /// <returns>通知集合</returns>
        public DataTable Find(int userId, bool isRead, Models.Pagination pagination)
        {
            var sql = string.Format(@"
                SELECT TOP (@End)
		            Notice.[NR_ID]
		            ,[UserId]
		            ,[Content]
		            ,[Time]
		            ,[Title]
		            ,CASE Notice.IsRead
			            WHEN 0 THEN N'否'
			            ELSE N'是'
		            END AS IsRead
		            ,[NoticeType]
	            FROM Notice_Notice Notice
	            LEFT JOIN (SELECT
			            ROW_NUMBER() OVER (ORDER BY IsRead, [Time] DESC) AS RowIndex
			            ,NR_ID
			            ,IsRead
		            FROM Notice_Notice
		            WHERE UserId = @UserId
		            AND IsRead = @IsRead) NoticeRelation
		            ON NoticeRelation.NR_ID = Notice.NR_ID
	            WHERE NoticeRelation.RowIndex > @Begin
            ");

            if (pagination == null)
            {
                sql = string.Format(@"
                SELECT 
                    NR_ID,UserId,Content,[Time],Title,case [IsRead] WHEN 0 THEN N'否' ELSE N'是' END as IsRead,NoticeType
                FROM 
                    Notice_Notice
                WHERE 
                    UserId=@UserId AND IsRead=@IsRead
                ORDER BY 
                    IsRead,[Time]
            ");
                pagination = new Models.Pagination(0, 0);
            }

            SqlCommand comm = DHelper.GetSqlCommand(sql);
            SqlCommand commPage = DHelper.GetSqlCommand(@"
				SELECT COUNT(*) FROM Notice_Notice  WHERE UserId=@UserId AND IsRead=@IsRead
			");

            // 变量赋值
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);
            DHelper.AddParameter(comm, "@IsRead", SqlDbType.Bit, isRead ? 1 : 0);
            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, pagination.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, pagination.End);

            DHelper.AddParameter(commPage, "@IsRead", SqlDbType.Bit, isRead ? 1 : 0);
            DHelper.AddParameter(commPage, "@UserId", SqlDbType.Int, userId);

            var dt = DHelper.ExecuteDataTable(comm);

            pagination.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return dt;
        }

        /// <summary>
        /// 查找指定用户所有的通知
        /// </summary>
        /// zouql   16.08.29
        /// YAND    16.09.13 查询条件增加系统通知条件
        /// <param name="userId">用户标识</param>
        /// <param name="pagination">分页</param>
        /// <returns>通知</returns>
        public DataTable FindAll(int userId, Models.Pagination pagination)
        {
            var sql = string.Format(@"
               SELECT TOP (@End)
		            Notice.[NR_ID]
		            ,[UserId]
		            ,[Content]
		            ,[Time]
		            ,[Title]
		            ,CASE Notice.IsRead
			            WHEN 0 THEN N'否'
			            ELSE N'是'
		            END AS IsRead
		            ,[NoticeType]
	            FROM Notice_Notice Notice
	            LEFT JOIN (SELECT
			            ROW_NUMBER() OVER (ORDER BY IsRead, [Time] DESC) AS RowIndex
			            ,NR_ID
			            ,IsRead
		            FROM Notice_Notice
		            WHERE UserId = @UserId AND NoticeType = @NoticeType) NoticeRelation
		            ON NoticeRelation.NR_ID = Notice.NR_ID
	            WHERE NoticeRelation.RowIndex > @Begin
            ");

            if (pagination == null)
            {
                sql = string.Format(@"
                SELECT 
                    NR_ID,UserId,Content,[Time],Title,case [IsRead] WHEN 0 THEN N'否' ELSE N'是' END as IsRead,NoticeType
                FROM 
                    Notice_Notice
                WHERE 
                    UserId=@UserId
                ORDER BY 
                    IsRead,[Time]
            ");
                pagination = new Models.Pagination(0, 0);
            }

            SqlCommand comm = DHelper.GetSqlCommand(sql);

            // 变量赋值
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, userId);
            DHelper.AddParameter(comm, "@Begin", SqlDbType.Int, pagination.Begin);
            DHelper.AddParameter(comm, "@End", SqlDbType.Int, pagination.End);
            DHelper.AddParameter(comm, "@NoticeType", SqlDbType.NVarChar, "系统提示");

            SqlCommand commPage = DHelper.GetSqlCommand(@"
				SELECT COUNT(*) FROM Notice_Notice WHERE UserId=@UserId AND NoticeType = @NoticeType
			");
            DHelper.AddParameter(commPage, "@NoticeType", SqlDbType.NVarChar, "系统提示");
            DHelper.AddParameter(commPage, "@UserId", SqlDbType.Int, userId);

            var dt = DHelper.ExecuteDataTable(comm);

            pagination.Total = Convert.ToInt32(DHelper.ExecuteScalar(commPage));

            return dt;
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// zouql   16.08.29
        /// <param name="noticeReceiver">通知实体</param>
        /// <returns>插入结果</returns>
        public int Insert(NoticeInfo noticeReceiver)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO Notice_Notice
                    (
                    UserId,Content,[Time],Title,IsRead,NoticeType
                    )
                VALUES
                    (
                    @UserId,@Content,@Time,@Title,@IsRead,@NoticeType
                    )
                SELECT SCOPE_IDENTITY()
            ");

            // 变量赋值
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, noticeReceiver.UserId);
            DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, noticeReceiver.Content);
            DHelper.AddParameter(comm, "@Time", SqlDbType.DateTime, noticeReceiver.Time);
            DHelper.AddParameter(comm, "@Title", SqlDbType.NVarChar, noticeReceiver.Title);
            DHelper.AddParameter(comm, "@IsRead", SqlDbType.Bit, noticeReceiver.IsRead ? 1 : 0);
            DHelper.AddParameter(comm, "@NoticeType", SqlDbType.NVarChar, noticeReceiver.NoticeType);

            return Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// zouql   16.08.29
        /// <param name="noticeReceiver">通知实体</param>
        /// <returns>更新结果</returns>
        public int Update(NoticeInfo noticeReceiver)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE  
                    Notice_Notice
                SET
                    UserId=@UserId,Content=@Content,[Time]=@Time,Title=@Title,IsRead=@IsRead,NoticeType=@NoticeType
                WHERE 
                    NR_ID=@NR_ID
            ");

            // 变量赋值
            DHelper.AddInParameter(comm, "@NR_ID", SqlDbType.Int, noticeReceiver.Id);
            DHelper.AddParameter(comm, "@UserId", SqlDbType.Int, noticeReceiver.UserId);
            DHelper.AddParameter(comm, "@Content", SqlDbType.NVarChar, noticeReceiver.Content);
            DHelper.AddParameter(comm, "@Time", SqlDbType.DateTime, noticeReceiver.Time);
            DHelper.AddParameter(comm, "@Title", SqlDbType.NVarChar, noticeReceiver.Title);
            DHelper.AddParameter(comm, "@IsRead", SqlDbType.Bit, noticeReceiver.IsRead ? 1 : 0);
            DHelper.AddParameter(comm, "@NoticeType", SqlDbType.NVarChar, noticeReceiver.NoticeType);

            return DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        ///  更新是否已读
        /// </summary>
        /// zouql   16.08.29
        /// <param name="idList">标识List</param>
        /// <param name="isRead">IsRead新值</param>
        /// <returns>更新结果</returns>
        public int UpdateIsRead(List<string> idList, bool isRead)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE 
                    Notice_Notice
                SET 
                    IsRead=@IsRead
                WHERE 
                    NR_ID in (" + string.Join(",", idList.ToArray()) + @")
            ");

            // 变量赋值
            DHelper.AddParameter(comm, "@IsRead", SqlDbType.Bit, isRead ? 1 : 0);

            return DHelper.ExecuteNonQuery(comm);
        }
    }
}
