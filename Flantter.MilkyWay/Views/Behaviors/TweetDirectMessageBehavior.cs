﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Flantter.MilkyWay.Views.Behaviors
{
    public class TweetDirectMessageBehavior
    {
        public static bool GetIsSelected(DependencyObject obj) { return (bool)obj.GetValue(IsSelectedProperty); }
        public static void SetIsSelected(DependencyObject obj, bool value) { obj.SetValue(IsSelectedProperty, value); }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(TweetDirectMessageBehavior), new PropertyMetadata(false, IsSelectedPropertyChanged));

        private static void IsSelectedPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            CommandGrid_PropertyChanged(obj, e);
        }

        #region Media 関連
        public static bool GetMediaVisibility(DependencyObject obj) { return (bool)obj.GetValue(MediaVisibilityProperty); }
        public static void SetMediaVisibility(DependencyObject obj, bool value) { obj.SetValue(MediaVisibilityProperty, value); }

        public static readonly DependencyProperty MediaVisibilityProperty =
            DependencyProperty.Register("MediaVisibility", typeof(bool), typeof(TweetStatusBehavior), new PropertyMetadata(false, MediaVisibility_PropertyChanged));

        private static void MediaVisibility_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var status = obj as Grid;
            var itemsControl = status.FindName("MediaItemsControl") as ItemsControl;

            if (GetMediaVisibility(obj))
                itemsControl.Visibility = Visibility.Visible;
            else
                itemsControl.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region CommandGrid 関連
        private static void CommandGrid_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var status = obj as Grid;
            var grid = status.FindName("CommandGrid") as Grid;

            if (grid == null)
                return;

            if ((bool)e.NewValue)
                (grid.Resources["TweetCommandBarOpenAnimation"] as Storyboard).Begin();
            else
                (grid.Resources["TweetCommandBarCloseAnimation"] as Storyboard).Begin();
        }
        #endregion
    }
}
