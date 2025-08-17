using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Question2 : System.Web.UI.Page
    {

        Dictionary<string, (string, string)> products = new Dictionary<string, (string, string)>
        {
            { "Dell", ("~/images/Dell.jpg", "₹90,000") },
            { "Macbook", ("~/images/Macbook.jpg", "₹112,000") },
            { "Lenovo", ("~/images/Lenovo.jpg", "₹75,000") },
            { "Samsung", ("~/images/Samsung.jpg", "₹77,000") }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var product in products.Keys)
                {
                    DropDownList1.Items.Add(product);
                }
            }
        }


        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (products.TryGetValue(DropDownList1.SelectedValue, out var product))
            {
                Image1.ImageUrl = product.Item1;
                LabelPrice.Text = "";
            }
            else
            {
                Image1.ImageUrl = "";
                LabelPrice.Text = "";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (products.TryGetValue(DropDownList1.SelectedValue, out var product))
            {
                LabelPrice.Text = $"Price of This Laptop: {product.Item2}";
            }
            else
            {
                LabelPrice.Text = "Please select a product.";
            }
        }
    }
}