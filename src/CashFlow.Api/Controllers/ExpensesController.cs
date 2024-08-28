using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using ClashFlow.Application.UseCases.Expenses.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost] IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
		try
		{
            var useCase = new RegisterExpenseUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
		catch (ArgumentException ex)
		{
            var errorResponse = new ResponseErrorJson(ex.Message);
            return BadRequest(errorResponse);
		}
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknow error");
        }
    }
}
