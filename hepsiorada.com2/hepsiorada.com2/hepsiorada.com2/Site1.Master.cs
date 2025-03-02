using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hepsiorada.com2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {}
        protected void urunbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("urunekle.aspx");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void sepetbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("sepet.aspx");
        }
    }
}