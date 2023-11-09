﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

public class InvalidCapacityExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is InvalidCapacityException)
        {
            context.Result = new BadRequestResult();
            context.ExceptionHandled = true;
        }
        else if(context.Exception is NotParkingLotofIdException)
        {
            context.Result = new NotFoundResult();
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

}
