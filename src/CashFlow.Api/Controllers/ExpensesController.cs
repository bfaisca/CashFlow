using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using ClashFlow.Application.UseCases.Expenses.Register;
using ClashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {
        var useCase = new RegisterExpenseUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
