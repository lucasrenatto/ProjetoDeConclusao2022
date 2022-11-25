using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using TCC.Domain.Entity;
using System.Activities.Expressions;
using MySql.Data.MySqlClient;

namespace TCC.Repository
{
    public class ReclamacaoRepository : BaseRepository
    {
        public async Task<List<ReclamacoesEntity>> BuscarTodas()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT 
                                       c.ID,
                                       c.AreaID,
                                       c.Descricao,
                                       c.Rua,
                                       c.Bairro,
                                       c.Cidade,
                                       c.DataHora,
                                       c.Estado,
                                       c.NomeUsuario,
                                       c.Imagem,
                                       c.Ativa,
                                       a.Descricao 'Area'
                                   FROM
                                   	reclamacao c
                                   LEFT JOIN
                                   	area a ON c.AreaID = a.ID";

                List<ReclamacoesEntity> listaReclamacoes = new List<ReclamacoesEntity>();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    ReclamacoesEntity reclamacao = new ReclamacoesEntity()
                    {
                        Cidade = GetString(reader, "Cidade"),
                        AreaID = GetInt(reader, "AreaID"),
                        DataHora = GetDateTime(reader, "DataHora"),
                        Area = new AreaEntity()
                        {
                            Descricao = GetString(reader, "Area")
                        },
                        Descricao = GetString(reader, "Descricao"),
                        Ativa = GetBool(reader, "Ativa"),
                        Estado = GetString(reader, "Estado"),
                        NomeUsuario = GetString(reader, "NomeUsuario"),
                        Rua = GetString(reader, "Rua"),
                        ID = GetInt(reader, "ID")
                    };
                    listaReclamacoes.Add(reclamacao);
                }
                conn.Close();
                return listaReclamacoes;

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<List<ReclamacoesEntity>> BuscarTodasAtivas()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT 
                                       c.ID,
                                       c.AreaID,
                                       c.Descricao,
                                       c.Rua,
                                       c.Bairro,
                                       c.Cidade,
                                       c.DataHora,
                                       c.Estado,
                                       c.NomeUsuario,
                                       c.Imagem,
                                       c.Ativa,
                                       a.Descricao 'Area'
                                   FROM
                                   	reclamacao c
                                   LEFT JOIN
                                   	area a ON c.AreaID = a.ID
                                   Where c.Ativa = 1";

