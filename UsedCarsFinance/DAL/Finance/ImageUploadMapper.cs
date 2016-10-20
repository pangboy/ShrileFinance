﻿using Model.Sys;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Finance
{
    public class ImageUploadMapper : AbstractMapper<FileInfo>
    {
        /// <summary>
        /// 获取融资人所有文件列表
        /// </summary>
        /// cais    16.04.08
        /// <param name="financeid">融资ID</param>
        /// <returns></returns>
        public DataTable Find(int financeid)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                SELECT FL_ID,ReferenceId,OldName,[NewName],ExtName,FilePath  FROM SYS_FileList
	                WHERE ReferenceId in (
		                SELECT ReferenceId  FROM SYS_Reference 	WHERE ReferencedId in (
			                SELECT ApplicantId FROM FANC_ApplicantInfo WHERE FinanceId=@FinanceId
		                ) OR ReferencedId=@FinanceId
                )
            ");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeid);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// cais    16.04.08
        /// <param name="referenceId">文件引用id</param>
        public void Delete(int referenceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                "DELETE SYS_FileList WHERE ReferenceId=@ReferenceId"
            );
            DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, referenceId);

            DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 根据FinanceId 获得所有申请人的引用ID
        /// </summary>
        /// cais    16.05.03
        /// <param name="financeid"></param>
        public DataTable FindReferenceId(int financeid)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
               SELECT ReferenceId,ReferencedId,ReferencedSid,ReferencedModule  FROM SYS_Reference
                    Where ReferencedId in (
                    SELECT ApplicantId FROM FANC_ApplicantInfo WHERE FinanceId=@financeid
                    ) OR ReferencedId=@financeid
               Order by ReferencedId,ReferencedSid,ReferencedModule
            ");

            DHelper.AddParameter(comm, "@financeid", SqlDbType.Int, financeid);

            return DHelper.ExecuteDataTable(comm);
        }

        /// <summary>
        /// 根据ReferenceId  获得文件
        /// </summary>
        /// <param name="ReferenceId">引用id</param>
        /// cais    16.05.04
        /// <returns>引用id 下的引用列表</returns>
        public DataTable FindFiles(int ReferenceId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
               SELECT FL_ID,ReferenceId,OldName,[NewName],ExtName,FilePath  FROM SYS_FileList
	            WHERE ReferenceId=@ReferenceId
            ");
            DHelper.AddParameter(comm, "@ReferenceId", SqlDbType.Int, ReferenceId);

            return DHelper.ExecuteDataTable(comm);
        }
    }
}