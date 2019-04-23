Feature: Use the website to find Postcode
 		So that I can search for a restaurant
 		As a hungry customer
 		I want to be able to find restaurants in my area

Scenario: Invalid Postcode in Search page
 		Given I want food in area invalidSearchValue
		Then I should see the error message
| PostCodeErrorMessage                |
| Please enter a full, valid postcode |