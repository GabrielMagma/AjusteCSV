using AjusteCSV.Access.Data;
using AjusteCSV.Access.DataEep;
using AjusteCSV.BL.Data;
using AjusteCSV.BL.Interfaces;

namespace AjusteCSV.Access.Access
{
    public class FileDataAccess : IFileDataAccess
    {
        protected DannteEepTestingContext context;        

        public FileDataAccess(DannteEepTestingContext _context)
        {
            context = _context;            
        }

        public Boolean CreateFile(List<Ideam> request)
        {
            
            context.Ideams.AddRange(request);
            context.SaveChanges();
            var result = true;

            return result;
        }

    }
}
