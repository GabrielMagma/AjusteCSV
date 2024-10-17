using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IExcelCSVServices
    {

        public ResponseQuery<string> ProcessXlsx(ResponseQuery<string> response);

    }
}
