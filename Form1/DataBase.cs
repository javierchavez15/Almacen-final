using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class DataBase
    {
        public static int Version = 2;
        public static string UltimaActualizacion = "6 Junio 2016, Modifique InsertObjet y ExecuteQuery";
        public string ConnectionString = "";
        public OdbcConnection odbcConnection;// = new SqlConnection(cs);
        private OleDbConnection oleDbConnection;
        public OleDbDataAdapter oleDbDataAdapter;
        public string error = "";
        public TypeOfDataBase DataBaseProvider = TypeOfDataBase.MySqlServer;
        public string query = "";
        public MySqlConnection mysqlconn;
        public MySqlDataAdapter mysqlda;


        public static void SerializeSOAP(object objectToSerialize, string file)
        {
            FileStream stmCar = new FileStream(file,
               FileMode.Create);
            SoapFormatter sopCar = new SoapFormatter();

            sopCar.Serialize(stmCar, objectToSerialize);
            stmCar.Close();
        }

        public static object DeserializeSOAP(string file)
        {
            object objectToDeserialize = null;
            FileStream stmCar = null;
            try
            {
                stmCar = new FileStream(file,
                FileMode.Open);

                SoapFormatter sopCar = new SoapFormatter();

                objectToDeserialize = sopCar.Deserialize(stmCar);
            }
            catch
            {
            }
            finally
            {
                if (stmCar != null)
                {
                    stmCar.Close();
                }
            }
            return objectToDeserialize;
        }

        public static void SerializeBinary(object objectToSerialize, string file)
        {
            FileStream stmCar = new FileStream(file,
               FileMode.Create);
            BinaryFormatter sopCar = new BinaryFormatter();

            sopCar.Serialize(stmCar, objectToSerialize);
            stmCar.Close();
        }

        public static object DeserializeBinary(string file)
        {
            FileStream stmCar = new FileStream(file,
               FileMode.Open);
            object objectToDeserialize = null;
            BinaryFormatter sopCar = new BinaryFormatter();
            try
            {
                objectToDeserialize = sopCar.Deserialize(stmCar);
            }
            catch
            {
            }
            finally
            {
                stmCar.Close();
            }
            return objectToDeserialize;
        }

        public void CreateConnection()
        {
            error = "";


            try
            {
                switch (DataBaseProvider)
                {
                    case TypeOfDataBase.MicrosoftAccess:
                        oleDbConnection = new OleDbConnection(ConnectionString);
                        break;
                    case TypeOfDataBase.MySqlServer:
                        mysqlconn = new MySqlConnection(ConnectionString);
                        mysqlconn = new MySqlConnection("server=localhost;Database=ejemplo;Uid=root;Password=; Convert Zero Datetime=True");
                        mysqlconn = new MySqlConnection("server=secure199.inmotionhosting.com;Database=abdsto5_cotizaciones;Uid=abdsto5_felipe;Password=1945Inadescobi; Convert Zero Datetime=True");
                        break;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

        }

        public string FormatoFecha(DateTime fecha)
        {
            string fechaMysql = "";
            switch (this.DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    fechaMysql = "#" + fecha.Month + "/" + fecha.Day + "/" + fecha.Year + " " + fecha.Hour + ":" + fecha.Minute + ":" + fecha.Second + "#";
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    fechaMysql = "'" + fecha.Year.ToString("0000") + "-" + fecha.Month.ToString("00") + "-" + fecha.Day.ToString("00") + " " + fecha.Hour.ToString("00") + ":" + fecha.Minute.ToString("00") + ":" + fecha.Second.ToString("00") + "'";
                    break;
                case TypeOfDataBase.MySqlServer:
                    fechaMysql = "'" + fecha.Year.ToString("0000") + "-" + fecha.Month.ToString("00") + "-" + fecha.Day.ToString("00") + " " + fecha.Hour.ToString("00") + ":" + fecha.Minute.ToString("00") + ":" + fecha.Second.ToString("00") + "'";
                    break;
                    //  fechaMysql = "DATE_FORMAT("+fecha+",'%m-%d-%Y')";
                    //  break;
            }

            return fechaMysql;
        }

        public void ExecuteQuery(string query)
        {
            error = "";
            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:

                    try
                    {
                        if (oleDbConnection.State == ConnectionState.Closed) oleDbConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return;
                    }

                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }

                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    break;
                case TypeOfDataBase.MySqlServer:

                    try
                    {
                        if (mysqlconn.State == ConnectionState.Closed) mysqlconn.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return;
                    }

                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);

                    foreach (parametro par in parametro.listaParametros)
                    {
                        /*if (par.nombre.ToString() == "@ID_PRODUCTO")
                        {
                            string hh = par.objeto.ToString();
                        }
                        string ok = "";
                        ok = par.objeto.ToString();
                        string tt = par.nombre.ToString();
                        if (par.nombre.ToString() == "32767" || par.objeto.ToString() == "32767")
                        {
                            string ss = ok;
                        }*/
                        cmd2.Parameters.AddWithValue(par.nombre, par.objeto);
                    }


                    try
                    {
                        cmd2.ExecuteNonQuery();
                        parametro.listaParametros.Clear();
                    }
                    catch (Exception ex)
                    {
                        parametro.listaParametros.Clear();
                        error = ex.Message;
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }

                    break;
            }

        }

        public void InsertObject(object objectToInsert)
        {
            error = "";
            FieldInfo[] miembros;
            Type tipo = objectToInsert.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);
            string Tabla = tipo.Name.ToLower();
            //query = "INSERT INTO "+tipo.Name+" (ID,Descripcion) VALUES (1,'descripcion 1')";            
            string columnas = "";
            string valores = "";
            parametro.listaParametros.Clear();
            for (int i = 0; i != miembros.Length; i++)
            {
                if (miembros[i].GetValue(objectToInsert) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 2) != "mE")
                {
                    string tipoDato = miembros[i].GetValue(objectToInsert).GetType().ToString();
                    if (tipoDato == "System.String")
                    {
                        if (miembros[i].Name == "Table")
                        {
                            string valorTabla = miembros[i].GetValue(objectToInsert).ToString();
                            if (valorTabla != "")
                            {
                                Tabla = valorTabla;
                            }
                        }
                        else
                        {
                            if (columnas != "")
                            {
                                columnas += ",";
                                valores += ",";
                            }
                            columnas += miembros[i].Name;
                            //  valores += "'" + miembros[i].GetValue(objectToInsert).ToString() + "'";
                            valores += "@" + miembros[i].Name;
                            parametro p = new parametro();
                            p.nombre = "@" + miembros[i].Name;
                            p.objeto = miembros[i].GetValue(objectToInsert);
                            parametro.listaParametros.Add(p);
                        }
                    }
                    if (tipoDato == "System.DateTime")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        //  valores += FormatoFecha(Convert.ToDateTime(miembros[i].GetValue(objectToInsert)));
                        valores += "@" + miembros[i].Name;
                        parametro p = new parametro();
                        p.nombre = "@" + miembros[i].Name;
                        p.objeto = miembros[i].GetValue(objectToInsert);
                        // p.objeto = DateTime.Now;
                        parametro.listaParametros.Add(p);
                    }
                    if (tipoDato == "System.Int32" || tipoDato == "System.Double")
                    {
                        if (columnas != "")
                        {
                            columnas += ",";
                            valores += ",";
                        }
                        columnas += miembros[i].Name;
                        //  valores += "'"+miembros[i].GetValue(objectToInsert).ToString()+"'";
                        valores += "@" + miembros[i].Name;
                        parametro p = new parametro();
                        p.nombre = "@" + miembros[i].Name;
                        p.objeto = miembros[i].GetValue(objectToInsert);
                        parametro.listaParametros.Add(p);
                        /* if (miembros[i].Name == "ID_PRODUCTO")
                         {
                             string ok = "";
                             ok = p.objeto.ToString();
                         }*/
                    }
                }
            }
            query = "INSERT INTO " + Tabla + " (" + columnas + ") VALUES (" + valores + ")";
            // string a = query;
            ExecuteQuery(query);
            //a = a + valores;
            /*
            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:

                    try
                    {
                        if (oleDbConnection.State==ConnectionState.Closed) oleDbConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return;
                    }

                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);

                    try
                    {
                        if (cmd != null) 
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }

                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    break;
                case TypeOfDataBase.MySqlServer:
                    break;
            }
            */
        }

        public void UpdateObject(object objectToUpdate, string Key, string Key2)
        {

            Type tipo = objectToUpdate.GetType();
            FieldInfo[] miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);
            string Valor = "";

            query = "UPDATE " + objectToUpdate.GetType().Name.ToLower() + " SET ";
            bool primero = true;
            string queryWHERE = "";
            bool tipoPermitido = false;

            foreach (FieldInfo miembro in miembros)
            {
                if (miembro.Name[0] != '_' && miembro.Name[0] != 'm')
                {
                    string strTipo = "";
                    if (miembro.GetValue(objectToUpdate) != null)
                    {
                        strTipo = miembro.GetValue(objectToUpdate).GetType().ToString();
                    }
                    tipoPermitido = false;
                    if (strTipo == "System.String")
                    {
                        Valor = "'" + miembro.GetValue(objectToUpdate).ToString() + "'";
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.DateTime")
                    {
                        Valor = FormatoFecha((DateTime)miembro.GetValue(objectToUpdate));
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.Int32" && miembro.Name != "Table")
                    {
                        Valor = miembro.GetValue(objectToUpdate).ToString();
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.Double")
                    {
                        Valor = miembro.GetValue(objectToUpdate).ToString();
                        tipoPermitido = true;
                    }

                    if (strTipo == "System.Boolean")
                    {
                        Valor = miembro.GetValue(objectToUpdate).ToString();
                        tipoPermitido = true;
                    }

                    if (miembro.Name != Key && miembro.Name != Key2)
                    {
                        if (tipoPermitido && miembro.Name != "Table")
                        {
                            if (!primero) query += " , ";
                            query += miembro.Name + "=" + Valor;
                            primero = false;
                        }

                    }


                    if (miembro.Name == Key)
                    {
                        if (queryWHERE == "")
                        {
                            queryWHERE = " WHERE " + Key + "=" + Valor;
                        }
                        else
                        {
                            queryWHERE += " AND " + Key + "=" + Valor;
                        }
                    }

                    if (miembro.Name == Key2)
                    {
                        if (queryWHERE == "")
                        {
                            queryWHERE = " WHERE " + Key2 + "=" + Valor;
                        }
                        else
                        {
                            queryWHERE += " AND " + Key2 + "=" + Valor;
                        }
                    }

                }
            }

            if (Valor != "")
            {
                switch (DataBaseProvider)
                {
                    case TypeOfDataBase.MicrosoftAccess:
                        oleDbConnection.Open();
                        OleDbCommand cmd = new OleDbCommand(query + queryWHERE, oleDbConnection);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message + "\n" + query + queryWHERE;
                        }
                        finally
                        {
                            oleDbConnection.Close();
                        }
                        break;
                    case TypeOfDataBase.MicrosoftSqlServer:
                        break;
                    case TypeOfDataBase.MySqlServer:

                        try
                        {
                            if (mysqlconn.State == ConnectionState.Closed) mysqlconn.Open();
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message;
                            return;
                        }

                        MySqlCommand cmd2 = new MySqlCommand(query + queryWHERE, mysqlconn);

                        try
                        {
                            cmd2.ExecuteNonQuery();
                            error = "";
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message;
                        }
                        finally
                        {
                            mysqlconn.Close();
                        }

                        break;
                }
            }


        }
        public void UpdateObject(object objectToUpdate, string Key)
        {

            Type tipo = objectToUpdate.GetType();
            FieldInfo[] miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);
            string Valor = "";

            query = "UPDATE " + objectToUpdate.GetType().Name + " SET ";
            bool primero = true;
            string queryWHERE = "";
            bool tipoPermitido = false;

            foreach (FieldInfo miembro in miembros)
            {
                if (miembro.Name[0] != '_' && miembro.Name[0] != 'm')
                {
                    string strTipo = "";
                    if (miembro.GetValue(objectToUpdate) != null)
                    {
                        strTipo = miembro.GetValue(objectToUpdate).GetType().ToString();
                    }
                    tipoPermitido = false;
                    if (strTipo == "System.String")
                    {
                        Valor = "'" + miembro.GetValue(objectToUpdate).ToString() + "'";
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.DateTime")
                    {
                        Valor = FormatoFecha((DateTime)miembro.GetValue(objectToUpdate));
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.Int32" && miembro.Name != "Table")
                    {
                        Valor = miembro.GetValue(objectToUpdate).ToString();
                        tipoPermitido = true;
                    }
                    if (strTipo == "System.Double")
                    {
                        Valor = miembro.GetValue(objectToUpdate).ToString();
                        tipoPermitido = true;
                    }

                    if (strTipo == "System.Boolean")
                    {
                        Valor = miembro.GetValue(objectToUpdate).ToString();
                        tipoPermitido = true;
                    }

                    if (miembro.Name != Key)
                    {
                        if (tipoPermitido && miembro.Name != "Table")
                        {
                            if (!primero) query += " , ";
                            query += miembro.Name + "=" + Valor;
                            primero = false;
                        }

                    }
                    else
                    {
                        queryWHERE = " WHERE " + Key + "=" + Valor;
                    }

                }
            }

            if (Valor != "")
            {
                string otra = query + queryWHERE;
                switch (DataBaseProvider)
                {
                    case TypeOfDataBase.MicrosoftAccess:
                        oleDbConnection.Open();
                        OleDbCommand cmd = new OleDbCommand(query + queryWHERE, oleDbConnection);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message + "\n" + query + queryWHERE;
                        }
                        finally
                        {
                            oleDbConnection.Close();
                        }
                        break;
                    case TypeOfDataBase.MicrosoftSqlServer:
                        break;
                    case TypeOfDataBase.MySqlServer:


                        try
                        {
                            if (mysqlconn.State == ConnectionState.Closed) mysqlconn.Open();
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message;
                            return;
                        }

                        MySqlCommand cmd2 = new MySqlCommand(query + queryWHERE + " limit 1", mysqlconn);

                        try
                        {
                            cmd2.ExecuteNonQuery();
                            error = "";
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message;
                        }
                        finally
                        {
                            mysqlconn.Close();
                        }

                        break;
                }
            }


        }

        public void LoadDataRowToObject(ref Object objectToWrite, DataRow campos)
        {
            FieldInfo[] miembros;
            Type tipo = objectToWrite.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            string Nombre;
            string stipo;

            for (int i = 0; i != miembros.Length; i++)
            {
                Nombre = miembros[i].Name;
                if (miembros[i].GetValue(objectToWrite) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 1) != "m")
                {
                    stipo = miembros[i].GetValue(objectToWrite).GetType().ToString();
                    //stipo=miembros[i].ToString();
                }
                else
                {
                    stipo = "";
                }

                if ((stipo == "System.String" || stipo == "System.DateTime" || stipo == "System.Int32" || stipo == "System.Double") && Nombre != "Table")
                {
                    string nombreDelCampo = campos[Nombre].GetType().ToString();
                    if (nombreDelCampo != "System.DBNull")
                    {
                        try
                        {
                            string value = campos[Nombre].ToString();
                            if (stipo == "System.String") miembros[i].SetValue(objectToWrite, campos[Nombre].ToString());
                            if (stipo == "System.DateTime") miembros[i].SetValue(objectToWrite, (DateTime)campos[Nombre]);
                            if (stipo == "System.Int32") miembros[i].SetValue(objectToWrite, int.Parse(value));
                            if (stipo == "System.Double") miembros[i].SetValue(objectToWrite, (double)campos[Nombre]);
                            if (stipo == "System.Boolean") miembros[i].SetValue(objectToWrite, (bool)campos[Nombre]);
                        }
                        catch (Exception ex)
                        {
                            error = ex.Message;
                            return;
                        }
                    }
                }
            }
        }

        public DataTable GetTable(string Query)
        {
            DataTable dt = new DataTable();
            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    oleDbDataAdapter = new OleDbDataAdapter(Query, oleDbConnection);
                    try
                    {
                        oleDbDataAdapter.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    break;
                case TypeOfDataBase.MySqlServer:
                    mysqlda = new MySqlDataAdapter(Query, mysqlconn);
                    try
                    {
                        mysqlda.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    break;
            }
            return dt;
        }

        public int NextNumber(DbObject objectToAutonumber, string Key)
        {
            int n = 0;
            Type tipo = objectToAutonumber.GetType();
            string tabla = tipo.Name.ToLower();
            if (objectToAutonumber.Table != "") tabla = objectToAutonumber.Table;

            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    query = "SELECT TOP 1 " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC";
                    try
                    {
                        oleDbConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return -1;
                    }
                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                    try
                    {
                        object o = cmd.ExecuteScalar();
                        if (o == null) return 1;
                        n = (int)(o);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return -1;
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    query = "SELECT " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC LIMIT 1";
                    break;
                case TypeOfDataBase.MySqlServer:
                    query = "SELECT " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC LIMIT 1";

                    try
                    {
                        mysqlconn.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return -1;
                    }
                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);
                    try
                    {
                        object o = cmd2.ExecuteScalar();
                        if (o == null) return 1;
                        n = (int)(o);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return -1;
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }

                    break;
            }




            return n + 1;
        }

        public string facturapo(DbObject objectToAutonumber, string Key)
        {
            string n = "0";
            Type tipo = objectToAutonumber.GetType();
            string tabla = tipo.Name.ToLower();
            if (objectToAutonumber.Table != "") tabla = objectToAutonumber.Table;
            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    query = "SELECT TOP 1 " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC";
                    try
                    {
                        oleDbConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                    try
                    {
                        object o = cmd.ExecuteScalar();
                        if (o == null) return "0";
                        n = (string)(o);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    query = "SELECT " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC LIMIT 1";
                    break;
                case TypeOfDataBase.MySqlServer:
                    query = "SELECT folio FROM " + tabla + " where (origen='PREFACTURA PROYECTOS' or origen='PREFACTURA PRODUCTOS') and pocliente='" + Key + "' LIMIT 1";
                    try
                    {
                        mysqlconn.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);
                    try
                    {
                        object o = cmd2.ExecuteScalar();
                        if (o == null) return "0";
                        n = o.ToString();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }
                    break;
            }
            return n;
        }

        public string facturaproyecto(DbObject objectToAutonumber, string Key)
        {
            string n = "0";
            Type tipo = objectToAutonumber.GetType();
            string tabla = tipo.Name.ToLower();
            if (objectToAutonumber.Table != "") tabla = objectToAutonumber.Table;
            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    query = "SELECT TOP 1 " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC";
                    try
                    {
                        oleDbConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                    try
                    {
                        object o = cmd.ExecuteScalar();
                        if (o == null) return "0";
                        n = (string)(o);
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    query = "SELECT " + Key + " FROM " + tabla + " ORDER BY " + Key + " DESC LIMIT 1";
                    break;
                case TypeOfDataBase.MySqlServer:
                    query = "SELECT folio FROM " + tabla + " where origen='PREFACTURA PROYECTOS' and idproyecto=" + Key + " LIMIT 1";
                    try
                    {
                        mysqlconn.Open();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);
                    try
                    {
                        object o = cmd2.ExecuteScalar();
                        if (o == null) return "0";
                        n = o.ToString();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                        return "0";
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }
                    break;
            }
            return n;
        }

        public virtual void Delete(object objectToDelete)
        {


            string where = "";



            FieldInfo[] miembros;
            Type tipo = objectToDelete.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);



            string Nombre;
            string stipo;
            bool first = true;

            for (int i = 0; i != miembros.Length; i++)
            {
                Nombre = miembros[i].Name;

                if (miembros[i].GetValue(objectToDelete) != null && miembros[i].Name.Substring(0, 1) != "_" && miembros[i].Name.Substring(0, 1) != "m")
                {
                    stipo = miembros[i].GetValue(objectToDelete).GetType().ToString();

                    if (stipo == "System.String" && Nombre != "Table")
                    {
                        if (!first) where += " AND ";
                        where += " " + miembros[i].Name + "='" + miembros[i].GetValue(objectToDelete) + "' ";
                        first = false;
                    }

                    if (stipo == "System.DateTime")
                    {
                        if (!first) where += " AND ";
                        where += " " + miembros[i].Name + "=" + FormatoFecha((DateTime)(miembros[i].GetValue(objectToDelete))) + " ";
                        first = false;
                    }

                    if (stipo == "System.Int32" || stipo == "System.Double")
                    {
                        if (!first) where += " AND ";
                        where += " " + miembros[i].Name + "=" + miembros[i].GetValue(objectToDelete) + " ";
                        first = false;
                    }
                }

            }


            Delete(objectToDelete, where);

        }

        public void Delete(object objectToDelete, string where)
        {
            error = "";
            Type tipo = objectToDelete.GetType();

            string Tabla = objectToDelete.GetType().Name.ToLower();
            try
            {
                DbObject dbO = (DbObject)objectToDelete;
                if (dbO.Table != "")
                {
                    Tabla = dbO.Table;
                }
            }
            catch
            {
            }

            query = "DELETE FROM " + Tabla + " WHERE " + where;

            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    oleDbConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    error = "Not Implemented";
                    break;
                case TypeOfDataBase.MySqlServer:
                    mysqlconn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);
                    try
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }
                    break;
            }

        }
        public void editarosa(string Columna, string Valor, string where)
        {

            query = "UPDATE osa_gral SET " + Columna + "="  + Valor + " WHERE " + where;

            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    oleDbConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    error = "Not Implemented";
                    break;
                case TypeOfDataBase.MySqlServer:
                    mysqlconn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);
                    try
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }
                    break;
            }

        }
        public void editar(string Columna, string Valor, string where)
        {

            query = "UPDATE productos SET " + Columna + "=" + Columna + "*" + Valor + " WHERE " + where;

            switch (DataBaseProvider)
            {
                case TypeOfDataBase.MicrosoftAccess:
                    oleDbConnection.Open();
                    OleDbCommand cmd = new OleDbCommand(query, oleDbConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        oleDbConnection.Close();
                    }
                    break;
                case TypeOfDataBase.MicrosoftSqlServer:
                    error = "Not Implemented";
                    break;
                case TypeOfDataBase.MySqlServer:
                    mysqlconn.Open();
                    MySqlCommand cmd2 = new MySqlCommand(query, mysqlconn);
                    try
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        error = ex.Message;
                    }
                    finally
                    {
                        mysqlconn.Close();
                    }
                    break;
            }

        }

        public void editarinflacion(string cadena)
        {

            try
            {
                if (mysqlconn.State == ConnectionState.Closed) mysqlconn.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return;
            }

            MySqlCommand cmd2 = new MySqlCommand(cadena, mysqlconn);

            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                mysqlconn.Close();
            }

        }

    }

    public enum TypeOfDataBase { MicrosoftAccess, MicrosoftSqlServer, MySqlServer };
}