using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace ClashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegistredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegistredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleEmpty = string.IsNullOrWhiteSpace(request.TItle);

        if (titleEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The Amount must be greater than zero.");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);

        if (result > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future.");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType),request.PaymentType);

        if (!paymentTypeIsValid)
        {
            throw new ArgumentException("Payment type is not valid.");
        }
    }
}
