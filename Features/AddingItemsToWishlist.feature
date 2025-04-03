Feature: AddingItemsToWishlist

Testing the wishlist feature by adding items to it. 

@tag1
Scenario: Adding items to wishlist
	Given User is on the landing page
	And User searches for watches
	And User selects few watches from the search results
	Then Watches should be added to the wishlist. 
	When User removes items from the wishlist
	Then Wishlist should be removed
