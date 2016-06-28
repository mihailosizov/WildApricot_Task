Feature: GMail account basic actions
	In order to use his e-mail mikhailsizov.test@gmail.com
	As a GMail user mikhailsizov.test
	User wants to perform some basic actions with his e-mail account

Scenario: Login to GMail box
	Given GMail login page
	When User tries to log in using standard password
	Then User successfully logged in

Scenario: Send and receive an e-mail
	Given User is on inbox page
	When User send an email to mikhailsizov.test@gmail.com
	Then User successfully receives email

Scenario: Delete e-mail from inbox
	Given User is on inbox page
	And Email with Test subject was sent to mikhailsizov.test@gmail.com
	When User deletes an email with Test subject
	Then Email with Test subject is deleted

Scenario: Delete several e-mail from inbox
	Given User is on inbox page
	And 2 emails with Test subject was sent to mikhailsizov.test@gmail.com
	When User deletes all emails with Test subject
	Then All emails with Test subject are deleted
