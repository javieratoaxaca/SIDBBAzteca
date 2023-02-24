using System;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Windows.Forms;

namespace SIDBAzteca.Config
{
    class ConexionBD
    {
        string cad_cnx;
        MySqlConnection mysqlcnn;

        public ConexionBD()
        {
            cad_cnx = "Database=universo_azteca;SERVER=192.168.1.90;UID=user_ext;password=oportunidades;";
            //cad_cnx = "SERVER=atoaxacalarios-cnbbbj.mysql.database.azure.com; PORT=3306;DATABASE=educacionbasica;UID=user_ext;PASSWORD=0p0rtun1d4d35#;"; // -->Usuario Externo
            //cad_cnx = "Server =" + Server + ";PORT=" + Port + ";DATABASE=" + Database + ";UID=" + UserID + ";PASSWORD=" + Password;
        }
        public MySqlConnection GetConnection()
        {
            try
            {
                mysqlcnn = new MySqlConnection(cad_cnx);
                mysqlcnn.Open();
                MessageBox.Show(" Conexion Establecida la Base de datos.");
            }
            catch (MySqlException ex)
            {
                //throw new  Exception("Error: Al conectarse a la Base de datos." + ex.Message);
                MessageBox.Show("Error: Al conectarse a la Base de datos." + ex.Message);
            }
            catch (Exception ex)
            {
                // throw new Exception(MessageBox.Show("Error: Al realizar la conexion la Base de datos." + ex.Message));
                MessageBox.Show("Error: Al realizar la conexion la Base de datos." + ex.Message);
            }

            return mysqlcnn;
        }
        public int ExecuteQuery(string SQL)
        {
            int result = 0;
            try
            {

                var MySqlCommand = new MySqlCommand(SQL, GetConnection());

                result = MySqlCommand.ExecuteNonQuery();
                mysqlcnn.Close();
            }
            catch (MySqlConnector.MySqlException ex)
            {
                throw new Exception("Error: Al ejecutar las sentencias SQL." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
        public MySqlDataReader GetDataReader(string SQL)
        {
            MySqlDataReader MySqlDr = null;
            try
            {
                var MySqlCommand = new MySqlCommand(SQL, GetConnection());
                var MySqlDap = new MySqlDataAdapter(MySqlCommand);
                MySqlDr = MySqlCommand.ExecuteReader();
            }
            catch (MySqlConnector.MySqlException ex)
            {
                throw new Exception("Error: Al ejecutar las sentencias SQL." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return MySqlDr;
        }
        public DataTable GetDataTabla(string SQL)
        {
            var dt = new DataTable();
            var ds = new DataSet();
            var MySqlCommand = new MySqlCommand(SQL, GetConnection());
            var MySqlDap = new MySqlDataAdapter(MySqlCommand);
            MySqlDap.SelectCommand = MySqlCommand;
            MySqlDap.Fill(ds);
            dt = ds.Tables[0];
            return dt;


        }

    }
}
