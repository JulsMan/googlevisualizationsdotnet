<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Postbacks.aspx.cs" Inherits="TestGoogleCharsNGraphsControls.Postbacks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Charts with Postback Annimation</h3>

        <asp:PlaceHolder ID="PlaceHolderChart" runat="server" />

        <p />

        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button1_Click" PostBackUrl="~/Postbacks.aspx" />
    </div>

    <p />

    <hr />

    <pre>
public partial class Postbacks : System.Web.UI.Page
{
    const int WD = 300;
    const int HT = 200;

    protected void Page_Load(object sender, EventArgs e)
    {
        codebehindGauge();
    }
        
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.PlaceHolderChart.Controls.Clear();
        codebehindGauge();
        codebehindAreaChart();
    }

    private void codebehindAreaChart()
    {
        GoogleChartsNGraphsControls.GVAreaChart chart = new GoogleChartsNGraphsControls.GVAreaChart();
        chart.Width = WD;
        chart.Height = HT;

        chart.DataSource = getDT();
        chart.DataBind();

        this.PlaceHolderChart.Controls.Add(chart);

    }

    private void codebehindGauge()
    {
        GoogleChartsNGraphsControls.GVGauge chart = new GoogleChartsNGraphsControls.GVGauge();
        chart.Width = WD;
        chart.Height = HT;

        chart.GviRedFrom = 90;
        chart.GviRedTo = 100;
        chart.GviYellowFrom = 75;
        chart.GviYellowTo = 90;


        chart.DataSource = getDT();
        chart.DataBind();

        this.PlaceHolderChart.Controls.Add(chart);

    }

    private DataTable getDT()
    {
        Random rnd = new Random(System.Environment.TickCount);

        System.Data.DataTable dt = new System.Data.DataTable("Computer");
        dt.Columns.AddRange(new System.Data.DataColumn[] {
            new System.Data.DataColumn("Label",typeof(string)), 
            new System.Data.DataColumn("Value",typeof(int))
        });
        dt.Rows.Add(new object[] { "Memory", rnd.Next(100) });
        dt.Rows.Add(new object[] { "CPU", rnd.Next(100) });
        dt.Rows.Add(new object[] { "Network", rnd.Next(100) });

        return dt;
    }

}
    </pre>
    </form>
</body>
</html>
