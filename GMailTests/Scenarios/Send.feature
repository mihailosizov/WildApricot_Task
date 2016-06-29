Feature: Send
	In order to send and receive e-mail
	As a GMail user
	User sends e-mail to his own e-mail account

Scenario: Send and receive an e-mail
	Given User is on Inbox page
	When User sends an email to mikhailsizov.test@gmail.com
	Then User received 1 email successfully