namespace AutomationPractice_Registration_Negative_Tests.Pages.RegistrationPage
{
    using Models;

    public partial class RegistrationPage
    {
        public void FillForm(User user)
        {
            RadioButtons[0].Click();
            CustomerFirstName.SendKeys(user.FirstName);
            CustomerLastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Days.SelectByValue(user.Day);
            Months.SelectByValue(user.Month);
            Years.SelectByValue(user.Year);
            FirstName.SendKeys(user.AddressFirstName);
            LastName.SendKeys(user.AddressLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByText(user.State);
            PostCode.SendKeys(user.Postalcode);
            Phone.SendKeys(user.MobilePhone);
            Alias.SendKeys(user.Alias);
        }

    }
}