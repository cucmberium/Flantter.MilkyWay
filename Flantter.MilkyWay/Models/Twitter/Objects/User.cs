﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flantter.MilkyWay.Models.Twitter.Objects
{
    public class User
    {
        public User(CoreTweet.User cUser)
        {
            this.CreateAt = cUser.CreatedAt.DateTime;
            this.Description = cUser.Description;
            this.Entities = new UserEntities(cUser.Entities);
            this.FavouritesCount = cUser.FavouritesCount;
            this.FollowersCount = cUser.FollowersCount;
            this.FriendsCount = cUser.FriendsCount;
            this.Id = cUser.Id.HasValue ? cUser.Id.Value : 0;
            this.IsFollowRequestSent = cUser.IsFollowRequestSent.HasValue ? cUser.IsFollowRequestSent.Value : false;
            this.IsMuting = cUser.IsMuting.HasValue ? cUser.IsMuting.Value : false;
            this.IsProtected = cUser.IsProtected;
            this.IsVerified = cUser.IsVerified;
            this.Language = cUser.Language;
            this.ListedCount = cUser.ListedCount.HasValue ? cUser.ListedCount.Value : 0;
            this.Location = cUser.Location;
            this.Name = cUser.Name;
            this.ProfileBackgroundColor = cUser.ProfileBackgroundColor;
            this.ProfileBackgroundImageUrl = cUser.ProfileBackgroundImageUrl;
            this.ProfileBannerUrl = cUser.ProfileBannerUrl;
            this.ProfileImageUrl = cUser.ProfileImageUrl;
            this.ScreenName = cUser.ScreenName;
            this.StatusesCount = cUser.StatusesCount;
            this.TimeZone = cUser.TimeZone;
            this.Url = cUser.Url;
        }

        public User(Mastonet.Entities.Account cUser)
        {
            this.CreateAt = cUser.CreatedAt;
            this.Description = cUser.Note;
            this.Entities = new UserEntities();
            this.FavouritesCount = 0;
            this.FollowersCount = cUser.FollowersCount;
            this.FriendsCount = cUser.FollowingCount;
            this.Id = cUser.Id;
            this.IsFollowRequestSent = false;
            this.IsMuting = false;
            this.IsProtected = cUser.Locked;
            this.IsVerified = false;
            this.Language = "en";
            this.ListedCount = 0;
            this.Location = "";
            this.Name = string.IsNullOrWhiteSpace(cUser.DisplayName) ? cUser.UserName: cUser.DisplayName;
            this.ProfileBackgroundColor = "C0DEED";
            this.ProfileBackgroundImageUrl = "http://localhost/";
            this.ProfileBannerUrl = cUser.HeaderUrl;
            this.ProfileImageUrl = cUser.AvatarUrl;
            this.ScreenName = cUser.AccountName;
            this.StatusesCount = cUser.StatusesCount;
            this.TimeZone = null;
            this.Url = cUser.ProfileUrl;
        }

        public User()
        {
        }

        #region CreateAt変更通知プロパティ
        public DateTime CreateAt { get; set; }
        #endregion

        #region Description変更通知プロパティ
        public string Description { get; set; }
        #endregion

        #region Entities変更通知プロパティ
        public UserEntities Entities { get; set; }
        #endregion

        #region FavouritesCount変更通知プロパティ
        public int FavouritesCount { get; set; }
        #endregion

        #region FollowersCount変更通知プロパティ
        public int FollowersCount { get; set; }
        #endregion

        #region FriendsCount変更通知プロパティ
        public int FriendsCount { get; set; }
        #endregion

        #region Id変更通知プロパティ
        public long Id { get; set; }
        #endregion

        #region IsFollowRequestSent変更通知プロパティ
        public bool IsFollowRequestSent { get; set; }
        #endregion

        #region IsMuting変更通知プロパティ
        public bool IsMuting { get; set; }
        #endregion

        #region IsProtected変更通知プロパティ
        public bool IsProtected { get; set; }
        #endregion

        #region IsVerified変更通知プロパティ
        public bool IsVerified { get; set; }
        #endregion

        #region Language変更通知プロパティ
        public string Language { get; set; }
        #endregion

        #region ListedCount変更通知プロパティ
        public int ListedCount { get; set; }
        #endregion

        #region Location変更通知プロパティ
        public string Location { get; set; }
        #endregion

        #region Name変更通知プロパティ
        public string Name { get; set; }
        #endregion

        #region ProfileBackgroundImageUrl変更通知プロパティ
        public string ProfileBackgroundImageUrl { get; set; }
        #endregion

        #region ProfileBannerUrl変更通知プロパティ
        public string ProfileBannerUrl { get; set; }
        #endregion

        #region ProfileImageUrl変更通知プロパティ
        public string ProfileImageUrl { get; set; }
        #endregion

        #region ProfileBackgroundColor変更通知プロパティ
        public string ProfileBackgroundColor { get; set; }
        #endregion

        #region ScreenName変更通知プロパティ
        public string ScreenName { get; set; }
        #endregion

        #region StatusesCount変更通知プロパティ
        public int StatusesCount { get; set; }
        #endregion

        #region TimeZone変更通知プロパティ
        public string TimeZone { get; set; }
        #endregion

        #region Url変更通知プロパティ
        public string Url { get; set; }
        #endregion
    }

    public class UserEntities
    {
        public UserEntities(CoreTweet.UserEntities cUserEntities)
        {
            if (cUserEntities == null)
                return;

            this.Description = new Entities(cUserEntities.Description);
            this.Url = new Entities(cUserEntities.Url);
        }

        public UserEntities()
        {
        }

        #region Description変更通知プロパティ
        public Entities Description { get; set; }
        #endregion

        #region Url変更通知プロパティ
        public Entities Url { get; set; }
        #endregion
    }
}
