using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Infra.Entity;

public class RentEntity
{
    [DataType(DataType.Date)]
    public DateTime RentalDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? ReturnDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BookId { get; set; }
    public Guid RentalId { get; set; }
    public long RentId { get; set; }
}