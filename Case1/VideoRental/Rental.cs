

namespace VideoRental;

public class Rental(Movie movie, int days)
{
    private int Days
    {
        get => days;
        set
        {
            if (value == -1)
                throw new RentalDaysException(value);

            days = value;
        }
    }

    public double CalculateDebt() => movie.RentalPrice * days;

    public void AddRentalDays(int d = 1) => Days += d;
    public void SubtractRentalDays(int d = 1) => Days -= d;
}