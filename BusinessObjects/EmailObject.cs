using BananaSongTest.Pages;
using System;

namespace BananaSongTest.BusinessObjects
{
    public class EmailObject
    {
        public DateTime creationTime;
        public string status;
        public string type;
        public string subject;

        public void CreateNewEmail(string to, string subject, string text, bool attachment = false, Attachment attachmentToAdd = null)
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.PopulateToField(to);
            gmailMainPage.PopulateSubjectField(subject);
            gmailMainPage.PopulateTextField(text);
            //attachment == true ? addAttachment(attachmentToAdd) : ;
            if (attachment == true)
            {
                addAttachment(attachmentToAdd);
            }
            this.subject = subject;
            this.creationTime = DateTime.Now;
        }

        public void SendAnEmail()
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.ClickSendEmailButton();
        }

        public int searchEmailsByTitleAndReturnQuantity(string title)
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.SearchForElement(title);
            return gmailMainPage.returnTheQuantityOfDraftEmails();
        }

        public void openEmailByTitle(string title)
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.SearchForElement(title);
            gmailMainPage.ClickOnFirstEmailFromTheList();
        }

        public void addAttachment(Attachment attachment)
        {
            var gmailMainPage = new GmailMainPage();
            gmailMainPage.ClickAddAttachmentButton();
            //to add file
        }
    }
}
