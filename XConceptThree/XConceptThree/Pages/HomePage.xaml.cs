using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XConceptThree.Classes;

namespace XConceptThree.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),
                new Thickness(10),
                new Thickness(10));

            employeesListView.ItemTemplate = new DataTemplate(typeof(EmployeeCell));
            employeesListView.RowHeight = 70;

            addButton.Clicked += AddButton_Clicked;
            employeesListView.ItemSelected += EmployeesListView_ItemSelected;
        }

        private async void EmployeesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EditPage((Employee)e.SelectedItem));
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a first name", "Accept");
                firstNameEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(lastNameEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a last name", "Accept");
                lastNameEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salaryEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a salary", "Accept");
                salaryEntry.Focus();
                return;
            }

            InsertEmployee();
        }

        private async void InsertEmployee()
        {
            var employee = new Employee
            {
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                ContractDate = contractDateDatePicker.Date,
                Salary = decimal.Parse(salaryEntry.Text),
                Active = activeSwitch.IsToggled
            };

            using (var db = new DataAccess())
            {
                db.Insert(employee);
                employeesListView.ItemsSource = db.GetList<Employee>();
            }

            firstNameEntry.Text = string.Empty;
            lastNameEntry.Text = string.Empty;
            salaryEntry.Text = string.Empty;
            contractDateDatePicker.Date = DateTime.Now;
            activeSwitch.IsToggled = true;
            await DisplayAlert("Message", "Employee added", "Accept");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var db = new DataAccess())
            {
                employeesListView.ItemsSource = db.GetList<Employee>();
            }
        }
    }
}
