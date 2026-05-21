using System.Net;
using Backend.Api.Extensions;
using Backend.Application.Common.Results;
using GateForce.Shared.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponseTestController : ControllerBase
{
    [HttpGet("success-no-data")]
    [ProducesResponseType(typeof(BaseResult), (int)HttpStatusCode.OK)]
    public ActionResult<BaseResult> SuccessNoData()
    {
        var result = new BaseResult(
            statusCode: HttpStatusCode.OK,
            message: "Request completed successfully"
        );

        return result.ToActionResult();
    }

    [HttpGet("success-with-data")]
    [ProducesResponseType(typeof(BaseResult), (int)HttpStatusCode.OK)]
    public ActionResult<BaseResult> SuccessWithData()
    {
        var result = new BaseResult(
            data: new { Id = 1, Name = "Test User", Email = "test@example.com" },
            statusCode: HttpStatusCode.OK,
            message: "Data returned successfully"
        );

        return result.ToActionResult();
    }

    [HttpGet("error")]
    [ProducesResponseType(typeof(BaseResult), (int)HttpStatusCode.BadRequest)]
    public ActionResult<BaseResult> Error()
    {
        var result = new BaseResult(
            statusCode: HttpStatusCode.BadRequest,
            message: "This is a bad request example"
        );

        return result.ToActionResult();
    }
}
