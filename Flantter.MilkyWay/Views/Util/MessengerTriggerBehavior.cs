﻿using Microsoft.Xaml.Interactivity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Flantter.MilkyWay.Views.Util
{
    /// <summary>
    /// VMのMessengerからの通知を受け取るトリガー
    /// </summary>
    [ContentProperty(Name = "Actions")]
    public class MessengerTriggerBehavior : DependencyObject, IBehavior
    {
        
        public DependencyObject AssociatedObject { get; private set; }

        /// <summary>
        /// メッセンジャー
        /// </summary>
        public Messenger Messenger
        {
            get { return (Messenger)GetValue(MessengerProperty); }
            set { SetValue(MessengerProperty, value); }
        }

        public static readonly DependencyProperty MessengerProperty =
            DependencyProperty.Register(
                "Messenger", 
                typeof(Messenger), 
                typeof(MessengerTriggerBehavior), 
                new PropertyMetadata(null, MessengerChanged));

        private static void MessengerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Messengerプロパティに変更があったらイベントを購読する
            var self = (MessengerTriggerBehavior)d;
            if (e.OldValue != null)
            {
                var m = (Messenger)e.OldValue;
                m.Raised -= self.MessengerRaised;
            }

            if (e.NewValue != null)
            {
                var m = (Messenger)e.NewValue;
                m.Raised += self.MessengerRaised;
            }
        }

        /// <summary>
        /// 子のアクション
        /// </summary>
        public ActionCollection Actions
        {
            get 
            { 
                var result = (ActionCollection)GetValue(ActionsProperty); 
                if (result == null)
                {
                    this.Actions = result = new ActionCollection();
                }
                return result;
            }
            set { SetValue(ActionsProperty, value); }
        }

        public static readonly DependencyProperty ActionsProperty =
            DependencyProperty.Register("Actions", typeof(ActionCollection), typeof(MessengerTriggerBehavior), new PropertyMetadata(null));

        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = associatedObject;
        }

        public void Detach()
        {
            if (this.Messenger != null)
            {
                this.Messenger.Raised -= this.MessengerRaised;
            }
        }


        private async void MessengerRaised(object sender, MessengerEventArgs e)
        {
            // アクションを実行する。戻り値がTaskのものがあったら待ち合わせる
            await Task.WhenAll(Interaction.ExecuteActions(this, this.Actions, e.Notification).OfType<Task>());
            // コールバック
            e.Callback();
        }

    }

    /// <summary>
    /// メッセンジャー
    /// </summary>
    public class Messenger
    {
        /// <summary>
        /// Vへ通知するためのイベント
        /// </summary>
        public event EventHandler<MessengerEventArgs> Raised;

        /// <summary>
        /// NotificationをVに通知して結果のNotificationを返す
        /// </summary>
        public Task<T> Raise<T>(T n)
            where T : Notification
        {
            var source = new TaskCompletionSource<T>();
            var h = this.Raised;
            if (h != null)
            {
                h(this, new MessengerEventArgs
                {
                    Notification = n,
                    Callback = () => source.SetResult(n)
                });
            }
            return source.Task;
        }
    }

    /// <summary>
    /// Raisedイベントの引数
    /// </summary>
    public class MessengerEventArgs : EventArgs
    {
        /// <summary>
        /// 通知用のNotification
        /// </summary>
        public Notification Notification { get; set; }

        /// <summary>
        /// Actionの実行が終わった時に呼び出されるコールバック
        /// </summary>
        public Action Callback { get; set; }
    }

    /// <summary>
    /// 通知用データの基本クラス
    /// </summary>
    public class Notification
    {
        public string Title { get; set; }
        public object Content { get; set; }
    }
}