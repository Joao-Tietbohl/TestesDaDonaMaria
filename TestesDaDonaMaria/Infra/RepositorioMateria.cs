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
    public class RepositorioMateria : RepositorioBase<Materia>
    {
        private const string enderecoBanco =
              @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DonaMaria;Integrated Security=True;Pooling=False";

        public RepositorioMateria(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Materias.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }

        public override List<Materia> ObterRegistros()
        {
            return dataContext.Materias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }

        public override List<Materia> SelecionarTodos()
        {
            string sqlSelecionarTodos =
               @"SELECT 
                	MT.NUMERO,
                	MT.NOME,
                	MT.SERIE,
                	MT.DISCIPLINA_NUMERO,
                    D.NOME AS DISCIPLINA_NOME
                FROM	
                	TBMATERIA AS MT LEFT JOIN 
                	TBDISCIPLINA AS D ON 
                	MT.DISCIPLINA_NUMERO = D.NUMERO";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);

                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;

        }

        public override Materia SelecionarPorNumero(int numero)
        {
            string sqlSelecionarPorNumero =
               @"SELECT 
                	MT.NUMERO,
                	MT.NOME,
                	MT.SERIE,
                	MT.DISCIPLINA_NUMERO,
                    D.NOME AS DISCIPLINA_NOME
                FROM	
                	TBMATERIA AS MT LEFT JOIN 
                	TBDISCIPLINA AS D ON 
                	MT.DISCIPLINA_NUMERO = D.NUMERO
                
                WHERE 
                    MT.NUMERO = @NUMERO
                ";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia materia = null;
            if (leitorMateria.Read())
                materia = ConverterParaMateria(leitorMateria);

            conexaoComBanco.Close();

            return materia;
        }
        private Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            var numero = Convert.ToInt32(leitorMateria["NUMERO"]);
            var nome = Convert.ToString(leitorMateria["NOME"]);
            var serie = (Serie)leitorMateria["SERIE"];
            var numeroDisciplina = Convert.ToInt32(leitorMateria["DISCIPLINA_NUMERO"]);
            var nomeDisciplina = Convert.ToString(leitorMateria["DISCIPLINA_NOME"]);


            var materia = new Materia
            {
                Numero = numero,
                Nome = nome,
                Serie = serie,
                Disciplina = new Disciplina
                {
                    Numero = numeroDisciplina,
                    Nome = nomeDisciplina
                }
               
            };

            return materia;
        }

        public override ValidationResult Inserir(Materia novaMateria)
        {

            var validator = ObterValidador();

            var resultadoValidacaoMateria = validator.Validate(novaMateria);


            if (resultadoValidacaoMateria.IsValid == false)
                return resultadoValidacaoMateria;

            string sqlInsercao =
                @"INSERT INTO [TBMATERIA]
                        (
                         [NOME],
                         [SERIE],
                         [DISCIPLINA_NUMERO],
                         [DISCIPLINA_NOME])
                  VALUES
                        (
                         @NOME,
                         @SERIE,
                         @DISCIPLINA_NUMERO
                         @DISCIPLINA_NOME);
                    
                SELECT SCOPE_IDENTITY()";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInserir = new SqlCommand(sqlInsercao, conexaoComBanco);

            ConfigurarParametrosMateria(novaMateria, comandoInserir);


            conexaoComBanco.Open();

            var id = comandoInserir.ExecuteScalar();
            novaMateria.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacaoMateria;
        }
        public override ValidationResult Editar(Materia materia)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(enderecoBanco, conexaoComBanco);
     
            string sql =
                @"UPDATE   [TBMATERIA]
	            SET
	            	
	            	[NOME] = @NOME,
	            	[SERIE] = @SERIE,
	            	[DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO
	            	
	            WHERE 
	            	[NUMERO] = @NUMERO";

            comandoEdicao.CommandText = sql;

            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(materia);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            ConfigurarParametrosMateria(materia, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }
        public override ValidationResult Excluir(Materia materia)
        {
            string sqlExcluir =
               @"DELETE FROM [TbMateria]
		            WHERE 
		             [NUMERO] = @NUMERO
                     ";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", materia.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover a materia"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        private void ConfigurarParametrosMateria(Materia materia, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", materia.Numero);
            comando.Parameters.AddWithValue("NOME", materia.Nome);
            comando.Parameters.AddWithValue("SERIE", materia.Serie);
            comando.Parameters.AddWithValue("DISCIPLINA_NUMERO", materia.Disciplina.Numero);
            comando.Parameters.AddWithValue("DISCIPLINA_NOME", materia.Disciplina.Nome);


        }
    }
}
