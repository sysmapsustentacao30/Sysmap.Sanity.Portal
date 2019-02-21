using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Sysmap.Portal.Sanity.Models;

namespace Sysmap.Portal.Sanity.DAO
{
    public class NaturaDAO
    {
        private IConfiguration _configuracoes;
        private readonly ILogger _logger;

        public NaturaDAO(IConfiguration config, ILogger<NaturaDAO> logger)
        {
            _logger = logger;
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
            catch (Exception ex)
            {
                captaAtivo = false;
                _logger.LogError("Erro: {0}", ex);
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
                _logger.LogInformation("Natura - Pegando releases ativas");

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
                _logger.LogError("Erro: {0}", ex);
            }

            return releases;
        }
        #endregion

        #region Select Release x
        internal NaturaRelease GetRelease(string codRelease)
        {
            NaturaRelease release = new NaturaRelease();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    release = mysqlCon.Query<NaturaRelease>("SELECT * FROM Sanity.release_natura WHERE cod_release = @codRelease;", new { codRelease }).SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
            }

            return release;
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
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
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
                _logger.LogError("Erro: {0}", ex);
            }

            return captas;
        }
        #endregion

        #region Cadastra uma nova Release da Natura
        internal void AddRelease_Natura(NaturaRelease naturaRelease)
        {
            try
            {
                _logger.LogInformation("Natura - Cadastrando release: {0} /n Ambiente: {1}, Status: {2}, Data Inicial: {3}, Data Final: {4}", naturaRelease.cod_release,naturaRelease.sistema,naturaRelease.status,naturaRelease.data_inicial,naturaRelease.data_final);

                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute("INSERT INTO `Sanity`.`release_natura` (`cod_release`,`sistema`,`status`,`data_inicial`,`data_final`) VALUES (@cod_release,@sistema,@status,@data_inicial,@data_final);", new {naturaRelease.cod_release, naturaRelease.sistema, status = 0, naturaRelease.data_inicial, naturaRelease.data_final} );
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
            }
        }
        #endregion

        #region Adiciona um teste  a release da Natura
        internal void AddTest_Natura(NaturaTeste naturaTeste)
        {
            try
            {
                _logger.LogInformation("Natura - Add Teste na release cod: {0}", naturaTeste.cod_release);
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute("INSERT INTO `Sanity`.`testes_natura` (`cod_release`,`numero_teste`,`executor`,`execucao_status`,`chamado_status`,`sistema`,`cenario`,`pre_condicao`,`passos`,`result_esperado`,`pos_condicao`,`observacao`,data_execucao,funcionalidade,massa,url_doc) VALUES (@cod_release,@numero_teste,@executor,@execucao_status,@chamado_status,@sistema,@cenario,@pre_condicao,@passos,@result_esperado,@pos_condicao,@observacao,@data_execucao,@funcionalidade,@massa,@url_doc);", naturaTeste);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
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
                _logger.LogError("Erro: {0}", ex);
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
                _logger.LogInformation("Natura carregando teste id: {0}", idTeste.ToString());

                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    teste = mysqlCon.Query<NaturaTeste>("SELECT * FROM Sanity.testes_natura WHERE id_natura_teste = @idTeste;", new {idTeste}).SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
            }
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
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
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
            catch (Exception ex)
            {
                _logger.LogError("Erro: {0}", ex);
            }

             return Task.FromResult<object>(null);
        }
        #endregion
    }
}
