Feature: OnlineStoreUITest
	As a Customer of an Eccomerce Store
	I should be able to purchase products, see purcnase history and update details
	To ensure the best customer experience so I return

@basket @web
Scenario: Order T-Shirt and Verify in Order History
	Given I Login as "Customer"
	When I add to my basket from the T-Shirts tab
	| Item Name                    | Quantity | Colour | Size |
	| Faded Short Sleeve T-shirts  | 1        |  Blue  | S    |
	And I complete checkout
	Then I should see in last order history

@settings @web
Scenario: Update First Name in My Account 
	Given I Login as "Customer"
	And my account firstname is "Tester"
	When I Update my account firstname to "Tester Update"
	Then my account firstname should be "Tester Update"