using QuizMaths.Enums;
using QuizMaths.Services;

namespace QuizMaths.Tests.Services;

public class QuestionGeneratorTests
{
    [Theory]
    [InlineData(Level.Easy, 10)]
    [InlineData(Level.Medium, 50)]
    [InlineData(Level.Hard, 100)]
    public void GenerateQuestion_NumbersInCorrectRange(
        Level level,
        int maxExpected)
    {
        var random = new Random();
        var generator = new QuestionGenerator(random);

        var question = generator.GenerateQuestion(level, TypeOperation.Addition);

        Assert.True(question.Number1 > 0 && question.Number1 <= maxExpected,
            $"Nombre1 pour le niveau {level} doit être entre 1 et {maxExpected}");
        Assert.True(question.Number2 > 0 && question.Number2 <= maxExpected,
            $"Nombre2 pour le niveau {level} doit être entre 1 et {maxExpected}");
    }

    [Fact]
    public void GenerateQuestion_Division_AvoidsDivisionByZero()
    {
        var random = new Random();
        var generator = new QuestionGenerator(random);

        for (int i = 0; i < 100; i++)
        {
            var question = generator.GenerateQuestion(Level.Medium, TypeOperation.Division);
            Assert.NotEqual(0, question.Number2);
        }
    }

    [Theory]
    [InlineData(TypeOperation.Addition)]
    [InlineData(TypeOperation.Subtraction)]
    [InlineData(TypeOperation.Multiplication)]
    [InlineData(TypeOperation.Division)]
    [InlineData(TypeOperation.All)]
    public void GenerateQuestion_SupportsAllOperationTypes(TypeOperation typeOperation)
    {
        var random = new Random();
        var generator = new QuestionGenerator(random);

        var question = generator.GenerateQuestion(Level.Medium, typeOperation);

        Assert.NotNull(question);
        Assert.True(question.Number1 > 0);
        Assert.True(question.Number2 > 0);
    }

    [Fact]
    public void GenerateQuestion_AllOperations_GetRandomOperation()
    {
        // Créé plusieurs générateurs avec des graines différentes
        var generators = Enumerable.Range(0, 5)
            .Select(i => new QuestionGenerator(new Random(i)))
            .ToList();

        // Collecte les opérations générées
        var operations = generators
            .SelectMany(g => Enumerable.Range(0, 10)
                .Select(_ => g.GenerateQuestion(Level.Medium, TypeOperation.All).Operation))
            .Distinct()
            .ToList();

        // Vérifie qu'au moins 2 types d'opérations différents ont été générés
        Assert.True(operations.Count > 1,
            $"Le type Mixte devrait générer des opérations différentes. Opérations générées : {string.Join(", ", operations)}");
    }
}