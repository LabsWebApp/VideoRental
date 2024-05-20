namespace VideoRental
{
    public class Movie
    {
        protected Movie(string name, double rentalPrice, MovieType type)
        {
            Name = name;
            RentalPrice = rentalPrice;
            Type = type;
        }

        public double RentalPrice { get; init; }

        public string Name { get; init; }

        public MovieType Type { get; init; }

        public static Movie RegularMovie(string name) =>
            new(name, 2, MovieType.RegularMovie);
        public static Movie ChildrenMovie(string name) =>
            new(name, 1, MovieType.ChildrenMovie);
        public static Movie NewReleaseMovie(string name) =>
            new(name, 3, MovieType.NewReleaseMovie);
    }
}