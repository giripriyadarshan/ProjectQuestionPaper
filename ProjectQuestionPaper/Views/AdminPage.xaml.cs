﻿using CommunityToolkit.Mvvm.DependencyInjection;

using Microsoft.UI.Xaml.Controls;

using ProjectQuestionPaper.ViewModels;
using ProjectQuestionPaper.Core.Models;
using System.Linq;

namespace ProjectQuestionPaper.Views
{
    public sealed partial class AdminPage : Page
    {
        public AdminViewModel ViewModel { get; }

        public AdminPage()
        {
            ViewModel = Ioc.Default.GetService<AdminViewModel>();
            InitializeComponent();
        }
    }

}
