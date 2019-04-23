Feature: Use the website to find restaurants
 		So that I can order food
 		As a hungry customer
 		I want to be able to find restaurants in my area

Scenario Outline: Search for open restaurant(s) in an area
 		Given I want food in area <postcode>
 		When I search for restaurant <restaurant>
		And I wait for the restaurant results page
		Then I should see the correct subheader details in the search results page
		And the restaurant name is included in the first and last search result titles
		And the search result count is reflected in the subheader
Examples:
| postcode | restaurant                       |
| AR51 1AA | Domino's                         |
| EC2Y 8BN | Papa John                        |

Scenario Outline: Search for pre-ordering restaurant(s) in an area
 		Given I want food in area <postcode>
 		When I search for restaurant <restaurant>
		And I wait for the restaurant results page
		Then I should see the correct subheader details in the search results page
		And the restaurant name is included in the first and last search result titles
		And the search result count is reflected in the subheader
Examples:
| postcode | restaurant                       |
| WC2H 7LE | subway goodge                    |

Scenario: Invalid restaurant search in an area
 		Given I want food in area AR51 1AA
 		When I search for restaurant invalidSearchValue
		And I wait for the restaurant results page
		Then I should see the correct subheader details in the search results page
		And I should see the following texts and links on the page
| Subheader           | EmptySearchResultMessage                                    | SearchButtonText     | SearchButtonLink                 | TipUsOffText | TipUsOffLink                                    |
| No open restaurants | We're coming up empty. Try casting your net a little wider. | Show All Restaurants | https://www.just-eat.co.uk/area/ | Tip us off   | https://www.just-eat.co.uk/suggest-a-restaurant |