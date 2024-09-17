using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IFileServices
    {

        public ResponseQuery<string> CreateFileCSV(string name, ResponseQuery<string> response);

    }
}
