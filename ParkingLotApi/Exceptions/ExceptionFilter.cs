using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ParkingLotApi.Exceptions
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 10;

        void IActionFilter.OnActionExecuted(ActionExecutedContext context) 
        { 
            if(context.Exception is InvalidCapacityException invalidCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ExistingNameException existingNameException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            else if (context.Exception is NoExistIdException noExistIdException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context) { }
    }
}
