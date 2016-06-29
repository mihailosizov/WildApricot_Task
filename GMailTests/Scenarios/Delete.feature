Feature: Delete
	In order to dispose of waste e-mail(s)
	As a GMail user
	User deletes e-mail(s)

Scenario: Delete e-mail with Test subject
	Given User is on Inbox page
	And An email was sent to mikhailsizov.test@gmail.com
	When User deletes an email that was sent
	Then An email that was sent has been deleted

Scenario: Delete several e-mails with Test subject
	Given User is on Inbox page
	And 2 emails was sent to mikhailsizov.test@gmail.com
	When User deletes all emails that was sent
	Then All emails that was sent has been deleted