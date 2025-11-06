using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Labwork_13.models;
namespace Labwork_13;

public partial class Update_acc : ContentPage
{
    int id;
    private ObservableCollection<accidents> Accid { get; set; }
    public Update_acc(ObservableCollection<accidents> acc, object x)
	{
		InitializeComponent();
		Accid = acc;
		BindingContext = this;
		accidents f = (accidents)x;
		addr.Text = f.address;
		ty.Text = f.type;
		sta.Text = f.state;
        id = f.id;
	}

    public async void Bac(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Accident_page());
        Navigation.RemovePage(this);
    }
    public async void Upd(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        var updated = db.accidents.Find(id);
        updated.address = addr.Text;
        updated.type = ty.Text;
        updated.state = sta.Text;
        db.SaveChanges();


        await Navigation.PushAsync(new Accident_page());
        Navigation.RemovePage(this);
    }

    public async void Del(object? sender, EventArgs e)
    {
        var db = new ApplicationContext();
        var x = db.accidents.First(u => u.id == id);
        db.accidents.Remove(x);
        db.SaveChanges();
        await Navigation.PushAsync(new Accident_page());
        Navigation.RemovePage(this);
    }
}