using AjusteCSV.BL.Responses;
using Microsoft.AspNetCore.Http;

namespace AjusteCSV.BL.Interfaces
{
    public interface IFileTC1ValidationServices
    {

        public ResponseQuery<bool> ValidationTC1(ResponseQuery<bool> response);

    }
}
