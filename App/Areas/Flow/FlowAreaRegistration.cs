using System.Web.Mvc;

namespace App.Areas.Flow
{
    public class FlowAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Flow";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Flow_default",
                "Flow/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}