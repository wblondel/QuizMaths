using QuizMaths.Enums;
using QuizMaths.Models;

namespace QuizMaths.UI;

/// <summary>
/// Represents a console-based user interface for interacting with the quiz application.
/// </summary>
public class ConsoleUI
{
    /// Prompts the user to enter the number of questions they would like for the quiz.
    /// Ensures the input is a valid integer between 1 and 10 inclusive.
    /// Repeats the prompt until a valid input is provided.
    /// <returns>The number of questions chosen by the user as an integer.</returns>
    public int AskNbQuestions()
    {
        int nbQuestions;

        do
        {
            Console.Write("How many questions would you like (1-10)? ");
        } while (!int.TryParse(Console.ReadLine(), out nbQuestions) || nbQuestions < 1 || nbQuestions > 10);

        return nbQuestions;
    }

    /// Prompts the user to select a difficulty level for the quiz.
    /// The method presents a list of difficulty levels (Easy, Medium, Hard) to the user
    /// and ensures valid input by re-prompting until a valid selection is made.
    /// <returns>
    /// Returns the selected quiz difficulty level as a value of the Level enumeration.
    /// </returns>
    public Level AskLevel()
    {
        Console.WriteLine("\nChoose a level:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        int choiceLevel;
        do
        {
            Console.Write("Your choice (1-3): ");
        } while (!int.TryParse(Console.ReadLine(), out choiceLevel) || !Enum.IsDefined(typeof(Level), choiceLevel));

        return (Level)choiceLevel;
    }

    /// Prompts the user to select a type of mathematical operation to be used for the quiz.
    /// Displays a menu with the following options: Addition, Subtraction, Multiplication, Division, or All.
    /// Validates the user input to ensure it corresponds to one of the defined operations in the TypeOperation enum.
    /// Repeatedly prompts the user until a valid input is provided.
    /// <returns>
    /// A TypeOperation value representing the chosen type of mathematical operation.
    /// </returns>
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

    /// <summary>
    /// Displays a quiz question on the console.
    /// </summary>
    /// <param name="questionNumber">The number of the current question in the quiz sequence.</param>
    /// <param name="question">The question object containing the operands and operation type to be displayed.</param>
    public void DisplayQuestion(int questionNumber, Question question)
    {
        Console.WriteLine($"\nQuestion {questionNumber}:");
        Console.WriteLine($"{question.Number1} {question.GetOperationSymbol()} {question.Number2} = ?");
    }

    /// <summary>
    /// Reads and returns the user's answer to a question as a double value.
    /// Re-prompts the user if the input is invalid until a valid double is provided.
    /// </summary>
    /// <returns>
    /// The user's answer as a double.
    /// </returns>
    public double GetUserAnswer()
    {
        double userAnswer;
        do
        {
            Console.Write("Your answer: ");
        } while (!double.TryParse(Console.ReadLine(), out userAnswer));

        return userAnswer;
    }

    /// <summary>
    /// Displays the result of a question, indicating whether the user's answer is correct
    /// and providing the correct answer if it is incorrect.
    /// </summary>
    /// <param name="isCorrect">A boolean value indicating whether the user's answer is correct.</param>
    /// <param name="correctAnswer">The correct answer to the question, displayed if the user's answer is incorrect.</param>
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

    /// <summary>
    /// Displays the final results of the quiz, including statistics such as level, operation type,
    /// total number of questions, correct answers, incorrect answers, percentage score,
    /// and the final pass or fail result.
    /// </summary>
    /// <param name="quizResult">The result data of the quiz to be displayed.</param>
    public void ShowFinalResults(QuizResult quizResult)
    {
        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"Level: {quizResult.Level}");
        Console.WriteLine($"Operation type: {quizResult.TypeOperation}");
        Console.WriteLine($"Number of questions: {quizResult.NbQuestions}");
        Console.WriteLine($"Correct answers: {quizResult.NbRightAnswers}");
        Console.WriteLine($"Incorrect answers: {quizResult.NbWrongAnswers}");
        Console.WriteLine($"Score: {quizResult.Percentage:F1}%");
        Console.WriteLine($"Final result: {(quizResult.IsPassed ? "Pass!" : "Fail")}");
    }


    /// Prompts the user to decide whether they would like to play the quiz again.
    /// Accepts user input and interprets it as a decision.
    /// Input starting with 'Y' (case-insensitive) is considered positive, all other inputs are treated as negative.
    /// Ensures null or empty input is handled as a default negative response.
    /// <returns>True if the user chooses to play again, otherwise false.</returns>
    public bool AskPlayAgain()
    {
        Console.Write("\nWould you like to play again? (Y/N) ");
        string? input = Console.ReadLine();

        return !string.IsNullOrEmpty(input) && input.Trim().StartsWith("Y", StringComparison.OrdinalIgnoreCase);
    }
}