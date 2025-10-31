using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library_mangement_system.filters
{
    public class HandelErrorExceptionAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Block the catch


            // make the result to viewresult in order to see nave and  bare with masasage Exception
            ViewResult viewresult = new ViewResult();
            viewresult.ViewName = "Error";

            context.Result = viewresult;
        }
    }
}
