namespace VideoRentalTests;

[TestFixture]
public class RentalTests4
{
    [Test]
    public static void Test4_CustomerCalculateDebit()
    {
        // Arrange
        MockRepository mockCustomerRepository = new();
        var mockWriter = mockCustomerRepository.DynamicMock<TextWriter>();
        
        TextWriterFactory.SetTextWriter(mockWriter);

        using (mockCustomerRepository.Record())
        {
            mockWriter.Write("Nothing");
            LastCall.Constraints(
                new Rhino.Mocks.Constraints.Contains("TestCustomer") &
                new Rhino.Mocks.Constraints.Contains("TestMovie") &
                new Rhino.Mocks.Constraints.Contains("6 days") &
                new Rhino.Mocks.Constraints.Contains(12.ToString("C")) &
                new Rhino.Mocks.Constraints.Contains("TestCustomer") &
                new Rhino.Mocks.Constraints.Contains("(Regular)"));
            mockWriter.Flush();
        }

        // Act
        Customer customer = new(name: "TestCustomer");
        customer.Rentals.Add(new Rental(Movie.RegularMovie("TestMovie"), 6));

        ReportManager.GetSimpleReport("SomePath", customer);

        //Assert
        mockCustomerRepository.VerifyAll();
    }

}