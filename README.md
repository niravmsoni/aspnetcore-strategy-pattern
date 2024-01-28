# Strategy Pattern
	- Select implementation at runtime based on user input without having to extend class

	- Usecase
		- Application is responsible for calculating tax based on location the order is getting shipped to (For ex: Sweden, US etc.)
	
	- Existing code
		- Order class has a GetTax() method that calculates tax based on region
		- Code is tightly coupled. It is not extensible(In case if we want to start shipping products to another country, we would have to add another else condition) or testable

	- Refactoring
		- Create a separate ISalesTaxStrategy interface that has a GetTaxFor() method
		- Created 2 separate concrete implementation:
			SwedenSalesTaxStrategy
			USASalesTaxStrategy
		- From order class, exposed a setter for the ISalesTaxStrategy interface
		- From Program, when we create Order, introduced an If..else statement and set SwedenSalesTaxStrategy or USASalesTaxStrategy based on whatever user selected in the destination
