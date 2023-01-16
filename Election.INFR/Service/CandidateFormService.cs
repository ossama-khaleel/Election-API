using Election.CORE.Data;
using Election.CORE.Repository;
using Election.CORE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Election.INFR.Service
{
    public class CandidateFormService : ISharedService<Ecandidateform>
    {
        private readonly ISharedRepository<Ecandidateform> _sharedRepository;
        private readonly ISharedRepository<Ecandidate> _candidateRepository;
        private readonly ISharedRepository<Euser> _userRepository;
        private readonly ISharedRepository<Euserinformation> _userInfoRepository;
        private readonly ISharedRepository<Eplaceswithinthemunicipal> _placesRepository;

        public CandidateFormService(ISharedRepository<Eplaceswithinthemunicipal> placesRepository, ISharedRepository<Ecandidateform> sharedRepository, ISharedRepository<Ecandidate> ecandidateRepository , ISharedRepository<Euserinformation> userInfoRepository , ISharedRepository<Euser> userRepository)
        {
            _sharedRepository = sharedRepository;
            _candidateRepository = ecandidateRepository;
            _userInfoRepository = userInfoRepository;
            _userRepository = userRepository;
            _placesRepository = placesRepository;
        }

        public Ecandidateform Create(Ecandidateform ecandidateform)
        {
            var form = _sharedRepository.Create(ecandidateform);
            var forms = _sharedRepository.GetAll().Where(x => x.Userid == form.Userid).ToList();
            if (forms == null)
            {
                return form;
            }
            else 
            {
                return null;
            }
            
        }

        public void Delete(int id)
        {
             _sharedRepository.Delete(id);
        }

        public List<Ecandidateform> GetAll()
        {
            return _sharedRepository.GetAll(); 
        }

        public Ecandidateform GetById(int id)
        {
            return _sharedRepository.GetById(id);   
        }

        public Ecandidateform Update(Ecandidateform ecandidateform)
        {
            var form = _sharedRepository.Update(ecandidateform);
            Ecandidate candidate = new Ecandidate();
            if (ecandidateform.Acceptstatus == 2)
            { 
                var user = _userRepository.GetById((int)form.Userid);
                var userInfo =  _userInfoRepository.GetById((int)user.Userinfoid);
                var places = _placesRepository.GetAll().Where(x => x.Placeofresidenceid == userInfo.Placeofresidenceid && x.Placeofresidencevillageid == userInfo.Placeofresidencevillageid).FirstOrDefault(); 
                candidate.Candidateformid = form.Id;
                candidate.Candidatename = form.Candidatename;
                candidate.Categoryid = form.Categoryid;
                candidate.Userid = form.Userid;
                candidate.Municipalstatusid = places.Municipalstatusid;
                var can = _candidateRepository.Create(candidate);
                return _sharedRepository.Update(ecandidateform);
            }
            else {
                var can = _candidateRepository.GetAll().Where(x=> x.Candidateformid == form.Id).FirstOrDefault();
                _candidateRepository.Delete((int)can.Id);
                return _sharedRepository.Update(ecandidateform);
            }
        }
    }
}
