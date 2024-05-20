
namespace VideoRental;

public class Rental(Movie movie, int days)
{
    public void AddRentalDays(int d = 1) => days += d;

    public double CalculateDebt() => movie.RentalPrice * days;
}