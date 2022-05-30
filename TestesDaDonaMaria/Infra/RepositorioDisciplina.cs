using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Infra
{
    public class RepositorioDisciplina : RepositorioBase<Disciplina>
    {


        private const string enderecoBanco =
               @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DonaMaria;Integrated Security=True;Pooling=False";

        public RepositorioDisciplina(DataContext dataContext) : base(dataContext)
        {
        }

        public override List<Disciplina> ObterRegistros()
        {
            return dataContext.Disciplinas;
        }

        public override AbstractValidator<Disciplina> ObterValidador()
        {
            return new ValidadorDisciplina();
        }


        public override ValidationResult Inserir(Disciplina novaDisciplina)
        {

            var validator = ObterValidador();

            var resultadoValidacaoDisciplina = validator.Validate(novaDisciplina);


            if (resultadoValidacaoDisciplina.IsValid == false)
                return resultadoValidacaoDisciplina;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = conexaoComBanco;

            string sql = @"INSERT INTO [TBDISCIPLINA]
            (

                 [NOME]
                 
	        )

	            VALUES
                (
                    @NOME
           
                );
                    SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sql;
           
            ConfigurarParametrosDisciplina(novaDisciplina, comandoInsercao);

            conexaoComBanco.Open();
           
            var id = comandoInsercao.ExecuteScalar();
            
            novaDisciplina.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacaoDisciplina;
        }

        public override List<Disciplina> SelecionarTodos()
        {
            string sqlSelecionarTodos = 
                @"SELECT 
                        [NUMERO],

                        [NOME]

                FROM[TbDisciplina]";
            
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorDisciplina = comandoSelecao.ExecuteReader();

            List<Disciplina> disciplinas = new List<Disciplina>();

            while (leitorDisciplina.Read())
            {
                Disciplina disciplina = ConverterParaDisciplina(leitorDisciplina);

                disciplinas.Add(disciplina);
            }

            conexaoComBanco.Close();

            return disciplinas;
        }

        private Disciplina ConverterParaDisciplina(SqlDataReader leitorDisciplina)
        {
            int numero = Convert.ToInt32(leitorDisciplina["NUMERO"]);
            string nome = Convert.ToString(leitorDisciplina["NOME"]);
            

            var disciplina = new Disciplina
            {
                Numero = numero,
                Nome = nome,
               
            };

            return disciplina;
        }

        private void ConfigurarParametrosDisciplina(Disciplina novaDisciplina, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", novaDisciplina.Numero);
            comando.Parameters.AddWithValue("NOME", novaDisciplina.Nome);
        }

        public override ValidationResult Editar(Disciplina disciplina)
        {
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoBanco;

            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexaoComBanco;

            string sql = 
                @"UPDATE [TBDISCIPLINA]
	            SET			
	            	[NOME] = @NOME
                
	            WHERE 
	            	[NUMERO] = @NUMERO";

            comandoEdicao.CommandText = sql;

            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(disciplina);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            ConfigurarParametrosDisciplina(disciplina, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        

        }

        public override ValidationResult Excluir(Disciplina disciplina)
        {
            string sqlExcluir =
                @"DELETE FROM [TbDisciplina]
		            WHERE 
		             [NUMERO] = @NUMERO
                     ";
            
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", disciplina.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover a disciplina"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public override Disciplina SelecionarPorNumero(int numero)
        {
            string sqlSelecionarPorNumero =
                @"SELECT 
                	[NUMERO],
                	[NOME]
                
                FROM 
                	[TbDisciplina]
                
                WHERE 
                	[NUMERO] = @NUMERO
                ";
            
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorDisciplina = comandoSelecao.ExecuteReader();

            Disciplina disciplina = null;
            if (leitorDisciplina.Read())
                disciplina = ConverterParaDisciplina(leitorDisciplina);

            conexaoComBanco.Close();

            return disciplina;
        }
    }
}
