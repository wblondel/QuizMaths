using QuizMaths.Enums;

namespace QuizMaths.Models;

public class Question
{
    public int Number1 { get; private set; }
    public int Number2 { get; private set; }
    public TypeOperation Operation { get; private set; }
    public double CorrectAnswer { get; private set; }

    public Question(int number1, int number2, TypeOperation operation)
    {
        Number1 = number1;
        Number2 = number2;
        Operation = operation;
        CorrectAnswer = ComputeAnswer();
    }

    private double ComputeAnswer()
    {
        return Operation switch
        {
            TypeOperation.Addition => Number1 + Number2,
            TypeOperation.Subtraction => Number1 - Number2,
            TypeOperation.Multiplication => Number1 * Number2,
            TypeOperation.Division => (double)Number1 / Number2,
            _ => 0
        };
    }

    public string GetOperationSymbole()
    {
        return Operation switch
        {
            TypeOperation.Addition => "+",
            TypeOperation.Subtraction => "-",
            TypeOperation.Multiplication => "×",
            TypeOperation.Division => "÷",
            _ => ""
        };
    }
}