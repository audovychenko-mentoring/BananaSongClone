﻿using BananaSongTest;
using BananaSongTest.BusinessObjects;
using BananaSongTest.main.Pages;
using BananaSongTest.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BananaSongClone.Steps
{
    [Binding]
    public sealed class SearchForYouTubeBannanaSongUsingGoogle
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public SearchForYouTubeBannanaSongUsingGoogle(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"User is on the Google search page")]
        public void GivenUserIsOnTheGoogleSearchPage()
        {
            Browser.Instance.GoToUrl("https://www.google.com/");
        }
        
        [When(@"User search for (.*)")]
        public void WhenUserSearchForBananaSong(string search)
        {
            var googleSearchPage = new GoogleSearchPage();
            googleSearchPage.SearchForKeyWords(search);
            googleSearchPage.ConfirmSelection();
        }
        
        [When(@"User selects YouTube link to navigate")]
        public void WhenUserSelectsYouTubeLinkToNavigate()
        {
            var googleSearchPage = new GoogleSearchPage();
            googleSearchPage.NavigateToYouTubeDespicableMeVideo();
        }
        
        [Then(@"User is on the page with (.*) title")]
        public void ThenUserIsOnThePageWithYouTubeTitle(string pageTitle)
        {
            Assert.IsTrue(Browser.Instance.Driver.Title.Contains(pageTitle));
        }
        
        [Then(@"Views quantity for the banana song video is more than (.*)")]
        public void ThenViewsQuantityForTheBananaSongVideoIsMoreThan(int expectedViews)
        {
            YouTubePage youTubePage = new YouTubePage();
            Assert.IsTrue(youTubePage.ValidateQuantityOfVideoViews(expectedViews));
        }

        [Given(@"User is signed in into Gmail with (.*) username and (.*) password")]
        public void GivenUserIsSignedInIntoGmail(string userName, string password)
        {
            var googleSearchPage = new GoogleSearchPage();
            Browser.Instance.GoToUrl(AppSettings.Url);
            var signInPage = new SignInPage();            
            signInPage.PopulateEmailAndClickEnter(userName);
            var gmailAboutPage = new GmailAboutPage();
            gmailAboutPage.ClickToSignIn();
            signInPage.PopulateEmailAndClickEnter(userName);
            signInPage.EnterPassword(password);
        }

        [Given(@"User is in the draft folder")]
        public void GivenUserIsInTheDraftFolder()
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.NavigateToDraft();
        }

        [Given(@"User creates new email to send to (.*) with (.*) title and (.*) text")]
        [When(@"User creates new email to send to (.*) with (.*) title and (.*) text")]
        public void WhenUserCreatesNewEmailWithNewTitle(string recipient, string title, string text)
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.ClickToComposeNewEmail();
            var newEmail = new EmailObject(recipient, title, text);
        }

        [Given(@"User saves a new email to drafts")]
        [When(@"User saves a new email to drafts")]
        public void WhenUserSavesANewEmailToDrafts()
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.ClickCloseButton();
        }

        [When(@"User send the draft email to (.*) with (.*) title and (.*) text")]
        public void WhenUserSendTheDraftEmailToNewReceipenEmailRecipientEmail(string recipient, string newTitle, string text)
        {
            var email = new EmailObject(recipient, newTitle, text);
            email.openEmailByTitle(newTitle);
            email.Send();
        }

        [Then(@"New email to (.*) with (.*) title and (.*) text is in draft folder")]
        public void ThenNewEmailWithNewTitleTitleIsInDraftFolder(string recipient, string newTitle, string text)
        {
            var email = new EmailObject(recipient, newTitle, text);
            Assert.AreEqual(email.searchEmailsByTitleAndReturnQuantity("in:draft " + newTitle), 1);
        }

        [Then(@"Email to (.*) with (.*) title and (.*) text is no longer in draft folder")]
        public void ThenEmailWithNewTitleTitleIsNoLongerInDraftFolder(string recipient, string newTitle, string text)
        {
            var email = new EmailObject(recipient, newTitle, text);
            Assert.AreEqual(email.searchEmailsByTitleAndReturnQuantity("in:draft " + newTitle), 0);
        }

        [Then(@"Email to (.*) with (.*) title and (.*) text is in sent folder")]
        public void ThenEmailWithNewTitleTitleIsInSentFolder(string recipient, string newTitle, string text)
        {
            var email = new EmailObject(recipient, newTitle, text);
            Assert.AreEqual(email.searchEmailsByTitleAndReturnQuantity("in:sent " + newTitle), 0);
        }       
    }
}
