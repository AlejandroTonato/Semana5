namespace Semana5.Vistas;

public partial class Login : ContentPage
{

    string[] usuarios = { "estudiante2024", "examen1", "atonato" };
    string[] contrasenas = { "uisrael2024", "parcial1", "2024" };
    public Login()
	{
		InitializeComponent();
	}

    private void btnAbrir_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string password = txtContrasena.Text;
        int index = Array.IndexOf(usuarios, usuario);

        if (index != -1 && contrasenas[index] == password)
        {
            string nombreUsuario = usuarios[index];
            DisplayAlert("Bienvenido", $"¡Hola {nombreUsuario}!", "Aceptar");
            Navigation.PushAsync(new Vistas.RegistroBDD(nombreUsuario));
        }
        else
        {
            DisplayAlert("ALERTA", "Usuario/Contraseña incorrectos", "Cancelar");
        }

    }

    private void btnAcerca_Clicked(object sender, EventArgs e)
    {

    }
}