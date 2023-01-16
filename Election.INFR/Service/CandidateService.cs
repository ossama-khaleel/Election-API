using Election.CORE.Data;
using Election.CORE.DTO;
using Election.CORE.Repository;
using Election.CORE.Service;
using EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Election.INFR.Service
{
    public class CandidateService : ISharedService<Ecandidate> ,ICandidateService
    {
        private readonly ISharedRepository<Ecandidate> _sharedRepository;
        private readonly ISharedRepository<Eplaceswithinthemunicipal> _municipal;
        private readonly ISharedRepository<Emunicipalstatus> _municipalStatus;
        private readonly ISharedRepository<Euser> _userRepository;
        private readonly ISharedRepository<Euserinformation> _userInfoRepository;
        private readonly ISharedRepository<Euservote> _userVote;
        private readonly ISharedRepository<Eelectionduration> _duration;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUserVotedRepository _userVotedRepository;
        private readonly IEmailSender _emailSender;

        public CandidateService(ISharedRepository<Emunicipalstatus> municipalStatus,
            ISharedRepository<Eplaceswithinthemunicipal> municipal,
            ISharedRepository<Ecandidate> sharedRepository, 
            ISharedRepository<Euser> userRepository,
            ISharedRepository<Euserinformation> userInfoRepository,
            ISharedRepository<Euservote> uservote,
            ICandidateRepository candidateRepository,
            IUserVotedRepository userVotedRepository,
            IEmailSender emailSender,
            ISharedRepository<Eelectionduration> duration)
        {
            _sharedRepository = sharedRepository;
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
            _municipal = municipal;
            _userVote = uservote;
            _candidateRepository = candidateRepository;
            _municipalStatus = municipalStatus;
            _userVotedRepository = userVotedRepository;
            _emailSender = emailSender;
            _duration = duration;
        }

        public Ecandidate Create(Ecandidate ecandidate)
        {
            return _sharedRepository.Create(ecandidate);
        }

        public void Delete(int id)
        {
            _sharedRepository.Delete(id);
        }

        public List<Ecandidate> GetAll()
        {

            return _sharedRepository.GetAll();
        }

        public Ecandidate GetById(int id)
        {
            return _sharedRepository.GetById(id);
        }

        public List<Ecandidate> GetCandidates(int userId, int catId)
        {
            try { 
            var user = _userRepository.GetById(userId);
            var userinfo = _userInfoRepository.GetById((int)user.Userinfoid);
            var muni = _municipal.GetAll().Where(x => x.Placeofresidenceid == userinfo.Placeofresidenceid && x.Placeofresidencevillageid == userinfo.Placeofresidencevillageid).FirstOrDefault();
            var muniStatus = _municipalStatus.GetById((int)muni.Municipalstatusid);
            
            IEnumerable<Ecandidate> candidate = null;
            if (catId != 0)
            {
                candidate = _candidateRepository.GetUserVotes(userId).Where(x => x.Municipalstatusid == muni.Municipalstatusid && x.Categoryid == catId);
                //var candidates = _sharedRepository.GetAll();
                //var usersVotes = _userVoted.GetAll();
                //var link = from c in candidates
                //           join u in usersVotes on c.Id equals u.Candidatesid into test
                //           where c.Municipalstatusid == muni.Municipalstatusid && c.Categoryid == catId 
                //           from can in test.DefaultIfEmpty()
                //           select  c;
                ////candidate = _sharedRepository.GetAll().Where(x => x.Municipalstatusid == muni.Municipalstatusid && x.Categoryid == catId).ToList();
                //candidate =link.ToList();
            }
            var uservote = _userVote.GetAll().Where(x=>x.Userid == user.Id).FirstOrDefault();
            if (uservote == null) 
            {
                Euservote euservote = new Euservote();
                euservote.Userid = userId;
                euservote.Usermunicipalid = muni.Id;
                euservote.Decentralized = muniStatus.Decentralized;
                euservote.Memebers = muniStatus.Memebers;
                euservote.President = muniStatus.President;
                var createVote = _userVote.Create(euservote);
            }
                return candidate.ToList();

            }
            catch
            {
                return null;
            }




            //var message = new Message(new string[] { $"{idWithEmail.Email}" }, "Please Enter The Link To Verify Your Account", $"https://localhost:44383/api/EmailMessage/Emailverifying/{idWithEmail.Id}");
            //_emailSender.SendEmail(message);

            
        }

        public List<Ecandidate> GetCandidatesForUser(int userId, int catId)
        {
            try { 
            var user = _userRepository.GetById(userId);
            var userinfo = _userInfoRepository.GetById((int)user.Userinfoid);
            var muni = _municipal.GetAll().Where(x => x.Placeofresidenceid == userinfo.Placeofresidenceid && x.Placeofresidencevillageid == userinfo.Placeofresidencevillageid).FirstOrDefault();
            IEnumerable<Ecandidate> candidate = null;
            if (catId != 0)
            {
                candidate = _sharedRepository.GetAll().Where(x => x.Municipalstatusid == muni.Municipalstatusid && x.Categoryid == catId).ToList();
            }
            return candidate.ToList();
            }
            catch
            {
                return null;
            }
        }

        public Ecandidate Update(Ecandidate ecandidate)
        {
            return _sharedRepository.Update(ecandidate);
        }

        public void UpdateStatus(int candidateId, int status)
        {
            _candidateRepository.UpdateStatus(candidateId, status);
        }

        public void ElectionDoneForCandidates() {

            var allMuniStatus = _municipalStatus.GetAll();
            foreach (var status in allMuniStatus)
            {
                var allVotesPresident = _userVotedRepository.TotalVotes().Where(x => x.Municipalstatusid == status.Id && x.CategoryName.ToUpper() == "PRESIDENT".ToUpper()).ToList();
                var allVotesMembers = _userVotedRepository.TotalVotes().Where(x => x.Municipalstatusid == status.Id && x.CategoryName.ToUpper() == "MEMEBERS".ToUpper()).ToList();
                var allVotesDecentralized = _userVotedRepository.TotalVotes().Where(x => x.Municipalstatusid == status.Id && x.CategoryName.ToUpper() == "DECENTRALIZED".ToUpper()).ToList();
                var durationPresident=_duration.GetAll().Where(x=>x.Categoryid==1).FirstOrDefault();
                var durationMembers = _duration.GetAll().Where(x=>x.Categoryid==3).FirstOrDefault();
                var durationDecentralized = _duration.GetAll().Where(x=>x.Categoryid==21).FirstOrDefault();
                //president method
                if (durationPresident.Electionenddate <= DateTime.Now)
                {
                    for (int i = 0; i < allVotesPresident.Count; i++)
                    {
                        if (i + 1 <= status.President)
                        {
                            var message = new Message(new string[] { $"{allVotesPresident[i].Email}" }, "Election Result", $"You won for President\n{allVotesPresident[i].Firstname + " " + allVotesPresident[i].Lastname}");
                            _emailSender.SendEmail(message);
                            UpdateStatus((int)allVotesPresident[i].CandidatesId, 1);
                        }
                        else
                        {
                            var message = new Message(new string[] { $"{allVotesPresident[i].Email}" }, "Election Result", $"Sorry You Lost President\n{allVotesPresident[i].Firstname + " " + allVotesPresident[i].Lastname}");
                            _emailSender.SendEmail(message);
                            UpdateStatus((int)allVotesPresident[i].CandidatesId, 0);
                        }
                    }
                }

                //Members method
                if (durationMembers.Electionenddate <= DateTime.Now)
                {
                    for (int i = 0; i < allVotesMembers.Count; i++)
                    {
                        if (i + 1 <= status.Memebers)
                        {
                            var message = new Message(new string[] { $"{allVotesMembers[i].Email}" }, "Election Result", $"You won for Members\n{allVotesMembers[i].Firstname + " " + allVotesMembers[i].Lastname}");
                            _emailSender.SendEmail(message);
                            UpdateStatus((int)allVotesMembers[i].CandidatesId, 1);
                        }
                        else
                        {
                            var message = new Message(new string[] { $"{allVotesMembers[i].Email}" }, "Election Result", $"Sorry You Lost Members\n{allVotesMembers[i].Firstname + " " + allVotesMembers[i].Lastname}");
                            _emailSender.SendEmail(message);
                            UpdateStatus((int)allVotesMembers[i].CandidatesId, 0);
                        }
                    }
                }
                //Decentralized method
                if (durationDecentralized.Electionenddate <= DateTime.Now)
                {
                    for (int i = 0; i < allVotesDecentralized.Count; i++)
                    {
                        if (i + 1 <= status.Decentralized)
                        {
                            var message = new Message(new string[] { $"{allVotesDecentralized[i].Email}" }, "Election Result", $"You won for Decentralized\n{allVotesDecentralized[i].Firstname + " " + allVotesDecentralized[i].Lastname}");
                            _emailSender.SendEmail(message);
                            UpdateStatus((int)allVotesDecentralized[i].CandidatesId, 1);
                        }
                        else
                        {
                            var message = new Message(new string[] { $"{allVotesDecentralized[i].Email}" }, "Election Result", $"Sorry You Lost Decentralized\n{allVotesDecentralized[i].Firstname + " " + allVotesDecentralized[i].Lastname}");
                            _emailSender.SendEmail(message);
                            UpdateStatus((int)allVotesDecentralized[i].CandidatesId, 0);
                        }
                    }
                }
            }
        }


        public void ElectionDoneForUsers()
        {
            var allMuniStatus = _municipalStatus.GetAll();
            var allusersvote = _userVote.GetAll();
            string messageCombined = "";
            foreach (var vote in allusersvote)
            {
                var eplaces = _municipal.GetById((int)vote.Usermunicipalid);
                var status = _municipalStatus.GetById((int)eplaces.Municipalstatusid);
                var userbyid = _userRepository.GetById((int)vote.Userid);
                var allVotesPresident = _userVotedRepository.TotalVotes().Where(x => x.Municipalstatusid == status.Id && x.CategoryName.ToUpper() == "PRESIDENT".ToUpper()).ToList();
                var allVotesMembers = _userVotedRepository.TotalVotes().Where(x => x.Municipalstatusid == status.Id && x.CategoryName.ToUpper() == "MEMEBERS".ToUpper()).ToList();
                var allVotesDecentralized = _userVotedRepository.TotalVotes().Where(x => x.Municipalstatusid == status.Id && x.CategoryName.ToUpper() == "DECENTRALIZED".ToUpper()).ToList();
                var durationPresident = _duration.GetAll().Where(x => x.Categoryid == 1).FirstOrDefault();
                var durationMembers = _duration.GetAll().Where(x => x.Categoryid == 3).FirstOrDefault();
                var durationDecentralized = _duration.GetAll().Where(x => x.Categoryid == 21).FirstOrDefault();
                //president method
                if (durationPresident.Electionenddate <= DateTime.Now)
                {
                    for (int i = 0; i < allVotesPresident.Count; i++)
                    {
                        if (i + 1 <= status.President)
                        {
                            messageCombined += $"{allVotesPresident[i].Firstname + " " + allVotesPresident[i].Lastname}:\t won for President\n";
                        }
                        else
                        {
                            messageCombined += $"{allVotesPresident[i].Firstname + " " + allVotesPresident[i].Lastname}:\t Lost for President\n";

                        }
                    }
                }

                //Members method
                if (durationMembers.Electionenddate <= DateTime.Now)
                {
                    for (int i = 0; i < allVotesMembers.Count; i++)
                    {
                        if (i + 1 <= status.Memebers)
                        {
                            messageCombined += $"{allVotesMembers[i].Firstname + " " + allVotesMembers[i].Lastname}:\t won for Members\n";

                        }
                        else
                        {
                            messageCombined += $"{allVotesMembers[i].Firstname + " " + allVotesMembers[i].Lastname}:\t lost for Members\n";

                        }
                    }
                }
                //Decentralized method
                if (durationDecentralized.Electionenddate <= DateTime.Now)
                {
                    for (int i = 0; i < allVotesDecentralized.Count; i++)
                    {
                        if (i + 1 <= status.Decentralized)
                        {
                            messageCombined += $"{allVotesDecentralized[i].Firstname + " " + allVotesDecentralized[i].Lastname}:\t won for Decentralized\n";

                        }
                        else
                        {
                            messageCombined += $"{allVotesDecentralized[i].Firstname + " " + allVotesDecentralized[i].Lastname}:\t Lost for Decentralized\n";

                        }
                    }
                }

                var message = new Message(new string[] { $"{userbyid.Email}" }, "Election Result", $"{messageCombined}");
                _emailSender.SendEmail(message);
                messageCombined = "";
            }
        }
    }
}
