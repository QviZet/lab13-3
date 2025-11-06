using Labwork_13.models;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Update_emp : ContentPage
{
    int id;
    private ObservableCollection<employees> Emplo { get; set; }
    public Update_emp(ObservableCollection<employees> em, object x)
    {
        InitializeComponent();
        Emplo = em;
        BindingContext = this;
        employees f = (employees)x;
        nam.Text = f.name;
        po.Text = f.post;
        id = f.id;
    }

    public async void Bac(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Employees_page());
        Navigation.RemovePage(this);
    }
    public async void Upd(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        var updated = db.employees.Find(id);
        updated.name = nam.Text;
        updated.post = po.Text;
        db.SaveChanges();


        await Navigation.PushAsync(new Employees_page());
        Navigation.RemovePage(this);
    }

    public async void Del(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        var x = db.employees.First(u => u.id == id);
        db.employees.Remove(x);
        db.SaveChanges();
        await Navigation.PushAsync(new Employees_page());
        Navigation.RemovePage(this);
    }
}