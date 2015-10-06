using ProWorldz.BL.BusinessLayer;
using ProWorldz.BL.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProWorldz.Web.Areas.Employer.Models
{
    public class BaseModel
    {
        public string SuccessMessage { get; set; }

        public string ErrorMessage { get; set; }
    }
    public class RegisterModel : BaseModel
    {
        public EmployerBM Employer { get; set; }

        public List<CountryBM> CountryList { get; set; }

        public List<IndustryBM> IndustryList { get; set; }

        public RegisterModel()
        {
            CountryBL CountryBL = new CountryBL();

            CommonBL commonBL = new CommonBL();

            CountryList = CountryBL.GetCountry();

            IndustryList = commonBL.GetIndustry();
        }
    }
}