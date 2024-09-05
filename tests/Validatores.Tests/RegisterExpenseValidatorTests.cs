using CashFlow.Communication.Enums;
using ClashFlow.Application.UseCases.Expenses.Register;
using ClashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validatores.Tests;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void ErrorTitleEmpty()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.TItle = string.Empty;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
    }

    [Fact]
    public void ErrorDateFuture()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.Now.AddDays(1);

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_BE_FUTURE));
    }

    [Fact]
    public void ErrorPaymentInvalid()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)77;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-709)]
    public void ErrorAmountInvalid(decimal amount)
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;

        //Act
        var result = validator.Validate(request);

        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_THAN_ZERO));
    }
}



