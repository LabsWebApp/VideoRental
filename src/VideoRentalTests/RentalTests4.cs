using System.Text;
using Moq;

namespace VideoRentalTests;

[TestFixture]
public class RentalTests4
{
    private const string Path = "test.txt";

    private static Mock<TextWriter>? _mockTextWriter;
    private readonly Customer _customer = new("TestCustomer");

    [SetUp]
    public void Init()
    {
        _mockTextWriter = new();
        // ReSharper disable once RedundantSuppressNullableWarningExpression
        TextWriterFactory.SetTextWriter(_mockTextWriter!.Object);

        _customer.Rentals.Add(
            new Rental(Movie.RegularMovie("TestRegularMovie"), 2));
    }

    [TearDown]
    public void Cleanup()
    {
        TextWriterFactory.SetTextWriter(null); // Reset the TextWriterFactory to its default state
        _customer.Rentals.Clear();
    }

    [Test]
    public void GetSimpleReport_ValidCustomer_WritesReport()
    {
        // Act
        ReportManager.GetSimpleReport(Path, _customer);

        // Assert
        _mockTextWriter!.Verify(
            tw => tw.Write(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void GetSimpleReport_ValidCustomer_ReportContent()
    {
        // Arrange
        _customer.Rentals.Add(new Rental(Movie.NewReleaseMovie("TestNewReleaseMovie"), 1));

        var expectedContent = new StringBuilder()
            .AppendLine($"Отчёт по клиенту {_customer.Name}")
            .AppendLine($"\t{_customer.Rentals[0].Movie.Name}" +
                        $"({MovieType.RegularMovie}) - {_customer.Rentals[0].Days} days")
            .AppendLine($"\t{_customer.Rentals[1].Movie.Name}" +
                        $"({MovieType.NewReleaseMovie}) - {_customer.Rentals[1].Days} day")
            .AppendLine($"Сумма долга клиента: {_customer.CalculateDebit():C}")
            .AppendLine(new string('-', 20))
            .ToString();

        // Act
        ReportManager.GetSimpleReport(Path, _customer);

        // Assert
        _mockTextWriter!.Verify(
            tw => tw.Write(
                                        It.Is<string>(s => s == expectedContent)), Times.Once);
    }
}