Feature: Wishlist Page Functionality 

A short Summary of the feature

A test will be performed mimicking a user with an account. The user will search for items on the
website and add item(s) to their wishlist. There will be a tear down to remove from wishlist at the end of each 
test run

@tag1
Scenario: Add items to customer wishlist page
Given user lands on the landing page
And user searches for an item on the website
And user clicks on the item
And user clicks on Add to Wishlist
When user is presented with login screen
And user enters the correct username
And user enters the correct password
Then the item should be added to user wishlist
And item can also be removed from wishlist