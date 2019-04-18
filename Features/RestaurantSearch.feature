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
| Domino's    |
| Papa Johns  |
| KFC         |


Scenario Outline: (Negative Scenario) Unable to search for restaurant(s) in an area
 		Given I want food in area AR51 1AA
 		When I search for restaurant <restaurants>
 		Then I shouldn't see the <restaurants> and I see the error message No open restaurants
Examples:
| restaurants    |
| Nando's        |
| Persian Palace |


Scenario Outline: Unable to search in an area using invalid values
 		Given I want food in area AR51 1AA
 		When I search for restaurant <invalidValues>
 		Then I shouldn't see the <invalidValues> and I see the error message No open restaurants
Examples:
| invalidValues |
| £$$£$         |
| 09098         |


Scenario Outline: (Positive Scenario) Search for restaurant(s) through 'Change Location'
 		Given I want food in area AR51 1AA
 		When I search for restaurant <restaurants>
 		And I change the area to W3 7JL using the 'Change Location' button
		And I search for restaurant <restaurants>
		Then I should see some <restaurants> in W3 7JL
Examples:
| restaurants  |
|              |
| Awafi Foods  |
| Adams Lounge |
| Hot Bread    |


Scenario Outline: (Negative Scenario) Unable to search for restaurant(s) through 'Change Location'
 		Given I want food in area AR51 1AA
 		When I search for restaurant <restaurants>
 		And I change the area to W3 7JL using the 'Change Location' button
		And I search for restaurant <restaurants>
		Then I shouldn't see the <restaurants> and I see the error message No open restaurants
Examples:
| restaurants      |
| Papa Johns       |
| Frankie & Bennys |


Scenario Outline: Unable to search through 'Change Location' using invalid values
 		Given I want food in area AR51 1AA
 		When I search for restaurant <invalidValues>
 		And I change the area to W3 7JL using the 'Change Location' button
		And I search for restaurant <invalidValues>
		Then I shouldn't see the <invalidValues> and I see the error message No open restaurants
Examples:
| invalidValues |
| £$$£$         |
| 09098         |