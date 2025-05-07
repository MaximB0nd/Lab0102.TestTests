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
using static EmployeeLibrary.Employee;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using EmployeeLibrary;

namespace EmployeeApp


{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> employees = new();
        
        public MainWindow()
        {
            InitializeComponent();
            dgEmployees.ItemsSource = employees;
        }
        
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && 
            dpBirthday.SelectedDate is not null &&
            txtSalary.Text != "") 
            {
                if (cmbGender.SelectedIndex <= 0 || 
                    cmbEducation.SelectedIndex <= 0 || 
                    cmbPosition.SelectedIndex <= 0)
                {
                    txtError.Text = "Выберите значения из всех списков";
                    return;
                }
                try
                {
                    txtError.Text = "";
                    var employee = new Employee(
                            txtName.Text,
                            dpBirthday.SelectedDate ?? DateTime.Now,
                            cmbGender.SelectedIndex == 1 ? Gender.MALE : Gender.FEMALE, 
                            decimal.Parse(txtSalary.Text),
                            (CurrentPosition)(cmbPosition.SelectedIndex - 1),        
                            (Education)(cmbEducation.SelectedIndex - 1)                
                        

                    );


                    if (!employee.checkName())
                    {
                        txtError.Text = "некорректное имя";
                        return;
                    }
                    
                    employees.Add(employee);
                    
                    txtName.Clear();
                    dpBirthday.SelectedDate = null;
                    cmbGender.SelectedIndex = 0;
                    cmbEducation.SelectedItem = 0;
                    cmbPosition.SelectedItem = 0;
                    txtSalary.Clear();
                    txtBonus.Text = "";
                }
                catch (Exception ex)
                {
                    txtError.Text = "Ошибка: " + ex.Message;
                }
            }
            else
            {
                txtError.Text = "Ошибка: не все параметры выбраны";
            }
        }

        private void CalculateBonus(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(txtSalary.Text, out decimal salary) && 
                cmbPosition.SelectedIndex > 0)
            {
                var position = (CurrentPosition)(cmbPosition.SelectedIndex - 1);
                decimal bonus = new Employee("", DateTime.Now, Gender.MALE, salary, position, Education.PRIMARY).bonus;
                txtBonus.Text = bonus.ToString("N2");
            }
        }
        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Текстовый файл (*.txt)|*.txt|Все файлы (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    StringBuilder sb = new();
                    foreach (var employee in employees)
                    {
                        sb.AppendLine($"Имя: {employee.name}");
                        sb.AppendLine($"Дата рождения: {employee.birthday:d}");
                        sb.AppendLine($"Должность: {employee.position}");
                        sb.AppendLine($"Зарплата: {employee.salary:N2}");
                        sb.AppendLine($"Премия: {employee.bonus:N2}");
                        sb.AppendLine($"Полная зарплата: {employee.FullSalary:N2}");
                        sb.AppendLine("----------------------");
                    }
                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    MessageBox.Show("Данные сохранены успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
                }
            }
        }
    }
    
}
