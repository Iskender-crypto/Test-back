namespace Test.Domain.Entities;

public class Question : Entity
{
    public string Caption { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string>? Variants { get; set; }
    public long SubjectId { get; set; }
}