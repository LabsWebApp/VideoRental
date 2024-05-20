namespace VideoRental;

public class Rental(Movie movie, int days)
{
    public double CalculateDebt() => movie.RentalPrice * days;
}