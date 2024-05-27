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

    public int Days
    {
        get => _days;
        private set
        {
            if (value < 0)
                throw new RentalDaysException(value);

            _days = value;
        }
    }

    internal Movie Movie => _movie;

    public double CalculateDebit() => _movie.RentalPrice * _days;

    public void AddRentalDays(int d = 1) => Days += d;
    public void SubtractRentalDays(int d = 1) => Days -= d;
}