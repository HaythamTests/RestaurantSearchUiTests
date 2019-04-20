Feature: Use the website to find restaurants
 		So that I can order food
 		As a hungry customer
 		I want to be able to find restaurants in my area

Scenario Outline: (Positive Scenario) Search for restaurant(s) in an area
 		Given I want food in area <postcode>
 		When I search for restaurant <restaurant>
		Then I should see the correct subheader details in the Search Results page
		And the restaurant name is included in the first and last search result titles
Examples:
| postcode | restaurant                       |
| AR51 1AA | Domino's                         |
| EC2Y 8BN | Papa John                        |
| WC2H 7LE | tinseltown great portland Street |

Scenario: (Negative Scenario) Invalid Postcode in Search page
 		Given I want food in area invalidSearchValue
		Then I should see the error message
| PostCodeErrorMessage                |
| Please enter a full, valid postcode |

Scenario: (Negative Scenario) Invalid restaurant search in an area
 		Given I want food in area AR51 1AA
 		When I search for restaurant invalidSearchValue
		Then I should see the correct subheader details in the Search Results page
		And I should see the following texts and links on the page
| Subheader           | EmptySearchResultMessage                                    | SearchButtonText     | SearchButtonLink                 | TipUsOffText | TipUsOffLink                                    |
| No open restaurants | We're coming up empty. Try casting your net a little wider. | Show All Restaurants | https://www.just-eat.co.uk/area/ | Tip us off   | https://www.just-eat.co.uk/suggest-a-restaurant |