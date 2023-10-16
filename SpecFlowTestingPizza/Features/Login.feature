Feature: Login

A short summary of the feature

@Login
Scenario: Login Test
	Given The user is on the login page
	When The user enters the email "pt@xyz.com" and password "Abc@123"
	When User clicks "Log in" button
	Then The user should be directed to home pages
