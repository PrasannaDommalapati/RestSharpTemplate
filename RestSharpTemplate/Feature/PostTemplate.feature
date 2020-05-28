Feature: PostTemplate
	So that i can create a request with specific template
	As a Customer
	I want to make a request to the endpoint with different templates

Scenario: Posting outputs with a template id of HARPA001
	When I request outputs with 'Banana'
	Then I should receive status code 'OK'