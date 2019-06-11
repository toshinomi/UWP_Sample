﻿using System;

using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace MediaPlayer
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StorageFile m_storageFile;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            mediaElement.Source = null;
            base.OnNavigatedFrom(e);
        }

        public async void OnClickFileSelect(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            picker.FileTypeFilter.Add("*");
            picker.FileTypeFilter.Add(".mp4");
            m_storageFile = await picker.PickSingleFileAsync();
            if (m_storageFile == null)
            {
                return;
            }

            mediaElement.SetSource(await m_storageFile.OpenReadAsync(), m_storageFile.ContentType);
        }
    }
}
