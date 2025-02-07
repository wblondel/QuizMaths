using QuizMaths.Enums;

namespace QuizMaths.Models;

/// <summary>
/// Represents a mathematical question, including two operands,
/// an operation type, and the correct answer.
/// </summary>
public class Question
{
    /// <summary>
    /// Represents the first operand in the mathematical question.
    /// </summary>
    /// <remarks>
    /// The <c>Number1</c> property is assigned during the initialization of the Question instance
    /// and is used as the first number in the mathematical operation specified by the <c>Operation</c> property.
    /// This property is read-only and cannot be modified after initialization.
    /// </remarks>
    public int Number1 { get; }

    /// <summary>
    /// Represents the second operand in a mathematical operation.
    /// </summary>
    /// <remarks>
    /// This property is used to define the second number in conjunction
    /// with <see cref="Number1"/> for performing operations such as addition,
    /// subtraction, multiplication, or division as defined by the <see cref="TypeOperation"/>.
    /// </remarks>
    public int Number2 { get; }

    /// <summary>
    /// Represents the type of mathematical operation (e.g., addition, subtraction, etc.)
    /// associated with the current <see cref="Question"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="Operation"/> property defines how the question is computed and
    /// determines the corresponding symbol when displayed.
    /// </remarks>
    public TypeOperation Operation { get; }

    /// <summary>
    /// Gets the correct result of the mathematical operation executed on the two operands
    /// specified by the <see cref="Number1"/>, <see cref="Number2"/>, and <see cref="Operation"/> properties.
    /// </summary>
    /// <remarks>
    /// The <see cref="CorrectAnswer"/> property is initialized during the creation of the <see cref="Question"/> object
    /// and is computed based on the <see cref="Operation"/> type (e.g., addition, subtraction, multiplication, or division).
    /// This property is read-only and cannot be directly modified.
    /// </remarks>
    public double CorrectAnswer { get; private set; }

    /// <summary>
    /// Represents a mathematical question, consisting of two numbers, an operation, and the correct answer.
    /// </summary>
    public Question(int number1, int number2, TypeOperation operation)
    {
        Number1 = number1;
        Number2 = number2;
        Operation = operation;
        CorrectAnswer = ComputeAnswer();
    }

    /// <summary>
    /// Computes the correct answer for the mathematical operation based on
    /// the operation type and the two numbers provided.
    /// </summary>
    /// <returns>
    /// The result of the operation using the specified numbers and operation type.
    /// </returns>
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

    /// <summary>
    /// Retrieves the mathematical symbol corresponding to the operation type of the question.
    /// </summary>
    /// <returns>The operation symbol as a string. "+", "-", "×", or "÷" for valid operations;
    /// returns an empty string if the operation type is not recognized.</returns>
    public string GetOperationSymbol()
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