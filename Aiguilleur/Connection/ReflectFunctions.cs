using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;


namespace Aiguilleur.Connection
{
    public class ReflectFunctions
    {
        public String getHtml(Object obj)
        {
            string value = "";
            string tr = "<tr>";
            string trClose = "</tr>";
            string td = "<td>";
            string tdClose = "</td>";
            Type cl = obj.GetType();
            FieldInfo[] att = cl.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            string[] attName = new string[att.Length];
            string[] methName = new string[att.Length];
            MethodInfo[] methods = new MethodInfo[att.Length];
            Type[] classArg = new Type[0];
            Object[] objArg = new Object[0];
            value += tr;
            for (int i = 0; i < att.Length; i++)
            {
                attName[i] = att[i].Name;
                methName[i] = "get" + firstMaj(attName[i]);
                methods[i] = cl.GetMethod(methName[i], classArg);
            }
            for (int i = 0; i < att.Length; i++)
            {
                value += td + methods[i].Invoke(obj, objArg) + tdClose;
            }
            value += trClose;
            return value;
        }
        public string firstMaj(string str)
        {
            str = str.Trim();
            string valiny = "";
            str = str.ToLower();
            char[] cara = str.ToCharArray();
            char[] vao = new char[cara.Length - 1];
            string debut = "" + (cara[0]);
            debut = debut.ToUpper();
            for (int i = 0; i < vao.Length; i++)
            {
                vao[i] = cara[i + 1];
            }
            string fin = new string(vao);
            valiny = string.Concat(debut, fin);
            return valiny;
        }
        object[] addObjet(object[] tabObj, object toAdd)
        {
            object[] temp = new object[tabObj.Length + 1];
            int i = 0;
            for (i = 0; i < tabObj.Length; i++)
            {
                temp[i] = tabObj[i];
            }
            temp[i] = toAdd;
            return temp;
        }

        public static object[] select(SqlConnection c, string table, string sep, string[] where)
        {
            string sql = "select * from " + table;
            string tab = table.ToUpper();
            SqlCommand command = new SqlCommand("select column_name from INFORMATION_SCHEMA.COLUMNS where table_name='" + tab + "'", c);
            SqlDataReader dataReader = command.ExecuteReader();
            int nb = 0;
            while (dataReader.Read())
            {
                nb++;
            }
            if (where != null)
            {
                sql = sql + " where ";
            }
            for (int i = 0; i < where.Length; i++)
            {
                if (sep != null)
                {
                    sql = sql + where[i] + " " + sep + " ";
                }
                else
                {
                    sql = sql + where[i];
                }
            }
            if (sep != null)
            {
                sql = sql.Substring(0, sql.Length - (sep.Length + 2));
            }
            dataReader.Close();
            command.Dispose();
            string maj = table.Substring(0, 1);
            maj = maj.ToUpper();
            string tableMaj = maj + table.Substring(1, table.Length);
            Type cl = Type.GetType(table + "." + tableMaj);
            SqlCommand command2 = new SqlCommand(sql, c);
            SqlDataReader dataReader2 = command.ExecuteReader();
            List<object> result = new List<object>();
            object[] arg = new Object[nb];
            Type[] param = new Type[nb];
            while (dataReader2.Read())
            {
                for (int i = 0; i < nb; i++)
                {
                    if (dataReader2.GetValue(i) is string)
                    {
                        arg[i] = (string)dataReader2.GetValue(i);
                    }
                    else
                    {
                        arg[i] = (double)dataReader2.GetValue(i);
                    }
                    param[i] = arg[i].GetType();
                }
                ConstructorInfo cons = cl.GetConstructor(param);
                result.Add(cons.Invoke(arg));
            }
            return result.ToArray();
        }

        void update(DBConnection db, Object o, string tableName, string attribtoignore)
        {
            bool check = true;
            if (db == null)
            {
                check = false;
                db = new DBConnection();
                db.OpenConnection();
            }
            try
            {
                FieldInfo[] attrib = o.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                Console.WriteLine("taille " + attrib.Length);

                string sql = "UPDATE " + tableName + " SET ";
                for (int i = 0; i < attrib.Length; i++)
                {
                    Object a = attrib[i].GetValue(o);
                    if (a is string && !attrib[i].Name.Equals(attribtoignore))
                    {
                        if (a is string || a is DateTime)
                        {
                            sql += attrib[i].Name + "='" + a + "'";
                        }
                        else
                        {
                            sql += attrib[i].Name + "=" + a;
                        }
                        sql += i + 1 != attrib.Length ? "," : "";
                    }
                }

                if (!attribtoignore.Equals(""))
                {
                    sql += " WHERE " + attribtoignore + "='" + attrib[0].GetValue(o) + "'";
                }

                Console.Write(sql);
                SqlCommand cmd = new SqlCommand(sql, db.getCon());
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!check)
                {
                    db.CloseConnection();
                }
            }
        }

