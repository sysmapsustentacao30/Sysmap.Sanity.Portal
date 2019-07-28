using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Sysmap.Portal.Sanity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sysmap.Portal.Sanity.DAO
{
    public class VivoDAO
    {
        private IConfiguration _configuracoes;
        private readonly ILogger _logger;

        public VivoDAO(IConfiguration config, ILogger<VivoDAO> logger)
        {
            _configuracoes = config;
            _logger = logger;
        }

        #region Pegando releases ativas
        internal List<VivoRelease> GetReleasesVivoAtivas()
        {
            List<VivoRelease> vivoRelease = new List<VivoRelease>();
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    vivoRelease = mysqlCon.Query<VivoRelease>(@"SELECT * FROM Sanity.`Release` Where Status = 0;").ToList();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return vivoRelease;
        }
        #endregion

        #region Lista com todas as releases.
        internal List<VivoRelease> GetListReleaseVivo()
        {
            List<VivoRelease> vivoRelease = new List<VivoRelease>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    vivoRelease = mysqlCon.Query<VivoRelease>("SELECT * FROM Sanity.`Release`;").ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return vivoRelease;
        }
        #endregion

        #region Atualiza status da release
        internal void AtualizaReleaseVivo(string codRelease, int status)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                {
                    var param = new { Status = status, CodRelease = codRelease };
                    mySqlCon.Execute("UPDATE `Sanity`.`Release` SET `Status` = @Status WHERE `CodRelease` = @CodRelease;", param);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        #endregion

        #region Deleta os dados da release
        internal void DeletaReleaseVivo(string codRelease)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                {
                    mySqlCon.Execute("DELETE FROM Sanity.Release WHERE CodRelease = @CodRelease;", new { CodRelease = codRelease });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                {
                    mySqlCon.Execute("DELETE FROM Sanity.TestesVivo WHERE CodRelease = @CodRelease;", new { CodRelease = codRelease });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
            #endregion

        #region Inserindo dados da release
        internal bool InsertReleaseVivo(VivoRelease vivoRelease)
        {
            bool insertSucess = true;
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                {
                    var param = new { CodRelease = vivoRelease.CodRelease, DataRelease = vivoRelease.DataRelease };
                    mySqlCon.Execute("INSERT INTO `Sanity`.`Release` (`CodRelease`,`DataRelease`) VALUES (@CodRelease,@DataRelease);", param);
                }
            }
            catch (Exception ex)
            {
                insertSucess = false;
                _logger.LogError(ex.Message);
            }

            return insertSucess;
        }
        #endregion

        #region Insert Lista de Testes
        internal void InsertTestesVivo(List<TestesVivo> listTeste)
        {
            foreach (var teste in listTeste)
            {
                try
                {
                    string insertQuery = @"INSERT INTO Sanity.TestesVivo
                                            (`IdRelease`,
                                            `CodRelease`,
                                            `Cenario`,
                                            `Excluido`,
                                            `Prioridade`,
                                            `Demanda`,
                                            `Analista`,
                                            `Login`,
                                            `Senha`,
                                            `Status`,
                                            `Sistema`,
                                            `Plataforma`,
                                            `Funcionalidade`,
                                            `Size`,
                                            `TipoTeste`,
                                            `Descricao`,
                                            `ResultEsperado`,
                                            `TipoMassa`,
                                            `Massa`,
                                            `Documento`,
                                            `ICCID`,
                                            `LinhaGerada`,
                                            `SolicGerada`,
                                            `Observacao`)
                                        VALUES
                                            (@IdRelease,
                                            @CodRelease,
                                            @Cenario,
                                            @Excluido,
                                            @Prioridade,
                                            @Demanda,
                                            @Analista,
                                            @Login,
                                            @Senha,
                                            @Status,
                                            @Sistema,
                                            @Plataforma,
                                            @Funcionalidade,
                                            @Size,
                                            @TipoTeste,
                                            @Descricao,
                                            @ResultEsperado,
                                            @TipoMassa,
                                            @Massa,
                                            @Documento,
                                            @ICCID,
                                            @LinhaGerada,
                                            @SolicGerada,
                                            @Observacao);";

                    string ConnectionString = _configuracoes.GetConnectionString("Sanity");
                    using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                    {
                        mySqlCon.Execute(insertQuery, teste);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

        }
        #endregion

        #region Lista de testes de uma Release
        internal List<TestesVivo> ListaTestesVivo(int idRelease)
        {
            List<TestesVivo> vivoTestes = new List<TestesVivo>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    vivoTestes = mysqlCon.Query<TestesVivo>("SELECT * FROM Sanity.TestesVivo Where IdRelease = @IdRelease",new { IdRelease = idRelease}).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return vivoTestes;
        }
        #endregion

        #region Pegando dados do teste por id
        internal TestesVivo GetTesteVivo(int idTeste)
        {
            TestesVivo testeVivo = new TestesVivo();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    testeVivo = mysqlCon.Query<TestesVivo>("SELECT * FROM Sanity.TestesVivo Where IdTeste = @IdTeste", new { IdTeste = idTeste }).First();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return testeVivo;
        }
        #endregion

        #region Atualiza os dados do teste
        internal void UpdateTesteVivo(TestesVivo teste)
        {
            try
            {
                string updateQuery = @"UPDATE Sanity.TestesVivo
                                       SET
	                                        Analista = @Analista,
	                                        Login = @Login,
	                                        Senha = @Senha,
	                                        Demanda = @Demanda,
	                                        Sistema = @Sistema,
	                                        Plataforma = @Plataforma,
	                                        TipoTeste = @TipoTeste,
	                                        Funcionalidade = @Funcionalidade,
	                                        Descricao = @Descricao,
	                                        ResultEsperado = @ResultEsperado,
	                                        TipoMassa = @TipoMassa,
	                                        Massa = @Massa,
	                                        Documento = @Documento,
	                                        ICCID = @ICCID,
	                                        LinhaGerada = @LinhaGerada,
	                                        SolicGerada = @SolicGerada,
	                                        Status = @Status,
	                                        Observacao = @Observacao
                                       WHERE IdTeste = @IdTeste;";

                string ConnectionString = _configuracoes.GetConnectionString("Sanity");
                using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                {
                    mySqlCon.Execute(updateQuery, teste);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        #endregion
    }
}
