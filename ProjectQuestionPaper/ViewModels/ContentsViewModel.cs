using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using ProjectQuestionPaper.Core.Models;

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

        public void GetTreeViewControl()
        {
            using var context = new Context();
            var semester = new ObservableCollection<MenuItem>();

            foreach (var sems in context.Semesters.OrderBy(s => s.Sem).ToList())
            {
                var sub = new MenuItem()
                {
                    Title = sems.Sem.ToString()
                };

                foreach(var subs in context.Subjects
                    .Where(s => s.Semester == sems)
                    .OrderBy(s => s.SubjectName)
                    .ToList())
                {
                    var year = new MenuItem()
                    {
                        Title = subs.SubjectName
                    };

                    foreach(var years in context.Years
                        .Where(y => y.Subject == subs)
                        .OrderBy(y => y.YearNumber)
                        .ToList())
                    {
                        year.Items.Add(new MenuItem()
                        {
                            Title = years.YearNumber.ToString(),
                            YearID = years.Id.ToString()
                        });
                    }
                    sub.Items.Add(year);
                }
                semester.Add(sub);
            }

            TreeViewControl = semester;
        }

        public void GetListBoxControl()
        {
            ListBoxControl = new();
            using var context = new Context();

            foreach (var files in context.Files.ToList())
            {
                ListBoxControl.Items.Add(new ListOfFiles()
                {
                    PathOfFile = files.FileName,
                    YearID = files.Year.Id.ToString()
                });
            }

        }
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
