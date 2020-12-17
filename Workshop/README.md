# Workshop : Unit Testing & TDD

Application used for the second part of the workshop's live coding.

## Mocking

"Mocking" is a simple app domain providing capabilities to filter products list by price and create some others.

The solution also contains the "Infrastructure" part to interrogate database through [Entity Framework Core](https://docs.microsoft.com/fr-fr/ef/core/).

It's up to you to test this application!

**Tips** : Use [xUnit](https://xunit.github.io/), [Moq](https://github.com/moq/moq4) and [AutoFixture](https://github.com/AutoFixture/AutoFixture) (and integration between them : AutoFixture.AutoMoq, AutoFixture.Xunit2)


**Hum...** In fact, "Mocking" is also a unit testing practice to isolate application layer during tests execution ;-)
