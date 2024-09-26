using AjusteCSV.Access.Data;
using AjusteCSV.Access.Utilities;
using AjusteCSV.BL.Data;
using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AutoMapper;

namespace AjusteCSV.Access.Access
{
    public class AllAssetDataAccess : IAllAssetDataAccess
    {
        protected DannteEssaContext context;
        private readonly IMapper mapper;

        public AllAssetDataAccess(DannteEssaContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public Boolean SearchData(List<AllAssetNew> request)
        {
            
            context.AllAssetNews.AddRange(request);
            context.SaveChanges();
            var result = true;

            return result;
        }

        public Boolean UpdateData(List<AllAssetDTO> request)
        {
            //  id list in request
            var idListToFind = request.Select(x => x.Id).ToList();

            // bring database data from related Ids
            List<AllAssetNew> entities = context.AllAssetNews.Where(x => idListToFind.Contains(x.Id)).ToList();            

            foreach (var item in entities)
            {
                var EntityExist = request.FirstOrDefault(x => x.Id == item.Id);
                //var EntityExistDTo = mapper.Map<AllAssetDTO>(EntityExist);
                //FrameworkTypeUtility.SetProperties(item, EntityExistDTo);
                item.State = EntityExist.State;
                //EntityExist = mapper.Map<AllAssetNew>(EntityExistDTo);
            }

            context.SaveChanges();


            var result = true;

            return result;
        }

        public List<AllAsset> GetListAllAsset()
        {

            List<AllAsset> entidad = context.AllAssets.ToList();
            return entidad;

        }

        public List<AllAssetNew> GetListAllAssetNews()
        {

            List<AllAssetNew> entidad = context.AllAssetNews.ToList();
            return entidad;

        }

    }
}
