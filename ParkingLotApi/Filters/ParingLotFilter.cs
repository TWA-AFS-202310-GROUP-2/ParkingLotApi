using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.ParkingLotExceptions;

namespace ParkingLotApi.Filters
{
    public class ParingLotFilter : IActionFilter,IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // catch exception
            switch (context.Exception)
            {
                case ParkingLotNotFoundException _:
                    context.Result = new NotFoundObjectResult(context.Exception.Message);
                    context.ExceptionHandled = true;
                    break;
                case ParkingLotIsFullException _:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    context.ExceptionHandled = true;
                    break;
                case ParkingLotHasExistedException _:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    context.ExceptionHandled = true;
                    break;
                case PageOrPageSizeOutOfRangeException _:
                    context.Result = new BadRequestObjectResult(context.Exception.Message);
                    context.ExceptionHandled = true;
                    break;
                // case ParkingLotCapacityIsNotValidException _:
                //     context.Result = new BadRequestObjectResult(context.Exception.Message);
                //     context.ExceptionHandled = true;
                //     break;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}