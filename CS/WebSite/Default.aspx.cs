using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page {
    DataTable GetData() {
        DataTable table;
        if (Session["table"] == null) {
            table = new DataTable();

            DataColumn column = table.Columns.Add("id", typeof(Int32));
            table.Columns.Add("parent_id", typeof(Int32));
            table.Columns.Add("text", typeof(String));
            table.PrimaryKey = new DataColumn[] { column };

            Int32 key = 0;
            for (Int32 i = 0; i < 10; i++) {
                table.Rows.Add(new Object[] { key, null, String.Format("Test{0}", key) });
                Int32 parent = key;
                for (Int32 j = 0; j < 20; j++) {
                    key++;
                    table.Rows.Add(new Object[] { key, parent, String.Format("Test{0}", key) });
                }
                key++;
            }

            Session["table"] = table;
        }
        else
            table = (DataTable)Session["table"];

        return table;
    }

    protected void Page_Init(object sender, EventArgs e) {
        tree.DataSource = GetData();
        tree.DataBind();
    }

    List<Int32> keys = new List<Int32>();
    Boolean deleted = false;

    protected void tree_NodeDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e) {
        keys.Add(Convert.ToInt32(e.Keys[0]));
    }

    protected void tree_NodeDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e) {
        e.ExceptionHandled = true;
        deleted = true;
    }

    protected void tree_DataBinding(object sender, EventArgs e) {
        if (deleted) {
            DataTable table = GetData();

            foreach (Int32 key in keys)
                table.Rows.Remove(table.Rows.Find(key));

            Session["table"] = table;

            tree.DataSource = table;
        }
    }

    protected void tree_CustomJSProperties(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomJSPropertiesEventArgs e) {
        if (deleted) {
            Int32[] a = keys.ToArray();
            String[] strArray = Array.ConvertAll(a, new Converter<Int32, String>(Convert.ToString));
            e.Properties["cpKeys"] = String.Join(", ", strArray);
        }
    }
}
