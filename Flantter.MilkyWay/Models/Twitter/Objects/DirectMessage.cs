﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flantter.MilkyWay.Models.Twitter.Objects
{
    public class DirectMessage : ITweet
    {
        private static readonly Regex ContentRegex = new Regex(@"<(""[^""]*""|'[^']*'|[^'"">])*>", RegexOptions.Compiled);

        public DirectMessage(CoreTweet.DirectMessage cDirectMessage)
        {
            this.CreatedAt = cDirectMessage.CreatedAt.DateTime;
            this.Entities = new Entities(cDirectMessage.Entities, null);
            this.Id = cDirectMessage.Id;
            this.Text = cDirectMessage.Text;
            this.Recipient = new User(cDirectMessage.Recipient);
            this.Sender = new User(cDirectMessage.Sender);
        }

        public DirectMessage(Mastonet.Entities.Status cDirectMessage, Mastonet.Entities.Account cRecipient)
        {
            this.CreatedAt = cDirectMessage.CreatedAt;
            this.Entities = new Entities(cDirectMessage.MediaAttachments, cDirectMessage.Mentions, cDirectMessage.Tags, cDirectMessage.Content);
            this.Id = cDirectMessage.Id;
            this.Text = ContentRegex.Replace(cDirectMessage.Content, "");
            this.Recipient = new User(cRecipient);
            this.Sender = new User(cDirectMessage.Account);
        }

        #region CreatedAt変更通知プロパティ
        public DateTime CreatedAt { get; set; }
        #endregion

        #region Entities変更通知プロパティ
        public Entities Entities { get; set; }
        #endregion

        #region Id変更通知プロパティ
        public long Id { get; set; }
        #endregion

        #region Text変更通知プロパティ
        public string Text { get; set; }
        #endregion

        #region Recipient変更通知プロパティ
        public User Recipient { get; set; }
        #endregion

        #region Sender変更通知プロパティ
        public User Sender { get; set; }
        #endregion
    }
}
