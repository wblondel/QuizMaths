using QuizMaths.Enums;

namespace QuizMaths.Models;

/// <summary>
/// Represents the result of a quiz, including performance metrics and details about the quiz settings.
/// </summary>
public readonly struct QuizResult(int nbQuestions, int nbRightAnswers, Level level, TypeOperation typeOperation)
{
    /// <summary>
    /// Gets the total number of questions in the quiz.
    /// Represents the count of all questions presented during the quiz session.
    /// This property is read-only and is set during the initialization of the quiz result.
    /// </summary>
    public int NbQuestions { get; } = nbQuestions;

    /// <summary>
    /// Gets the number of correctly answered questions in a quiz.
    /// </summary>
    /// <remarks>
    /// This property represents the total number of correct responses
    /// provided by the user during a quiz session.
    /// It is calculated based on the user's answers and is used to determine their
    /// performance, percentage score, and pass/fail status.
    /// </remarks>
    public int NbRightAnswers { get; } = nbRightAnswers;

    /// <summary>
    /// Gets the calculated number of incorrect answers in the quiz.
    /// This value is determined by subtracting the number of correct answers
    /// from the total number of questions.
    /// </summary>
    public int NbWrongAnswers { get; } = nbQuestions - nbRightAnswers;

    /// <summary>
    /// Represents the difficulty level of the quiz.
    /// </summary>
    /// <remarks>
    /// The levels are defined as follows:
    /// Easy = 1, Medium = 2, Hard = 3.
    /// </remarks>
    public Level Level { get; } = level;

    /// <summary>
    /// Specifies the type of mathematical operation used in a quiz.
    /// </summary>
    /// <remarks>
    /// The possible values include:
    /// - Addition: Represents the addition operation.
    /// - Subtraction: Represents the subtraction operation.
    /// - Multiplication: Represents the multiplication operation.
    /// - Division: Represents the division operation.
    /// - All: Represents a mix of all operation types.
    /// </remarks>
    public TypeOperation TypeOperation { get; } = typeOperation;

    /// <summary>
    /// Gets the percentage score calculated based on the number of correct answers
    /// divided by the total number of questions, multiplied by 100.
    /// </summary>
    /// <value>
    /// A double representing the percentage score. The value is computed as
    /// (NbRightAnswers / NbQuestions) * 100.
    /// </value>
    public double Percentage => (double)NbRightAnswers / NbQuestions * 100;

    /// <summary>
    /// Gets a value indicating whether the quiz result is considered a pass or fail.
    /// </summary>
    /// <remarks>
    /// The passing condition is determined by the percentage of correct answers.
    /// A percentage of 60% or higher is required to pass.
    /// </remarks>
    public bool IsPassed => Percentage >= 60;
}