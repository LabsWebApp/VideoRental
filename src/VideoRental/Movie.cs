namespace VideoRental
{
    public abstract class Movie(string name, double rentalPrice)
    {
        public double RentalPrice => rentalPrice;
        public string Name => name;
    }
}