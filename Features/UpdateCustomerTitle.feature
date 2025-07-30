Feature: UpdateCustomerTitle

The purpose of this test is to update the customer's title from Mr to Mrs. Once saved, this data will be 
reverted back to Mr. 

@tag1
Scenario: Update users title from mr to mrs
	Given User lands on the home page 
	And User signs into their user account
	And User clicks Customer Name
	When User clicks Edit Details
	And User selects Mrs from the title drop down list
	When User selects save button
	Then The User title should be changed to Mrs
	When User reverts changes
	Then The User title should revert back to Mr
