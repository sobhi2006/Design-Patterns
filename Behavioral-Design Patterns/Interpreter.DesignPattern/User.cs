public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Permissions { get; set; } = [];
}
