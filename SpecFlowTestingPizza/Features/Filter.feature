Feature: Filter

A short summary of the feature

@tag1
Scenario: Filtering and Searching Pizza
	Given The user is logged in on the home page
	When The user enters the pizza name "Non-Veg Pizza 14" and chooses category as "Non-Veg" 
	When The user clicks on "Search" button
	Then The pizza "Non-Veg Pizza 14" should be displayed 

