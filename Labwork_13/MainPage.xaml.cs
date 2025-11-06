namespace Labwork_13
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAccidentClicked(object? sender, EventArgs e)
        {
            Navigation.PushAsync(new Accident_page());
        }

        private void OnEmployeeClicked(object? sender, EventArgs e)
        {
            Navigation.PushAsync(new Employees_page());
        }

        private void OnEquipmentClicked(object? sender, EventArgs e)
        {
            Navigation.PushAsync(new Equipment_page());
        }
    }
}
