using Labwork_13.models;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Update_equipment : ContentPage
{
    int id;
    private ObservableCollection<equipment> Equip { get; set; }
    public Update_equipment(ObservableCollection<equipment> eq, object x)
    {
        InitializeComponent();
        Equip = eq;
        BindingContext = this;
        equipment f = (equipment)x;
        ty.Text = f.type;
        co.Text = f.count.ToString();
        id = f.id;
    }

    public async void Bac(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Equipment_page());
        Navigation.RemovePage(this);
    }
    public async void Upd(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        var updated = db.accessibleEquipment.Find(id);
        updated.type = ty.Text;
        updated.count = int.Parse(co.Text);
        db.SaveChanges();


        await Navigation.PushAsync(new Equipment_page());
        Navigation.RemovePage(this);
    }

    public async void Del(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        var x = db.accessibleEquipment.First(u => u.id == id);
        db.accessibleEquipment.Remove(x);
        db.SaveChanges();
        await Navigation.PushAsync(new Equipment_page());
        Navigation.RemovePage(this);
    }
}