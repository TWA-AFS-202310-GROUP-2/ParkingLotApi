using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class InvalidCapacityExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is InvalidCapacityException invalidCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
           // throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           //throw new NotImplementedException();
        }
    }
}
