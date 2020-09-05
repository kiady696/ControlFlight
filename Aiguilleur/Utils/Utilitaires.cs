using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Aiguilleur.Utils
{
    public class Utilitaires
    {

        public static DateTime parseStringInputToDbDateTime(string dateInput,string dateFormatDb)
        {
            try
            {
                //dateFormatDb = "yyyy / MM / dd HH: mm: ss.fff";
                //DateTime res = Convert.ToDateTime(dateInput);
                
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime res = DateTime.ParseExact("05/09/2020", "yyyy-MM-dd h:m:s tt", provider);
                System.Diagnostics.Debug.WriteLine(res.ToString());
                return res;
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static DateTime getToday()
        {
            DateTime today = DateTime.Today;
            return today;
        }

        public static void FillDDL<T>(DropDownList DDL, List<ListItem> list)
        {
            DDL.DataSource = list;
            DDL.DataBind();
            DDL.Items.Insert(0, list[0]);
            DDL.SelectedIndex = 0;
        }
    }
}