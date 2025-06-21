using System;
using System.Windows.Forms;
using QuizMaths.Enums;
using QuizMaths.Models;
using QuizMaths.Services;

namespace QuizMaths.UI;

public class GUIUI : IQuizUI
{
    private readonly ILocalizationService _localizationService;
    private string _currentQuestionText = "";

    public GUIUI(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    }

    public int AskNbQuestions()
    {
        using var form = CreateInputForm("Number of questions", "How many questions would you like (1-10)?", "5");

        if (form.ShowDialog() == DialogResult.OK)
        {
            if (int.TryParse(form.InputText, out int result) && result >= 1 && result <= 10)
                return result;
        }

        MessageBox.Show("Please enter a number from 1 to 10.", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return AskNbQuestions();
    }

    public Level AskLevel()
    {
        using var form = CreateSelectionForm("Level",
            new[] { "Easy", "Medium", "Hard" });

        if (form.ShowDialog() == DialogResult.OK)
        {
            return (Level)(form.SelectedIndex + 1);
        }

        return AskLevel();
    }

    public TypeOperation AskTypeOperation()
    {
        using var form = CreateSelectionForm("Operation type",
            new[] { "Addition", "Subtraction", "Multiplication", "Division", "All" });

        if (form.ShowDialog() == DialogResult.OK)
        {
            return (TypeOperation)(form.SelectedIndex + 1);
        }

        return AskTypeOperation();
    }

    public void DisplayQuestion(int questionNumber, Question question)
    {
        _currentQuestionText = $"Question {questionNumber}:\n{question.Number1} {question.GetOperationSymbol()} {question.Number2} = ?";
    }

    public double GetUserAnswer()
    {
        using var form = CreateInputForm("Answer", _currentQuestionText + "\n\nYour answer:", "");

        if (form.ShowDialog() == DialogResult.OK)
        {
            if (double.TryParse(form.InputText, out double result))
                return result;
        }

        MessageBox.Show("Please enter a valid number.", "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return GetUserAnswer();
    }

    public void ShowResultQuestion(bool isCorrect, double correctAnswer)
    {
        string message = isCorrect ?
            "✓ Correct!" :
            $"✗ Incorrect. The right answer is: {correctAnswer}";

        MessageBox.Show(message, "Result", MessageBoxButtons.OK,
            isCorrect ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
    }

    public void ShowFinalResults(QuizResult quizResult)
    {
        string message = $"Level: {quizResult.Level}\n" +
                        $"Operation type: {quizResult.TypeOperation}\n" +
                        $"Number of questions: {quizResult.NbQuestions}\n" +
                        $"Correct answers: {quizResult.NbRightAnswers}\n" +
                        $"Incorrect answers: {quizResult.NbWrongAnswers}\n" +
                        $"Score: {quizResult.Percentage:F1}%\n" +
                        $"Final result: {(quizResult.IsPassed ? "Pass!" : "Fail")}";

        MessageBox.Show(message, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public bool AskPlayAgain()
    {
        DialogResult result = MessageBox.Show("Would you like to play again?", "Play again",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        return result == DialogResult.Yes;
    }

    private InputForm CreateInputForm(string title, string prompt, string defaultValue)
    {
        return new InputForm
        {
            Text = title,
            PromptText = prompt,
            InputText = defaultValue
        };
    }

    private SelectionForm CreateSelectionForm(string title, string[] options)
    {
        return new SelectionForm
        {
            Text = title,
            Options = options
        };
    }
}