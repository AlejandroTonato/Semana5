namespace Semana5
{
    public partial class App : Application
    {
        public static PersonaRepository personaRepo {  get; set; }
        public App(PersonaRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Login());
            personaRepo = personRepository;
        }
    }
}
