using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XConceptThree.Classes
{
    public class EmployeeCell : ViewCell
    {
        public EmployeeCell()
        {
            var employeeIdLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };

            employeeIdLabel.SetBinding(Label.TextProperty, new Binding("EmployeeId"));

            var fullNameLabel = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            fullNameLabel.SetBinding(Label.TextProperty, new Binding("FullName"));

            var contractDateLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            contractDateLabel.SetBinding(Label.TextProperty, new Binding("ContractDate", stringFormat: "{0:yyyy/MM/dd}"));

            var salaryLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            salaryLabel.SetBinding(Label.TextProperty, new Binding("Salary", stringFormat: "{0:C2}"));

            var activeSwitch = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };

            activeSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Active"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    employeeIdLabel, fullNameLabel
                },
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    contractDateLabel, salaryLabel, activeSwitch,
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    line1, line2,
                },
            };
        }
    }
}
