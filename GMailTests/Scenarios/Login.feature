Feature: Login
	In order to use his e-mail
	As a GMail user
	User wants to login to his GMail box

Scenario: Login to GMail box
	Given GMail login page
	When User tries to log in using mikhailsizov.test and Qwerty489
	Then User successfully logged in