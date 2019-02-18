using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sysmap.Portal.Sanity.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Sysmap.Portal.Sanity.DAO
{
    public class VivoDAO
    {
        private IConfiguration _configuracoes;

        public VivoDAO(IConfiguration config)
        {
            _configuracoes = config;
        }
        #region Release
        internal dynamic ReleaseAtivaVivo()
        {
            bool releaseAtiva = false;
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    int result = mysqlCon.Query<int>(@"SELECT count(*) FROM Sanity.`Release` Where Status = 0;").First();

                    if (result == 1)
                    {
                        releaseAtiva = true;
                    }
                }

            }
            catch (Exception)
            {
                releaseAtiva = false;
            }

            return releaseAtiva;
        }

        internal VivoRelease GetReleaseVivoAtiva()
        {
            VivoRelease vivoRelease = new VivoRelease();
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mysqlCon = new MySqlConnection(ConnectionString))
                {
                    vivoRelease = mysqlCon.Query<VivoRelease>(@"SELECT * FROM Sanity.`Release` Where Status = 0;").First();
                }

            }
            catch (Exception)
            {
                
            }

            return vivoRelease;
        }

        internal List<VivoRelease> GetListReleaseVivo()
        {
            List<VivoRelease> vivoRelease = new List<VivoRelease>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<VivoRelease>("SELECT * FROM Sanity.`Release`;");

                    foreach (VivoRelease cenario in result)
                    {
                        vivoRelease.Add(cenario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vivoRelease;
        }

        internal List<VivoCenarios> GetCenariosVivo_CodRelease(int codRelease)
        {
            List<VivoCenarios> vivoCenarios = new List<VivoCenarios>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<VivoCenarios>("SELECT * FROM Sanity.Cenarios WHERE CodRelease = @CodRelease;",new { CodRelease = codRelease});

                    foreach (VivoCenarios cenario in result)
                    {
                        vivoCenarios.Add(cenario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vivoCenarios;
        }

        internal void AtualizaReleaseVivo(VivoRelease vivoRelease)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (MySqlConnection mySqlCon = new MySqlConnection(ConnectionString))
                {
                    var param = new { Status = vivoRelease.Status, CodRelease = vivoRelease.CodRelease };
                    mySqlCon.Execute("UPDATE `Sanity`.`Release` SET `Status` = @Status WHERE `CodRelease` = @CodRelease;", param);
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Cenarios
        internal List<VivoCenarios> GetListCenariosVivo()
        {
            List<VivoCenarios> vivoCenarios = new List<VivoCenarios>();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    var result = mysqlCon.Query<VivoCenarios>("CALL `Sanity`.`procGetRelease`();");

                    foreach (VivoCenarios cenario in result)
                    {
                        vivoCenarios.Add(cenario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vivoCenarios;
        }

        internal VivoCenarios GetCenarioVivo(int nCenario)
        {
            VivoCenarios vivoCenario = new VivoCenarios();

            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                   vivoCenario = mysqlCon.Query<VivoCenarios>("CALL `Sanity`.`procGetCenario`(@Cenario);",new {Cenario = nCenario}).SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vivoCenario;
        }

        internal void CriaCenarioVivo(VivoCenarios vivoCenarios)
        {
            try
            {
                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute("INSERT INTO `Sanity`.`Cenarios` (`CodRelease`,`Excluido`,`Cenario`,`Prioridade`,`Demanda`,`Tipo`,`Analista`,`Login`,`Senha`,`Status`,`Executado`,`Sistema`,`Plataforma`,`Funcionalidade`,`Size`,`TipoTeste`,`Descricao`,`ResultEsperado`,`TipoMassa`,`Massa`,`Documento`,`ICCID`,`SolicGerada`,`LinhaGerada`,`Observacao`) VALUES (@CodRelease,@Excluido,@Cenario, @Prioridade, @Demanda, @Tipo, @Analista, @Login, @Senha, @Status, @Executado, @Sistema, @Plataforma, @Funcionalidade, @Size, @TipoTeste, @Descricao, @ResultEsperado, @TipoMassa, @Massa, @Documento, @IccID, @SolicGerada, @LinhaGerada, @Observacao);", vivoCenarios);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void AtualizaCenarioVivo(VivoCenarios vivoCenario)
        {
            try
            {
                var query = @"UPDATE Sanity.Cenarios 
                                SET Cenario = @Cenario, 
	                                Prioridade = @Prioridade, 
	                                Demanda = @Demanda, 
	                                Tipo = @Tipo, 
	                                Analista = @Analista, 
	                                Login = @Login, 
	                                Senha = @Senha, 
	                                Status = @Status, 
	                                Executado = @Executado, 
	                                Sistema = @Sistema, 
	                                Plataforma = @Plataforma, 
	                                Funcionalidade = @Funcionalidade, 
	                                Size = @Size, 
	                                TipoTeste = @TipoTeste, 
	                                Descricao = @Descricao, 
	                                ResultEsperado = @ResultEsperado, 
	                                TipoMassa = @TipoMassa, 
	                                Massa = @Massa, 
	                                Documento = @Documento, 
	                                ICCID = @IccID, 
	                                SolicGerada = @SolicGerada, 
	                                LinhaGerada = @LinhaGerada, 
	                                Observacao = @Observacao 
                            WHERE Cenario = @Cenario
                                  AND Excluido = 0
                                  AND CodRelease = @CodRelease";

                string ConnectionString = _configuracoes.GetConnectionString("Sanity");

                using (var mysqlCon = new MySqlConnection(ConnectionString))
                {
                    mysqlCon.Execute(query, vivoCenario);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
