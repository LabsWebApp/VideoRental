using System.Text;

namespace VideoRental;

public static class ReportManager
{
    public static void GetSimpleReport(string path, Customer customer)
    {
        if (customer == null) throw new NullReferenceException(
            $"Param: {nameof(customer)} is null.");

        using var textWriter = TextWriterFactory.GetTextWriter(path);
        textWriter.Write(GetTxtSimpleReport(customer));
    }

    public static string GetTxtSimpleReport(Customer customer)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Отчёт по клиенту {customer.Name}");

        foreach (var rental in customer.Rentals)
        {
            sb.AppendLine(
                $"\t{rental.Movie.Name}({rental.Movie.Type})" +
                $" - {rental.Days} day{(rental.Days == 1 ? string.Empty : 's')}");
        }
        sb.AppendLine($"Сумма долга клиента: {customer.CalculateDebit():C}");
        sb.AppendLine(new string('-', 20));
        return sb.ToString();
    }
}