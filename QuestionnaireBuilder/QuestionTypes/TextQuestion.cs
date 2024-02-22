using QuestionnaireBuilder.ValidationRules;

namespace QuestionnaireBuilder.QuestionTypes;

public class TextQuestion : Question
{
    public Guid Id { get; }
    public string Question { get; private set; }
    public string Answer { get; private set; }

    private TextQuestion(string question)
    {
        Id = Guid.NewGuid();
        Question = question;
    }

    public static TextQuestion Create(string question) => new(question);

    public TextQuestion WithAnswerMaxLengthRule(int maxLength)
    {
        ValidationRules.Add(new MaxLengthRule(maxLength, this));
        return this;
    }

    public ErrorOr<Success> SubmitAnswer(string answer)
    {
        var isValid = !ValidationRules
            .Select(r => r.Validate(answer))
            .Where(result => result.IsError)
            .SelectMany(result => result.Errors)
            .Any();
            
        if(!isValid)
            return Error.Validation();

        Answer = answer;
            
        return Result.Success;
    }
}