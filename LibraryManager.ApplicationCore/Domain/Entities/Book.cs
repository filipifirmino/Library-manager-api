using LibraryManager.ApplicationCore.Domain.Enum;

namespace LibraryManager.ApplicationCore.Domain.Entities;

public class Book
{
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public Category Category { get; set; }
    public Status Status { get; set; }
    public Guid AuthorId { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ISBN { get; set; }
}