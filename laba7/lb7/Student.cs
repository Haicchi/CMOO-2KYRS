using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace lb7
{
    public class Student : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private int _age;
        private string _sex;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string fullname { get { return _name + ' ' +  _surname; } }
        public bool isMale { get; set; }
        public bool isFemale { get; set; }
        public string AgeWithSuffix
        {
            get
            {
                int n = this.age;
                if (n % 100 >= 11 && n % 100 <= 14)
                    return $"{n} років";
                if (n % 10 == 1)
                    return $"{n} рік";
                if (n % 10 >= 2 && n % 10 <= 4)
                    return $"{n} роки";
                return $"{n} років";
            }
        }
        [JsonIgnore]
        public ICommand SubmitCommand { get; private set; }

        public Student() {
            _name = "";
            _surname = "";
            _age = 0;
            _sex = "";
            isMale = false;
            isFemale = true;
            SubmitCommand = new RelayCommand(SubmitData, CanSubmitData);
        }

        public Student(string _name, string _surname, int _age, string _sex ,bool isMale,bool isFemale)
        {
            this._name = _name;
            this._surname = _surname;
            this._age = _age;
            this._sex = _sex;
            this.isMale = isMale;
            this.isFemale = isFemale;
        }

        public string name { get { return _name; }
        set {  _name = value;
                OnPropertyChanged(nameof(name));
                OnPropertyChanged(nameof(fullname));
            }
        }

        public string surname
        {
            get
            {
                return _surname;

            }
            set
            {
               _surname = value;
                OnPropertyChanged(nameof(surname));
                OnPropertyChanged(nameof(fullname));

            }
        }
        
        public int age { get { return _age; } set { _age = value; OnPropertyChanged(nameof(age)); } }

        public string sex { get { return _sex; } set {
                _sex = value; OnPropertyChanged(nameof(sex));
            } }

        public override string ToString() { return $"{_name}|{_surname}|{_age}|{_sex}";}

        private bool CanSubmitData(object parameter)
        {
           
                if (string.IsNullOrWhiteSpace(this.name)) return false;
                if (this.name.Any(char.IsDigit)) return false;
                if (string.IsNullOrWhiteSpace(this.surname)) return false;
                if (this.surname.Any(char.IsDigit)) return false;
                if (this.age < 16) return false;
                if (this.age > 100) return false;
                if(this.isMale == false && this.isFemale == false) return false;
                return true;
            

            
        }
        private void SubmitData(object parameter)
        {
            if (isMale == true) this.sex = "Male";
            else if (isFemale == true) this.sex = "Female";
            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }


        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
