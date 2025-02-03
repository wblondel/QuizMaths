// See https://aka.ms/new-console-template for more information

using QuizMaths.Services;
using QuizMaths.UI;

namespace QuizMaths;

using Enums;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var ui = new ConsoleUI();
        var questionGenerator = new QuestionGenerator(random);
        var quizManager = new QuizManager(ui, questionGenerator);
        
        quizManager.Start();
    }
}
