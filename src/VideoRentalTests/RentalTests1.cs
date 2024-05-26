namespace VideoRentalTests;

[TestFixture]
public class RentalTests1
{
    private static readonly Movie Movie = Movie.RegularMovie("Movie Name");

    [Test]
    public static void Case1_RentalCalculateDebit()
    {
        //double rentalPrice = 2;
        int days = 6;

        //Movie movie = new Movie(rentalPrice: rentalPrice);

        Rental rental = new (Movie, days: days);

        Assert.That(rental.CalculateDebit(), Is.EqualTo(days * Movie.RentalPrice));
    }

    [Test]
    public static void Case1_RentalAddRentalDays()
    {
        Rental rental = new(Movie, days: 6);

        rental.AddRentalDays();
        Assert.That(rental.CalculateDebit(), Is.EqualTo(2 * 7));

        rental.AddRentalDays(2);
        Assert.That(rental.CalculateDebit(), Is.EqualTo(2 * 9));
    }

    [Test]
    public static void Case1_RentalSubtractRentalDays()
    {
        Rental rental = new(Movie, days: 6);

        rental.SubtractRentalDays();
        Assert.That(rental.CalculateDebit(), Is.EqualTo(2 * 5));

        rental.SubtractRentalDays(2);
        Assert.That(rental.CalculateDebit(), Is.EqualTo(2 * 3));
    }

    [Test]
    public static void Case1_ExpectedRentalDaysException1()
    {
        try
        {
            Rental rental = new(Movie, days: 6);

            rental.SubtractRentalDays(7);

            Assert.Fail();
        }
        catch (RentalDaysException e)
        {
            Assert.That(e.Days, Is.EqualTo(-1));
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }

    [Test]
    public static void Case1_ExpectedRentalDaysException2()
    {
        try
        {
            Rental rental = new(Movie, days: -6);

            Assert.Fail();
        }
        catch (RentalDaysException e)
        {
            Assert.That(e.Days, Is.EqualTo(-6));
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }
}