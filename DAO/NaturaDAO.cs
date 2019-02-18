using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.DAO
{
    public class NaturaDAO
    {
        private IConfiguration _configuracoes;

        public NaturaDAO(IConfiguration config)
        {
            _configuracoes = config;
        }

        #region Verifica se existe alguma Release Ativa
        internal bool ExistReleaseAtiva_Natura()
        {
            bool captaAtivo = false;

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    int result = mysqlCon.Query<int>(@"SELECT count(*) FROM Sanity.release_natura WHERE status != 2;").First();

                    if (result != 0)
                    {
                        captaAtivo = true;
                    }
                }

            }
            catch (Exception)
            {
                captaAtivo = false;
            }

            return captaAtivo;
        }
        #endregion

        #region Select Releases Natura ativas
        internal List<NaturaRelease> GetReleasesAtiva_Natura()
        {
            List<NaturaRelease> releases = new List<NaturaRelease>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<NaturaRelease>("SELECT * FROM Sanity.release_natura WHERE status != 2 order by data_inicial;");

                    foreach (NaturaRelease item in result)
                    {
                        releases.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return releases;
        }
        #endregion

        #region Atualiza dados da release x da Natura
        internal void AtualizaRelease_Natura(NaturaRelease naturaRelease)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                string query = @"UPDATE Sanity.release_natura SET status = @status, data_inicial = @data_inicial, data_final = @data_final WHERE id_release = @id_release;";

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute(query, new {naturaRelease.status, naturaRelease.data_inicial, naturaRelease.data_final, naturaRelease.id_release});
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Lista com todas as releases da Natura
        internal List<NaturaRelease> ListRelease_Natura()
        {
            List<NaturaRelease> captas = new List<NaturaRelease>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<NaturaRelease>("SELECT * FROM Sanity.release_natura;");

                    foreach (NaturaRelease cenario in result)
                    {
                        captas.Add(cenario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return captas;
        }
        #endregion

        #region Cadastra uma nova Release da Natura
        internal void AddRelease_Natura(NaturaRelease naturaRelease)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute("INSERT INTO `Sanity`.`release_natura` (`cod_release`,`sistema`,`status`,`data_inicial`,`data_final`) VALUES (@cod_release,@sistema,@status,@data_inicial,@data_final);", new {naturaRelease.cod_release, naturaRelease.sistema, status = 0, naturaRelease.data_inicial, naturaRelease.data_final} );
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Adiciona um teste  a release da Natura
        internal void AddTest_Natura(NaturaTeste naturaTeste)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute("INSERT INTO `Sanity`.`testes_natura` (`cod_release`,`numero_teste`,`executor`,`execucao_status`,`chamado_status`,`sistema`,`cenario`,`pre_condicao`,`passos`,`result_esperado`,`pos_condicao`,`observacao`,data_execucao,funcionalidade,massa,url_doc) VALUES (@cod_release,@numero_teste,@executor,@execucao_status,@chamado_status,@sistema,@cenario,@pre_condicao,@passos,@result_esperado,@pos_condicao,@observacao,@data_execucao,@funcionalidade,@massa,@url_doc);", naturaTeste);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Lista de testes 
        internal List<NaturaTeste> ListaTestes_Natura(string codRelease)
        {
            List<NaturaTeste> natura = new List<NaturaTeste>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                string query = @"SELECT * FROM Sanity.testes_natura t
                                 WHERE t.cod_release = @codRelease;";

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<NaturaTeste>(query,new { codRelease });

                    foreach (NaturaTeste cenario in result)
                    {
                        natura.Add(cenario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return natura;
        }
        #endregion

        #region Carrega teste x
        internal NaturaTeste Teste_Natura(int idTeste)
        {
            NaturaTeste teste = new NaturaTeste();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    teste = mysqlCon.Query<NaturaTeste>("SELECT * FROM Sanity.testes_natura WHERE id_natura_teste = @idTeste;", new {idTeste}).SingleOrDefault();
                }

            }
            catch (Exception)
            {

            }

            return teste;
        }
        #endregion

        #region Atualiza teste x
        internal void AtualizaTeste_Natura(NaturaTeste teste)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                string query = @"UPDATE Sanity.testes_natura
                                SET
                                    executor = @executor,
                                    execucao_status = @execucao_status,
                                    chamado_status = @chamado_status,
                                    sistema = @sistema,
                                    cenario = @cenario,
                                    pre_condicao = @pre_condicao,
                                    passos = @passos,
                                    result_esperado = @result_esperado,
                                    pos_condicao = @pos_condicao,
                                    observacao = @observacao,
                                    data_execucao = @data_execucao,
                                    data_executado = @data_executado,
                                    url_doc = @url_doc
                                WHERE id_natura_teste = @id_natura_teste;";

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute(query,teste);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Lista de teste por id da Release
        internal List<NaturaTeste> TestesByIdRelease_Natura(int idRelease)
        {
            List<NaturaTeste> natura = new List<NaturaTeste>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                string query = @"SELECT * FROM Sanity.testes_natura t
                                Join Sanity.release_natura c on t.cod_release = c.cod_release
                                WHERE c.id_release = @idRelease ;";

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<NaturaTeste>(query,new {idRelease});

                    foreach (NaturaTeste cenario in result)
                    {
                        natura.Add(cenario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return natura;
        }
        #endregion
        
        #region Retorna o ID para gerar o codigo da release
        internal int GetMaxId_Release()
        {
            int maxId = 0;
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    maxId = mysqlCon.Query<int>("SELECT max(id_release) FROM Sanity.release_natura;").SingleOrDefault();
                }

            }
            catch (Exception)
            {

            }

            return maxId + 1;
        }
        #endregion

        #region Deleta teste
        internal Task DeletaTeste_Natura(string codRelease, int nTeste)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                string query = @"CALL Sanity.procDeletaTeste_Natura(@codRelease,@nTeste);";

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute(query, new { codRelease, nTeste });
                }
            }
            catch (Exception)
            {

            }

             return Task.FromResult<object>(null);
        }
        #endregion
    }
}
