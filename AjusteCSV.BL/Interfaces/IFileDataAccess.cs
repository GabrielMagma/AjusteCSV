
using AjusteCSV.BL.DTOs;

namespace AjusteCSV.BL.Interfaces
{
    public interface IFileDataAccess
    {

        public Boolean CreateFile(List<IdeamDTO> request);

    }
}
