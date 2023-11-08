using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filter
{
    public class LowCapacityFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue-10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is LowCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
