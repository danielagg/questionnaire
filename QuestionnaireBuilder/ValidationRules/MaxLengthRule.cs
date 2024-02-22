using QuestionnaireBuilder.QuestionTypes;

namespace QuestionnaireBuilder.ValidationRules;

public class MaxLengthRule : IValidationRule
{
    public string Name => "Maximum length rule";
    public int MaxLength { get; }
    
    private TextQuestion Question { get; } // todo
    
    public ErrorOr<Success> Validate<T>(T proposedAnswer)
    {
        var todo = proposedAnswer?.ToString();
        
        if (string.IsNullOrEmpty(todo))
            return Error.Validation();
        
        return todo.Length <= MaxLength
            ? Result.Success
            : Error.Validation();
    }

    public MaxLengthRule(int maxLength, TextQuestion question) // todo
    {
        MaxLength = maxLength;
        Question = question;
    }
}