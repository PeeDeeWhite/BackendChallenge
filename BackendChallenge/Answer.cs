namespace BackendChallenge;

public class Answer    
{
    public string Text { get; set; } = null!;
    public string Outcome { get; set; } = null!;
    public int LivesCost { get; set; }
    public int NextRoomId { get; set; }
}