namespace LibraryManager.Infra.Entity;

public class AuthorEntity
{
    public string Name { get; set; }
    public string Biografi { get; set; }
    public DateTime Birth { get; set; }
    public Guid Id { get; set; }
}