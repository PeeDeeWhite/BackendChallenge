namespace BackendChallenge;

public class Room()
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public bool IsStart { get; set; }
    public bool IsExit { get; set; }
    public string Question { get; set; } = null!;
    public List<Answer> Answers { get; set; } = [];
    public List<int> AvailableRooms { get; set; } = [];
    
    public void Display()
    {
        Console.WriteLine(Text);
        Console.WriteLine(Question);
        for (var index = 0; index < Answers.Count; index++)
        {
            var answer = Answers[index];
            Console.WriteLine($"{index+1} {answer.Text}");
        }
    }
    
    public Answer GetAnswer()
    {
        var keyInfo = Console.ReadKey(intercept: true);
        while (true)
        {
            if (int.TryParse(keyInfo.KeyChar.ToString(), out var answerId) && answerId > 0 && answerId <= Answers.Count)
            {
                return Answers[answerId-1];
            }
        }
    }
}