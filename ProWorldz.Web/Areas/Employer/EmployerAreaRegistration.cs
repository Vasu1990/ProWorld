using System.Web.Mvc;

namespace ProWorldz.Web.Areas.Employer
{
    public class EmployerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Employer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Employer_default",
                "Employer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
