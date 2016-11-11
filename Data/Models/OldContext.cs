namespace Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class OldContext : DbContext
    {
        public OldContext()
            : base("name=MyContext")
        {
        }

        public virtual DbSet<CRET_Cities> CRET_Cities { get; set; }
        public virtual DbSet<CRET_CreditInfo> CRET_CreditInfo { get; set; }
        public virtual DbSet<CRET_PartnerInfo> CRET_PartnerInfo { get; set; }
        public virtual DbSet<FANC_ApplicantInfo> FANC_ApplicantInfo { get; set; }
        public virtual DbSet<FANC_BankInfo> FANC_BankInfo { get; set; }
        public virtual DbSet<FANC_Borrow> FANC_Borrow { get; set; }
        public virtual DbSet<FANC_CreditExamineReport> FANC_CreditExamineReport { get; set; }
        public virtual DbSet<FANC_FinanceInfo> FANC_FinanceInfo { get; set; }
        public virtual DbSet<FANC_VehicleInfo> FANC_VehicleInfo { get; set; }
        public virtual DbSet<FLOW_Action> FLOW_Action { get; set; }
        public virtual DbSet<FLOW_Form> FLOW_Form { get; set; }
        public virtual DbSet<FLOW_Instance> FLOW_Instance { get; set; }
        public virtual DbSet<FLOW_Log> FLOW_Log { get; set; }
        public virtual DbSet<FLOW_Node> FLOW_Node { get; set; }
        public virtual DbSet<FLOW_WorkFlow> FLOW_WorkFlow { get; set; }
        public virtual DbSet<Notice_Notice> Notice_Notice { get; set; }
        public virtual DbSet<PROD_ProduceInfo> PROD_ProduceInfo { get; set; }
        public virtual DbSet<SYS_DicCommon> SYS_DicCommon { get; set; }
        public virtual DbSet<SYS_DicType> SYS_DicType { get; set; }
        public virtual DbSet<SYS_FileList> SYS_FileList { get; set; }
        public virtual DbSet<SYS_Menu> SYS_Menu { get; set; }
        public virtual DbSet<SYS_OperationLog> SYS_OperationLog { get; set; }
        public virtual DbSet<SYS_Reference> SYS_Reference { get; set; }
        public virtual DbSet<USER_Role> USER_Role { get; set; }
        public virtual DbSet<USER_UserInfo> USER_UserInfo { get; set; }
        public virtual DbSet<CRET_ProcessUser> CRET_ProcessUser { get; set; }
        public virtual DbSet<FANC_Contracts> FANC_Contracts { get; set; }
        public virtual DbSet<FANC_FinanceExtra> FANC_FinanceExtra { get; set; }
        public virtual DbSet<FANC_ReviewInfo> FANC_ReviewInfo { get; set; }
        public virtual DbSet<FLOW_FormWithNode> FLOW_FormWithNode { get; set; }
        public virtual DbSet<FLOW_FormWithRole> FLOW_FormWithRole { get; set; }
        public virtual DbSet<Notice_ActionNotice> Notice_ActionNotice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<CRET_Cities>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<CRET_Cities>()
                .Property(e => e.ProvinceName)
                .IsUnicode(false);

            modelBuilder.Entity<CRET_CreditInfo>()
                .Property(e => e.LineOfCredit)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CRET_CreditInfo>()
                .HasOptional(e => e.CRET_PartnerInfo)
                .WithRequired(e => e.CRET_CreditInfo);

            modelBuilder.Entity<CRET_CreditInfo>()
                .HasOptional(e => e.CRET_ProcessUser)
                .WithRequired(e => e.CRET_CreditInfo);

            modelBuilder.Entity<CRET_CreditInfo>()
                .HasMany(e => e.FANC_FinanceInfo)
                .WithOptional(e => e.CRET_CreditInfo)
                .HasForeignKey(e => e.CreateOf);

            modelBuilder.Entity<CRET_CreditInfo>()
                .HasMany(e => e.USER_UserInfo)
                .WithMany(e => e.CRET_CreditInfo)
                .Map(m => m.ToTable("CRET_Account").MapLeftKey("CreditId").MapRightKey("UserId"));

            modelBuilder.Entity<CRET_CreditInfo>()
                .HasMany(e => e.PROD_ProduceInfo)
                .WithMany(e => e.CRET_CreditInfo)
                .Map(m => m.ToTable("CRET_BindProduce").MapLeftKey("CreditId").MapRightKey("ProduceId"));

            modelBuilder.Entity<CRET_PartnerInfo>()
                .Property(e => e.Bail)
                .HasPrecision(12, 2);

            modelBuilder.Entity<FANC_Borrow>()
                .Property(e => e.ApprovalPrincipal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_Borrow>()
                .Property(e => e.FinalCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_Borrow>()
                .Property(e => e.ExtralCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.MainBuyHousePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.MainPresentWorth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.MainMonthlyIncome)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.JointlyBuyHousePrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.JointlyPresentWorth)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.JointlyMonthlyIncome)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FANC_CreditExamineReport>()
                .Property(e => e.ContactInformation)
                .IsUnicode(false);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .Property(e => e.IntentionPrincipal)
                .HasPrecision(12, 2);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .Property(e => e.ApprovalValue)
                .HasPrecision(12, 2);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasMany(e => e.FANC_ApplicantInfo)
                .WithRequired(e => e.FANC_FinanceInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasMany(e => e.FANC_BankInfo)
                .WithRequired(e => e.FANC_FinanceInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasMany(e => e.FANC_Borrow)
                .WithRequired(e => e.FANC_FinanceInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasMany(e => e.FANC_CreditExamineReport)
                .WithRequired(e => e.FANC_FinanceInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasMany(e => e.FANC_Contracts)
                .WithRequired(e => e.FANC_FinanceInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasOptional(e => e.FANC_VehicleInfo)
                .WithRequired(e => e.FANC_FinanceInfo);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasOptional(e => e.FANC_ReviewInfo)
                .WithRequired(e => e.FANC_FinanceInfo);

            modelBuilder.Entity<FANC_FinanceInfo>()
                .HasOptional(e => e.FANC_FinanceExtra)
                .WithRequired(e => e.FANC_FinanceInfo);

            modelBuilder.Entity<FLOW_Action>()
                .Property(e => e.Method)
                .IsUnicode(false);

            modelBuilder.Entity<FLOW_Action>()
                .Property(e => e.BusinessMethod)
                .IsUnicode(false);

            modelBuilder.Entity<FLOW_Action>()
                .HasMany(e => e.FLOW_Log)
                .WithRequired(e => e.FLOW_Action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Action>()
                .HasMany(e => e.Notice_ActionNotice)
                .WithRequired(e => e.FLOW_Action)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Form>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FLOW_Form>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<FLOW_Form>()
                .HasMany(e => e.FLOW_FormWithRole)
                .WithRequired(e => e.FLOW_Form)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Form>()
                .HasMany(e => e.FLOW_FormWithNode)
                .WithRequired(e => e.FLOW_Form)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Instance>()
                .Property(e => e.InstanceData)
                .IsUnicode(false);

            modelBuilder.Entity<FLOW_Instance>()
                .HasMany(e => e.FLOW_Log)
                .WithRequired(e => e.FLOW_Instance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Node>()
                .HasMany(e => e.FLOW_Action)
                .WithRequired(e => e.FLOW_Node)
                .HasForeignKey(e => e.NodeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Node>()
                .HasMany(e => e.FLOW_Action1)
                .WithOptional(e => e.FLOW_Node1)
                .HasForeignKey(e => e.Transfer);

            modelBuilder.Entity<FLOW_Node>()
                .HasMany(e => e.FLOW_Instance)
                .WithOptional(e => e.FLOW_Node)
                .HasForeignKey(e => e.CurrentNode);

            modelBuilder.Entity<FLOW_Node>()
                .HasMany(e => e.FLOW_Log)
                .WithRequired(e => e.FLOW_Node)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_Node>()
                .HasMany(e => e.FLOW_FormWithNode)
                .WithRequired(e => e.FLOW_Node)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_WorkFlow>()
                .HasMany(e => e.FLOW_Form)
                .WithRequired(e => e.FLOW_WorkFlow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_WorkFlow>()
                .HasMany(e => e.FLOW_Instance)
                .WithRequired(e => e.FLOW_WorkFlow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FLOW_WorkFlow>()
                .HasMany(e => e.FLOW_Node)
                .WithRequired(e => e.FLOW_WorkFlow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROD_ProduceInfo>()
                .Property(e => e.CustomerPoundage)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PROD_ProduceInfo>()
                .Property(e => e.AdditionalGPSCost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PROD_ProduceInfo>()
                .Property(e => e.AdditionalOtherCost)
                .HasPrecision(12, 2);

            modelBuilder.Entity<PROD_ProduceInfo>()
                .HasMany(e => e.FANC_FinanceInfo)
                .WithRequired(e => e.PROD_ProduceInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_DicType>()
                .HasMany(e => e.SYS_DicCommon)
                .WithRequired(e => e.SYS_DicType)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SYS_FileList>()
                .Property(e => e.ExtName)
                .IsUnicode(false);

            modelBuilder.Entity<SYS_Reference>()
                .HasMany(e => e.SYS_OperationLog)
                .WithRequired(e => e.SYS_Reference)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_Role>()
                .HasMany(e => e.FLOW_Node)
                .WithOptional(e => e.USER_Role)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<USER_Role>()
                .HasMany(e => e.FLOW_FormWithRole)
                .WithRequired(e => e.USER_Role)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_Role>()
                .HasMany(e => e.USER_UserInfo)
                .WithMany(e => e.USER_Role)
                .Map(m => m.ToTable("USER_Relation").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<USER_UserInfo>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<USER_UserInfo>()
                .Property(e => e.Password)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER_UserInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<USER_UserInfo>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.FANC_FinanceInfo)
                .WithOptional(e => e.USER_UserInfo)
                .HasForeignKey(e => e.CreateBy);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.FLOW_Instance)
                .WithOptional(e => e.USER_UserInfo)
                .HasForeignKey(e => e.CurrentUser);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.FLOW_Instance1)
                .WithOptional(e => e.USER_UserInfo1)
                .HasForeignKey(e => e.ProcessUser);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.FLOW_Instance2)
                .WithOptional(e => e.USER_UserInfo2)
                .HasForeignKey(e => e.StartUser);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.FLOW_Log)
                .WithRequired(e => e.USER_UserInfo)
                .HasForeignKey(e => e.ProcessUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.Notice_Notice)
                .WithRequired(e => e.USER_UserInfo)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.SYS_OperationLog)
                .WithRequired(e => e.USER_UserInfo)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.CRET_ProcessUser)
                .WithOptional(e => e.USER_UserInfo)
                .HasForeignKey(e => e.User1);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.CRET_ProcessUser1)
                .WithOptional(e => e.USER_UserInfo1)
                .HasForeignKey(e => e.User2);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.CRET_ProcessUser2)
                .WithOptional(e => e.USER_UserInfo2)
                .HasForeignKey(e => e.User3);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.CRET_ProcessUser3)
                .WithOptional(e => e.USER_UserInfo3)
                .HasForeignKey(e => e.User4);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.CRET_ProcessUser4)
                .WithOptional(e => e.USER_UserInfo4)
                .HasForeignKey(e => e.User5);

            modelBuilder.Entity<USER_UserInfo>()
                .HasMany(e => e.CRET_ProcessUser5)
                .WithOptional(e => e.USER_UserInfo5)
                .HasForeignKey(e => e.User6);

            modelBuilder.Entity<FANC_Contracts>()
                .Property(e => e.ContractMainCode)
                .IsUnicode(false);

            modelBuilder.Entity<FANC_ReviewInfo>()
                .Property(e => e.FinanceCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FANC_ReviewInfo>()
                .Property(e => e.FinalCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FANC_ReviewInfo>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<FANC_ReviewInfo>()
                .Property(e => e.ApprovalPrincipal)
                .HasPrecision(12, 2);
        }
    }
}
