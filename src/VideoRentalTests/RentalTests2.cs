namespace VideoRentalTests;

[TestFixture]
public class RentalTests2
{
    [Test]
    public static void Test2_RegularMovie()
    {
        // Rental rental = new(new RegularMovie("Film1"), 6);
        Rental rental = new(Movie.RegularMovie("Film1"), 6);

        Assert.That(rental.CalculateDebit(), Is.EqualTo(12));
    }

    [Test]
    public static void Test2_ChildrenMovie()
    {
        Rental rental = new(Movie.ChildrenMovie("Film2"), 6);

        Assert.That(rental.CalculateDebit(), Is.EqualTo(6));
    }

    [Test]
    public static void Test2_NewReleaseMovie()
    {
        Rental rental = new(Movie.NewReleaseMovie("Film3"), 6);

        Assert.That(rental.CalculateDebit(), Is.EqualTo(18));
    }
}