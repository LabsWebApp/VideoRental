

namespace VideoRental;

public class Rental(Movie movie, int days)
{
    public double CalculateDebt() => movie.RentalPrice * days;

    public void AddRentalDays(int d = 1) => days += d;
    public void SubtractRentalDays(int d = 1) => days -= d;
}