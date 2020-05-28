Feature: PostRequest
	
@http
Scenario: Post Request
	When I post the request
	Then I hould get the status code 'OK'