                List<ReclamacoesEntity> listaReclamacoes = new List<ReclamacoesEntity>();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    ReclamacoesEntity reclamacao = new ReclamacoesEntity()
                    {
                        Cidade = GetString(reader, "Cidade"),
                        AreaID = GetInt(reader, "AreaID"),
                        DataHora = GetDateTime(reader, "DataHora"),
                        Area = new AreaEntity()
                        {
                            Descricao = GetString(reader, "Area")
                        },
                        Descricao = GetString(reader, "Descricao"),
                        Ativa = GetBool(reader, "Ativa"),
                        Estado = GetString(reader, "Estado"),
                        NomeUsuario = GetString(reader, "NomeUsuario"),
                        Rua = GetString(reader, "Rua"),
                        ID = GetInt(reader, "ID")
                    };
                    listaReclamacoes.Add(reclamacao);
                }
                conn.Close();
                return listaReclamacoes;

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<ReclamacoesEntity> BuscarPorID(int ID)
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT 
                                       c.ID,
                                       c.AreaID,
                                       c.Descricao,
                                       c.Rua,
                                       c.Bairro,
                                       c.Cidade,
                                       c.DataHora,
                                       c.Estado,
                                       c.NomeUsuario,
                                       c.Imagem,
                                       c.Ativa,
                                       a.Descricao 'Area'
                                   FROM
                                   	reclamacao c
                                   LEFT JOIN
                                   	area a ON c.AreaID = a.ID
                                   Where c.ID = @id";

                ReclamacoesEntity reclamacao = new ReclamacoesEntity();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    reclamacao = new ReclamacoesEntity()
                    {
                        Cidade = GetString(reader, "Cidade"),
                        AreaID = GetInt(reader, "AreaID"),
                        DataHora = GetDateTime(reader, "DataHora"),
                        Area = new AreaEntity()
                        {
                            Descricao = GetString(reader, "Area")
                        },
                        Descricao = GetString(reader, "Descricao"),
                        Ativa = GetBool(reader, "Ativa"),
                        Estado = GetString(reader, "Estado"),
                        NomeUsuario = GetString(reader, "NomeUsuario"),
                        Rua = GetString(reader, "Rua"),
                        ID = GetInt(reader, "ID")
                    };
                }
                conn.Close();
                return reclamacao;

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task ConcluirReclamacao(int ID)
        {
            string myConnectionString;
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"UPDATE reclamacao
                                SET Ativa = 0
                                   Where ID = @id";

                ReclamacoesEntity reclamacao = new ReclamacoesEntity();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<List<ReclamacoesEntity>> BuscarTodasConcluidas()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT 
                                       c.ID,
                                       c.AreaID,
                                       c.Descricao,
                                       c.Rua,
                                       c.Bairro,
                                       c.Cidade,
                                       c.DataHora,
                                       c.Estado,
                                       c.NomeUsuario,
                                       c.Imagem,
                                       c.Ativa,
                                       a.Descricao 'Area'
                                   FROM
                                   	reclamacao c
                                   LEFT JOIN
                                   	area a ON c.AreaID = a.ID
                                    Where c.Ativa = 0";

                List<ReclamacoesEntity> listaReclamacoes = new List<ReclamacoesEntity>();
                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    ReclamacoesEntity reclamacao = new ReclamacoesEntity()
                    {
                        Cidade = GetString(reader, "Cidade"),
                        AreaID = GetInt(reader, "AreaID"),
                        DataHora = GetDateTime(reader, "DataHora"),
                        Area = new AreaEntity()
                        {
                            Descricao = GetString(reader, "Area")
                        },
                        Descricao = GetString(reader, "Descricao"),
                        Ativa = GetBool(reader, "Ativa"),
                        Estado = GetString(reader, "Estado"),
                        NomeUsuario = GetString(reader, "NomeUsuario"),
                        Rua = GetString(reader, "Rua"),
                        ID = GetInt(reader, "ID")
                    };
                    listaReclamacoes.Add(reclamacao);
                }
                conn.Close();
                return listaReclamacoes;

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<int> BuscarSAE()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT COUNT(a.Descricao)	 AS Quantidade		
                                   FROM
                                   	reclamacao c
                                   INNER JOIN
                                   	area a ON c.AreaID = a.ID WHERE a.Descricao = 'SAE'";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int quantidade = 0;
                while (await reader.ReadAsync())
                {
                    quantidade = GetInt(reader, "Quantidade");
                }
                conn.Close();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<int> BuscarCFPL()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT COUNT(a.Descricao)	 AS Quantidade		
                                   FROM
                                   	reclamacao c
                                   INNER JOIN
                                   	area a ON c.AreaID = a.ID WHERE a.Descricao = 'CFPL'";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int quantidade = 0;
                while (await reader.ReadAsync())
                {
                    quantidade = GetInt(reader, "Quantidade");
                }
                conn.Close();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<int> BuscarSaude()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT COUNT(a.Descricao)	 AS Quantidade		
                                   FROM
                                   	reclamacao c
                                   INNER JOIN
                                   	area a ON c.AreaID = a.ID WHERE a.Descricao = 'Saúde'";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int quantidade = 0;
                while (await reader.ReadAsync())
                {
                    quantidade = GetInt(reader, "Quantidade");
                }
                conn.Close();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
        public async Task<int> BuscarOutros()
        {
            string myConnectionString;

            myConnectionString = "Server=http://a2nlmysql41plsk.secureserver.net:3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            myConnectionString = "Server=a2nlmysql41plsk.secureserver.net; Port=3306; Database=RockLTdb; Uid=RockLT; Pwd=rPvdutAHt7XLZKp;";
            try
            {
                MySqlConnection conn = new MySqlConnection(myConnectionString);
                conn.Open();
                var command = @"SELECT COUNT(a.Descricao)	 AS Quantidade		
                                   FROM
                                   	reclamacao c
                                   INNER JOIN
                                   	area a ON c.AreaID = a.ID WHERE a.Descricao <> 'SAE'
                                    AND a.Descricao <> 'CFPL' AND a.Descricao <> 'Saúde' ";

                MySqlCommand cmd = new MySqlCommand(command, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int quantidade = 0;
                while (await reader.ReadAsync())
                {
                    quantidade = GetInt(reader, "Quantidade");
                }
                conn.Close();
                return quantidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao Realizar a operação no banco de dados | {ex.Message}");
            }
        }
    }
}
