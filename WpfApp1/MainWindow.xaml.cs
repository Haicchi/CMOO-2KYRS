using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isFine = false;
        double data = 0;
        private List<Worker> workers = new List<Worker>();
        private List<Salary> salaries = new List<Salary>();
        public MainWindow()
        {
            InitializeComponent();
            GetInfoFromFile();
            isFine = true;
            //Worker worker = new Worker(1, "Doe J.", "Bachelor's", "Engineer", new DateTime(1990, 1, 1));
            //Worker worker1 = new Worker(2, "Smith A.", "Master's", "Scientist", new DateTime(1985, 5, 15));
            //Worker worker2 = new Worker(3, "Brown B.", "PhD", "Researcher", new DateTime(1978, 9, 30));
            //Worker[] workers = { worker, worker1, worker2 };
            //foreach (var w in workers)
            //{
            //    using (FileStream fs = new FileStream("workers.txt", FileMode.Append, FileAccess.Write))
            //    {
            //        using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8)) { sw.WriteLine(w.ToString()); }

            //    }
            //}
            //Salary salary = new Salary(1, 1500.50, 1600.75);
            //Salary salary1 = new Salary(2, 2000.00, 2100.25);
            //Salary salary2 = new Salary(3, 2500.75, 2600.80);
            //Salary[] salaries = { salary, salary1, salary2 };
            //foreach (var s in salaries)
            //{
            //    using (FileStream fs = new FileStream("salaries.txt", FileMode.Append, FileAccess.Write))
            //    {
            //        using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8)) { sw.WriteLine(s.ToString()); }
            //    }
            //}
          
            //var olderThen35 = workers.Where(w => (DateTime.Now.Year - w.DateOfBirth.Year) > 35).Select(w => w.SurnameAndInitials);
            //var highestSalaryFor2Half = salaries.OrderByDescending(s => s.SalaryForSecondHalf).First();
            //var workerWithHighestSalaryFor2Half = workers.Where(w => w.Id == highestSalaryFor2Half.WorkerId).Select(w => w.Id +" "+ w.Specialty).First();
            //var avgSalary = salaries.Average(s => s.SalaryForFirstHalf+s.SalaryForSecondHalf);
            //var workersWithSalaryBelowAvg = salaries.Where(s => (s.SalaryForFirstHalf + s.SalaryForSecondHalf) < avgSalary).Join(workers,salaries=>salaries.WorkerId,workers=>workers.Id,(s,workers)=>workers.SurnameAndInitials + " " + workers.Education);
            //var workersWithHighEducationAndSalaryAboveInserted = workers.Where(w => w.Education == "Master's" || w.Education == "PhD").Join(salaries, w => w.Id, s => s.WorkerId, (w, s) => new { Worker = w, Salary = s }).Where(ws => (ws.Salary.SalaryForFirstHalf + ws.Salary.SalaryForSecondHalf) > data).Select(ws => ws.Worker.SurnameAndInitials + " " + ws.Worker.Education);
        }
        private void GetInfoFromFile()
        {
            workers = new List<Worker>();
            salaries = new List<Salary>();

            using (var fs = new FileStream("workers.txt", FileMode.OpenOrCreate, FileAccess.Read))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                    workers.Add(new Worker(int.Parse(parts[0]), parts[1], parts[2], parts[3], DateTime.Parse(parts[4])));
                }
            }

            using (var fs = new FileStream("salaries.txt", FileMode.OpenOrCreate, FileAccess.Read))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                    salaries.Add(new Salary(int.Parse(parts[0]), double.Parse(parts[1]), double.Parse(parts[2])));
                }
            }
        }

        private void WorkerTask(object sender, RoutedEventArgs e)
        {
            if(!isFine) return;
            Button btn = sender as Button;
            if (btn.Name == "Task1")
            {
                var olderThen35 = workers.Where(w => (DateTime.Now.Year - w.DateOfBirth.Year) > 35).Select(w => w.SurnameAndInitials);
                foreach (var worker in olderThen35)
                {
                    MessageBox.Show(worker.ToString());
                }
            }
            else if (btn.Name == "Task2")
            {
                var highestSalaryFor2Half = salaries.OrderByDescending(s => s.SalaryForSecondHalf).First();
                var workerWithHighestSalaryFor2Half = workers.Where(w => w.Id == highestSalaryFor2Half.WorkerId).Select(w => w.Id + " " + w.Specialty).First();
                MessageBox.Show(workerWithHighestSalaryFor2Half.ToString());
            }
            else if (btn.Name == "Task3")
            {
                var avgSalary = salaries.Average(s => s.SalaryForFirstHalf + s.SalaryForSecondHalf);
                var workersWithSalaryBelowAvg = salaries.Where(s => (s.SalaryForFirstHalf + s.SalaryForSecondHalf) < avgSalary).Join(workers, salaries => salaries.WorkerId, workers => workers.Id, (s, workers) => workers.SurnameAndInitials + " " + workers.Education);
                foreach (var worker in workersWithSalaryBelowAvg)
                {
                    MessageBox.Show(worker.ToString());
                }   
            }
            else if (btn.Name == "Task4")
            {
                if(!double.TryParse(TextForTask4.Text, out data))
                {
                    MessageBox.Show("Please enter a valid integer value.");
                    return;
                }
                data = double.Parse(TextForTask4.Text);
                var workersWithHighEducationAndSalaryAboveInserted = workers.Where(w => w.Education == "Master's" || w.Education == "PhD").Join(salaries, w => w.Id, s => s.WorkerId, (w, s) => new { Worker = w, Salary = s }).Where(ws => (ws.Salary.SalaryForFirstHalf + ws.Salary.SalaryForSecondHalf) > data).Select(ws => ws.Worker.SurnameAndInitials + " " + ws.Worker.Education);
                foreach (var worker in workersWithHighEducationAndSalaryAboveInserted)
                {
                    MessageBox.Show(worker.ToString());
                }
            }

        }
    }
}