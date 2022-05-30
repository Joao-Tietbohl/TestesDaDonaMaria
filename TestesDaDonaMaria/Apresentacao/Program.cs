using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Apresentacao.ModuloDisciplina;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao
{
    public static class Program
    {

        static string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DonaMaria;Integrated Security=True;Pooling=False";

        static SqlConnection conexaoComBanco = new SqlConnection();
       
        static Serializador serializador = new Serializador();

        static DataContext contexto = new DataContext(serializador);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            conexaoComBanco.ConnectionString = connectionString;
            conexaoComBanco.Open();

            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipalForm(contexto));

            contexto.GravarDados();
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            contexto.GravarDados();
        }

    }
}
