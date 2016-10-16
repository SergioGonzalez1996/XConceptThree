using System;
using Xamarin.Forms;
using XConceptThree.Classes;

namespace XConceptThree.Pages
{
    public partial class EditPage : ContentPage
    {
        private Employee employee;

        public EditPage(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;

            Padding = Device.OnPlatform(
               new Thickness(10, 20, 10, 10),
               new Thickness(10),
               new Thickness(10));

            firstNameEntry.Text = employee.FirstName;
            lastNameEntry.Text = employee.LastName;
            contractDateDatePicker.Date = employee.ContractDate;
            salaryEntry.Text = employee.Salary.ToString();
            activeSwitch.IsToggled = employee.Active;

            updateButton.Clicked += UpdateButton_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;

        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm", "Are you sure to delete the record?", "Yes", "No");
            if (!response)
            {
                return;
            }

            using (var db = new DataAccess())
            {
                db.Delete(employee);
            }

            await DisplayAlert("Message", "The record was deleted", "Accept");
            await Navigation.PopAsync();
        }


        private async void UpdateButton_Clicked(object sender, EventArgs e)
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

            employee.FirstName = firstNameEntry.Text;
            employee.LastName = lastNameEntry.Text;
            employee.Salary = decimal.Parse(salaryEntry.Text);
            employee.ContractDate = contractDateDatePicker.Date;
            employee.Active = activeSwitch.IsToggled;

            using (var data = new DataAccess())
            {
                data.Update(employee);
            }

            await DisplayAlert("Message", "The record was updated", "Accept");
            await Navigation.PopAsync();
        }
    }
}
