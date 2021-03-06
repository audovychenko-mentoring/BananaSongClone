﻿Feature: SearchForYouTubeBannanaSongUsingGoogle

In order to validate views quantity for bannana song
As a basic User 
I want to search for bannana song using Google

@bannanasong

#Background: 
#	Given User navigate to the login page
#	When User submit username and password 223218Qwerty
#	Then User should be logged into Google Account: Test Mentoring (mentoringepam@gmail.com) account

Scenario: Search for YouTube song using Google
	Given User is on the Google search page
	When User search for <searchRequest>
	And User selects YouTube link to navigate
	Then User is on the page with <titleToValidate> title

Examples: 
    | searchRequest   | titleToValidate |
    | banana song     |  Despicable Me  |
    #| redroom         |  Redroom        |
    #| арменфильм      |  говорящая рыба |

Scenario: Validate the views quantity
	Given User is on the Google search page
	When User search for 'banana song'
	And User selects YouTube link to navigate
	Then Views quantity for the banana song video is more than 50000000

Scenario: Create a new email and save as a draft
    Given User is signed in into Gmail with mentoringepam@gmail.com username and 223218Qwerty password
	When User creates new email to send to test@gmail.com with mentoring title and test text
	And User saves a new email to drafts
    Then New email to test@gmail.com with newTitle title and 123 text is in draft folder

Scenario: Send an email from the draft folder
    Given User is signed in into Gmail with mentoringepam@gmail.com username and 223218Qwerty password
	And User creates new email to send to test@gmail.com with mentoring title and test text
	And User saves a new email to drafts
	And User is in the draft folder
	When User send the draft email to test@gmail.com with newTitle title and 123 text
	Then Email to test@gmail.com with newTitle title and 123 text is no longer in draft folder
	And Email to test@gmail.com with newTitle title and 123 text is in sent folder
