using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Domain.Exceptions;
using FluentAssertions;

namespace CoffeeCorner.Domain.Tests.EntitiesTests;

public class CharacteristicValueTests
{
    [Fact]
    public void Constructor_WhenValueIsNullOrEmpty_ShouldThrowCharacteristicValueException()
    {
        var act = () => new CharacteristicValue(null!);

        act.Should().Throw<CharacteristicValueException>()
            .WithMessage("Value cannot be null or empty.");
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenValueIsEmpty()
    {
        var act = () => new CharacteristicValue(string.Empty);

        act.Should().Throw<CharacteristicValueException>();
    }

    [Fact]
    public void Constructor_ShouldSetValue()
    {
        var value = new CharacteristicValue("Dark");

        value.Value.Should().Be("Dark");
    }
}