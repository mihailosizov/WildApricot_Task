Feature: ExportContacts
	In order to have contacts in external file
	As a Wild Apricot account admin user
	Admin user performs an export of contacts

	Background:
	Given Admin user is logged in to admin view
	And Admin user is in Contacts menu

Scenario: Export contacts to XLS file w/o filter with all fields, waiting until file is generated
	Given Contacts are not filtered
	And Admin user is in Export screen
	And XLS is a file format for Contacts export
	And All fields are selected for Contacts export
	When Admin user presses export Contacts and waits for file being generated
	Then Dialog with a link to an exported file is appeared
	And Exported file has XLS extension
	And Exported file has been downloaded automatically

Scenario: Export contacts to CSV file w/o filter with all fields, waiting until file is generated
	Given Contacts are not filtered
	And Admin user is in Export screen
	And CSV is a file format for Contacts export
	And All fields are selected for Contacts export
	When Admin user presses export Contacts and waits for file being generated
	Then Dialog with a link to an exported file is appeared
	And Exported file has CSV extension
	And Exported file has been downloaded automatically

Scenario: Export contacts to XML file w/o filter with all fields, waiting until file is generated
	Given Contacts are not filtered
	And Admin user is in Export screen
	And XML is a file format for Contacts export
	And All fields are selected for Contacts export
	When Admin user presses export Contacts and waits for file being generated
	Then Dialog with a link to an exported file is appeared
	And Exported file has XML extension
	And Exported file has been downloaded automatically