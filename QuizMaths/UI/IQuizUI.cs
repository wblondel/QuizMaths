using QuizMaths.Enums;
using QuizMaths.Models;

namespace QuizMaths.UI;

/// <summary>
/// Interface définissant les méthodes requires pour l'interface utilisateur du quiz.
/// </summary>
public interface IQuizUI
{
    int AskNbQuestions();
    Level AskLevel();
    TypeOperation AskTypeOperation();
    void DisplayQuestion(int questionNumber, Question question);
    double GetUserAnswer();
    void ShowResultQuestion(bool isCorrect, double correctAnswer);
    void ShowFinalResults(QuizResult quizResult);
    bool AskPlayAgain();
}
