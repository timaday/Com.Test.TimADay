Feature: BookingAPITest
	As a User for the booking API
	I should be able to create a booking, update my booking and delete my booking
	To ensure the best user experience so I return

@booking @api
Scenario: Add Booking
	Given I can interact with the booking api
	When I create the following booking
	| firstname | lastname | totalprice | depositpaid | checkin    | checkout     | additionalneeds |
	| Tester    | Day      | 111        | true        | 2022-01-01 |  2022-01-01  | n/a             |
	Then I see my booking in response
	| firstname | lastname | totalprice | depositpaid | checkin    | checkout     | additionalneeds |
	| Tester    | Day      | 111        | true        | 2022-01-01 |  2022-01-01  | n/a             |

@booking @api
Scenario: Update Booking
	Given I can interact with the booking api
	When I create the following booking
	| firstname | lastname | totalprice | depositpaid | checkin    | checkout     | additionalneeds |
	| Tester    | Day      | 111        | true        | 2022-01-01 |  2022-01-01  | n/a             |
	When I update the booking with
	| firstname              |
	| Tester Update          |
	Then I see my booking in response
	| firstname       |
	| Tester Update   |

@booking @api
Scenario: Delete Booking
	Given I can interact with the booking api
	When I create the following booking
	| firstname | lastname | totalprice | depositpaid | checkin    | checkout     | additionalneeds |
	| Tester    | Day      | 111        | true        | 2022-01-01 |  2022-01-01  | n/a             |
	When I delete the booking
	Then my booking is not present