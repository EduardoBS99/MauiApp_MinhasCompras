namespace MauiApp_MinhasCompras
{

    // Classe principal da aplicação .NET MAUI
    // Herda de Application, que é a base para configurar o ciclo de vida do app
    public partial class App : Application
    {

        // Construtor do App: chamado quando o aplicativo é iniciado
        public App()
        {
            InitializeComponent();

            // Inicializa os componentes definidos no XAML (ex.: estilos, recursos globais)

            // Define a página inicial do aplicativo
            // MainPage = new AppShell();   // Estrutura com Shell (opção comentada)

            // Aqui foi escolhido usar NavigationPage para habilitar navegação por pilha
            // A primeira tela exibida será a "ListaProduto"

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto()); 
        }
    }
}
