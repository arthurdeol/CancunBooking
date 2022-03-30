using CancunBooking.Application.Common.Exceptions;
using NUnit.Framework;
using System;
using FluentAssertions;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CancunBooking.Application.Tests.Exceptions
{
    public class ValidationExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Test]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Checkin", "Check in is required"),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Checkin" });
            actual["Checkin"].Should().BeEquivalentTo(new string[] { "Check in is required" });
        }

        [Test]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Checkin", "Check in is required"),
                new ValidationFailure("Checkout", "Checkout is required"),
                new ValidationFailure("Checkin", "Booking shouldn't be more than 30 days in advance."),
                new ValidationFailure("Checkout", "Check out must be over than check in."),
                new ValidationFailure("Checkin", "Check in should start tomorrow."),
                new ValidationFailure("Name", "Name is required."),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Checkout", "Checkin", "Name" });

            actual["Checkout"].Should().BeEquivalentTo(new string[]
            {
                "Checkout is required",
                "Check out must be over than check in.",
            });

            actual["Checkin"].Should().BeEquivalentTo(new string[]
            {
                "Check in is required",
                "Booking shouldn't be more than 30 days in advance.",
                "Check in should start tomorrow."
            });
        }
    }
}
