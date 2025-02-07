using QuizMaths.Enums;
using QuizMaths.Models;

namespace QuizMaths.Tests.Models;

public class QuestionTests
{
    [Theory]
    [InlineData(10, 5, TypeOperation.Addition, 15)]
    [InlineData(10, 5, TypeOperation.Subtraction, 5)]
    [InlineData(10, 5, TypeOperation.Multiplication, 50)]
    [InlineData(10, 5, TypeOperation.Division, 2)]
    public void Question_ComputeAnswer_CorrectlyCalculatesResult(
        int nombre1,
        int nombre2,
        TypeOperation operation,
        double expectedResult)
    {
        var question = new Question(nombre1, nombre2, operation);

        Assert.Equal(expectedResult, question.CorrectAnswer, 0.001);
    }

    [Theory]
    [InlineData(TypeOperation.Addition, "+")]
    [InlineData(TypeOperation.Subtraction, "-")]
    [InlineData(TypeOperation.Multiplication, "×")]
    [InlineData(TypeOperation.Division, "÷")]
    public void Question_GetOperationSymbol_ReturnsCorrectSymbol(
        TypeOperation operation,
        string expectedSymbol)
    {
        var question = new Question(10, 5, operation);

        Assert.Equal(expectedSymbol, question.GetOperationSymbol());
    }
}