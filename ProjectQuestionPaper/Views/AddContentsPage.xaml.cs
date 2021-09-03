using CommunityToolkit.Mvvm.DependencyInjection;
using System.Linq;
using Microsoft.UI.Xaml.Controls;
using ProjectQuestionPaper.Core.Models;
using ProjectQuestionPaper.ViewModels;

namespace ProjectQuestionPaper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContentsPage : Page
    {
        public AddContentsViewModel ViewModel { get; }

        public AddContentsPage()
        {
            ViewModel = Ioc.Default.GetService<AddContentsViewModel>();
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void GoBack_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void SubmitButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (!IsInputValid()) return;

            using var context = new Context();

            var semester = context.Semesters
                .Where(s => s.Sem == int.Parse(SemesterInput.Text.Trim()))
                .FirstOrDefault();
            if (semester == null)
            {
                semester = new();
                semester.Sem = int.Parse(SemesterInput.Text.Trim());
                _ = context.Semesters.Add(semester);
            }

            var subject = context.Subjects
                .Where(s => s.SubjectName == SubjectInput.Text.Trim().ToLower())
                .Where(s => s.Semester == semester)
                .FirstOrDefault();
            if (subject == null)
            {
                subject = new();
                subject.Semester = semester;
                subject.SubjectName = SubjectInput.Text.Trim().ToLower();
                _ = context.Subjects.Add(subject);
            }

            var year = context.Years
                .Where(y => y.Subject == subject)
                .Where(y => y.YearNumber == int.Parse(YearInput.Text.Trim()))
                .FirstOrDefault();
            if (year == null)
            {
                year = new();
                year.Subject = subject;
                year.YearNumber = int.Parse(YearInput.Text.Trim());
                _ = context.Years.Add(year);
            }

            var file = context.Files
                .Where(f => f.Year == year)
                //.Where(f => f.FileName == _filename)
                .FirstOrDefault();
            if (file == null)
            {
                file = new();
                file.Year = year;
                file.FileName = "TEST"; // to be replaced with _filename
                _ = context.Files.Add(file);
            }
            else
            {
                // file already exists ... write logic to see if the user wants to replace the existing file
            }

            _ = context.SaveChanges();
            


        }

        private bool IsInputValid()
        {
            var valid = true;

            if (string.IsNullOrWhiteSpace(SemesterInput.Text))
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(SubjectInput.Text))
            {
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(YearInput.Text))
            {
                valid = false;
            }

            return valid;
        }
    }
}