        bool insert(DBConnection con, string tabName, Object toInsert)
        {
            bool check = true;
            if (con == null)
            {
                con = new DBConnection();
                check = false;
                con.OpenConnection();
            }
            bool result = false;
            try
            {
                string objName = toInsert.GetType().Name;
                FieldInfo[] champs = toInsert.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                string[] att = new string[champs.Length];
                MethodInfo[] functions = new MethodInfo[champs.Length];
                Type[] clas = new Type[0];
                object[] arg = new object[0];
                object[] valeurs = new object[functions.Length];

                string donnees = "";

                att[0] = champs[0].Name;
                att[0] = "get" + firstMaj(att[0]);
                functions[0] = toInsert.GetType().GetMethod(att[0], clas);
                valeurs[0] = functions[0].Invoke(toInsert, arg);
                if (valeurs[0] is string)
                {
                    donnees = "'" + valeurs[0] + "'";
                }
                else if (valeurs[0] is DateTime)
                {
                    donnees = "DateTime '" + valeurs[0] + "'";
                }
                else
                {
                    donnees = "" + valeurs[0];
                }
                for (int i = 1; i < champs.Length; i++)
                {
                    att[i] = champs[i].Name;
                    att[i] = "get" + (firstMaj(att[i]));
                    functions[i] = toInsert.GetType().GetMethod(att[i], clas);
                    valeurs[i] = functions[i].Invoke(toInsert, arg);
                    if (valeurs[i] is string)
                    {
                        valeurs[i] = "'" + valeurs[i] + "'";
                    }
                    donnees = donnees + "," + valeurs[i];
                }
                if (objName.CompareTo(tabName) == 0)
                {
                    string query = "INSERT INTO " + tabName + " VALUES (" + donnees + ")";
                    result = true;
                    Console.WriteLine("query " + query);
                    SqlCommand cmd = new SqlCommand(query, con.getCon());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!check)
                {
                    con.CloseConnection();
                }
            }
            return result;
        }

        List<FieldInfo> getAttributs(object o)
        {
            Type appel = o.GetType();
            FieldInfo [] att = appel.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            int nb = att.Length;
            string[] nameMethods = new string[nb];
            MethodInfo[] methods = new MethodInfo[nb];
            object[] args = new object[0];
            Type[] clArgs = new Type[0];

            List<FieldInfo> temp = new List<FieldInfo>();
		    for(int i = 0; i<nb;i++){
			    nameMethods[i] = "get"+firstMaj(att[i].Name);
			    methods[i] = appel.GetMethod(nameMethods[i], clArgs);
			    if((methods[i].Invoke(o, args)).ToString().CompareTo("")!=0){
				    temp.Add(att[i]);
				    Console.Write("ok");
                }
            }
	    return temp;
	    }
	    List<FieldInfo> getAttributsNuls(object o)
        {
        Type appel = o.GetType();
        FieldInfo []att = appel.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
	    int nb = att.Length;
        string []nameMethods = new string[nb];
	    MethodInfo[] methods = new MethodInfo[nb];
        object[] args = new object[0];
        Type[] clArgs = new Type[0];

        List<FieldInfo> temp = new List<FieldInfo>();
		    for(int i = 0; i<nb;i++){
			    nameMethods[i] = "get"+firstMaj(att[i].Name);
			    methods[i] = appel.GetMethod(nameMethods[i], clArgs);
			    if((methods[i].Invoke(o, args)).ToString().CompareTo("")==0){
				    temp.Add(att[i]);
			    }
		    }
	    return temp;
	    }
	    public void update(DBConnection db, object o, string tableName, string[] att, string[] search)
        {
        bool check = true;
		    if(db==null){
            check = false;
            db = new DBConnection();
            db.OpenConnection();
            }
            try
            {
            Type cl = o.GetType();
            object[] arg = new object[0];
            FieldInfo[] nonNuls = getAttributs(o).ToArray();
            int n = nonNuls.Length;
            MethodInfo[] fonc = new MethodInfo[n];
            string[] toChange = new string[n];
            string[] valeurs = new string[n];
            Type[] paramTypes = new Type[n];
            Type[] args = new Type[0];
            for (int i = 0; i < n; i++)
            {
                paramTypes[i] = nonNuls[i].GetType();
                toChange[i] = nonNuls[i].Name;
                fonc[i] = cl.GetMethod("get" + firstMaj(nonNuls[i].Name), args);
                valeurs[i] = (fonc[i].Invoke(o, arg)).ToString();
            }

            string entete = "";
            string query = "";
            string complement = "";
            if (n > 0)
            {
                entete += toChange[0] + "=";
                if (paramTypes[0].Name.ToLower().CompareTo("string") == 0)
                {
                    entete += "'" + valeurs[0] + "'";
                }
                for (int i = 1; i < n; i++)
                {
                    entete += "," + toChange[i] + "=";
                    if (paramTypes[0].Name.ToLower().CompareTo("string") == 0)
                    {
                        entete += "'" + valeurs[i] + "'";
                    }
                }

                complement += att[0] + search[0];
                for (int i = 1; i < att.Length; i++)
                {
                    complement += " AND " + att[i] + search[i];
                }
                query += "UPDATE " + tableName + " SET " + entete + " WHERE " + complement;
                db.ExecuteQueries(query);
            }
            else
            {
                throw new Exception("Pas de donnees a modifier?????????");
            }
        }catch(Exception e){
            throw e;
        }finally{
            if (!check)
            {
                db.CloseConnection();
            }
        }
    }

    }
}