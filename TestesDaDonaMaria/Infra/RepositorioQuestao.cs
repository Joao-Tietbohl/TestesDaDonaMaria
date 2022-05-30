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
    public class RepositorioQuestao : RepositorioBase<Questao>
    {
        private const string enderecoBanco =
            @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DonaMaria;Integrated Security=True;Pooling=False";


        public RepositorioQuestao(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Questoes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Numero);
        }
        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }

        public List<Questao> SelecionarTodosPorMateria(List<Questao>registros ,Materia materia)
        {
            List<Questao> lista = new List<Questao>();

            foreach (var q in registros)
            {
                if (q.Materia == materia)
                    lista.Add(q);
            }

            return lista;
        }

        public override ValidationResult Inserir(Questao novaQuestao)
        {
            var validator = ObterValidador();

            var resultadoValidacaoMateria = validator.Validate(novaQuestao);


            if (resultadoValidacaoMateria.IsValid == false)
                return resultadoValidacaoMateria;

            string sqlInsercao =
                @"INSERT INTO [TBQUESTAO]
                (
	                [ENUNCIADO],
	                [MATERIA_NUMERO]
                )
                VALUES
                (
                    @ENUNCIADO,
                    @MATERIA_NUMERO
                );

                SELECT SCOPE_IDENTITY()";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInserir = new SqlCommand(sqlInsercao, conexaoComBanco);

            ConfigurarParametrosMateria(novaQuestao, comandoInserir);


            conexaoComBanco.Open();

            var id = comandoInserir.ExecuteScalar();
            novaQuestao.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();


            return resultadoValidacaoMateria;
        }

        private void ConfigurarParametrosMateria(Questao questao, SqlCommand comando)
        {

            comando.Parameters.AddWithValue("NUMERO", questao.Numero);
            comando.Parameters.AddWithValue("PERGUNTA", questao.Enunciado);
            comando.Parameters.AddWithValue("MATERIA_NUMERO", questao.Materia.Numero);
        }

        public override List<Questao> SelecionarTodos()
        {
            string sqlSelecionarTodos =
              @"SELECT 
                Q.NUMERO AS NUMERO,
	            Q.ENUNCIADO AS ENUNCIADO,
	            M.NUMERO AS MATERIA_NUMERO,
	            M.NOME AS MATERIA_NOME
	           

            FROM TBQUESTAO AS Q

            LEFT JOIN TBMATERIA AS M

            ON Q.MATERIA_NUMERO = M.NUMERO";

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestao = comandoSelecao.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestao.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestao);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        private Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            throw new NotImplementedException();
        }
    }
}
