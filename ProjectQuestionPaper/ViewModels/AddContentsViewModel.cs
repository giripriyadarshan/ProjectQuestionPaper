using CommunityToolkit.Mvvm.ComponentModel;
using Windows.Storage;
using System.Linq;
using ProjectQuestionPaper.Core.Models;
using ProjectQuestionPaper.Contracts.Services;
using Windows.Storage.Pickers;
using System;
using System.Threading.Tasks;
using static ProjectQuestionPaper.Models.FilesStorage;

namespace ProjectQuestionPaper.ViewModels
{
    public class AddContentsViewModel : ObservableObject
    {
        private INavigationService NavigationService { get; }

        public AddContentsViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public string PopupTitle { get; set; }
        public string PopupMessage { get; set; }
        public bool PopupItem { get; set; }
        public bool PopupButton { get; set; }
        private bool _popupResponse;

        private int _semesterInput;
        public int SemesterInput
        {
            get => _semesterInput;
            set => SetProperty(ref _semesterInput, value);
        }

        private string _subjectInput;
        public string SubjectInput
        {
            get => _subjectInput;
            set => SetProperty(ref _subjectInput, value);
        }

        private int _yearInput;
        public int YearInput
        {
            get => _yearInput;
            set => SetProperty(ref _yearInput, value);
        }

        private StorageFile fileInput;

        public async void UploadFile()
        {
            var openPicker = new FileOpenPicker();
            fileInput = await openPicker.PickSingleFileAsync();
        }
        
        private bool IsInputValid()
        {
            var valid = true;

            // add all error messages to one string and push it to one dialog box
            // or change the dialog to teaching tip ..... should work fine
            if (SemesterInput < 1)
            {
                valid = false;
                OpenPopUpMessage("Missing Semester", "Please input semester (ex: 1, 2, 3", false);
            }
            if (string.IsNullOrWhiteSpace(SubjectInput))
            {
                valid = false;
                OpenPopUpMessage("Missing Subject", "Please input subject (ex: Maths)", false);
            }
            if (YearInput < 1)
            {
                valid = false;
                OpenPopUpMessage("Missing Year", "Please input year (ex: 2021, 2022", false);
            }

            if (fileInput == null)
            {
                valid = false;
                OpenPopUpMessage("Missing file", "Please upload the paper", false);
            }

            return valid;
        }

        public void SubmitButton()
        {
            if (!IsInputValid())
            {
                return;
            }

            using var context = new Context();

            var semester = context.Semesters
                .FirstOrDefault(s => s.Sem == SemesterInput);
            if (semester == null)
            {
                semester = new()
                {
                    Sem = SemesterInput
                };
                _ = context.Semesters.Add(semester);
            }

            var subject = context.Subjects
                .Where(s => s.SubjectName == SubjectInput.Trim().ToLower())
                .FirstOrDefault(s => s.Semester == semester);
            if (subject == null)
            {
                subject = new()
                {
                    Semester = semester,
                    SubjectName = SubjectInput.Trim().ToLower()
                };
                _ = context.Subjects.Add(subject);
            }

            var year = context.Years
                .Where(y => y.YearNumber == YearInput)
                .FirstOrDefault(y => y.Subject == subject);
            if (year == null)
            {
                year = new()
                {
                    Subject = subject,
                    YearNumber = YearInput
                };
                _ = context.Years.Add(year);
            }

            var file = context.Files
                .Where(f => f.FileName == fileInput.DisplayName)
                .FirstOrDefault(f => f.Year == year);
            if (file == null)
            {
                file = new()
                {
                    Year = year,
                    FileName = fileInput.DisplayName
                };
                _ = context.Files.Add(file);
                // logic to copy the file to local folder
                _ = fileInput.CopyAsync((IStorageFolder)CreateSubFolderAsync(year.Id.ToString()));
            }
            else
            {
                // file already exists ... write logic to see if the user wants to replace the existing file
            }

            _ = context.SaveChanges();

        }

        public void GoBack()
        {
            if (NavigationService.CanGoBack)
            {
                _ = NavigationService.GoBack();
            }
        }

        private void OpenPopUpMessage(string title, string message, bool button)
        {
            if (!PopupItem)
            {
                PopupTitle = title;
                PopupMessage = message;
                PopupButton = button;
            }
        }

        public void PopupOkButton()
        {
            _popupResponse = true;
        }

        public void PopupCancelButton()
        {
            _popupResponse = false;
            PopupItem = false;
        }

    }
}
