using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IAllAssetOracleServices
    {
        public ResponseEntity<List<AllAssetDTO>> SearchData(ResponseEntity<List<AllAssetDTO>> response);
    }
}
