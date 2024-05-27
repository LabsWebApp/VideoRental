using System.Text;
using Moq;

namespace VideoRentalTests;

[TestFixture]
public class RentalTests4
{
    [Test]
    public void GetSimpleReport_ValidCustomer_WritesReport()
    {
        // Arrange
        var path = "test.txt";
        var mockTextWriter = new Mock<TextWriter>();
        TextWriterFactory.SetTextWriter(mockTextWriter.Object);

        var customer = new Customer("TestCustomer");
        customer.Rentals.Add(
            new Rental(Movie.RegularMovie("TestRegularMovie"), 2));

        // Act
        ReportManager.GetSimpleReport(path, customer);

        // Assert
        mockTextWriter.Verify(
            tw => tw.Write(It.IsAny<StringBuilder>()), Times.Once);
    }

    [Test]
    public void GetSimpleReport_ValidCustomer_ReportContent()
    {
        // Arrange
        const string path = "test.txt";

        var customer = new Customer("TestCustomer2");
        customer.Rentals.Add(
            new Rental(Movie.RegularMovie("TestRegularMovie"), 2));
        customer.Rentals.Add(
            new Rental(Movie.NewReleaseMovie("TestRegularMovie"), 1));

        var expectedContent = new StringBuilder()
            .AppendLine($"Отчёт по клиенту {customer.Name}")
            .AppendLine($"\t{customer.Rentals[0].Movie.Name}" +
                        $"({MovieType.RegularMovie})" +
                        $" - {customer.Rentals[0].Days} days")
            .AppendLine($"\t{customer.Rentals[1].Movie.Name}" +
                        $"({MovieType.NewReleaseMovie})" +
                        $" - {customer.Rentals[1].Days} day")
            .AppendLine($"Сумма долга клиента: {customer.CalculateDebit()}")
            .AppendLine(new string('-', 20));

        // Act + Assert
        Assert.That(ReportManager.GetSimpleReport(path, customer), 
            Is.EqualTo(expectedContent.ToString()));
    }
}