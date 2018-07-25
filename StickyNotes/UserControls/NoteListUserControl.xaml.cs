﻿using StickyNotes.View;
using StickyNotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using StickyNotes.Models;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace StickyNotes.UserControls
{
    public sealed partial class NoteListUserControl : UserControl
    {
        // 为不同的菜单创建不同的List类型
        private ObservableCollection<NavMenuItem> navMenuPrimaryItem = new ObservableCollection<NavMenuItem>();


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var theNoteViewModel = (this.DataContext as NoteViewModel);
            theNoteViewModel.AddNoteCommand.Execute(null);
        }



        public NoteListUserControl()
        {
            this.InitializeComponent();
           
            // SplitView 开关
            PaneOpenButton.Click += (sender, args) =>
            {
                RootSplitView.IsPaneOpen = !RootSplitView.IsPaneOpen;
            };
            // 导航事件
            NavMenuPrimaryListView.ItemClick += NavMenuListView_ItemClick;
            // 默认页
            RootFrame.SourcePageType = typeof(BlankPage);
        }

        private void NavMenuListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var theNote = (e.ClickedItem as Note);
            if (theNote == null) return;
            var theNoteViewModel = (this.DataContext as NoteViewModel);

            theNoteViewModel.SetSelectNoteCommand.Execute(theNote);

        }

    }
}
