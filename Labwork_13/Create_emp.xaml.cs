using Labwork_13.models;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Create_emp : ContentPage
{
    private ObservableCollection<employees> Emplo { get; set; }
    public Create_emp(ObservableCollection<employees> v)
    {
        InitializeComponent();
        Emplo = v;
        BindingContext = this;
    }

    public void Bac(object? sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    public void Cre(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        employees x = new employees();
        x.name = nam.Text;
        x.post = po.Text;
        db.employees.Add(x);
        db.SaveChanges();
        Emplo.Add(x);
        Navigation.RemovePage(this);
    }

}