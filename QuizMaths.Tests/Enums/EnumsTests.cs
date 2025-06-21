using QuizMaths.Enums;

namespace QuizMaths.Tests.Enums;

public class EnumsTests
{
    [Fact]
    public void Enums_AllValuesHaveUniqueValues()
    {
        var levelValues = Enum.GetValues<Level>();
        var typeOperationValues = Enum.GetValues<TypeOperation>();

        Assert.Equal(levelValues.Length, levelValues.Distinct().Count());
        Assert.Equal(typeOperationValues.Length, typeOperationValues.Distinct().Count());
    }
}
