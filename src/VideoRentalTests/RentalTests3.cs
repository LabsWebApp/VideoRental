namespace VideoRentalTests;

[TestFixture]
public class RentalTests3
{
    [Test]
    public static void Test2_CustomerCalculateDebit()
    {
        Customer customer = new(name: "Петя");
        customer.Rentals.Add(new Rental(Movie.RegularMovie("Movie1"), 6));
        customer.Rentals.Add(new Rental(Movie.NewReleaseMovie("Movie2"), 2));

        Assert.That(customer.CalculateDebit(), Is.EqualTo(12 + 6));
    }

}