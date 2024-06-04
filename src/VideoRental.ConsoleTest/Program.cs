﻿Customer customer = new(name: "Петя");
customer.Rentals.Add(new Rental(Movie.RegularMovie("Movie1"), 6));
customer.Rentals.Add(new Rental(Movie.NewReleaseMovie("Movie2"), 2));

//WriteLine($"Клиент с именем {customer.Name} должен нам {customer.CalculateDebit():C}.");
//WriteLine(new string('*', 20));

WriteLine(ReportManager.GetTxtSimpleReport(customer));
ReportManager.GetSimpleReport("test.txt", customer);

// Delay
ReadKey();