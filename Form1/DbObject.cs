using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Form1
{
    public class DbObject
    {

        public static string UltimaModificacion = "27 de Julio de 2012";
        public static DataBase DefaultDataBaseObject;
        public DataBase DataBaseObject;
        public string Table = "";

        protected void SelectDataBase()
        {
            if (DataBaseObject == null)
            {
                if (DefaultDataBaseObject == null)
                {
                    DefaultDataBaseObject = new DataBase();
                }

                DataBaseObject = DefaultDataBaseObject;
            }
        }

        public virtual void Insert()
        {
            SelectDataBase();
            DataBaseObject.InsertObject(this);
        }

        public string Error
        {
            get
            {
                SelectDataBase();
                return DataBaseObject.error;
            }
        }

        public void LoadDataRow(DataRow campos)
        {
            SelectDataBase();

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

                if ((stipo == "System.String" || stipo == "System.DateTime" || stipo == "System.Int32" || stipo == "System.Double" || stipo == "System.Boolean") && Nombre != "Table")
                {
                    string nombreDelCampo = campos[Nombre].GetType().ToString();
                    if (nombreDelCampo != "System.DBNull")
                    {
                        try
                        {
                            string value = campos[Nombre].ToString();
                            if (stipo == "System.String") miembros[i].SetValue(this, campos[Nombre].ToString());
                            if (stipo == "System.DateTime") miembros[i].SetValue(this, Convert.ToDateTime(campos[Nombre]));
                            if (stipo == "System.Int32") miembros[i].SetValue(this, int.Parse(value));
                            if (stipo == "System.Double") miembros[i].SetValue(this, (double)campos[Nombre]);
                            if (stipo == "System.Boolean") miembros[i].SetValue(this, (bool)campos[Nombre]);
                        }
                        catch (Exception ex)
                        {
                            DataBaseObject.error = ex.Message;
                        }
                    }
                }
            }

        }

        public DataTable GetTable()
        {
            SelectDataBase();
            DataTable dt;
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            string Tabla = tipo.Name.ToLower();
            if (this.Table != "") Tabla = Table;
            dt = DataBaseObject.GetTable("SELECT * FROM " + Tabla);
            return dt;
        }

        public DataTable Tabla( string consultas)
        {
            SelectDataBase();
            DataTable dt;
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            string Tabla = tipo.Name.ToLower();
            if (this.Table != "") Tabla = Table;
            dt = DataBaseObject.GetTable(consultas);
            return dt;
        }

        public DataTable GetTable(string WHERE)
        {
            SelectDataBase();
            DataTable dt;
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);

            string Tabla = tipo.Name.ToLower();
            if (this.Table != "") Tabla = Table;
            dt = DataBaseObject.GetTable("SELECT * FROM " + Tabla + " WHERE " + WHERE);
            return dt;
        }

        public string datoinfla()
        {
            try
            {
                SelectDataBase();
                DataTable dt;
                FieldInfo[] miembros;
                Type tipo = this.GetType();
                miembros = tipo.GetFields(BindingFlags.Instance
                    | BindingFlags.Public | BindingFlags.NonPublic);

                string Tabla = tipo.Name;
                if (this.Table != "") Tabla = Table;
                dt = DataBaseObject.GetTable("SELECT cambio from inflacion where Id=1");
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                return "1";
            }
        }

        public string añoinflacion()
        {
            try
            {
                SelectDataBase();
                DataTable dt;
                FieldInfo[] miembros;
                Type tipo = this.GetType();
                miembros = tipo.GetFields(BindingFlags.Instance
                    | BindingFlags.Public | BindingFlags.NonPublic);

                string Tabla = tipo.Name;
                if (this.Table != "") Tabla = Table;
                dt = DataBaseObject.GetTable("SELECT year(fecha) FROM `inflacion` WHERE Id=1");
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                return DateTime.Now.Year.ToString();
            }
        }

        public void LoadMembers(string WHERE)
        {
            SelectDataBase();
            DataTable dt = GetTable(WHERE);
            if (dt.Rows.Count == 0)
            {
                if (DataBaseObject.error == "")
                {
                    DataBaseObject.error = "Object data not found, there is not any " + this.GetType() + " with " + WHERE;
                }
                return;
            }
            LoadDataRow(dt.Rows[0]);
        }

        public virtual void Update(string Key)
        {
            SelectDataBase();
            DataBaseObject.UpdateObject(this, Key);
        }

        public virtual void actualizarprecio(string Columna, string Valor, string where)
        {
            SelectDataBase();
            DataBaseObject.editar(Columna, Valor, where);
            //DataBaseObject.editarinflacion(consulta2);
        }

        public virtual void actualizarosa(string Columna, string Valor, string where)
        {
            SelectDataBase();
            DataBaseObject.editarosa(Columna, Valor, where);
            //DataBaseObject.editarinflacion(consulta2);
        }

        public virtual void actualizarinflacion(string consulta2)
        {
            SelectDataBase();
            DataBaseObject.editarinflacion(consulta2);
        }

        public virtual void Update(string Key, string key2)
        {
            SelectDataBase();
            DataBaseObject.UpdateObject(this, Key, key2);
        }

        public int NextID()
        {
            SelectDataBase();
            return DataBaseObject.NextNumber(this, "ID");
        }

        public int NextNumber(string key)
        {
            SelectDataBase();
            return DataBaseObject.NextNumber(this, key);
        }

        public string factura(string key)
        {
            SelectDataBase();
            return DataBaseObject.facturaproyecto(this, key);
        }

        public string facturapoliza(string key)
        {
            SelectDataBase();
            return DataBaseObject.facturapo(this, key);
        }

        public void Delete()
        {
            SelectDataBase();
            DataBaseObject.Delete(this);
        }

        public void Delete(string WHERE)
        {
            SelectDataBase();
            DataBaseObject.Delete(this, WHERE);
        }
    }
}
