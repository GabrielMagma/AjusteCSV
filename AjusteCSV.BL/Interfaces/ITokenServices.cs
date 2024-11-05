using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface ITokenServices
    {

        public ResponseQuery<string> CreateToken(ResponseQuery<string> response);

    }
}
