using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Election.INFR.Service
{
    public class PlacesWithInTheMunicipalService : ISharedService<Eplaceswithinthemunicipal>, IPlacesWithInTheMunicipalService
    {
        private readonly ISharedRepository<Eplaceswithinthemunicipal> _sharedRepository;
        private readonly ISharedRepository<Euser> _userRepository;
        private readonly ISharedRepository<Euserinformation> _userInfoRepository;

        public PlacesWithInTheMunicipalService(ISharedRepository<Euser> userRepository, ISharedRepository<Eplaceswithinthemunicipal> sharedRepository, ISharedRepository<Euserinformation> userInfoRepository)
        {
            _sharedRepository = sharedRepository;
            _userInfoRepository = userInfoRepository;
            _userRepository = userRepository;
        }


        public Eplaceswithinthemunicipal UserMunicipal(int id)
        {
            try
            {
                var user = _userRepository.GetById(id);
                var userinfo = _userInfoRepository.GetById((int)user.Userinfoid);
                var muni = _sharedRepository.GetAll().Where(x => x.Placeofresidenceid == userinfo.Placeofresidenceid && x.Placeofresidencevillageid == userinfo.Placeofresidencevillageid).FirstOrDefault();
                return muni;
            }
            catch { 
                return null;
            }

        }

        public Eplaceswithinthemunicipal Create(Eplaceswithinthemunicipal eplaceswithinthemunicipal)
        {
            return _sharedRepository.Create(eplaceswithinthemunicipal);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Eplaceswithinthemunicipal> GetAll()
        {
            return _sharedRepository.GetAll();
        }

        public Eplaceswithinthemunicipal GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public Eplaceswithinthemunicipal Update(Eplaceswithinthemunicipal eplaceswithinthemunicipal)
        {
            return _sharedRepository.Update(eplaceswithinthemunicipal);
        }

      
    }
}
