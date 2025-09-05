namespace LibraryManager.ApplicationCore.Domain.Entities;

public class Customer
{
    public string Name { get; set; }
    public Guid Id { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public decimal Score { get; set; }
}

// Todo: representar score com estrelas no front