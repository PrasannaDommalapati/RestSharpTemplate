Feature: Cancel the Booking in Events

Background:
	Given I have a valid authorization token

Scenario: Cancel provisional booking
	Given I have a booking with deposit requirement
	When I Cancel the Booking from event host
	Then I should see the booking is cancelled

#Scenario: Cancel Confirmed booking
#Scenario: Cancel past booking
#Scenario: Cancel enquiry