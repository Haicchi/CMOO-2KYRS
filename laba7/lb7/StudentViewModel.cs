using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;


namespace lb7
{
    public class StudentViewModel
    {
        public string filepath = "Students.json";
        public ObservableCollection<Student> Students { get; set; }
        private Student _currentstudent;
        public Student currentStudent
        {
            get { return _currentstudent; }
            set
            {
                _currentstudent = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        [JsonIgnore]
        public ICommand AddButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand ChangeButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand DeleteButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand CheckButtonCommand { get; private set; }

        public StudentViewModel() {
        Students = new ObservableCollection<Student>();
            AddButtonCommand = new RelayCommand(AddButton);
            ChangeButtonCommand = new RelayCommand(ChangeButton, CanChangeButton);
            DeleteButtonCommand = new RelayCommand(DeleteButton, CanDeleteButton);
            CheckButtonCommand = new RelayCommand(CheckButton, CanCheckButton);
        }

        public StudentViewModel(ObservableCollection<Student> students)
        {
            Students = students;
        }
        public void AddApplication()
        {
            Students.Add(currentStudent);
            currentStudent = new Student();
        }
        public void RemoveApplication()
        {
            Students.Remove(currentStudent);
        }

        public void SaveUsersToFileJson(string filePath)
        {
            var json = JsonSerializer.Serialize(Students);
            File.WriteAllText(filePath, json);

        }
        public void LoadUsersFromFileJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Students = JsonSerializer.Deserialize<ObservableCollection<Student>>(json);
            }
        }
        private void AddButton(object parameter)
        {


            AddWindow addWindow = new AddWindow();
            Student stud = new Student();
            addWindow.DataContext = stud;
            if (addWindow.ShowDialog() == true)
            {
                currentStudent = stud;
                AddApplication();
                SaveUsersToFileJson(filepath);

            }

        }
        private bool CanChangeButton(object parameter)
        {
            if (parameter is System.Collections.IList selectedItems)
            {
                return selectedItems.Count == 1;
            }
            return false;
        }
        private void ChangeButton(object parameter)
        {
            var checkedstudent = currentStudent;
            if (checkedstudent != null)
            {
                AddWindow checkedwindow = new AddWindow();
                checkedwindow.DataContext = checkedstudent;
                if (checkedwindow.ShowDialog() == true)
                {
                    SaveUsersToFileJson(filepath);
                }
            }
        }
        private bool CanDeleteButton(object parameter)
        {
            if (currentStudent == null)
            {
                return false;
            }
            return true;
        }
        private void DeleteButton(object parameter)
        {
            var selectedItems = parameter as System.Collections.IList;

            if (selectedItems == null || selectedItems.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть хоча б одну заявку для видалення.", "Увага");
                return;
            }
            string message = $"Ви точно хочете видалити {selectedItems.Count} заявок?";
            var result = MessageBox.Show(message, "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                var itemsToDelete = selectedItems.Cast<Student>().ToList();
                foreach (var student in itemsToDelete)
                {
                    Students.Remove(student);
                }
                SaveUsersToFileJson(filepath);
            }
        }
        private bool CanCheckButton(object parameter)
        {
            if (parameter is System.Collections.IList selectedItems)
            {
                return selectedItems.Count == 1;
            }
            return false;
        }
        private void CheckButton(object parameter)
        {
            var checkedstudent = currentStudent;
            if (checkedstudent != null)
            {
                FullInfo infoWindow = new FullInfo();
                infoWindow.DataContext = checkedstudent;
                infoWindow.ShowDialog();
            }
        }
    }
}
