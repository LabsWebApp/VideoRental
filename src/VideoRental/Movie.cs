namespace VideoRental
{
    public class Movie(string name, double rentalPrice)
    {
        public double RentalPrice => rentalPrice;
        public string Name => name;

        public static Movie RegularMovie(string name) => 
            new Movie(name, 2);
    }
}