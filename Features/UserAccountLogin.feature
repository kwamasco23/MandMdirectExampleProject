Feature: UserAccountLogin

A short summary of the feature

@tag1
Scenario: Logging in to user account successfully
	Given User lands on the landing page
	When User selects My Account
	And User types correct data into the username field
	And User types correct data into the password field
	And User selects Continue
	Then User should be directed to their account successfully
