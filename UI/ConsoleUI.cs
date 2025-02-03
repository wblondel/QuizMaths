using QuizMaths.Enums;
using QuizMaths.Models;

namespace QuizMaths.UI;

public class ConsoleUI
{
    public int AskNbQuestions()
    {
        int nbQuestions;

        do
        {
            Console.Write("How many questions would you like (1-10)? ");
        } while (!int.TryParse(Console.ReadLine(), out nbQuestions) || nbQuestions < 1 || nbQuestions > 10);

        return nbQuestions;
    }

    public Level AskLevel()
    {
        Console.WriteLine("\nChoose a level:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        int choiceLevel;
        do
        {
            Console.WriteLine("Your choice (1-3): ");
        } while (!int.TryParse(Console.ReadLine(), out choiceLevel) || !Enum.IsDefined(typeof(Level), choiceLevel));

        return (Level)choiceLevel;
    }

    public TypeOperation AskTypeOperation()
    {
        Console.WriteLine("\nChoose a type of operation: ");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. All");

        int choiceOperation;
        do
        {
            Console.Write("Your choice (1-5): ");
        } while (!int.TryParse(Console.ReadLine(), out choiceOperation) ||
                 !Enum.IsDefined(typeof(TypeOperation), choiceOperation));

        return (TypeOperation)choiceOperation;
    }

    public void DisplayQuestion(int questionNumber, Question question)
    {
        Console.WriteLine($"\nQuestion {questionNumber}:");
        Console.WriteLine($"{question.Number1} {question.GetOperationSymbole()} {question.Number2} = ?");
    }

    public double GetUserAnswer()
    {
        double userAnswer;
        do
        {
            Console.Write("Your answer: ");
        } while (!double.TryParse(Console.ReadLine(), out userAnswer));

        return userAnswer;
    }

    public void ShowResultQuestion(bool isCorrect, double correctAnswer)
    {
        if (isCorrect)
        {
            Console.WriteLine("✓ Correct!");
        }
        else
        {
            Console.WriteLine($"✗ Incorrect. The right answer is: {correctAnswer}");
        }
    }

    public void ShowFinalResults(ResultQuiz result)
    {
        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"Level: {result.Level}");
        Console.WriteLine($"Operation type: {result.TypeOperation}");
        Console.WriteLine($"Number of questions: {result.NbQuestions}");
        Console.WriteLine($"Correct answers: {result.NbRightAnswers}");
        Console.WriteLine($"Incorrect answers: {result.NbWrongAnswers}");
        Console.WriteLine($"Score: {result.Percentage:F1}%");
        Console.WriteLine($"Final result: {(result.IsPassed ? "Pass!" : "Fail")}");
    }

    public bool AskPlayAgain()
    {
        Console.Write("\nWould you like to play again? (Y/N) ");

        return Console.ReadLine().Trim().ToUpper().StartsWith("Y");
    }
}