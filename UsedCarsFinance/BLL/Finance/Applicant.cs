using Models.Finance;
using System.Collections.Generic;
using System.Data;

namespace BLL.Finance
{
    public class Applicant
    {
        private readonly static DAL.Finance.ApplicantInfoMapper financeMapper = new DAL.Finance.ApplicantInfoMapper();

        /// <summary>
        /// 查询所有申请人（无分页，无筛选）
        /// </summary>
        /// cais    16.03.30
        /// <param name="financeId"></param>
        /// <returns></returns>
        public List<ApplicantInfo> List(int financeId)
        {
            return financeMapper.Find(financeId);
        }

        /// <summary>
        /// 通过ApplicantId查询单个附加申请人下的信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public ApplicantInfo Get(int applicantId)
        {
            return financeMapper.FindByApplicantId(applicantId);
        }

        /// <summary>
        /// 通过实体，增加一个申请人信息
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicant"></param>
        /// <returns></returns>
        public bool Add(ApplicantInfo applicant)
        {
            bool add = false;
            financeMapper.Insert(applicant);
            if (applicant.ApplicantId.Value > 0) add = true;

            return add;
        }

        /// <summary>
        /// 通过实体修改
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Modify(ApplicantInfo values)
        {
            bool modify = false;

            ApplicantInfo applicant = financeMapper.FindByApplicantId(values.ApplicantId.Value);

            if (values == null) return false;

            applicant.ApplicantId = values.ApplicantId;
            applicant.FinanceId = values.FinanceId;
            applicant.Name = values.Name;
            applicant.Sex = values.Sex;
            applicant.Age = values.Age;
            applicant.Type = values.Type;
            applicant.RelationWithMaster = values.RelationWithMaster;
            applicant.Identity = values.Identity;
            applicant.IdentityType = values.IdentityType;
            applicant.Mobile = values.Mobile;
            applicant.Phone = values.Phone;
            applicant.MaritalStatus = values.MaritalStatus;
            applicant.WifeName = values.WifeName;
            applicant.Degree = values.Degree;
            applicant.RegisteredAddress = values.RegisteredAddress;
            applicant.OfficeName = values.OfficeName;
            applicant.Department = values.Department;
            applicant.IndustryType = values.IndustryType;
            applicant.ProfessionType = values.ProfessionType;
            applicant.OfficePhone = values.OfficePhone;
            applicant.OfficeAddress = values.OfficeAddress;
            applicant.LiveHouseType = values.LiveHouseType;
            applicant.LiveHouseArea = values.LiveHouseArea;
            applicant.LiveHouseAddress = values.LiveHouseAddress;
            applicant.OwnHouseType = values.OwnHouseType;
            applicant.OwnHouseAddress = values.OwnHouseAddress;
            applicant.ContactAddress = values.ContactAddress;
            applicant.ContactAddressType = values.ContactAddressType;
            applicant.TotalMonthlyIncome = values.TotalMonthlyIncome;
            applicant.HomeMonthlyIncome = values.HomeMonthlyIncome;
            applicant.HomeMonthlyExpend = values.HomeMonthlyExpend;
            applicant.OtherIncome = values.OtherIncome;
            applicant.FamilyNumber = values.FamilyNumber;
            applicant.EMail = values.EMail;
            applicant.Fax = values.Fax;
            applicant.Postcode = values.Postcode;
            if (financeMapper.Update(applicant) > 0)
            {
                modify = true;
            }

            return modify;
        }

        /// <summary>
        /// 根据ApplicantId 删除相对应的附加申请人（担保人、联系人）
        /// </summary>
        /// cais    16.03.31
        /// <param name="applicantId"></param>
        /// <returns></returns>
        public bool Delete(int applicantId)
        {
            bool delete = false;

            if (financeMapper.Delete(applicantId) > 0) delete = true;

            return delete;
        }
        /// <summary>
        /// 获取申请人姓名和ID
        /// zouql   16.07.27
        /// yangj   16.09.14(还款用户直接默认为主要申请人名字，不用下拉菜单)
        /// </summary>
        /// <returns>集合</returns>
        public ApplicantInfo Option(int financeId)
        {
            return financeMapper.Option(financeId);
        }
    }
}