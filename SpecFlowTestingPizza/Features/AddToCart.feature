Feature: AddToCart

A short summary of the feature

@tag1
Scenario: Add to Cart Test
	Given The user is logged in on 
	When Add to cart "Non-Veg Pizza 16" and "Veg Pizza 10"
	When User navigates to my cart page
	Then Pizzas "Non-Veg Pizza 16" and "Veg Pizza 10" should be displayed in the cart
