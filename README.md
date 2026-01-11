\# CManager



CManager är en konsolbaserad kundhanteringsapplikation byggd i C#. Applikationen är framtagen som en del av en inlämningsuppgift och syftar till att hantera kunder genom ett enkelt menysystem i konsolen.



I applikationen går det att skapa nya kunder där varje kund tilldelas ett unikt ID med hjälp av GUID. Det är även möjligt att visa alla kunder, visa information om en specifik kund samt ta bort en kund baserat på e-postadress. Kundinformationen sparas i en JSON-fil och läses in igen när applikationen startas.



Projektet är uppdelat i olika lager med Controllers, Services och Repositories för att separera ansvar i koden. Interfaces används för Service och Repository och Single Responsibility Principle har tillämpats.



Det finns även ett separat testprojekt som innehåller enhetstest för CustomerService. Tester är skrivna med xUnit och Repository mockas med hjälp av Moq.



Applikationen körs genom att starta projektet CManager.Presentation.ConsoleApp i Visual Studio och följa instruktionerna som visas i konsolen.



AI har använts som ett bollplank under utvecklingsprocessen för att diskutera idéer och felsökning, men all kod är skriven och strukturerad av mig.

