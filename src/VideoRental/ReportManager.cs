using System.Text;

namespace VideoRental;

public static class ReportManager
{
    public static string GetSimpleReport(string path, Customer customer)
    {
        if (customer == null) throw new NullReferenceException(
            $"Param: {nameof(customer)} is null.");

        var sb = new StringBuilder();
        sb.AppendLine($"Отчёт по клиенту {customer.Name}");
        foreach (var rental in customer.Rentals)
            sb.AppendLine(
                $"\t{rental.Movie.Name}({rental.Movie.Type})" +
                $" - {rental.Days} day{(rental.Days == 1 ? string.Empty : 's')}");
        sb.AppendLine($"Сумма долга клиента: {customer.CalculateDebit()}")
            .AppendLine(new string('-', 20));

        using (var textWriter = TextWriterFactory.GetTextWriter(path))
            textWriter.Write(sb);

        return sb.ToString();
    }
}