using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using ClashFlow.Domain;
using ClashFlow.Exception.ExceptionBase;

namespace ClashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegistredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        var entity = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Title = request.Title,
            Date = request.Date,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType,
        };

        return new ResponseRegistredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
