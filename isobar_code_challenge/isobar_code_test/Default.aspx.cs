
using isobar_code_test.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace isobar_code_test
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            string address = Address.Text;
            StringBuilder htmlTable = new StringBuilder();
            int noofresults = Constants.noOfResults;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56676/api/");
                 var input = new Input(address,noofresults);
                var responseTask = client.PostAsJsonAsync<Input>("shortestDistance", input);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Distance>>();
                    readTask.Wait();
                    var distances = readTask.Result;
                    htmlTable.Append("<table border='1'>");
                    htmlTable.Append("<tr style='background-color:blue; color: White;'><th>Starting Location </th><th>Destination Location </th><th> Distance (in km)</th></tr>");
                    foreach (var distance in distances)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + distance.StartLocation + "</td>");
                        htmlTable.Append("<td>" + distance.DestinationLocation + "</td>");
                        htmlTable.Append("<td>" + distance.Distanceinkm + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</table>");
                    DynamicDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}