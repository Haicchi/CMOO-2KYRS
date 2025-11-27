using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public class WorkerApplication
    {
        private string pip;
        private DateTime birthdate;
        private string education;
        private List<string> languages;
        private bool isGoodAtUsingComputer;
        private int yearsOfExperience;
        private bool hasRecommendations;
        [JsonIgnore]
        public ICommand SubmitCommand { get; private set; }
        
        public WorkerApplication(string pip, DateTime birthdate, string education, List<string> languages, bool isGoodAtUsingComputer, int yearsOfExperience, bool hasRecommendations)
        {
            this.pip = pip;
            this.birthdate = birthdate;
            this.education = education;
            this.languages = languages;
            this.isGoodAtUsingComputer = isGoodAtUsingComputer;
            this.yearsOfExperience = yearsOfExperience;
            this.hasRecommendations = hasRecommendations;
        }

        public WorkerApplication() {
            pip = "";
            birthdate = DateTime.Now;
            education = "";
            languages = new List<string>();
            isGoodAtUsingComputer = false;
            yearsOfExperience = 0;
            hasRecommendations = false;
            SubmitCommand = new RelayCommand(SubmitData, CanSubmitData);

        }

        public string Pip { get => pip; set => pip = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public string Education { get => education; set => education = value; }
        public List<string> Languages { get => languages; set => languages = value; }
        public bool IsGoodAtUsingComputer { get => isGoodAtUsingComputer; set => isGoodAtUsingComputer = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
        public bool HasRecommendations { get => hasRecommendations; set => hasRecommendations = value; }
        
        public override string ToString()
        {
            return $"{pip}|{birthdate.ToShortDateString()}|{education}|{string.Join(", ", languages)}|{isGoodAtUsingComputer}|{yearsOfExperience}|{hasRecommendations}";
        }

        private bool CanSubmitData(object parameter)
        {
            if (parameter is AddWindow window)
            {
                if (string.IsNullOrWhiteSpace(this.Pip)) return false;
                if (this.Pip.Any(char.IsDigit)) return false;
                if(this.Birthdate >= DateTime.Now) return false;
                if (this.YearsOfExperience < 0) return false;
                if(this.Birthdate.AddYears(this.YearsOfExperience) > DateTime.Now) return false;
                if(DateTime.Now.Year-this.Birthdate.Year < 18) return false;
                bool isEduSelected = window.RbSchool.IsChecked == true ||
                window.RbBachelor.IsChecked == true ||
                window.RbHigh.IsChecked == true;
                if (!isEduSelected) return false;
                bool isCompSelected = window.Yes.IsChecked == true || window.No.IsChecked == true;
                bool isRecSelected = window.Have.IsChecked == true || window.DontHave.IsChecked == true;
                if (!isCompSelected || !isRecSelected) return false;
                return true;
            }

            return false;
        }
        private void SubmitData(object parameter)
        {
            if (parameter is AddWindow window)
            {
                
                if (window.RbSchool.IsChecked == true) this.Education = "Среднее";
                else if (window.RbBachelor.IsChecked == true) this.Education = "Бакалавр";
                else if (window.RbHigh.IsChecked == true) this.Education = "Высшее";
                else this.Education = "Не указано";
           
                this.Languages = new List<string>();
               
                foreach (var child in window.LanguagesPanel.Children)
                {
                    if (child is CheckBox checkBox && checkBox.IsChecked == true)
                    {
                        this.Languages.Add(checkBox.Tag.ToString());
                    }
                }

                this.IsGoodAtUsingComputer = (window.Yes.IsChecked == true);

                this.HasRecommendations = (window.Have.IsChecked == true);

                window.DialogResult = true;
                window.Close();
            }
        }

    }
}
