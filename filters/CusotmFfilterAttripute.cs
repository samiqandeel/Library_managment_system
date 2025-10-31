using Microsoft.AspNetCore.Mvc.Filters;

namespace Library_mangement_system.filters
{
    public class CusotmFfilterAttribute : Attribute, IActionFilter // inhirt Attripute untel can use her as Attribte on controler , action 
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //write logic Execute after actoin, before Result

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //write logic Execute during action
        }
    }
}
