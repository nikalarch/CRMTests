Feature: CRMBDD

A short summary of the feature

@CreateContactTest
Scenario: Create a contact
	Given User is logged in to the application
	When User clicks on the create contact button
	When User fills in all necessary fields
    When User clicks on create contact button
    Then User sees that filled-in data is displayed on the page
