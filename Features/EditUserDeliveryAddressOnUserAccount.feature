Feature: Delivery Address

Edit user delivery address on account

@tag1
Scenario: As a user I want to be able to log into my account and edit User delivery address
	Given User is on the landing page
	And User log into my user account
	And User select Delivery Addresses
	When User select Edit on an address entry
	And User manually fill out the address form after removing any existing data
	And User select Save
	Then User account should be updated with my new address entry
