using QuizMaths.Enums;
using QuizMaths.Models;

namespace QuizMaths.Services;

public class QuestionGenerator
{
    private readonly Random _random;

    public QuestionGenerator(Random random)
    {
        _random = random;
    }

    public Question GenerateQuestion(Level level, TypeOperation typeOperation)
    {
        var (min, max) = GetRangeNumbers(level);
        var currentOperation = typeOperation == TypeOperation.All
            ? (TypeOperation)_random.Next(1, 5)
            : typeOperation;
        
        int number1 = _random.Next(min, max);
        int number2;

        if (currentOperation == TypeOperation.Division)
        {
            // Génère un diviseur non-nul adapté au niveau
            do
            {
                number2 = _random.Next(min, max);
            } while (number2 == 0);
        }
        else
        {
            number2 = _random.Next(min, max);
        }
        
        return new Question(number1, number2, currentOperation);
    }

    private (int min, int max) GetRangeNumbers(Level level)
    {
        return level switch
        {
            Level.Easy => (1, 10),
            Level.Medium => (1, 50),
            Level.Hard => (1, 100),
            _ => (1, 10)
        };
    }
}