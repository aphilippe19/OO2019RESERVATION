using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GestionRessourcesP.Models
{
    public class Accesdonnees
    {
        SqlConnection _cnSQL;
        //String chaine = "Data Source=localhost;Initial Catalog=BD_PGIBNETD2;Integrated Security=True;Connect Timeout=45";
        //String chaine = "Data Source=srv-bnt-sql-dev;Initial Catalog=BD_PGIBNETD;User ID=ebnetd_user;Password=1234Pass;Connect Timeout=45";

        //DEBUT by willy for regis
        String chaine;
        //by regis
        //String chaine = "Data Source=srv-bnt-sql-dev;Initial Catalog=BD_PGIBNETD_TEST_TEST;User ID=ebnetd_user;Password=1234Pass;Connect Timeout=45";
        //FIN

        //String chainedfc = "Data Source=ZED;Initial Catalog=ARNEAS;User ID=USER_PGI;Password=12345";

        String chainedfc = "";

        SqlCommand cmd;
        /*permet d'obtenir ou définir l'instruction Transact-SQL, le nom de table ou la procédure
        stockée à exécuter au niveau de la source de données.*/

        public Accesdonnees() //constructeur
        {
            try
            {
                DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();

                var connection = db.Database.Connection as SqlConnection;
                /* J'affecte à la variable connection 
                 la connection à ma base de donnée qui est réprésenté par la classe SqlConnection*/

                this.chaine = connection.ConnectionString.ToString();

                //Constat_infractions.pr.Settings s = new Properties.Settings();

                //this.chainedfc = s.Setting.ToString();

                //chainedfc = WebConfigurationManager.ConnectionStrings[1].ConnectionString.ToString();

                //chainedfc = ConfigurationManager.ConnectionStrings.Count.ToString();

                // chainedfc = ConfigurationManager.);


            }
            catch (Exception)
            {
                DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();
                var connection = db.Database.Connection as SqlConnection;

                this.chaine = connection.ToString();
            }
        }

        private String chaineConnexion()
        {
            try
            {
                DB_RESSOURCESPEntities db = new DB_RESSOURCESPEntities();
                var connection = db.Database.Connection as SqlConnection;

                return connection.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public void OuvrirConnexionSQL(ref SqlConnection cnSQL, ref SqlTransaction tr, ref SqlCommand cmdtr)
        {
            // Instancier la connexion
            cnSQL = new SqlConnection(chaine);

            // Ouvrir la connexion
            if (cnSQL.State == ConnectionState.Closed)
                cnSQL.Open();
            tr = cnSQL.BeginTransaction();
            cmdtr.Connection = cnSQL;
            cmdtr.Transaction = tr;
        }

        public void FermerConnexionSQL(ref SqlConnection cnSQL)
        {
            if (cnSQL != null)
                cnSQL.Close();
        }


        public DataTable getDatatable_fromPS(SqlTransaction tr, SqlConnection cnSQL, string ps, ArrayList cles, ArrayList valeurs)
        {

            DataTable dt;
            SqlDataAdapter daSQ;

            try
            {

                daSQ = new SqlDataAdapter();
                dt = new DataTable();

                cmd = new SqlCommand();
                cmd.Connection = cnSQL;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ps;
                cmd.Transaction = tr;

                if (cles.Count >= 1)
                {
                    for (int i = 0; i <= cles.Count - 1; i++)
                    {
                        cmd.Parameters.AddWithValue(Convert.ToString(cles[i]), valeurs[i]);
                    }
                }

                daSQ.SelectCommand = cmd;

                daSQ.Fill(dt);
                return (dt);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return (null);
            }

        }


        public DataTable getDatatable_fromPS(string ps)
        {

            DataTable dt;
            SqlDataAdapter daSQ;

            try
            {

                daSQ = new SqlDataAdapter();
                dt = new DataTable();
                this._cnSQL = new SqlConnection(this.chaine);
                this._cnSQL.Open();
                cmd = new SqlCommand();
                cmd.Connection = _cnSQL;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ps;

                daSQ.SelectCommand = cmd;

                daSQ.Fill(dt);
                return (dt);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return (null);
            }

        }

        public DataTable getDatatable_fromPS(string ps, ArrayList cles, ArrayList valeurs)
        {

            DataTable dt;
            SqlDataAdapter daSQ;

            try
            {

                daSQ = new SqlDataAdapter();
                dt = new DataTable();
                this._cnSQL = new SqlConnection(this.chaine);
                this._cnSQL.Open();
                cmd = new SqlCommand();
                cmd.Connection = _cnSQL;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ps;

                if (cles.Count >= 1)
                {
                    for (int i = 0; i <= cles.Count - 1; i++)
                    {
                        cmd.Parameters.AddWithValue(Convert.ToString(cles[i]), valeurs[i]);
                    }
                }

                daSQ.SelectCommand = cmd;

                daSQ.Fill(dt);
                return (dt);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return (null);
            }

        }
    }
}