Feature: AddPhoneNumbersToUserAccount

Adding & removing telephone numbers to user account

@tag1
Scenario: Add telephone number to user account
	Given User is on the landing page
	And User log into my user account
	And User selects My Account
	And user selects Phone Numbers link
	And User selects Edit Details
	When user keys in contact details within Landline Number field
	And user keys in contact details within Mobile Phone Number field
	And user clicks on Save button
	Then contact details should be saved
	When user selects Edit Details
	And user clears both contact number fields
	When user selects save button
	Then contacts should be removed from Phone Numbers field
