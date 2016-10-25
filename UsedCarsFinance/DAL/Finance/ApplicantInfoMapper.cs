using DataHelper;
using Models.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Finance
{
    public class ApplicantInfoMapper : AbstractMapper<ApplicantInfo>
    {
        /// <summary>
        /// 通过实体，增加一个申请人信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="values"></param>
        /// <returns></returns>
        public void Insert(ApplicantInfo values)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                INSERT INTO FANC_ApplicantInfo (
                    FinanceId  ,
                    Name ,
                    Sex ,
                    Age ,
                    Type ,
                    RelationWithMaster ,
                    [Identity] ,
                    IdentityType ,
                    Mobile ,
                    Phone ,
                    MaritalStatus ,
                    WifeName ,
                    Degree ,
                    RegisteredAddress ,
                    OfficeName ,
                    Department ,
                    IndustryType ,
                    ProfessionType ,
                    OfficePhone ,
                    OfficeAddress ,
                    LiveHouseType ,
                    LiveHouseArea ,
                    LiveHouseAddress ,
                    OwnHouseType ,
                    OwnHouseAddress ,
                    ContactAddress ,
                    ContactAddressType ,
                    TotalMonthlyIncome ,
                    HomeMonthlyIncome ,
                    HomeMonthlyExpend ,
                    OtherIncome ,
                    FamilyNumber ,
                    AddDate,
                    Fax,
                    EMail,
                    Postcode
                    ) VALUES(
                    @FinanceId ,
                    @Name ,
                    @Sex ,
                    @Age,
                    @Type ,
                    @RelationWithMaster ,
                    @Identity ,
                    @IdentityType ,
                    @Mobile ,
                    @Phone ,
                    @MaritalStatus ,
                    @WifeName ,
                    @Degree ,
                    @RegisteredAddress ,
                    @OfficeName ,
                    @Department ,
                    @IndustryType,
                    @ProfessionType ,
                    @OfficePhone ,
                    @OfficeAddress,
                    @LiveHouseType ,
                    @LiveHouseArea ,
                    @LiveHouseAddress ,
                    @OwnHouseType ,
                    @OwnHouseAddress ,
                    @ContactAddress ,
                    @ContactAddressType ,
                    @TotalMonthlyIncome ,
                    @HomeMonthlyIncome ,
                    @HomeMonthlyExpend ,
                    @OtherIncome ,
                    @FamilyNumber ,
                    getdate(),
                    @Fax,
                    @EMail,
                    @Postcode
                )

                SELECT SCOPE_IDENTITY()"
              );

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, values.FinanceId);
            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, values.Name);
            DHelper.AddParameter(comm, "@Sex", SqlDbType.NVarChar, values.Sex);
            DHelper.AddParameter(comm, "@Age", SqlDbType.Int, values.Age);
            DHelper.AddParameter(comm, "@Type", SqlDbType.Int, (ApplicantInfo.TypeEnum)values.Type);
            DHelper.AddParameter(comm, "@RelationWithMaster", SqlDbType.NVarChar, values.RelationWithMaster);
            DHelper.AddParameter(comm, "@Identity", SqlDbType.NVarChar, values.Identity);
            DHelper.AddParameter(comm, "@IdentityType", SqlDbType.NVarChar, values.IdentityType);
            DHelper.AddParameter(comm, "@Mobile", SqlDbType.NVarChar, values.Mobile);
            DHelper.AddParameter(comm, "@Phone", SqlDbType.NVarChar, values.Phone);
            DHelper.AddParameter(comm, "@MaritalStatus", SqlDbType.NVarChar, values.MaritalStatus);
            DHelper.AddParameter(comm, "@WifeName", SqlDbType.NVarChar, values.WifeName);
            DHelper.AddParameter(comm, "@Degree", SqlDbType.NVarChar, values.Degree);
            DHelper.AddParameter(comm, "@RegisteredAddress", SqlDbType.NVarChar, values.RegisteredAddress);
            DHelper.AddParameter(comm, "@OfficeName", SqlDbType.NVarChar, values.OfficeName);
            DHelper.AddParameter(comm, "@Department", SqlDbType.NVarChar, values.Department);
            DHelper.AddParameter(comm, "@IndustryType", SqlDbType.NVarChar, values.IndustryType);
            DHelper.AddParameter(comm, "@ProfessionType", SqlDbType.NVarChar, values.ProfessionType);
            DHelper.AddParameter(comm, "@OfficePhone", SqlDbType.NVarChar, values.OfficePhone);
            DHelper.AddParameter(comm, "@OfficeAddress", SqlDbType.NVarChar, values.OfficeAddress);
            DHelper.AddParameter(comm, "@LiveHouseType", SqlDbType.NVarChar, values.LiveHouseType);
            DHelper.AddParameter(comm, "@LiveHouseArea", SqlDbType.NVarChar, values.LiveHouseArea);
            DHelper.AddParameter(comm, "@LiveHouseAddress", SqlDbType.NVarChar, values.LiveHouseAddress);
            DHelper.AddParameter(comm, "@OwnHouseType", SqlDbType.NVarChar, values.OwnHouseType);
            DHelper.AddParameter(comm, "@OwnHouseAddress", SqlDbType.NVarChar, values.OwnHouseAddress);
            DHelper.AddParameter(comm, "@ContactAddress", SqlDbType.NVarChar, values.ContactAddress);
            DHelper.AddParameter(comm, "@ContactAddressType", SqlDbType.NVarChar, values.ContactAddressType);
            DHelper.AddParameter(comm, "@TotalMonthlyIncome", SqlDbType.NVarChar, values.TotalMonthlyIncome);
            DHelper.AddParameter(comm, "@HomeMonthlyIncome", SqlDbType.NVarChar, values.HomeMonthlyIncome);
            DHelper.AddParameter(comm, "@HomeMonthlyExpend", SqlDbType.NVarChar, values.HomeMonthlyExpend);
            DHelper.AddParameter(comm, "@OtherIncome", SqlDbType.NVarChar, values.OtherIncome);
            DHelper.AddParameter(comm, "@FamilyNumber", SqlDbType.NVarChar, values.FamilyNumber);
            DHelper.AddParameter(comm, "@Fax", SqlDbType.NVarChar, values.Fax);
            DHelper.AddParameter(comm, "@EMail", SqlDbType.NVarChar, values.EMail);
            DHelper.AddParameter(comm, "@Postcode", SqlDbType.NVarChar, values.Postcode);
            values.ApplicantId = Convert.ToInt32(DHelper.ExecuteScalar(comm));
        }

        /// <summary>
        /// 通过FinanceId 查询 产品列表查询方法
        /// </summary>
        /// cais    16.03.31
        /// <param name="financeId"></param>
        /// <returns></returns>
        public List<ApplicantInfo> Find(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(
                @"SELECT * FROM  FANC_ApplicantInfo WHERE FinanceId = @FinanceId ORDER BY Type");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeId);

            return LoadAll(DHelper.ExecuteDataTable(comm).Rows);
        }

        /// <summary>
        /// 根据融资ID查询主要申请人信息
        /// </summary>
        /// yand    16.07.25
        /// <param name="FinanceId"></param>
        /// <returns></returns>
        public ApplicantInfo FindByFinanceID(int FinanceId)
        {
            string findStatement =
                "SELECT * FROM  FANC_ApplicantInfo WHERE FinanceId = @ID AND Type = 1";

            return AbstractFind(findStatement, FinanceId);
        }

        /// <summary>
        /// 通过ApplicantId查询单个附加申请人下的信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public ApplicantInfo FindByApplicantId(int applicantId)
        {
            if (default(int).Equals(applicantId)) return null;

            SqlCommand comm = DHelper.GetSqlCommand(
                @"SELECT * FROM  FANC_ApplicantInfo WHERE ApplicantId = @ApplicantId"
            );

            DHelper.AddParameter(comm, "@ApplicantId", SqlDbType.VarChar, applicantId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return Load(dt);
        }

        /// <summary>
        /// 根据ApplicantId 删除相对应的附加申请人（担保人、联系人）
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public int Delete(int applicantId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"DELETE FANC_ApplicantInfo WHERE ApplicantId = @ApplicantId");

            DHelper.AddParameter(comm, "@ApplicantId", SqlDbType.Int, applicantId);

            return DHelper.ExecuteNonQuery(comm);
        }

        /// <summary>
        /// 根据ApplicantId 来修改申请人信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="values"></param>
        /// <returns></returns>
        public int Update(ApplicantInfo values)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"
                UPDATE FANC_ApplicantInfo SET
                      Name=@Name,
                      Sex=@Sex,
                      Age=@Age,
                      Type=@Type,
                      RelationWithMaster=@RelationWithMaster,
                      [Identity]=@Identity,
                      IdentityType=@IdentityType,
                      Mobile=@Mobile,
                      Phone=@Phone,
                      MaritalStatus=@MaritalStatus,
                      WifeName=@WifeName,
                      Degree=@Degree,
                      RegisteredAddress=@RegisteredAddress,
                      OfficeName=@OfficeName,
                      Department=@Department,
                      IndustryType=@IndustryType,
                      ProfessionType=@ProfessionType,
                      OfficePhone=@OfficePhone,
                      OfficeAddress=@OfficeAddress,
                      LiveHouseType=@LiveHouseType,
                      LiveHouseArea=@LiveHouseArea,
                      LiveHouseAddress=@LiveHouseAddress,
                      OwnHouseType=@OwnHouseType,
                      OwnHouseAddress=@OwnHouseAddress,
                      ContactAddress=@ContactAddress,
                      ContactAddressType=@ContactAddressType,
                      TotalMonthlyIncome=@TotalMonthlyIncome,
                      HomeMonthlyIncome=@HomeMonthlyIncome,
                      HomeMonthlyExpend=@HomeMonthlyExpend,
                      OtherIncome=@OtherIncome,
                      Fax = @Fax,
                      EMail = @EMail,
                      Postcode = @Postcode,
                      FamilyNumber=@FamilyNumber
                WHERE ApplicantId=@ApplicantId");

            DHelper.AddParameter(comm, "@Name", SqlDbType.NVarChar, values.Name);
            DHelper.AddParameter(comm, "@Sex", SqlDbType.NVarChar, values.Sex);
            DHelper.AddParameter(comm, "@Age", SqlDbType.Int, values.Age);
            DHelper.AddParameter(comm, "@Type", SqlDbType.Int, (ApplicantInfo.TypeEnum)values.Type);
            DHelper.AddParameter(comm, "@RelationWithMaster", SqlDbType.NVarChar, values.RelationWithMaster);
            DHelper.AddParameter(comm, "@Identity", SqlDbType.NVarChar, values.Identity);
            DHelper.AddParameter(comm, "@IdentityType", SqlDbType.NVarChar, values.IdentityType);
            DHelper.AddParameter(comm, "@Mobile", SqlDbType.NVarChar, values.Mobile);
            DHelper.AddParameter(comm, "@Phone", SqlDbType.NVarChar, values.Phone);
            DHelper.AddParameter(comm, "@MaritalStatus", SqlDbType.NVarChar, values.MaritalStatus);
            DHelper.AddParameter(comm, "@WifeName", SqlDbType.NVarChar, values.WifeName);
            DHelper.AddParameter(comm, "@Degree", SqlDbType.NVarChar, values.Degree);
            DHelper.AddParameter(comm, "@RegisteredAddress", SqlDbType.NVarChar, values.RegisteredAddress);
            DHelper.AddParameter(comm, "@OfficeName", SqlDbType.NVarChar, values.OfficeName);
            DHelper.AddParameter(comm, "@Department", SqlDbType.NVarChar, values.Department);
            DHelper.AddParameter(comm, "@IndustryType", SqlDbType.NVarChar, values.IndustryType);
            DHelper.AddParameter(comm, "@ProfessionType", SqlDbType.NVarChar, values.ProfessionType);
            DHelper.AddParameter(comm, "@OfficePhone", SqlDbType.NVarChar, values.OfficePhone);
            DHelper.AddParameter(comm, "@OfficeAddress", SqlDbType.NVarChar, values.OfficeAddress);
            DHelper.AddParameter(comm, "@OwnHouseType", SqlDbType.NVarChar, values.OwnHouseType);
            DHelper.AddParameter(comm, "@OwnHouseAddress", SqlDbType.NVarChar, values.OwnHouseAddress);
            DHelper.AddParameter(comm, "@LiveHouseType", SqlDbType.NVarChar, values.LiveHouseType);
            DHelper.AddParameter(comm, "@LiveHouseArea", SqlDbType.NVarChar, values.LiveHouseArea);
            DHelper.AddParameter(comm, "@LiveHouseAddress", SqlDbType.NVarChar, values.LiveHouseAddress);
            DHelper.AddParameter(comm, "@ContactAddress", SqlDbType.NVarChar, values.ContactAddress);
            DHelper.AddParameter(comm, "@ContactAddressType", SqlDbType.NVarChar, values.ContactAddressType);
            DHelper.AddParameter(comm, "@TotalMonthlyIncome", SqlDbType.NVarChar, values.TotalMonthlyIncome);
            DHelper.AddParameter(comm, "@HomeMonthlyIncome", SqlDbType.NVarChar, values.HomeMonthlyIncome);
            DHelper.AddParameter(comm, "@HomeMonthlyExpend", SqlDbType.NVarChar, values.HomeMonthlyExpend);
            DHelper.AddParameter(comm, "@OtherIncome", SqlDbType.NVarChar, values.OtherIncome);
            DHelper.AddParameter(comm, "@FamilyNumber", SqlDbType.NVarChar, values.FamilyNumber);
            DHelper.AddParameter(comm, "@Fax", SqlDbType.NVarChar, values.Fax);
            DHelper.AddParameter(comm, "@EMail", SqlDbType.NVarChar, values.EMail);
            DHelper.AddParameter(comm, "@Postcode", SqlDbType.NVarChar, values.Postcode);
            DHelper.AddParameter(comm, "@ApplicantId", SqlDbType.Int, values.ApplicantId);

            return DHelper.ExecuteNonQuery(comm);
        }


        /// <summary>
        /// 获取申请人姓名和ID
        /// zouql   16.07.27
        /// yangj   16.09.14(还款用户直接默认为主要申请人名字，不用下拉菜单)
        /// </summary>
        /// <returns></returns>
        public ApplicantInfo Option(int financeId)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"SELECT ApplicantId,Name FROM FANC_ApplicantInfo WHERE Type = 1 AND FinanceId = @FinanceId");

            DHelper.AddParameter(comm, "@FinanceId", SqlDbType.Int, financeId);

            DataTable dt = DHelper.ExecuteDataTable(comm);

            return dt.Rows.Count > 0 ? Load(dt.Rows[0]) : null;
        }


        /// <summary>
        /// 根据实例ID查询主要申请人信息
        /// </summary>
        /// yand    19.09.14
        /// <param name="instanceid"></param>
        /// <returns></returns>
        public DataTable FindApplicationByInstanceId(int instanceid)
        {
            SqlCommand comm = DHelper.GetSqlCommand(@"SELECT ApplicantId,Name FROM FANC_ApplicantInfo AS ai 
                LEFT JOIN FANC_FinanceInfo AS fi ON fi.FinanceId = ai.FinanceId 
                LEFT JOIN FLOW_Instance AS fli ON fli.KeyXML.value('FinanceId[1]', 'Int') = fi.FinanceId
            WHERE fli.InstanceId = @InstanceId AND ai.Type =1
            ");
            DHelper.AddInParameter(comm, "@InstanceId", SqlDbType.Int, instanceid);

            return DHelper.ExecuteDataTable(comm);
        }
    }
}