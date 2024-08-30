using ExampleMvcProject.MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExampleMvcProject.MVC.Service
{
    public class BaseController : Controller
    {
        private readonly IVariablesToController _variables;
        public BaseController(IVariablesToController variables)
        {
            _variables = variables;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Wywołanie metody bazowej
            base.OnActionExecuting(context);

            // Dodaj swoją logikę tutaj
            ViewBag.Variables = _variables.Get();
        }
    }
}
