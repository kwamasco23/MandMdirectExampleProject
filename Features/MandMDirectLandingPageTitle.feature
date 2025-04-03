Feature: M&MDirectLandingPageTitle

Asserting page title on landing page

@tag1
Scenario: Assert page title
	Given User navigates to M&M Direct landing page
	When User asserts the page title
	Then The correct page title should be displayed
