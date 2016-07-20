Feature: Login
	In order to use his Wild Apricot account
	As an Wild Apricot account admin user
	Admin user performs a login to his account

Scenario: Login with correct credentials
	Given Test account admin login page
	When Admin user performs login with correct credentials
	Then Admin user is successfully logged in to admin view
