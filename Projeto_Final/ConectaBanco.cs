using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Projeto_Final
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost; port=3306; User Id=root; password=963852741; database=banco_arkiver");
        public string mensagem;

        public bool verifica(string user, string pass)
        {
            string senhaHash = BibliotecaHash.makeHash(pass);
            MySqlCommand cmd = new MySqlCommand("sp_ConsultaLogin", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("loginUser", user);
            cmd.Parameters.AddWithValue("loginPass", senhaHash);
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }//fim verifica

        public DataTable listaGeneros()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaGeneros", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_generos 

        public bool InserirGenero(string nomeGenero)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_InserirGenero", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("nomeGenero", nomeGenero);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }

        }// fim do insereGenero


        public bool insereGame(Jogo novoJogo)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_inserirGame", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nome", novoJogo.Nome);
                cmd.Parameters.AddWithValue("p_fk_plataforma", novoJogo.Fk_plataforma);
                cmd.Parameters.AddWithValue("p_fk_genero", novoJogo.Fk_genero);
                cmd.Parameters.AddWithValue("p_desenvolvedora", novoJogo.Desenvolvedora);
                cmd.Parameters.AddWithValue("p_ano_lancamento", novoJogo.Ano_lancamento);
                cmd.Parameters.AddWithValue("p_nota", novoJogo.Nota);
                cmd.Parameters.AddWithValue("p_observacao", novoJogo.Observacao);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }//fim insereGame

        public DataTable listaGames()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarGames", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }//fim listaGames

        public DataTable listaPlataformas()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaPlataformas", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool deletaGame(int idRemoveGame)
        {
            MySqlCommand cmd = new MySqlCommand("sp_removeGame", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_idjogos", idRemoveGame);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool RemoveGenero(int idGenero)
        {
            MySqlCommand cmd = new MySqlCommand("sp_removeGenero", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_idgenero", idGenero);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                if (erro.Number == 1451)
                    mensagem = "Não é possível excluir este gênero pois existem jogos cadastrados com ele.";
                else
                    mensagem = "Erro ao excluir gênero: " + erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }   

        public bool alteraGame(Jogo jogoAlterado, int idGame)
        {
            MySqlCommand cmd = new MySqlCommand("sp_alteraGame", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_idjogos", idGame);
            cmd.Parameters.AddWithValue("p_nome", jogoAlterado.Nome);
            cmd.Parameters.AddWithValue("p_fk_plataforma", jogoAlterado.Fk_plataforma);
            cmd.Parameters.AddWithValue("p_fk_genero", jogoAlterado.Fk_genero);
            cmd.Parameters.AddWithValue("p_desenvolvedora", jogoAlterado.Desenvolvedora);
            cmd.Parameters.AddWithValue("p_ano_lancamento", jogoAlterado.Ano_lancamento);
            cmd.Parameters.AddWithValue("p_nota", jogoAlterado.Nota);
            cmd.Parameters.AddWithValue("p_observacao", jogoAlterado.Observacao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro: " + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}
