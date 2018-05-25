using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class BaseDatosSQL
    {
        public BaseDatosSQL()
        {

        }

        public BaseDatosSQL(DataRow dr)
        {
            Leer(dr);
        }

        public string _Key = "ID";
        public string _Tabla = "";
        public static SqlDataAdapter SqlDataAdapter;
        public static string cs = "";
        public static SqlConnection SqlConnection;// = new SqlConnection(cs);
        public static OleDbDataAdapter oleDbDataAdapter;
        public static OleDbConnection oleDbConnection;// = new OleDbConnection(cs);
        public static bool Sql = false;
        public string mError = "";

        public static void SetConnectionString(string connectionString)
        {
            cs = connectionString;
            if (Sql)
            {

                SqlConnection = new SqlConnection(cs);
            }
            else
            {
                oleDbConnection = new OleDbConnection(cs);
            }
        }

        public void EscribirDataRow()
        {

        }

        public void Leer(DataRow campos)
        {

            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            string Nombre;
            string stipo;

            for (int i = 0; i != miembros.Length; i++)
            {
                Nombre = miembros[i].Name;
                if (miembros[i].GetValue(this) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 1) != "m")
                {
                    stipo = miembros[i].GetValue(this).GetType().ToString();
                    //stipo=miembros[i].ToString();
                }
                else
                {
                    stipo = "";
                }

                if (stipo == "System.String" || stipo == "System.DateTime" || stipo == "System.Int32" || stipo == "System.Double")
                {
                    if (campos[Nombre].GetType().ToString() != "System.DBNull")
                    {
                        string v = campos[Nombre].ToString();
                        if (stipo == "System.String") miembros[i].SetValue(this, campos[Nombre].ToString());
                        if (stipo == "System.DateTime") miembros[i].SetValue(this, (DateTime)campos[Nombre]);
                        if (stipo == "System.Int32") miembros[i].SetValue(this, Convert.ToInt32(campos[Nombre]));
                        if (stipo == "System.Double") miembros[i].SetValue(this, double.Parse(campos[Nombre].ToString()));
                    }
                }
            }
        }

        public int UltimoNumero(ref string error)
        {
            int n = 0;
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }

            string query = "SELECT TOP 1 ID FROM " + _Tabla + " ORDER BY ID DESC";

            if (Sql)
            {

                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return 0;
                    n = (int)(o);
                }
                catch (Exception ex)
                {
                    error = ex.Message + "\n" + query;
                }
                finally
                {
                    SqlConnection.Close();
                }
            }
            else
            {
                OleDbConnection cn;
                cn = new OleDbConnection(cs);
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return 0;
                    n = (int)(o);
                }
                catch (Exception ex)
                {
                    error = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }

            }

            return n;
        }

        public int UltimoNumero()
        {
            int n = 0;
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string query = "SELECT TOP 1 ID FROM " + _Tabla + " ORDER BY ID DESC";

            if (Sql)
            {
                SqlConnection cn;
                cn = new SqlConnection(cs);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return 0;
                    n = (int)(o);
                }
                catch
                {

                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                OleDbConnection cn;
                cn = new OleDbConnection(cs);
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return 0;
                    n = (int)(o);
                }
                catch
                {

                }
                finally
                {
                    cn.Close();
                }

            }

            return n;
        }

        public int NumeroLibre()
        {
            return NumeroLibre("ID");
        }

        public int NumeroLibre(string campo)
        {
            mError = "";
            int n = 0;
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string query = "SELECT TOP 1 " + campo + " FROM " + _Tabla + " ORDER BY  " + campo + "  DESC";

            if (Sql)
            {
                query = "SELECT TOP 1 " + campo + "  FROM " + _Tabla + " ORDER BY  " + campo + "  DESC";
                try
                {
                    SqlConnection.Open();
                }
                catch (Exception ex)
                {
                    mError = ex.Message;
                }

                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return 0;
                    n = (int)(o);
                }
                catch (Exception ex)
                {

                    mError = ex.Message;
                }
                finally
                {
                    SqlConnection.Close();
                }
            }
            else
            {
                oleDbConnection.Open();
                OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                try
                {
                    object o = cmd.ExecuteScalar();
                    if (o == null) return 0;
                    n = (int)(o);
                }
                catch (Exception ex)
                {
                    mError = ex.Message;
                }
                finally
                {
                    oleDbConnection.Close();
                }
            }
            return n + 1;
        }

        public static DataTable Tabla(string query, ref string error)
        {
            DataTable dt = new DataTable();
            if (Sql)
            {
                SqlDataAdapter = new SqlDataAdapter(query, SqlConnection);
                try
                {
                    SqlDataAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
            else
            {
                oleDbDataAdapter = new OleDbDataAdapter(query, oleDbConnection);
                try
                {
                    oleDbDataAdapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }

            return dt;
        }

        public static DataTable Tabla(string query)
        {
            DataTable dt = new DataTable();
            if (Sql)
            {

                SqlDataAdapter = new SqlDataAdapter(query, SqlConnection);
                SqlDataAdapter.Fill(dt);
            }
            else
            {
                oleDbDataAdapter = new OleDbDataAdapter(query, oleDbConnection);
                oleDbDataAdapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable Tabla(string query, ref SqlDataAdapter dataAdapter)
        {
            DataTable dt = new DataTable();
            SqlCommandBuilder cb;
            SqlDataAdapter = new SqlDataAdapter(query, SqlConnection);
            cb = new SqlCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = cb.GetUpdateCommand();
            dataAdapter.InsertCommand = cb.GetInsertCommand();
            dataAdapter.DeleteCommand = cb.GetDeleteCommand();
            dataAdapter.Fill(dt);
            return dt;
        }

        public static DataTable Tabla(string query, ref OleDbDataAdapter dataAdapter)
        {
            DataTable dt = new DataTable();

            OleDbCommandBuilder cb;
            dataAdapter = new OleDbDataAdapter(query, oleDbConnection);
            cb = new OleDbCommandBuilder(dataAdapter);
            dataAdapter.UpdateCommand = cb.GetUpdateCommand();
            dataAdapter.InsertCommand = cb.GetInsertCommand();
            dataAdapter.DeleteCommand = cb.GetDeleteCommand();
            dataAdapter.Fill(dt);
            return dt;
        }

        /*
        static public DataTable CrearTabla(string query)
        {
            //DataSet ds=new DataSet();
            DataTable dt=new DataTable();
            //ds.Tables.Add(dt);
            da=new OleDbDataAdapter(query,cn);
            cb = new OleDbCommandBuilder( da );
            try
            {
                //da.Fill(ds,query);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            //ds.Dispose();
            //da.Dispose();
            return dt;
        }
        */

        public static string FormatoFecha(DateTime fecha)
        {
            string fechaMysql;
            if (Sql)
            {
                fechaMysql = "'" + fecha.ToString() + "'";

            }
            else
            {
                fechaMysql = "#" + fecha.ToString() + "#";
            }
            return fechaMysql;
        }


        public virtual string Insertar()
        {
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string columnas = "";
            string valores = "";

            for (int i = 0; i != miembros.Length; i++)
            {
                if (miembros[i].GetValue(this) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 1) != "m")
                {

                    string tipoDato = miembros[i].GetValue(this).GetType().ToString();

                    if (tipoDato == "System.String")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        valores += "'" + miembros[i].GetValue(this).ToString() + "'";

                    }

                    if (tipoDato == "System.DateTime")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        valores += FormatoFecha((DateTime)miembros[i].GetValue(this));

                    }

                    if (tipoDato == "System.Int32" || tipoDato == "System.Double")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        valores += miembros[i].GetValue(this).ToString();

                    }
                }
            }

            string query = "INSERT INTO " + _Tabla + " (" + columnas + ") VALUES (" + valores + ")";
            string Mensaje = "";

            if (Sql)
            {

                //MySqlConnection mySqlConnection;
                //mySqlConnection = new MySqlConnection(cs);
                try
                {
                    SqlConnection.Open();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message;
                    return Mensaje;
                }
                SqlCommand cmd = new SqlCommand(query, SqlConnection);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    SqlConnection.Close();
                }
            }
            else
            {
                //OleDbConnection ConnectionOleDb;
                //ConnectionOleDb = new OleDbConnection(cs);
                oleDbConnection.Open();
                OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    oleDbConnection.Close();
                }
            }

            return Mensaje;
        }

        public string Update(string Columna, string Valor, string Where)
        {
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string query = "UPDATE " + _Tabla + " SET " + Columna + "=" + Valor + " WHERE " + Where;
            string Mensaje = "";

            if (Sql)
            {
                SqlConnection cn;
                cn = new SqlConnection(cs);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                OleDbConnection cn;
                cn = new OleDbConnection(cs);
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }
            return Mensaje;
        }

        public virtual string Update()
        {
            string Mensaje = "";
            Type tipo = this.GetType();
            FieldInfo[] miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);
            string Valor = "";

            string query = "UPDATE " + this.GetType().Name.ToLower() + " SET ";
            bool primero = true;
            string queryWHERE = "";
            bool tipoPermitido = false;

            foreach (FieldInfo miembro in miembros)
            {
                if (miembro.Name[0] != '_' && miembro.Name[0] != 'm')
                {
                    string strTipo = "";
                    if (miembro.GetValue(this) != null)
                    {
                        strTipo = miembro.GetValue(this).GetType().ToString();
                    }
                    tipoPermitido = false;
                    if (strTipo == "System.String")
                    {
                        Valor = "'" + miembro.GetValue(this).ToString() + "'";
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.DateTime")
                    {
                        Valor = FormatoFecha((DateTime)miembro.GetValue(this));
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.Int32")
                    {
                        Valor = miembro.GetValue(this).ToString();
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.Double")
                    {
                        Valor = miembro.GetValue(this).ToString();
                        tipoPermitido = true;
                    }

                    if (miembro.Name != _Key)
                    {
                        if (tipoPermitido)
                        {
                            if (!primero) query += " , ";
                            query += miembro.Name + "=" + Valor;
                        }
                        primero = false;
                    }
                    else
                    {
                        queryWHERE = " WHERE " + _Key + "=" + Valor;
                    }

                }
            }

            if (Valor != "")
            {

                if (Sql)
                {
                    SqlConnection cn;
                    cn = new SqlConnection(cs);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query + queryWHERE, cn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Mensaje = ex.Message + "\n" + query + queryWHERE;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
                else
                {
                    OleDbConnection cn;
                    cn = new OleDbConnection(cs);
                    cn.Open();
                    OleDbCommand cmd = new OleDbCommand(query + queryWHERE, cn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Mensaje = ex.Message + "\n" + query + queryWHERE;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }

            return Mensaje;

        }

        public string Update(string Columna)
        {
            string Valor = "";
            string Mensaje = "";
            string strTipo;
            string key = "";
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }

            for (int i = 0; i != miembros.Length; i++)
            {
                if (Columna.ToUpper() == miembros[i].Name.ToUpper())
                {
                    strTipo = miembros[i].GetValue(this).GetType().ToString();
                    if (strTipo == "System.String") Valor = "'" + miembros[i].GetValue(this).ToString() + "'";
                    if (strTipo == "System.DateTime") Valor = "'" + miembros[i].GetValue(this).ToString() + "'";
                    if (strTipo == "System.Int32") Valor = miembros[i].GetValue(this).ToString();
                    if (strTipo == "System.Double") Valor = miembros[i].GetValue(this).ToString();
                }
            }

            strTipo = miembros[0].GetValue(this).GetType().ToString();
            if (strTipo == "System.String") key = "'" + miembros[0].GetValue(this).ToString() + "'";
            if (strTipo == "System.DateTime") key = "'" + miembros[0].GetValue(this).ToString() + "'";
            if (strTipo == "System.Int32") key = miembros[0].GetValue(this).ToString();
            if (strTipo == "System.Double") key = miembros[0].GetValue(this).ToString();

            if (Valor != "")
            {
                string query = "UPDATE " + _Tabla + " SET " + Columna + "=" + Valor + " WHERE " + miembros[0].Name + "=" + key;

                if (Sql)
                {
                    SqlConnection cn;
                    cn = new SqlConnection(cs);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query, cn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Mensaje = ex.Message + "\n" + query;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
                else
                {
                    OleDbConnection cn;
                    cn = new OleDbConnection(cs);
                    cn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, cn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Mensaje = ex.Message + "\n" + query;
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
            return Mensaje;
        }

        public string Agregar(string Columna, string Valor, string Where)
        {
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string query = "UPDATE " + _Tabla + " SET " + Columna + "=" + Columna + "+" + Valor + " WHERE " + Where;
            string Mensaje = "";

            if (Sql)
            {
                SqlConnection cn;
                cn = new SqlConnection(cs);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                OleDbConnection cn;
                cn = new OleDbConnection(cs);
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }

            return Mensaje;
        }

        public virtual string Delete(string where)
        {
            if (_Tabla == "")
            {
                _Tabla = this.GetType().Name.ToLower();
            }
            string query = "DELETE FROM " + _Tabla + " WHERE " + where;
            string Mensaje = "";

            if (Sql)
            {
                SqlConnection cn;
                cn = new SqlConnection(cs);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                OleDbConnection cn;
                cn = new OleDbConnection(cs);
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }

            return Mensaje;

        }

        public string editar(string Columna, string Valor, string Where)
        {
            string query = "UPDATE productos SET " + Columna + "="+ Valor + " WHERE " + Where;
            string Mensaje = "";

            if (Sql)
            {
                SqlConnection cn;
                cn = new SqlConnection(cs);
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                OleDbConnection cn;
                cn = new OleDbConnection(cs);
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(query, cn);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Mensaje = ex.Message + "\n" + query;
                }
                finally
                {
                    cn.Close();
                }
            }

            return Mensaje;
        }

    }
}
