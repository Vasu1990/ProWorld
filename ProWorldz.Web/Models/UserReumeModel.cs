using ProWorldz.BL.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProWorldz.Web.Models
{
    public class UserResumeModel:BaseModel
    {
        public UserResumeBM UserResume { get; set; }
    }
}