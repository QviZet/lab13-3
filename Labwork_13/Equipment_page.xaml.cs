using Labwork_13.models;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Equipment_page : ContentPage
{
    public ObservableCollection<equipment> Equip { get; set; }
    public Equipment_page()
    {
        InitializeComponent();
        var db = new ApplicationContext();
        var acc = db.accessibleEquipment.OrderBy(u => u.id).ToList();
        Equip = new ObservableCollection<equipment>();
        foreach (var t in acc)
        {
            Equip.Add(t);
        }
        BindingContext = this;
    }

    public void createEquip(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new Create_equip(Equip));
    }

    public async void rowTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new Update_equipment(Equip, e.Item));
        Navigation.RemovePage(this);
    }

    public void GoBack(object? sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }
}