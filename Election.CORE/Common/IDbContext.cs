using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Election.CORE.Common
{
    public interface IDbContext
    {
        public DbConnection Connection { get; }
    }
}

//Scaffold - DbContext "USER ID=JOR15_User67;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb" Oracle.EntityFrameworkCore - outputdir Data - Tables EGender,EPlaceAndRegNum,EPlaceOfRelease,EPlaceOfResidence,EBloodType,ERole,ECategory,EMunicipalName,EPlaceOfResidenceVillage,EGovernorate,EUserInformation,EUser,EUserVote,EElectionDuration,EUserVoted,ECandidates,EMunicipalStatus,EPlacesWithinTheMunicipal,ECandidateForm
//Scaffold - DbContext "USER ID=JOR15_User67;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb" Oracle.EntityFrameworkCore - outputdir Data - Tables EGENDER,EPLACEANDREGNUM,EPLACEOFRELEASE,EPLACEOFRESIDENCE,EBLOODTYPE,EROLE,ECATEGORY,EMUNICIPALNAME,EPLACEOFRESIDENCEVILLAGE,EGOVERNORATE,EUSERINFORMATION,EUSER,EUSERVOTE,EELECTIONDURATION,EUSERVOTED,ECANDIDATES,EMUNICIPALSTATUS,EPLACESWITHINTHEMUNICIPAL,ECANDIDATEFORM