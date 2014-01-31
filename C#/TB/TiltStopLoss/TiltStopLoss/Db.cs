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
        public String getHand(Int64 hhid)
        {
            string sql = "select handhistory from handhistories where handhistory_id = " + hhid + ";";
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
        /// </summary>
        /// <param name="playerid"></param>
        /// <param name="yearmonth"></param>
        /// <returns></returns>
        public Double getSumBB(String playerid, String yearmonth)
        {
            string sql = "select sum(totalbbswon) as bbtotal from compiledplayerresults where player_id = "+playerid+" and playedyearandmonth >= "+yearmonth;
            //string sql = "select sum(totalbbswon) as bbtotal from compiledplayerresults where player_id = " + playerid + " and playedyearandmonth = 201402";
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
    }
}
