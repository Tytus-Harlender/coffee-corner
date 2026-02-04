using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Domain.Exceptions;
using FluentAssertions;

namespace CoffeeCorner.Domain.Tests.EntitiesTests;

public class CharacteristicTests
{
    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Constructor_WhenNameIsNullEmptyOrWhitespace_ShouldThrowCharacteristicCreationException(string? name)
    {
        var act = () => new Characteristic(name!);

        act.Should().Throw<CharacteristicCreationException>()
            .WithMessage("Characteristic name cannot be null, empty or whitespace.");
    }

    [Fact]
    public void Constructor_NameIsValid_ShouldSetName()
    {
        var characteristic = new Characteristic("Roast Level");

        characteristic.Name.Should().Be("Roast Level");
    }

    [Fact]
    public void AddValues_WhenValuesAreNull_ShouldThrowCharacteristicCreationException()
    {
        var characteristic = new Characteristic("Roast Level");

        var act = () => characteristic.AddValues(null!);

        act.Should().Throw<CharacteristicCreationException>()
            .WithMessage("Characteristic values cannot be null.");
    }

    [Fact]
    public void AddValues_ValuesAreValid_ShouldAddCharacteristicValues()
    {
        var characteristic = new Characteristic("Roast Level");
        var values = new[] { "Light", "Medium", "Dark" };

        characteristic.AddValues(values);

        characteristic.CharacteristicValues.Should().HaveCount(3);
        characteristic.CharacteristicValues
            .Select(v => v.Value)
            .Should()
            .BeEquivalentTo(values);
    }
}