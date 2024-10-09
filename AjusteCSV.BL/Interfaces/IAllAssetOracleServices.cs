using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Responses;

namespace AjusteCSV.BL.Interfaces
{
    public interface IAllAssetOracleServices
    {
        public ResponseEntity<List<AllAssetDTO>> SearchDataTransfor(ResponseEntity<List<AllAssetDTO>> response);

        public ResponseEntity<List<AllAssetDTO>> SearchDataSwitch(ResponseEntity<List<AllAssetDTO>> response);

        public ResponseEntity<List<AllAssetDTO>> SearchDataRecloser(ResponseEntity<List<AllAssetDTO>> response);
    }
}
