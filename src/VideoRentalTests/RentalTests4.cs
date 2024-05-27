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
}