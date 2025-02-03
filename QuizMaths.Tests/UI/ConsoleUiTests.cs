using QuizMaths.Enums;
using QuizMaths.Models;
using QuizMaths.UI;

namespace QuizMaths.Tests.UI;

public class ConsoleUiTests
{
    private static ConsoleUI CreateConsoleUiWithInput(string input)
    {
        var consoleUi = new ConsoleUI();
        var stringReader = new StringReader(input);
        Console.SetIn(stringReader);

        return consoleUi;
    }

    private static StringWriter CaptureConsoleOutput()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        return stringWriter;
    }

    [Theory]
    [InlineData("1\n", 1)]
    [InlineData("5\n", 5)]
    [InlineData("10\n", 10)]
    public void AskNbQuestions_ValidInput_ReturnsCorrectNumber(string userInput, int expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskNbQuestions();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0\n-1\n11\n3\n", 3)]
    [InlineData("a\n0\n10", 10)]
    [InlineData("-\nb\n123\n6", 6)]
    public void AskNbQuestions_InvalidThenValidInputs_ReturnsValidNumber(string userInput, int expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskNbQuestions();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n", Level.Easy)]
    [InlineData("2\n", Level.Medium)]
    [InlineData("3\n", Level.Hard)]
    public void AskLevel_ValidInput_ReturnsCorrectLevel(string userInput, Level expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskLevel();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0\n-1\n11\n1\n", Level.Easy)]
    [InlineData("a\n0\n2", Level.Medium)]
    [InlineData("-\nb\n123\n3", Level.Hard)]
    [InlineData("0\n-1\n100\n1\n", Level.Easy)] // Invalid entries followed by lower boundary value.
    [InlineData("abcd\nxyz\n2\n", Level.Medium)] // Non-numeric entries followed by valid level.
    public void AskLevel_InvalidThenValidInputs_ReturnsValidLevel(string userInput, Level expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskLevel();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n", TypeOperation.Addition)]
    [InlineData("2\n", TypeOperation.Subtraction)]
    [InlineData("3\n", TypeOperation.Multiplication)]
    [InlineData("4\n", TypeOperation.Division)]
    [InlineData("5\n", TypeOperation.All)]
    public void AskTypeOperation_ValidInput_ReturnsCorrectOperationType(string userInput, TypeOperation expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskTypeOperation();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0\n-1\n11\n1\n", TypeOperation.Addition)]
    [InlineData("a\n0\n2", TypeOperation.Subtraction)]
    [InlineData("-\nb\n123\n3", TypeOperation.Multiplication)]
    [InlineData("c\n123\n456\n4", TypeOperation.Division)]
    [InlineData("é-\n...d\n@&é\n5", TypeOperation.All)]
    public void AskTypeOperation_InvalidThenValidInputs_ReturnsValidOperationType(string userInput, TypeOperation expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskTypeOperation();

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3", 3)]
    [InlineData("abc\n@\nl123\n-4,5\n5,678\n", -4.5)] // Handle multiple invalid inputs and a valid negative number.
    [InlineData("1,2\n", 1.2)] // Correct parsing of floating-point input.
    [InlineData("\na\n@\n\n0\n", 0)] // Empty and junk inputs followed by valid input.
    public void GetUserAnswer_ValidInput_ReturnsCorrectAnswer(string userInput, double expected)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.GetUserAnswer();

        Assert.Equal(expected, result, 2);
    }

    [Theory]
    [InlineData("y\n")]
    [InlineData("Y\n")]
    [InlineData("   Y   \n")]
    [InlineData("yes\n")]
    [InlineData("Yes\n")]
    [InlineData("YES\n")]
    [InlineData("yeah\n")]
    [InlineData("Yeah\n")]
    public void AskPlayAgain_YesInput_ReturnsTrue(string userInput)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskPlayAgain();

        Assert.True(result);
    }

    [Theory]
    [InlineData("n\n")]
    [InlineData("N\n")]
    [InlineData(" N  \n")]
    [InlineData("no\n")]
    [InlineData("No\n")]
    [InlineData("NO\n")]
    [InlineData("nonsense\n")]
    [InlineData("\n")]
    [InlineData("   \n")]
    [InlineData("42\n")]
    public void AskPlayAgain_NoInput_ReturnsFalse(string userInput)
    {
        var consoleUi = CreateConsoleUiWithInput(userInput);

        var result = consoleUi.AskPlayAgain();

        Assert.False(result);
    }

    [Fact]
    public void ShowFinalResults_ValidQuizResult_DisplaysCorrectOutput()
    {
        var consoleUi = new ConsoleUI();
        var quizResult = new QuizResult(10, 8, Level.Easy, TypeOperation.Addition);
        var output = CaptureConsoleOutput();

        consoleUi.ShowFinalResults(quizResult);

        var consoleOutput = output.ToString();
        Assert.Contains("Level: Easy", consoleOutput);
        Assert.Contains("Operation type: Addition", consoleOutput);
        Assert.Contains("Number of questions: 10", consoleOutput);
        Assert.Contains("Correct answers: 8", consoleOutput);
        Assert.Contains("Incorrect answers: 2", consoleOutput);
        Assert.Contains("Score: 80,0%", consoleOutput);
        Assert.Contains("Final result: Pass!", consoleOutput);
    }

    [Fact]
    public void ShowFinalResults_PerfectScore_DisplaysCorrectOutput()
    {
        var consoleUi = new ConsoleUI();
        var quizResult = new QuizResult(10, 10, Level.Hard, TypeOperation.Multiplication);
        var output = CaptureConsoleOutput();

        consoleUi.ShowFinalResults(quizResult);

        var consoleOutput = output.ToString();
        Assert.Contains("Score: 100,0%", consoleOutput);
        Assert.Contains("Final result: Pass!", consoleOutput);
    }

    [Fact]
    public void ShowFinalResults_ZeroScore_DisplaysCorrectOutput()
    {
        var consoleUi = new ConsoleUI();
        var quizResult = new QuizResult(10, 0, Level.Hard, TypeOperation.Subtraction);
        var output = CaptureConsoleOutput();

        consoleUi.ShowFinalResults(quizResult);

        var consoleOutput = output.ToString();
        Assert.Contains("Score: 0,0%", consoleOutput);
        Assert.Contains("Final result: Fail", consoleOutput);
    }

    [Fact]
    public void DisplayQuestion_ValidQuestion_DisplaysCorrectOutput()
    {
        var consoleUi = new ConsoleUI();
        var question = new Question(5, 10, TypeOperation.Addition);
        var output = CaptureConsoleOutput();

        consoleUi.DisplayQuestion(1, question);

        var consoleOutput = output.ToString();
        Assert.Contains("Question 1:", consoleOutput);
        Assert.Contains("5 + 10 = ?", consoleOutput);
    }

    [Fact]
    public void ShowResultQuestion_CorrectAnswer_DisplaysCorrectMessage()
    {
        var consoleUi = new ConsoleUI();
        var output = CaptureConsoleOutput();

        consoleUi.ShowResultQuestion(true, 0);

        var consoleOutput = output.ToString();
        Assert.Contains("✓ Correct!", consoleOutput);
    }

    [Fact]
    public void ShowResultQuestion_IncorrectAnswer_DisplaysCorrectAnswerMessage()
    {
        var consoleUi = new ConsoleUI();
        var output = CaptureConsoleOutput();

        consoleUi.ShowResultQuestion(false, 42);

        var consoleOutput = output.ToString();
        Assert.Contains("✗ Incorrect.", consoleOutput);
        Assert.Contains("The right answer is: 42", consoleOutput);
    }
}