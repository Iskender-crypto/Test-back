namespace Test.Domain.Entities;

public class Subject : Entity
{
    public string Caption { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
}