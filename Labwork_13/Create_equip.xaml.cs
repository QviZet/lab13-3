using Labwork_13.models;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Create_equip : ContentPage
{
    private ObservableCollection<equipment> Equip { get; set; }
    public Create_equip(ObservableCollection<equipment> v)
    {
        InitializeComponent();
        Equip = v;
        BindingContext = this;
    }

    public void Bac(object? sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }

    public void Cre(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        equipment x = new equipment();
        x.type = ty.Text;
        x.count = int.Parse(co.Text);
        db.accessibleEquipment.Add(x);
        db.SaveChanges();
        Equip.Add(x);
        Navigation.RemovePage(this);
    }
}