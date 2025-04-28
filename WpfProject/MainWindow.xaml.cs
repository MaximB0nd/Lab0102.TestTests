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
            try
            {
                // Сброс ошибок
                txtError.Text = "";

                // Получаем данные из формы
                var employee = new Employee(
                    txtName.Text,
                    dpBirthday.SelectedDate ?? DateTime.Now,
                    cmbGender.Text == "Мужской" ? Gender.MALE : Gender.FEMALE,
                    decimal.Parse(txtSalary.Text),
                    (CurrentPosition)cmbPosition.SelectedIndex,
                    (Education)cmbEducation.SelectedIndex
                );

             
                if (!employee.checkName())
                {
                    txtError.Text = "Некорректное имя!";
                    return;
                }

                // Добавляем сотрудника
                employees.Add(employee);

                // Очищаем форму
                txtName.Clear();
                dpBirthday.SelectedDate = null;
                cmbGender.SelectedIndex = 0;
                cmbEducation.SelectedIndex = 0;
                cmbPosition.SelectedIndex = 0;
                txtSalary.Clear();
                txtBonus.Text = "";
            }
            catch (Exception ex)
            {
                txtError.Text = "Ошибка: " + ex.Message;
            }
        }

        private void CalculateBonus(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                var position = (Employee.CurrentPosition)(cmbPosition.SelectedIndex);
                decimal bonus = 0;

                switch (position)
                {
                    case Employee.CurrentPosition.DIRECTOR:
                    case Employee.CurrentPosition.SENIOR:
                        bonus = salary * 0.15m;
                        break;
                    case Employee.CurrentPosition.MIDDLE:
                        bonus = salary * 0.10m;
                        break;
                    case Employee.CurrentPosition.JUNIOR:
                        bonus = salary * 0.05m;
                        break;
                    case Employee.CurrentPosition.MANAGER:
                        bonus = salary * 0.03m;
                        break;
                }

                txtBonus.Text = bonus.ToString("N2");
            }
        }
    }
}