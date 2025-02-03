using QuizMaths.Models;
using QuizMaths.Services;
using QuizMaths.UI;

namespace QuizMaths;

public class QuizManager
{
    private readonly ConsoleUI _ui;
    private readonly QuestionGenerator _questionGenerator;

    public QuizManager(ConsoleUI ui, QuestionGenerator questionGenerator)
    {
        _ui = ui;
        _questionGenerator = questionGenerator;
    }

    public void Start()
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayQuiz();
            playAgain = _ui.AskPlayAgain();
        }
        
        Console.WriteLine("Thank you for playing!");
    }

    private void PlayQuiz()
    {
        int nbQuestions = _ui.AskNbQuestions();
        var level = _ui.AskLevel();
        var operationType = _ui.AskTypeOperation();
        
        int nbRightAnswers = 0;

        for (int i = 1; i <= nbQuestions; i++)
        {
            var question = _questionGenerator.GenerateQuestion(level, operationType);
            _ui.DisplayQuestion(i, question);

            double userAnswer = _ui.GetUserAnswer();
            bool isCorrect = Math.Abs(userAnswer - question.CorrectAnswer) < 0.01;

            _ui.ShowResultQuestion(isCorrect, question.CorrectAnswer);
            
            if (isCorrect) nbRightAnswers++;
        }
        
        var result = new QuizResult(nbQuestions, nbRightAnswers, level, operationType);
        _ui.ShowFinalResults(result);
    }
}