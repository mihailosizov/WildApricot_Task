Feature: Login
	In order to use his e-mail
	As a GMail user
	User performs a login to his e-mail

Scenario: Login with correct credentials
	Given User is logged out
	And GMail login page
	When User performs login with correct credentials
	Then User logged in successfully