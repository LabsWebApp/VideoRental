namespace VideoRental
{
    public class Customer(string name)
    {
        public string Name { get; init; } = name;
        public readonly IList<Rental> Rentals = [];

        public double CalculateDebit() =>
            Rentals.Sum(rental => rental.CalculateDebit());
    }
}