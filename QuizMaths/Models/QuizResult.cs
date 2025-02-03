using QuizMaths.Enums;

namespace QuizMaths.Models;

public class QuizResult
{
    public int NbQuestions { get; }
    public int NbRightAnswers { get; }
    public int NbWrongAnswers { get; }
    public Level Level { get; }
    public TypeOperation TypeOperation { get; }
    public double Percentage => (double)NbRightAnswers / NbQuestions * 100;
    public bool IsPassed => Percentage >= 60;

    public QuizResult(int nbQuestions, int nbRightAnswers, Level level, TypeOperation typeOperation)
    {
        NbQuestions = nbQuestions;
        NbRightAnswers = nbRightAnswers;
        NbWrongAnswers = nbQuestions - nbRightAnswers;
        Level = level;
        TypeOperation = typeOperation;
    }
}