Feature: Registration

A short summary of the feature

@tag1
Scenario: Registration Test
	Given The user is on the registation page
	When The user enter email "abcde@xyz.com" password "Abc@123" and confirm passowrd as "Abc@123"
	When User clicks the "Register" button
	Then The user lands on registration confirmed page with email "abcde@xyz.com"
