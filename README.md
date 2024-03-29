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

		- Later, introduced detailed tax calculation for Sweden based on item (Food, Literature, HW etc.)
		- We had to only modify SwedenSalesTaxStrategy and the change was easy.
			- We were sure the change we are doing only impacts Sweden and not any other country
			- Write better tests
			- Cleaner code that follows SRP
			- Refer this commit - https://github.com/niravmsoni/aspnetcore-strategy-pattern/commit/7b22a5e41b3ea08476d0b70fad0c46cc41eed4ac

		- Alternative implementation achieve strategy
			- Instead of setting value for ISalesTaxStrategy in Order, we could pass ISalesStrategy as a parameter to GetTax method
			- Whenever a method takes an interface to allow outcome of computation, we are leveraging strategy pattern
			- Refer commit - https://github.com/niravmsoni/aspnetcore-strategy-pattern/commit/728e62e98a4585cb40500edbba3bbcc2a99910d3


	- Another example of strategy
		- Requirement - Invoice generation
			-  Allow app to send invoice
				- Email
				- Print on demand svc
				- Store them as file on disc

		- Here we can leverage strategy pattern from start for new features to make it easy to extend application in future
		- Changes
			- Add new interface IInvoiceStrategy under Strategies/Invoice
			- There are going to be 3 interfaces implementing this strategy
				- EmailInvoiceStrategy
				- FileInvoiceStrategy
				- PrintOnDemandInvoiceStrategy

			- 2 of these implementations(Email and File) are going to share the content that is required to be present in invoice
			- So, we create a abstract base class namely InvoiceStrategy and have it implement IInvoiceStrategy
			- We leave Generate method as abstract here since we want classes inheriting from InvoiceStrategy to implement them
			- Add implementation in all strategies
			- Expose IInvoiceStrategy as a property to Order class
			- Set strategy from Program

	- Another example of strategy
		- Requirement - Support different shipping providers
			- Created new IShippingStrategy interface
			- Implemented few different strategies. Find them under Strategies/Shipping
			- Exposed setter of IShippingStrategy from Order
			- Set value from Program

	- Whenever we can inject interface to allow change of behavior we are leveraging strategy pattern