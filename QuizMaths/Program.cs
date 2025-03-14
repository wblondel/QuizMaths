// See https://aka.ms/new-console-template for more information

using QuizMaths.Services;
using QuizMaths.UI;

namespace QuizMaths;

/// <summary>
/// The Program class serves as the entry point for the QuizMaths application.
/// This class is responsible for initializing and orchestrating the execution
/// of the program.
/// </summary>
class Program
{
    /// <summary>
    /// Entry point of the application. Initializes and starts the quiz application.
    /// </summary>
    /// <param name="args">An array of command-line arguments.</param>
    static void Main(string[] args)
    {
        Random random = new Random();
        ConsoleUI ui = new ConsoleUI();
        QuestionGenerator questionGenerator = new QuestionGenerator(random);
        QuizManager quizManager = new QuizManager(ui, questionGenerator);
        
        quizManager.Start();
    }
}
