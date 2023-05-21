﻿using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace DiplomskiRad.Validation
{
    public class ValidationBehavior<TRequest, TRespose> : IPipelineBehavior<TRequest, TRespose>
        where TRequest : IRequest<TRespose>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TRespose> Handle(TRequest request, RequestHandlerDelegate<TRespose> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new FluentValidation.ValidationException(failures);
            }
            return await next();
        }
    }
}
