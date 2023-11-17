using CountriesAPI.Models;
using Newtonsoft.Json;


namespace CountriesAPI.Views;

public partial class Listado : ContentPage
{
    private string jsonObj;



	public Listado(){
		InitializeComponent();
        SetPickerOptions();
    }







    private void SetPickerOptions() {
        List<string> regiones = new List<string>();
        regiones.Add("africa");
        regiones.Add("americas");
        regiones.Add("asia");
        regiones.Add("europe");
        regiones.Add("oceania");
        listaRegiones.ItemsSource = regiones;
    }




    private void OnPickerSelectedIndexChanged(object sender, EventArgs e) {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1) {
            string regionSeleccionada = (string)picker.ItemsSource[selectedIndex];
            GetDataFromAPI(regionSeleccionada);
        }
    }





    private async void GetDataFromAPI(string regionSeleccionada) {
        viewListado.ItemsSource = null;
        viewListado.Header = "Cargando lista...";

        string apiUrl = "https://restcountries.com/v3.1/region/" + regionSeleccionada;

        using (HttpClient client = new HttpClient()) {
            HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);
            if (responseMessage != null && responseMessage.IsSuccessStatusCode) {
                jsonObj = await responseMessage.Content.ReadAsStringAsync();

                List<Pais> paises = JsonConvert.DeserializeObject<List<Pais>>(jsonObj);
                viewListado.ItemsSource = paises;
                viewListado.Header = string.Empty;
            }
        }

        
    }



    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) {
        Pais p = args.SelectedItem as Pais;
        await Navigation.PushAsync(new MapaView(p));
    }
}