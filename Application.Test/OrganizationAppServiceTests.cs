namespace Application.Tests
{
    using System;
    using Application;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Test.Repositories;

    [TestClass]
    public class OrganizationAppServiceTests
    {
        private readonly OrganizationAppService service;

        public OrganizationAppServiceTests()
        {
            var repository = new OrganizationRepository();

            service = new OrganizationAppService(repository);
        }

        [TestMethod]
        public void CreateTest()
        {
            var model = new ViewModels.OrganizationViewModels.Organization();

            try
            {
                service.Create(model);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}