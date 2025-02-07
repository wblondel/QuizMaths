using QuizMaths.Models;
using QuizMaths.Services;
using QuizMaths.UI;

namespace QuizMaths;

/// <summary>
/// The QuizManager class manages the overall flow of the quiz application.
/// It coordinates between user interactions via ConsoleUI and question generation
/// using the QuestionGenerator.
/// </summary>
public class QuizManager(ConsoleUI ui, QuestionGenerator questionGenerator)
{
    /// <summary>
    /// Starts the quiz game loop.
    /// This method manages the main flow of the quiz game,
    /// allowing the user to repeatedly play quizzes based on their preferences.
    /// At the end of each quiz session, it prompts the user if they would like to play again.
    /// Displays a final thank-you message after the game loop ends.
    /// </summary>
    public void Start()
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayQuiz();
            playAgain = ui.AskPlayAgain();
        }
        
        Console.WriteLine("Thank you for playing!");
    }

    /// <summary>
    /// Executes the main quiz logic by handling user interactions and evaluating answers.
    /// Coordinates the generation of quiz questions based on user input such as the number of questions,
    /// difficulty level, and type of operation, and then evaluates the user's responses against the correct answers.
    /// Displays individual question results and comprehensive final results at the end of the quiz.
    /// </summary>
    private void PlayQuiz()
    {
        int nbQuestions = ui.AskNbQuestions();
        var level = ui.AskLevel();
        var operationType = ui.AskTypeOperation();
        
        int nbRightAnswers = 0;

        for (int i = 1; i <= nbQuestions; i++)
        {
            var question = questionGenerator.GenerateQuestion(level, operationType);
            ui.DisplayQuestion(i, question);

            double userAnswer = ui.GetUserAnswer();
            bool isCorrect = Math.Abs(userAnswer - question.CorrectAnswer) < 0.01;

            ui.ShowResultQuestion(isCorrect, question.CorrectAnswer);
            
            if (isCorrect) nbRightAnswers++;
        }
        
        var result = new QuizResult(nbQuestions, nbRightAnswers, level, operationType);
        ui.ShowFinalResults(result);
    }
}