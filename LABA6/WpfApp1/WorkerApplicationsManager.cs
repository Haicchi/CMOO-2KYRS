using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;

namespace WpfApp1
{
    public class WorkerApplicationsManager
    {
        public string filepath = "workerapps.json";
        [JsonIgnore]
        public ICommand AddButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand ChangeButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand DeleteButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand CheckButtonCommand { get; private set; }
        [JsonIgnore]
        public ICommand FilterCommand { get; private set; }
        public ObservableCollection<WorkerApplication> Applications { get; set; }
        private WorkerApplication _currentApplication { get; set; }
        public WorkerApplication currentapplication
        {
            get => _currentApplication;
            set
            {
                _currentApplication = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }
        public WorkerApplicationsManager()
        {
            Applications = new ObservableCollection<WorkerApplication>();
            AddButtonCommand = new RelayCommand(AddButton);
            ChangeButtonCommand = new RelayCommand(ChangeButton,CanChangeButton);
            DeleteButtonCommand = new RelayCommand(DeleteButton, CanDeleteButton);
            CheckButtonCommand = new RelayCommand(CheckButton, CanCheckButton);
            FilterCommand = new RelayCommand(ApplyFilter);
        }

        public WorkerApplicationsManager(ObservableCollection<WorkerApplication> applications)
        {
            Applications = applications;
            AddButtonCommand = new RelayCommand(AddButton);
        }
        public void SetCurrentApplication(WorkerApplication application)
        {
            currentapplication = application;
        }

        public void AddApplication()
        {
            Applications.Add(currentapplication);
            currentapplication = new WorkerApplication();
        }
        public void RemoveApplication() {
            Applications.Remove(currentapplication);
        }

        public void SaveUsersToFileJson(string filePath)
        {
            var json = JsonSerializer.Serialize(Applications);
            File.WriteAllText(filePath, json);

        }
        public void LoadUsersFromFileJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Applications = JsonSerializer.Deserialize<ObservableCollection<WorkerApplication>>(json);
            }
        }
        private void AddButton(object parameter)
        {
           

                AddWindow addWindow = new AddWindow();
                WorkerApplication application = new WorkerApplication();
                addWindow.DataContext = application;
                if (addWindow.ShowDialog() == true)
                {
                    currentapplication = application;
                    AddApplication();
                    SaveUsersToFileJson(filepath);

                }
            
        }
        private bool CanChangeButton(object parameter)
        {
            if(currentapplication == null)
            {
                return false;
            }
            return true;
        }
        private void ChangeButton(object parameter)
        {
            var checkedworker = currentapplication;
            if (checkedworker != null)
            {
                AddWindow checkedwindow = new AddWindow();
                checkedwindow.DataContext = checkedworker;
                if (checkedwindow.ShowDialog() == true)
                {
                    SaveUsersToFileJson(filepath);
                }
            }
        }
        private bool CanDeleteButton(object parameter)
        {
            if (currentapplication == null)
            {
                return false;
            }
            return true;
        }
        private void DeleteButton(object parameter)
        {
            RemoveApplication();
            SaveUsersToFileJson(filepath);
        }
        private bool CanCheckButton(object parameter)
        {
            if (currentapplication == null)
            {
                return false;
            }
            return true;
        }
        private void CheckButton(object parameter)
        {
            var checkedworker = currentapplication;
            if (checkedworker != null)
            {
                FullInfo infoWindow = new FullInfo();
                infoWindow.DataContext = checkedworker;
                infoWindow.ShowDialog();
            }
        }

        private void ApplyFilter(object parameter)
        {
            if (parameter is string filterText)
            {
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(Applications);
                if (string.IsNullOrWhiteSpace(filterText) || filterText=="All")
                {
                    collectionView.Filter = null;
                }
                else
                {
                    collectionView.Filter = (obj) =>
                    {
                        if (obj is WorkerApplication worker)
                        {
                            return worker.Education != null &&
                                   worker.Education.Contains(filterText);
                        }
                        return false;
                    };
                }
            }
        }
    }
}
