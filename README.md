# Strategy Pattern
	- Select implementation at runtime based on user input without having to extend class

	- Usecase
		- Application is responsible for calculating tax based on location the order is getting shipped to (For ex: Sweden, US etc.)
	
	- Existing code
		- Order class has a GetTax() method that calculates tax based on region
		- Code is tightly coupled. It is not extensible(In case if we want to start shipping products to another country, we would have to add another else condition) or testable
