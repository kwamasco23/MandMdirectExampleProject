Feature: Chatbox Help Box

Testing the Help Chat Box functionality. 

@tag1
Scenario: Interract with the help chatbox
	Given User lands on the home page 
	And User clicks on the help link to access the help page
	When User clicks on the help chat box 
	And user types in a text message 
	Then the chatbox should provide a response 
	And when user clicks on exit button
	Then help chatbox should close