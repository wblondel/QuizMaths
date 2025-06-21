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
        var localizationService = new LocalizationService();
        
        // Switch language based on user preference or system settings
        localizationService.SetLanguage("fr"); // For French
        // localizationService.SetLanguage("en"); // For English (default)
        
        Random random = new Random();

        IQuizUI ui;
        if (args.Length > 0 && args[0].ToLower() == "gui")
        {
            ui = new GUIUI(localizationService);
        }
        else
        {
            ui = new ConsoleUI(localizationService);
        }

        QuestionGenerator questionGenerator = new QuestionGenerator(random);
        QuizManager quizManager = new QuizManager(ui, questionGenerator, localizationService);
        
        quizManager.Start();
    }
}
