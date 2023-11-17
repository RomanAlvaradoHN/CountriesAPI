using CountriesAPI.Models;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace CountriesAPI.Views;

public partial class MapaView : ContentPage
{
	private Pais pais;


	public MapaView(Pais p){
		InitializeComponent();
		this.pais = p;
	}




    protected override void OnAppearing() {
        base.OnAppearing();

        Location locacion = new Location(pais.latlng[0], pais.latlng[1]);

        mapa.Pins.Add(new Pin {
            Label = pais.name.official,
            Address = "Area: " + pais.area + " km^2",
            Location = locacion,
            Type = PinType.Place
        }); ;

        //mapa.MapType = MapType.Satellite;
        mapa.MoveToRegion(new MapSpan(locacion, 0.1, 0.1));
    }


}