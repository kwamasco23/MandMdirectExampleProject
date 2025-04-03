Feature: AddAdidasSambaTrainersToWishList

Adding items to wishlist

@tag1
Scenario: As a user on M & M site, I want to search for Adidas Samba and add it to my wishlist. 
	Given User is on the landing page
	When User searches for Adidas Samba trainers
	And User adds the trainers to the wishlist
	Then The product should be added to the wishlist
	When Users removes the item from their wishlist
	Then The item should be removed from their wishlist




