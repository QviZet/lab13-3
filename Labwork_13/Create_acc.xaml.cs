using Labwork_13.models;
using System.Collections.ObjectModel;
using static Labwork_13.Accident_page;

namespace Labwork_13;

public partial class Create_acc : ContentPage
{
	private ObservableCollection<accidents> Accid {  get; set; }
	public Create_acc(ObservableCollection<accidents> v)
	{
		InitializeComponent();
		Accid = v;
		BindingContext = this;
    }

	public  void Bac(object? sender, EventArgs e)
	{
		Navigation.RemovePage(this);
	}

    public void Cre(object? sender, EventArgs e)
    {
		var db = new ApplicationContext();
		accidents x = new accidents();
		x.address = addr.Text;
		x.type = ty.Text;
		x.state = sta.Text;
		db.accidents.Add(x);
		db.SaveChanges();
		Accid.Add(x);
        Navigation.RemovePage(this);
    }

}