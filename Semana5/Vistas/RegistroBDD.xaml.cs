using Semana5.Modelos;

namespace Semana5.Vistas;

public partial class RegistroBDD : ContentPage
{
	public RegistroBDD(string usuario)
	{
		InitializeComponent();
		lblUsuario.Text = "Usuario conectado: "+usuario;
	}

    private async void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        await App.personaRepo.AddNewPersona(txtNombre.Text);
        RefreshCollectionView();
        lblStatusMessage.Text = App.personaRepo.statusMessage;
    }

    private async void btnMostrar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "Los Datos Son: ";
        List<Persona> people = await App.personaRepo.GetAllPersonas();
        listaPersona.ItemsSource = people;
    }

    private async  void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        int id = int.Parse(txtID.Text);
        if (txtID.Text.Equals("") == false && id > 0)
        {
            await App.personaRepo.DeletePerson(id);
            RefreshCollectionView();
            lblStatusMessage.Text = "Dato Eliminado.";
        }
        else
        {
            lblStatusMessage.Text = "ingrese ID de persona para eliminar.";
        }

    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        int id = int.Parse(txtID.Text);

        if (id > 0)
        {
            string updatedName = txtNombre.Text;

            Persona updatedPerson = new Persona
            {
                Id = id,
                Name = updatedName
            };

            await App.personaRepo.UpdatePerson(updatedPerson);
            RefreshCollectionView();
            lblStatusMessage.Text = "Dato actualizado.";
        }
        else
        {
            lblStatusMessage.Text = "Ingrese id de una persona para actualizar.";
        }

    }

    private async void RefreshCollectionView()
    {

        List<Persona> people = await App.personaRepo.GetAllPersonas();
        listaPersona.ItemsSource = people;
    }
}