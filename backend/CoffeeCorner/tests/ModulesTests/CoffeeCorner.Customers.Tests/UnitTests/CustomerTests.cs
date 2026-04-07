using CoffeeCorner.Customers.Domain.Entities;
using CoffeeCorner.Customers.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace CoffeeCorner.Customers.Tests.UnitTests;

public class CustomerTests
{
    [Fact]
    public void Constructor_Should_CreateCustomer_When_ValidInput()
    {
        // Arrange
        var publicId = Guid.NewGuid();
        var name = "John";
        var surname = "Doe";
        var email = "john.doe@example.com";
        var addressLine1 = "123 Street";
        var city = "Warsaw";

        // Act
        var customer = new Customer(
            publicId,
            name,
            surname,
            email,
            addressLine1: addressLine1,
            city: city
        );

        // Assert
        customer.PublicId.Should().Be(publicId);
        customer.Name.Should().Be(name);
        customer.Surname.Should().Be(surname);
        customer.Email.Should().Be(email);
        customer.AddressLine1.Should().Be(addressLine1);
        customer.City.Should().Be(city);
        customer.AddressLine2.Should().BeNull();
        customer.Country.Should().BeNull();
        customer.PhoneNumber.Should().BeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_ThrowException_When_NameIsInvalid(string invalidName)
    {
        // Act
        Action act = () => new Customer(
            Guid.NewGuid(),
            invalidName,
            "Doe",
            "john.doe@example.com"
        );

        // Assert
        act.Should().Throw<CustomerCreationException>()
            .WithMessage("Customers name cannot be null or empty");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_ThrowException_When_SurnameIsInvalid(string invalidSurname)
    {
        // Act
        Action act = () => new Customer(
            Guid.NewGuid(),
            "John",
            invalidSurname,
            "john.doe@example.com"
        );

        // Assert
        act.Should().Throw<CustomerCreationException>()
            .WithMessage("Customers surname must be positive");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_Should_ThrowException_When_EmailIsInvalid(string invalidEmail)
    {
        // Act
        Action act = () => new Customer(
            Guid.NewGuid(),
            "John",
            "Doe",
            invalidEmail
        );

        // Assert
        act.Should().Throw<CustomerCreationException>()
            .WithMessage("Email is required");
    }
}