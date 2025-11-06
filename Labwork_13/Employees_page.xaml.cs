using Labwork_13.models;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Employees_page : ContentPage
{
    public ObservableCollection<employees> Employees { get; set; }
    public Employees_page()
	{
		InitializeComponent();
        var db = new ApplicationContext();
        var acc = db.employees.OrderBy(u => u.id).ToList();
        Employees = new ObservableCollection<employees>();
        foreach (var t in acc)
        {
            Employees.Add(t);
        }
        BindingContext = this;
    }

    public void createEmployee(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new Create_emp(Employees));
    }

    public async void rowTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new Update_emp(Employees, e.Item));
        Navigation.RemovePage(this);
    }

    public void GoBack(object? sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }
}