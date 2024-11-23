using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;

namespace AjusteCSV.BL.Interfaces
{
    public interface IRamalesDataAccess
    {

        public Boolean SaveData(List<FileIoTemp> request);

        public Boolean SaveDataList(List<FileIoTempDetail> request);

    }
}
