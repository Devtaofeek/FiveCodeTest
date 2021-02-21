using FiveCode.Application.Features.Payment.Command;
using FluentValidation.TestHelper;
using NUnit.Framework;
using System;

namespace FiveCodeTest.UnitTest
{
    public class ValidationTester
    {
        private CreatePaymentCommandValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new CreatePaymentCommandValidator();
        }

        [Test]
        public void Should_have_error_when_CardHolder_is_null()
        {
            var model = new CreatePaymentCommand { CardHolder = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CardHolder);
        }

        [Test]
        public void Should_not_have_error_when_name_is_specified()
        {
            var model = new CreatePaymentCommand { CardHolder = "Andrew" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.CardHolder);
        }

        [Test]
        public void Should_have_error_when_CardNumber_is_NotCorrect()
        {
            var model = new CreatePaymentCommand { CreditCardNumber = "3344234" };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.CreditCardNumber);
        }

        [Test]
        public void Should_not_have_error_when_CardNumber_is_Correct()
        {
            var model = new CreatePaymentCommand { CreditCardNumber = "370867823381128" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.CreditCardNumber);
        }

        [Test]
        public void Should_have_error_when_CardExipyDate_Has_Expired()
        {
            var model = new CreatePaymentCommand { ExpirationDate = DateTime.Now.AddDays(-20) };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.ExpirationDate);
        }

        [Test]
        public void Should_not_have_error_when_CardExipyDate_HasNot_Expired()
        {
            var model = new CreatePaymentCommand { ExpirationDate = DateTime.Now.AddDays(20) };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.ExpirationDate);
        }

        [Test]
        public void Should_have_error_when_SecurityNumber_is_GreaterThamThree()
        {
            var model = new CreatePaymentCommand { SecurityCode = "223444" };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.SecurityCode);
        }

        [Test]
        public void Should_Nothave_error_when_SecurityNumber_isNot_GreaterThanThree()
        {
            var model = new CreatePaymentCommand { SecurityCode = "223" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.SecurityCode);
        }

        [Test]
        public void Should_have_error_when_Amount_is_LessThanZero()
        {
            var model = new CreatePaymentCommand { Amount = 0 };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Amount);
        }

        [Test]
        public void Should_Nothave_error_when_Amount_is_GreaterThanZero()
        {
            var model = new CreatePaymentCommand { Amount = 200 };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Amount);
        }
    }
}