using QuestionnaireBuilder.ValidationRules;

namespace QuestionnaireBuilder;

public abstract class Question
{
    protected List<IValidationRule> ValidationRules { get; } = new();
}
