using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application;

namespace Web.Controllers.Statistics
{
    public class StatisticsController : ApiController
    {
        private readonly StatisticsAppService statistics;

        public StatisticsController(StatisticsAppService statistics)
        {
            this.statistics = statistics;
        }
        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="orgaizateId"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult TreeGridPageList(Guid? organizateId, int page, int rows)
        {
            var list = statistics.TreeGridPageList(organizateId, page, rows);

            return Ok(list);
        }
    }
}
