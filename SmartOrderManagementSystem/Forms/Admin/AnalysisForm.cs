using SmartOrderManagementSystem.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartOrderManagementSystem.Forms.Admin
{
    public partial class AnalysisForm : Form
    {
        public AnalysisForm()
        {
            InitializeComponent();
        }
        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            cmbPeriod.SelectedIndex = 0;

            LoadSummaryCards();
            LoadRevenueChart();
            LoadTopProductsChart();
            LoadLeastProductsChart();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadRevenueChart();
            LoadTopProductsChart();
            LoadLeastProductsChart();
        }
        private void LoadSummaryCards()
        {
            try
            {
                string period = cmbPeriod.Text;

                string dateFilter = "1=1";

                switch (cmbPeriod.Text)
                {
                    case "Daily":
                        dateFilter =
                            "CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
                        break;

                    case "Weekly":
                        dateFilter =
                            "OrderDate >= DATEADD(DAY,-7,GETDATE())";
                        break;

                    case "Monthly":
                        dateFilter =
                            "MONTH(OrderDate)=MONTH(GETDATE()) " +
                            "AND YEAR(OrderDate)=YEAR(GETDATE())";
                        break;

                    case "Yearly":
                        dateFilter =
                            "YEAR(OrderDate)=YEAR(GETDATE())";
                        break;

                    case "All":
                        dateFilter = "1=1";
                        break;
                }

                DataTable dt =
                    DatabaseConnection.ExecuteQuery($@"
SELECT
COUNT(*) AS TotalOrders,
SUM(TotalAmount) AS Revenue,
COUNT(DISTINCT CustomerID) AS Customers
FROM Orders
WHERE {dateFilter}");

                if (dt.Rows.Count > 0)
                {
                    lblTotalOrders.Text =
                        dt.Rows[0]["TotalOrders"].ToString();

                    lblRevenue.Text =
                        "$" +
                        Convert.ToDecimal(
                            dt.Rows[0]["Revenue"] == DBNull.Value
                            ? 0
                            : dt.Rows[0]["Revenue"])
                        .ToString("N2");

                    lblCustomers.Text =
                        dt.Rows[0]["Customers"].ToString();
                }

                DataTable productCount =
                    DatabaseConnection.ExecuteQuery(
                        "SELECT COUNT(*) AS TotalProducts FROM Products");

                lblProducts.Text =
                    productCount.Rows[0]["TotalProducts"]
                    .ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadRevenueChart()
        {
            chartRevenue.Series.Clear();

            chartRevenue.Series.Add("Revenue");

            chartRevenue.Series["Revenue"].ChartType =
                System.Windows.Forms.DataVisualization.Charting
                .SeriesChartType.Spline;

            chartRevenue.Series["Revenue"].BorderWidth = 3;

            chartRevenue.Legends[0].Enabled = false;

            chartRevenue.ChartAreas[0]
                .AxisX.MajorGrid.Enabled = false;

            chartRevenue.ChartAreas[0]
                .AxisY.MajorGrid.LineColor =
                Color.LightGray;

            string query = "";

            switch (cmbPeriod.Text)
            {
                case "Daily":

                    query = @"
SELECT
FORMAT(OrderDate,'HH:mm') AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE CAST(OrderDate AS DATE)=CAST(GETDATE() AS DATE)
GROUP BY FORMAT(OrderDate,'HH:mm')
ORDER BY Label";

                    break;

                case "Weekly":

                    query = @"
SELECT
FORMAT(OrderDate,'ddd') AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE OrderDate >= DATEADD(DAY,-7,GETDATE())
GROUP BY FORMAT(OrderDate,'ddd')
ORDER BY MIN(OrderDate)";

                    break;

                case "Monthly":

                    query = @"
SELECT
DAY(OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE MONTH(OrderDate)=MONTH(GETDATE())
AND YEAR(OrderDate)=YEAR(GETDATE())
GROUP BY DAY(OrderDate)
ORDER BY Label";

                    break;

                default:

                    query = @"
SELECT
DATENAME(MONTH,OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
GROUP BY DATENAME(MONTH,OrderDate),
MONTH(OrderDate)
ORDER BY MONTH(OrderDate)";

                    break;
            }

            DataTable dt =
                DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                chartRevenue.Series["Revenue"]
                    .Points.AddXY(
                        row["Label"],
                        row["Revenue"]);
            }
        }
        private void LoadTopProductsChart()
        {
            chartTopProducts.Series.Clear();

            chartTopProducts.Series.Add("Products");

            chartTopProducts.Series["Products"].ChartType =
                System.Windows.Forms.DataVisualization.Charting
                .SeriesChartType.Bar;

            chartTopProducts.Series["Products"]
                .IsValueShownAsLabel = true;

            chartTopProducts.Legends[0].Enabled = false;

            int topCount = 10;

            switch (cmbPeriod.Text)
            {
                case "Daily":
                    topCount = 5;
                    break;

                case "Weekly":
                    topCount = 7;
                    break;

                case "Monthly":
                    topCount = 10;
                    break;

                case "Yearly":
                    topCount = 15;
                    break;
            }

            string query = $@"
SELECT TOP {topCount}
    P.ProductName,
    SUM(OI.Quantity) AS Qty
FROM OrderItems OI
INNER JOIN Products P
    ON OI.ProductID = P.ProductID
GROUP BY P.ProductName
ORDER BY Qty DESC";

            DataTable dt =
                DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                chartTopProducts.Series["Products"]
                    .Points.AddXY(
                        row["ProductName"],
                        row["Qty"]);
            }
        }
        private void LoadLeastProductsChart()
        {
            chartLeastProducts.Series.Clear();

            chartLeastProducts.Series.Add("Products");

            chartLeastProducts.Series["Products"].ChartType =
                System.Windows.Forms.DataVisualization.Charting
                .SeriesChartType.Bar;

            chartLeastProducts.Series["Products"]
                .IsValueShownAsLabel = true;

            chartLeastProducts.Legends[0].Enabled = false;

            int topCount = 10;

            switch (cmbPeriod.Text)
            {
                case "Daily":
                    topCount = 5;
                    break;

                case "Weekly":
                    topCount = 7;
                    break;

                case "Monthly":
                    topCount = 10;
                    break;

                case "Yearly":
                    topCount = 15;
                    break;
            }

            string query = $@"
SELECT TOP {topCount}
    P.ProductName,
    SUM(OI.Quantity) AS Qty
FROM OrderItems OI
INNER JOIN Products P
    ON OI.ProductID = P.ProductID
GROUP BY P.ProductName
ORDER BY Qty ASC";

            DataTable dt =
                DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                chartLeastProducts.Series["Products"]
                    .Points.AddXY(
                        row["ProductName"],
                        row["Qty"]);
            }
        }
    }
}
