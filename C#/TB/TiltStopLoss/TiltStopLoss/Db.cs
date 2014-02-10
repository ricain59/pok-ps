using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Windows.Forms;

namespace TiltStopLoss
{
    public class Db
    {
        private String user;
        private String server;
        private String port;
        private String password;
        private String database;
        private String connstring;
        public NpgsqlConnection conn;
        private String player;

        /// <summary>
        /// Aqui obtenho os dados de connexão a DB
        /// </summary>
        /// <param name="user"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="password"></param>
        /// <param name="Db"></param>
        /// <param name="player"></param>
        public void getData(String user, String server, String port, String password, String Db, String player)
        {
            this.player = player;
            this.user = user;
            this.server = server;
            this.port = port;
            this.password = password;
            this.database = Db;
            this.connstring = String.Format("Server={0};Port={1};" +
                            "User Id={2};Password={3};Database={4};",
                            server, port, user, password, database);
        }
        
        /// <summary>
        /// Para testat a connexão a DB
        /// </summary>
        /// <returns></returns>
        public String testconnectDb()
        {
            try
            {
                //PostgeSQL-style connection string
                conn = new NpgsqlConnection(connstring);
                
                conn.Open();
                conn.Close();
                return "";
            }
            catch (Exception msg)
            {
                return msg.ToString();
            }
        }

        /// <summary>
        /// Ligo me a DB
        /// </summary>
        /// <returns></returns>
        public String connectDb()
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                return "";
            }
            catch (Exception msg)
            {
                return msg.ToString();
            }
        }

        /// <summary>
        /// Fecho a ligação a DB
        /// </summary>
        /// <returns></returns>
        public String closeconDb()
        {
            try
            {
                conn.Close();
                return "";
            }
            catch (Exception msg)
            {
                return msg.ToString();
            }
        }

        /// <summary>
        /// Ir buscar o ultimo id de uma coluna de uma tabela
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Int64 getLastValue(String table, String column)
        {
            string sql = "select * from " + table + " order by " + column + " desc limit 1;";
            // data adapter making request from our connection
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            // Execute the query and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            // Output rows
            Int64 lastline = 0;
            while (dr.Read())
            {
                lastline = Convert.ToInt64(dr[0]);                
                break;
            }
            dr.Close();
            return lastline;
        }

        /// <summary>
        /// Permite ir buscar uma mão
        /// </summary>
        /// <param name="hhid"></param>
        /// <returns></returns>
        public String getHand(Int64 hhid, String table, String column2, String column1)
        {
            string sql = "select "+column1+" from " + table + " where " + column2 + " = " + hhid;
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            String hand = "";
            while (dr.Read())
            {
                hand = dr[0].ToString();
                break;
            }
            dr.Close();
            return hand;
        }

        /// <summary>
        /// Vou buscar a soma total da BBs de um mês.
        /// Hem2
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="yearmonth"></param>
        /// <returns></returns>
        public Double getSumBB(String playerid, String yearmonth)
        {
            //string sql = "select sum(totalbbswon) as bbtotal from compiledplayerresults where player_id = "+playerid+" and playedyearandmonth >= "+yearmonth;
            string sql = "select sum(totalbbswon) as bbtotal "+
                         "from compiledplayerresults "+ 
                         "where player_id = "+playerid+" and playedyearandmonth >= "+yearmonth+" and gametype_id in "+
                         "(select gametype_id "+ 
						  "from gametypes "+
						  "where istourney = false)";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            Double bb = 0.0;
            while (dr.Read())
            {
                if (dr[0].ToString().Equals(""))
                {
                    dr.Close();
                    return 0.0;
                }
                else
                {
                    bb = Convert.ToDouble(dr[0].ToString());                    
                }
                break;
            }
            dr.Close();
            return bb/100;
        }

        /// <summary>
        /// Vou buscar a soma total da BBs de um mês.
        /// PT4
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="yearmonth"></param>
        /// <returns></returns>
        public Double getSumBBPt4(String playerid, String yearmonth)
        {
            string sql = "select sum(amt_bb_won) as bbtotal " +
                         "from cash_cache " +
                         "where id_player = " + playerid + " and date_played_year_week >= " + yearmonth;
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            Double bb = 0.0;
            while (dr.Read())
            {
                if (dr[0].ToString().Equals(""))
                {
                    dr.Close();
                    return 0.0;
                }
                else
                {
                    bb = Convert.ToDouble(dr[0].ToString());
                }
                break;
            }
            dr.Close();
            return bb;
        }

        /// <summary>
        /// Vou buscar a soma total da BBs de um mês.
        /// Hem1
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="yearmonth"></param>
        /// <returns></returns>
        public Double getSumBBHem1(String playerid, String yearmonth)
        {
            //string sql = "select sum(totalbbswon) as bbtotal from compiledplayerresults where player_id = "+playerid+" and playedyearandmonth >= "+yearmonth;
            string sql = "select sum(cpm.totalbbswon) as bbtotal " +
                         "from compiledresults_month crm, compiledplayerresults_month cpm " +
                         "where crm.player_id = " + playerid + " and crm.playedonmonth >= " + yearmonth + " and " +
                         "crm.compiledplayerresults_id = cpm.compiledplayerresults_id and crm.gametype_id in " +
                            "(select gametype_id " +
                             "from gametypes " +
                             "where istourney = false)";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            Double bb = 0.0;
            while (dr.Read())
            {
                if (dr[0].ToString().Equals(""))
                {
                    dr.Close();
                    return 0.0;
                }
                else
                {
                    bb = Convert.ToDouble(dr[0].ToString());
                }
                break;
            }
            dr.Close();
            return bb / 100;
        }

        /// <summary>
        /// Para obter a lista do alias de hem1 ou hem2
        /// </summary>
        /// <param name="idplayer"></param>
        /// <returns></returns>
        public List<Tuple<String,String>> isAlias(String idplayer)
        {
            //mettre une requete plus complete
            string sql = "select al.player_id, pl.playername from aliases al, players pl where al.aliasplayer_id = "+idplayer+" and al.player_id = pl.player_id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<Tuple<String, String>> playeralias = new List<Tuple<String, String>>();
            while (dr.Read())
            {
                playeralias.Add(Tuple.Create(dr[0].ToString(), dr[1].ToString()));                
            }
            dr.Close();
            return playeralias;            
        }

        /// <summary>
        /// Para obter os alias de pt4
        /// </summary>
        /// <param name="idplayer"></param>
        /// <returns></returns>
        public List<Tuple<String, String>> isAliasPt4(String idplayer)
        {
            //mettre une requete plus complete
            string sql = "select player_name from player where id_player = " + idplayer;
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<Tuple<String, String>> playeralias = new List<Tuple<String, String>>();
            while (dr.Read())
            {
                playeralias.Add(Tuple.Create(idplayer, dr[0].ToString()));
            }
            sql = "select id_player, player_name from player where id_player_alias = " + idplayer;
            command = new NpgsqlCommand(sql, conn);
            dr = command.ExecuteReader();
            while (dr.Read())
            {
                playeralias.Add(Tuple.Create(dr[0].ToString(), dr[1].ToString()));
            }
            dr.Close();    
            return playeralias;
        }
    }
}
