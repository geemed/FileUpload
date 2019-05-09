using System.Web.Http;
using System.Threading.Tasks;
using FileUpload.Core.Attributes;
using FileUpload.Core.Logic;

namespace FileUpload.Controllers {
    [RoutePrefix("api/upload")]
    public class UploadController : ApiController {
        private readonly UploadLogic _logic;

        public UploadController() {
            _logic = new UploadLogic();
        }

        [HttpPost]
        [ValidateMimeMultipartContentFilter]
        [Route("multiple")]
        public async Task<IHttpActionResult> UploadFile() {
            await Task.Delay(1000);
            var files = await _logic.UploadFile(Request);

            return Ok(files);
        }

        [HttpDelete]
        [Route("remove/{id:int}")]
        public async Task<IHttpActionResult> UploadFile(int id) {
            var result = await _logic.DeleteFile(id);

            return Ok(result);
        }
    }
}
