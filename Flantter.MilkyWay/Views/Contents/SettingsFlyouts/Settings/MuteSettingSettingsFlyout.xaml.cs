﻿using Flantter.MilkyWay.ViewModels.SettingsFlyouts;
using Flantter.MilkyWay.ViewModels.SettingsFlyouts.Settings;
using Flantter.MilkyWay.Views.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Flantter.MilkyWay.Views.Contents.SettingsFlyouts.Settings
{
    public sealed partial class MuteSettingSettingsFlyout : ExtendedSettingsFlyout
    {
        public MuteSettingSettingsFlyout()
        {
            this.InitializeComponent();
        }

        public MuteSettingSettingsFlyoutViewModel ViewModel
        {
            get { return (MuteSettingSettingsFlyoutViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(MuteSettingSettingsFlyoutViewModel), typeof(MuteSettingSettingsFlyout), null);

    }
}
