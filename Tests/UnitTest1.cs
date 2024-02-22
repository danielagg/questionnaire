
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var result = TextQuestion
            .Create("What's your name?")
            .WithAnswerMaxLengthRule(255);
        
        result.Question.Should().Be("What's your name?");
        
        var stringWithLength256 = new string('a', 256);

        var submittedAnswerResult = result.SubmitAnswer(stringWithLength256);
        submittedAnswerResult.FirstError.Should().BeEquivalentTo(Error.Validation());
    }
}