using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AjusteCSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        readonly IFileServices fileServices;

        public FileController(IFileServices _fileServices)
        {
            fileServices = _fileServices;
        }

        [HttpPost]
        [Route(nameof(FileController.CreateFileCSV))]        
        public async Task<IActionResult> CreateFileCSV([FromBody] string name)
        {
            return await Task.Run(() =>
            {
                ResponseQuery<string> response = new ResponseQuery<string>();
                fileServices.CreateFileCSV(name, response);
                return Ok(response);
            });
        }
    }
}
