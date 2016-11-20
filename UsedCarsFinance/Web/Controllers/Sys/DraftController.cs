namespace Web.Controllers.Sys
{
    using System.Web.Http;
    using Application;
    using Application.ViewModels.OtherViewModels;

    public class DraftController : ApiController
    {
        private readonly DraftAppService service;

        public DraftController(DraftAppService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IHttpActionResult Save(DraftViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Save(model);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Read(string pageLink)
        {
            var draft = service.Read(pageLink);

            if (draft == null)
            {
                return NotFound();
            }

            return Ok(draft);
        }

        [HttpDelete]
        public IHttpActionResult Clear(string pageLink)
        {
            service.Clear(pageLink);

            return Ok();
        }
    }
}
