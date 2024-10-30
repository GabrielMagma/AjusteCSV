using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IFileTC1ValidationServices
    {

        public ResponseQuery<bool> ValidationTC1(ResponseQuery<bool> response);

    }
}
