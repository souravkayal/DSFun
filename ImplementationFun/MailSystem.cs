using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.MailBox
{
    //Here is the class implementation of mail system client Gmail.
    //The model 

    public enum MailStatus
    {
        Delevered, Failure
    }

    public enum MailType
    {
        Spam, Normal, Promotional
    }

    public class Mail
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public MailStatus MailStatus { get; set; }
        public Mail ReplyOf { get; set; }
        public MailType MailCategory { get; set; }
    }

    public class MailClient
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Outbox { get; set; }
        public List<Mail> Trash { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }


    public class MailSystem
    {

    }
}
