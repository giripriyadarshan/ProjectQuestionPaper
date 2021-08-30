using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;

namespace ProjectQuestionPaper.ViewModels
{
    public class ContentsViewModel : ObservableRecipient
    {
        public ContentsViewModel()
        {

        }
    }


    public class ContentsItems
    {
        public ObservableCollection<MenuItem> TreeViewControl { get; set; }
        public ListBox ListBoxControl { get; set; }
    }

    public class MenuItem
    {
        public ObservableCollection<MenuItem> Items { get; set; }

        public MenuItem()
        {
            Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }
        public string YearID { get; set; }
    }

    public class ListOfFiles
    {
        public string PathOfFile { get; set; }
        public string YearID { get; set; }
    }
}
