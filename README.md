
Testing the Postcode and Restaurant search functionalities.

Valid Postcode Search:
Using a valid postcode for a search, results in the display of a sub-header containing information of the number of open restaurants for the postcode. The search result populates with restaurants of three categories: Open restaurants – available for taking orders, Pre-order restaurants – soon to open, Not taking any orders. The sub-header only includes the number of open restaurants. Given there isn’t any open restaurant for the area specified, then the sub-header defaults to ‘No open restaurants...’.
The test journey stores the information below for assertions:
1)	Total number of restaurants in the sub-header for the searched postcode.
2)	The full sub-header for the searched postcode.

Invalid Postcode Search:
The test asserts on the error message displayed when searching using an invalid value.

Valid Restaurant Search:
Searching using a valid restaurant, updates the total open restaurants details in the sub-header, and re-generates the search results. 
The test asserts on:
1)	Validating the sub-header details before the restaurant search doesn’t equal the sub-header details after the restaurant search.
2)	Validating the sub-header contains the postcode string.
3)	Boundary testing to check the restaurant titles for the first and last restaurants in the search result contains the restaurant name provided in the search.
4)	If there are open restaurants available for the restaurant search, then the value of the total number of open restaurants in the search result is equal to the total value displayed in the sub-header.
If the restaurant search was valid but returned no open restaurants, then the test will assert on 1), 2), 3) and the sub-header contains the default message ‘No open restaurants...’. 

Invalid Restaurant Search:
The test asserts on various error messages and some links displayed on the search result area, which includes: 
1)	We’re coming up empty… .
2)	Show All Restaurants – text, link.
3)	Tip Us Off – text, link.