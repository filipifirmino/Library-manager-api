using LibraryManager.ApplicationCore.Domain.Enum;

namespace LibraryManager.ApplicationCore.Domain.Entities;

public class Rent
{
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BookId { get; set; }
    public long Id { get; set; }

    
    public bool CheckReturnTime()
    {
        var diferenceDate = RentalDate.Subtract(RentalDate);
        return diferenceDate.Days > (int)RentPeriod.simple;
    }
}

//Todo: Verificar normalização da tabela nas 3 formas.
//Todo: Ajustar logica de verificação de VIP.