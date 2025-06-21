using QuizMaths.Enums;
using QuizMaths.Models;

namespace QuizMaths.Tests.Models;

public class QuizResultTests
{
    [Theory]
    [InlineData(10, 0, false)]
    [InlineData(10, 5, false)]
    [InlineData(10, 6, true)]
    [InlineData(10, 7, true)]
    [InlineData(10, 10, true)]
    public void QuizResult_IsPassed_CalculatesCorrectly(
        int nbQuestions,
        int nbRightAnswers,
        bool expectedResult)
    {
        var result = new QuizResult(
            nbQuestions,
            nbRightAnswers,
            Level.Medium,
            TypeOperation.Addition);

        Assert.Equal(expectedResult, result.IsPassed);
    }

    [Theory]
    [InlineData(10, 0, 0)]
    [InlineData(10, 1, 10)]
    [InlineData(10, 10, 100)]
    [InlineData(1, 1, 100)]
    [InlineData(1, 0, 0)]
    [InlineData(7, 3, 42.86)]
    public void QuizResult_Percentage_CalculatesCorrectly(
        int nbQuestions,
        int nbRightAnswers,
        double expectedResult)
    {
        var result = new QuizResult(
            nbQuestions,
            nbRightAnswers,
            Level.Medium,
            TypeOperation.Addition);

        Assert.Equal(expectedResult, result.Percentage, 2);
    }

    [Theory]
    [InlineData(10, 0, 10)]
    [InlineData(10, 5, 5)]
    [InlineData(10, 10, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 1, 0)]
    public void QuizResult_NbWrongAnswers_CalculatesCorrectly(
        int nbQuestions,
        int nbRightAnswers,
        int expectedResult)
    {
        var result = new QuizResult(
            nbQuestions,
            nbRightAnswers,
            Level.Medium,
            TypeOperation.Addition);

        Assert.Equal(expectedResult, result.NbWrongAnswers);
    }
}