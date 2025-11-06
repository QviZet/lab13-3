using Labwork_13.models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Labwork_13;

public partial class Accident_page : ContentPage
{
    public ObservableCollection<accidents> Accidents { get; set; }
    public Accident_page()
	{
        InitializeComponent();
        var db = new ApplicationContext();
        var acc = db.accidents.OrderBy(u => u.id).ToList();
        Accidents = new ObservableCollection<accidents>();
        foreach (var t in acc)
        {
            Accidents.Add(t);
        }
        BindingContext = this;
    }

    public void createAccident(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new Create_acc(Accidents));
    }

    public async void rowTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new Update_acc(Accidents, e.Item));
        Navigation.RemovePage(this);
    }

    public void GoBack(object? sender, EventArgs e)
    {
        Navigation.RemovePage(this);
    }






}