Feature: Use the website to find restaurants
 		So that I can order food
 		As a hungry customer
 		I want to be able to find restaurants in my area

Scenario Outline: (Positive Scenario) Search for restaurant(s) in an area
 		Given I want food in area AR51 1AA
 		When I search for restaurant <restaurant>
		Then I should see the correct details in the subheader
		And the restaurant name is included in the first and last search results
Examples:
| restaurant |
| Domino's   |
| Papa Johns |
| Kfc        |

Scenario: (Negative Scenario) Invalid Postcode in Search page
 		Given I want food in area invalid
		Then I should see the message Please enter a full, valid postcode

Scenario: (Negative Scenario) Invalid restaurant search in an area
 		Given I want food in area AR51 1AA
 		When I search for restaurant invalid
		Then I should see the correct details in the subheader
		And I should see the following messages on the page
| Subheader             | EmptySearchResultMessage                                      |
| "No open restaurants" | "We're coming up empty. Try casting your net a little wider." |