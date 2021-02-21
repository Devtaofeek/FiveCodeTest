﻿using AutoMapper;
using FiveCode.Application.Contract.Data;
using FiveCode.Application.Extensions;
using FiveCode.Application.PaymentGateways;
using FiveCode.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FiveCode.Application.Features.Payment.Command
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, PaymentStatus>
    {
        private readonly IMapper _mapper;
        private IPaymentProcessor _paymentProcessor;
        private IUnitOfWork _unitOfwork;
        private CreatePaymentCommand _request;

        public CreatePaymentCommandHandler(
             IPaymentProcessor paymentProcessor,
            IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;

            _paymentProcessor = paymentProcessor;
            _mapper = mapper;
        }

        public async Task<PaymentStatus> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            _request = request;

            var validator = new CreatePaymentCommandValidator();
            var validationresult = await validator.ValidateAsync(request);
            if (validationresult.Errors.Count > 0)
                throw new ValidationException(validationresult);
            _paymentProcessor.ProcessPayment(request);
            var payment = _mapper.Map<Domain.Payment>(request);
            payment.CreatedBy = "testuser";
            payment.CreatedDate = DateTime.Now;
            PaymentHistory paymenthistory = new PaymentHistory
            {
                Payment = payment,
                PaymentStatus = _paymentProcessor.ReturnPaymentStatus()
            };
            await _unitOfwork.PaymentHistoryRepository.AddAsync(paymenthistory);
            await _unitOfwork.complete();
            return paymenthistory.PaymentStatus;
        }
    }
}