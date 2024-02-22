namespace QuestionnaireBuilder.ValidationRules;

public interface IValidationRule
{
    public string Name { get; }

    ErrorOr<Success> Validate<T>(T proposedAnswer);
}