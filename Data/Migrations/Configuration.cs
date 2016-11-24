namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Core.Entities.Produce;
    using Core.Entities;
    using Core.Entities.Flow;
    using Core.Entities.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Flow_ = Core.Entities.Flow.Flow;

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyContext context)
        {
            IdentitySeed(context);
            FlowSeed(context);

            context.Set<FinancingProject>().AddOrUpdate(
               m => m.Id,
               new FinancingProject { Id = new Guid("{093C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "裸车价", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0A3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "购置税", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0B3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "商业险", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0C3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "交强险", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0D3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "车船税", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0E3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "延保险", IsFinancing = true },
               new FinancingProject { Id = new Guid("{0F3C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "其他", IsFinancing = true },
               new FinancingProject { Id = new Guid("{103C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "GPS费用", IsFinancing = false },
               new FinancingProject { Id = new Guid("{113C0A6D-ABA4-E611-80C5-507B9DE4A488}"), Name = "手续费", IsFinancing = false }
               );

            context.SaveChanges();
        }

        /// <summary>
        /// Identity Seed
        /// </summary>
        /// <param name="context"></param>
        private void IdentitySeed(MyContext context)
        {
            context.Set<AppRole>().AddOrUpdate(
                m => m.Id,
                new AppRole { Id = "BB42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "系统管理员", Power = 1 },
                new AppRole { Id = "BC42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "管理员", Power = 2 },
                new AppRole { Id = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "初审员", Power = 3 },
                new AppRole { Id = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "复审员", Power = 3 },
                new AppRole { Id = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营初审", Power = 3 },
                new AppRole { Id = "C042BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营复审", Power = 3 },
                new AppRole { Id = "C142BEE1-05A4-E611-80C5-507B9DE4A488", Name = "财务", Power = 3 },
                new AppRole { Id = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "总经理", Power = 2 },
                new AppRole { Id = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "客户经理", Power = 4 },
                new AppRole { Id = "C442BEE1-05A4-E611-80C5-507B9DE4A488", Name = "渠道经理", Power = 4 });

            context.Set<AppUser>().AddOrUpdate(
                m => m.Id,
                new AppUser {
                    Id = "0075D0E3-53A6-E611-80C5-507B9DE4A488",
                    UserName = "sysadmin",
                    Name = "系统管理员",
                    Email = "sysadmin@shrile.com",
                    PasswordHash = "ACIJtS4jqQUARKbBSMOwza0fOQmx9WTAi1C3Y4K9cP7/nXzu5sfLCvNgppBKGHvgcQ==",
                    SecurityStamp = "9312a299-ca53-43ee-9d03-b01dcd9cd2fe"
                },
                new AppUser {
                    Id = "0175D0E3-53A6-E611-80C5-507B9DE4A488",
                    UserName = "foolishqi",
                    Name = "七月",
                    Email = "qiy@ywsoftware.com",
                    PhoneNumber = "18858261668",
                    PasswordHash = "ACIJtS4jqQUARKbBSMOwza0fOQmx9WTAi1C3Y4K9cP7/nXzu5sfLCvNgppBKGHvgcQ==",
                    SecurityStamp = "9312a299-ca53-43ee-9d03-b01dcd9cd2fe",
                },
                new AppUser {
                    Id = "0275D0E3-53A6-E611-80C5-507B9DE4A488",
                    UserName = "admin",
                    Name = "管理员",
                    Email = "admin@shrile.com",
                    PasswordHash = "ACIJtS4jqQUARKbBSMOwza0fOQmx9WTAi1C3Y4K9cP7/nXzu5sfLCvNgppBKGHvgcQ==",
                    SecurityStamp = "9312a299-ca53-43ee-9d03-b01dcd9cd2fe"
                });

            context.Set<IdentityUserRole>().AddOrUpdate(
                m => m.UserId,
                new IdentityUserRole { UserId = "0075D0E3-53A6-E611-80C5-507B9DE4A488", RoleId = "BB42BEE1-05A4-E611-80C5-507B9DE4A488" },
                new IdentityUserRole { UserId = "0175D0E3-53A6-E611-80C5-507B9DE4A488", RoleId = "BB42BEE1-05A4-E611-80C5-507B9DE4A488" },
                new IdentityUserRole { UserId = "0275D0E3-53A6-E611-80C5-507B9DE4A488", RoleId = "BC42BEE1-05A4-E611-80C5-507B9DE4A488" });

            context.SaveChanges();
        }

        /// <summary>
        /// Flow Seed
        /// </summary>
        /// <param name="context"></param>
        private void FlowSeed(MyContext context)
        {
            context.Set<Flow_>().AddOrUpdate(
                m => m.Id,
                new Flow_ { Id = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资流程" },
                new Flow_ { Id = new Guid("{238C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "授信流程" });

            context.Set<Node>().AddOrUpdate(
                m => m.Id,
                new Node { Id = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "融资申请" },
                new Node { Id = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C442BEE1-05A4-E611-80C5-507B9DE4A488", Name = "申请检查资料" },
                new Node { Id = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "融资初审" },
                new Node { Id = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "融资复审" },
                new Node { Id = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "融资审批" },
                new Node { Id = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营补充" },
                new Node { Id = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "客户补充" },
                new Node { Id = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款资料" },
                new Node { Id = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C442BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款资料检查" },
                new Node { Id = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款初审" },
                new Node { Id = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款复审" },
                new Node { Id = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "放款审批" },
                new Node { Id = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", Name = "财务打款" });

            context.Set<FAction>().AddOrUpdate(
                m => m.Id,
                new FAction { Id = new Guid("{294B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.渠道经理, Method = "FinanceApply" },
                new FAction { Id = new Guid("{2A4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "撤销", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{2B4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{2C4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{2D4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "FinanceAudit" },
                new FAction { Id = new Guid("{2E4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{2F4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{304B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.无, Method = "FinanceReaudit" },
                new FAction { Id = new Guid("{314B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{324B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{334B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{344B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回至客户", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{354B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回至复审", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{364B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{374B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = "FinanceOperation" },
                new FAction { Id = new Guid("{384B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = "FinanceCustomer" },
                new FAction { Id = new Guid("{394B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.渠道经理, Method = "" },
                new FAction { Id = new Guid("{3A4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "撤销", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{3B4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{3C4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{3D4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{3E4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{3F4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{404B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{414B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = null },
                new FAction { Id = new Guid("{424B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null },
                new FAction { Id = new Guid("{434B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{444B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = null },
                new FAction { Id = new Guid("{454B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = null });

            context.Set<Form>().AddOrUpdate(
                m => m.Id,
                new Form { Id = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资申请", Link = "../Finance/NewFinanceEdit.html", Sort = 200 },
                new Form { Id = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资审核", Link = "../Finance/FinanceAudit.html", Sort = 200 },
                new Form { Id = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "信审报告", Link = "../Finance/CreditExamine.html", Sort = 200 },
                new Form { Id = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "信息补充", Link = "../Finance/FinanceOperation.html", Sort = 200 },
                new Form { Id = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "放款资料", Link = "../Finance/LoanUploadImages.html", Sort = 200 },
                new Form { Id = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "运营审核", Link = "../Finance/FinanceApproval.html", Sort = 200 },
                new Form { Id = new Guid("{5DDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "财务信息", Link = "../Finance/Loan.html", Sort = 200 },
                new Form { Id = new Guid("{5EDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "合同生成", Link = "../Finance/PrintContract.html", Sort = 200 },
                new Form { Id = new Guid("{5FDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{60DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{61DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{62DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "审核意见", Link = "../Flow/ExamineOpinion.html", Sort = 200 });

            context.Set<FormNode>().AddOrUpdate(
                m => new { m.NodeId, m.FormId },
                new FormNode { NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态1, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态1, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态1, IsOpen = false, IsHandler = true },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态2, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态1, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态2, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态1, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5EDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.状态1, IsOpen = false, IsHandler = true },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5DDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false });

            context.Set<FormRole>().AddOrUpdate(
                m => new { m.RoleId, m.FormId },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("58DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("59DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BD42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("58DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("59DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BE42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("58DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("59DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5ADC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5BDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5CDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("58DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("59DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5ADC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5BDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5CDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C042BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("58DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("59DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5ADC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5BDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5CDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5DDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C142BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("58DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("59DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5ADC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5BDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5CDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5DDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C242BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5ADC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5BDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C342BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C442BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("57DC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C442BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5ADC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C442BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("5BDC5FCF-18A4-E611-80C5-507B9DE4A488") },
                new FormRole { RoleId = "C442BEE1-05A4-E611-80C5-507B9DE4A488", FormId = new Guid("63DC5FCF-18A4-E611-80C5-507B9DE4A488") });

            context.SaveChanges();
        }
    }
}
