namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using Core.Entities.Flow;
    using Core.Entities.Identity;
    using Action_ = Core.Entities.Flow.Action;
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
                new AppRole { Id = "BF42BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营", Power = 3 },
                new AppRole { Id = "C042BEE1-05A4-E611-80C5-507B9DE4A488", Name = "运营复审", Power = 3 },
                new AppRole { Id = "C142BEE1-05A4-E611-80C5-507B9DE4A488", Name = "财务", Power = 3 },
                new AppRole { Id = "C242BEE1-05A4-E611-80C5-507B9DE4A488", Name = "总经理", Power = 2 },
                new AppRole { Id = "C342BEE1-05A4-E611-80C5-507B9DE4A488", Name = "客户经理", Power = 4 },
                new AppRole { Id = "C442BEE1-05A4-E611-80C5-507B9DE4A488", Name = "渠道经理", Power = 4 });

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

            context.Set<Action_>().AddOrUpdate(
                m => m.Id,
                new Action_ { Id = new Guid("{294B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.发起, AllocationType = ActionAllocationEnum.角色, Method = "SaveFinanceData" },
                new Action_ { Id = new Guid("{2A4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "撤销", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{2B4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "NULL" },
                new Action_ { Id = new Guid("{2C4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{2D4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "SaveCreditExamineReportData" },
                new Action_ { Id = new Guid("{2E4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{2F4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{304B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "SaveAuditOptionData" },
                new Action_ { Id = new Guid("{314B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{324B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{334B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "SaveContrantData" },
                new Action_ { Id = new Guid("{344B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回至客户", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{354B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回至复审", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{364B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{374B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = "SaveOperationData" },
                new Action_ { Id = new Guid("{384B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.发起者, Method = "NULL" },
                new Action_ { Id = new Guid("{394B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "提交", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.角色, Method = "SaveInfoAdditionalData" },
                new Action_ { Id = new Guid("{3A4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "撤销", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{3B4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "NULL" },
                new Action_ { Id = new Guid("{3C4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{3D4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "NULL" },
                new Action_ { Id = new Guid("{3E4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{3F4B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "NULL" },
                new Action_ { Id = new Guid("{404B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{414B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "通过", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.指定, Method = "NULL" },
                new Action_ { Id = new Guid("{424B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" },
                new Action_ { Id = new Guid("{434B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "终止", Type = ActionTypeEnum.终止, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{444B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = null, Name = "完成", Type = ActionTypeEnum.完成, AllocationType = ActionAllocationEnum.无, Method = "NULL" },
                new Action_ { Id = new Guid("{454B41DB-14A4-E611-80C5-507B9DE4A488}"), NodeId = new Guid("{1595D79F-08A4-E611-80C5-507B9DE4A488}"), TransferId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), Name = "退回", Type = ActionTypeEnum.流转, AllocationType = ActionAllocationEnum.记录, Method = "NULL" });

            context.Set<Form>().AddOrUpdate(
                m => m.Id,
                new Form { Id = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资申请", Link = "../Finance/FinanceEdit.html", Sort = 200 },
                new Form { Id = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "融资审核", Link = "../Finance/Review.html", Sort = 200 },
                new Form { Id = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "信审报告", Link = "../Finance/CreditExamineReport.html", Sort = 200 },
                new Form { Id = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "信息补充", Link = "../Finance/Operation.html", Sort = 200 },
                new Form { Id = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "放款资料", Link = "../Finance/LoanUploadImages.html", Sort = 200 },
                new Form { Id = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "运营审核", Link = "../Finance/InfoAdditional.html", Sort = 200 },
                new Form { Id = new Guid("{5DDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "财务信息", Link = "../Finance/Loan.html", Sort = 200 },
                new Form { Id = new Guid("{5EDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{5FDC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{60DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{61DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{62DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "预留表单", Link = "about:blank", Sort = 200 },
                new Form { Id = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), FlowId = new Guid("{228C8C80-06A4-E611-80C5-507B9DE4A488}"), Name = "审核意见", Link = "../Flow/ExamineOpinion.html", Sort = 200 });

            context.Set<FormNode>().AddOrUpdate(
                m => new { m.NodeId, m.FormId },
                new FormNode { NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0995D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0A95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = false, IsHandler = true },
                new FormNode { NodeId = new Guid("{0B95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.部分禁用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0C95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0D95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0E95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{0F95D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = false, IsHandler = true },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.启用, IsOpen = true, IsHandler = true },
                new FormNode { NodeId = new Guid("{1095D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1195D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1295D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
                new FormNode { NodeId = new Guid("{1395D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{57DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{58DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{59DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5ADC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5BDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{5CDC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = false, IsHandler = false },
                new FormNode { NodeId = new Guid("{1495D79F-08A4-E611-80C5-507B9DE4A488}"), FormId = new Guid("{63DC5FCF-18A4-E611-80C5-507B9DE4A488}"), State = FormStateEnum.禁用, IsOpen = true, IsHandler = false },
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
