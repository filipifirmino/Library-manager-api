namespace LibraryManager.ApplicationCore.Domain.Entities;

public class Author
{
    public string Name { get; set; }
    public string Biografi { get; set; }
    public DateTime Birth { get; set; }
    public Guid Id { get; set; }
}

//Todo: Adcionar foto ao registro do autor