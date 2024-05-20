namespace VideoRental;

public class Rental
{
    private readonly Movie _movie;
    private int _days;

    public Rental(Movie movie, int days)
    {
        _movie = movie;
        Days = days;
    }

    private int Days
    {
        get => _days;
        set
        {
            if (value < 0)
                throw new RentalDaysException(value);

            _days = value;
        }
    }

    public double CalculateDebt() => _movie.RentalPrice * _days;

    public void AddRentalDays(int d = 1) => Days += d;
    public void SubtractRentalDays(int d = 1) => Days -= d;
}