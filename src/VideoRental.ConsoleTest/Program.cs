Customer customer = new(name: "Петя");
customer.Rentals.Add(new Rental(Movie.RegularMovie("Movie1"), 6));
customer.Rentals.Add(new Rental(Movie.NewReleaseMovie("Movie2"), 2));

WriteLine($"Клиент с именем {customer.Name} должен нам {customer.CalculateDebit()}.");
WriteLine(new string('*', 20));

//WriteLine(ReportManager.GetSimpleReport());
//WriteLine(new string('*', 20));
//WriteLine(ReportManager.GetHtmlReport());

// Delay
ReadKey();