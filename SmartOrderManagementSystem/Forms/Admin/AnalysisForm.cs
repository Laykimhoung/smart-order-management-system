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
            cmbPeriod.Items.Clear();

            cmbPeriod.Items.Add("All");
            cmbPeriod.Items.Add("Daily");
            cmbPeriod.Items.Add("Weekly");
            cmbPeriod.Items.Add("Monthly");
            cmbPeriod.Items.Add("Yearly");

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
                .SeriesChartType.Line;

            chartRevenue.Series["Revenue"].BorderWidth = 3;

            chartRevenue.Series["Revenue"].Color =
                Color.FromArgb(0, 122, 204);

            chartRevenue.Legends[0].Enabled = false;

            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor =
                Color.LightGray;

            chartRevenue.ChartAreas[0].AxisX.Interval = 1;
            chartRevenue.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartRevenue.ChartAreas[0].AxisX.LabelStyle.Font =
                new Font("Segoe UI", 8);

            string query = "";

            switch (cmbPeriod.Text)
            {
                case "Daily":

                    query = @"
SELECT
DATEPART(HOUR, OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE CAST(OrderDate AS DATE) =
      CAST(GETDATE() AS DATE)
GROUP BY DATEPART(HOUR, OrderDate)";
                    break;

                case "Weekly":

                    query = @"
SELECT
DATENAME(WEEKDAY, OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE OrderDate >= DATEADD(DAY,-7,GETDATE())
GROUP BY DATENAME(WEEKDAY, OrderDate)";
                    break;

                case "Monthly":

                    query = @"
SELECT
DAY(OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE MONTH(OrderDate)=MONTH(GETDATE())
AND YEAR(OrderDate)=YEAR(GETDATE())
GROUP BY DAY(OrderDate)";
                    break;

                case "Yearly":

                    query = @"
SELECT
MONTH(OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
WHERE YEAR(OrderDate)=YEAR(GETDATE())
GROUP BY MONTH(OrderDate)";
                    break;

                default:

                    query = @"
SELECT
YEAR(OrderDate) AS Label,
SUM(TotalAmount) AS Revenue
FROM Orders
GROUP BY YEAR(OrderDate)
ORDER BY YEAR(OrderDate)";
                    break;
            }

            DataTable dt =
                DatabaseConnection.ExecuteQuery(query);

            // DAILY
            if (cmbPeriod.Text == "Daily")
            {
                Dictionary<int, decimal> revenue =
                    new Dictionary<int, decimal>();

                for (int i = 0; i <= 24; i++)
                    revenue[i] = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int hour =
                        Convert.ToInt32(row["Label"]);

                    revenue[hour] =
                        Convert.ToDecimal(row["Revenue"]);
                }

                for (int i = 0; i <= 24; i++)
                {
                    chartRevenue.Series["Revenue"]
                        .Points.AddXY(
                            i + ":00",
                            revenue[i]);
                }

                chartRevenue.ChartAreas[0].AxisX.Interval = 6;
            }

            // WEEKLY
            else if (cmbPeriod.Text == "Weekly")
            {
                string[] days =
                {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

                Dictionary<string, decimal> revenue =
                    new Dictionary<string, decimal>();

                foreach (string day in days)
                    revenue[day] = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string day =
                        row["Label"].ToString();

                    if (revenue.ContainsKey(day))
                    {
                        revenue[day] =
                            Convert.ToDecimal(
                                row["Revenue"]);
                    }
                }

                foreach (string day in days)
                {
                    chartRevenue.Series["Revenue"]
                        .Points.AddXY(
                            day,
                            revenue[day]);
                }
            }

            // MONTHLY
            else if (cmbPeriod.Text == "Monthly")
            {
                Dictionary<int, decimal> revenue =
                    new Dictionary<int, decimal>();

                for (int i = 1; i <= 31; i++)
                    revenue[i] = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int day =
                        Convert.ToInt32(
                            row["Label"]);

                    revenue[day] =
                        Convert.ToDecimal(
                            row["Revenue"]);
                }

                for (int i = 1; i <= 31; i++)
                {
                    chartRevenue.Series["Revenue"]
                        .Points.AddXY(
                            i,
                            revenue[i]);
                }

                chartRevenue.ChartAreas[0].AxisX.Interval = 5;
            }

            // YEARLY
            else if (cmbPeriod.Text == "Yearly")
            {
                string[] months =
                {
            "Jan","Feb","Mar","Apr",
            "May","Jun","Jul","Aug",
            "Sep","Oct","Nov","Dec"
        };

                Dictionary<int, decimal> revenue =
                    new Dictionary<int, decimal>();

                for (int i = 1; i <= 12; i++)
                    revenue[i] = 0;

                foreach (DataRow row in dt.Rows)
                {
                    int month =
                        Convert.ToInt32(
                            row["Label"]);

                    revenue[month] =
                        Convert.ToDecimal(
                            row["Revenue"]);
                }

                for (int i = 1; i <= 12; i++)
                {
                    chartRevenue.Series["Revenue"]
                        .Points.AddXY(
                            months[i - 1],
                            revenue[i]);
                }
            }

            // ALL
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    chartRevenue.Series["Revenue"]
                        .Points.AddXY(
                            row["Label"],
                            row["Revenue"]);
                }
            }
        }
        private void LoadTopProductsChart()
        {
            chartTopProducts.Series.Clear();

            chartTopProducts.Series.Add("Products");

            chartTopProducts.Series["Products"].ChartType =
                System.Windows.Forms.DataVisualization.Charting
                .SeriesChartType.Bar;

            chartTopProducts.Legends[0].Enabled = false;

            chartTopProducts.ChartAreas[0]
                .AxisX.MajorGrid.Enabled = false;

            chartTopProducts.ChartAreas[0]
                .AxisY.MajorGrid.Enabled = false;

            chartTopProducts.Series["Products"]
                ["PointWidth"] = "0.6";

            chartTopProducts.BackColor =
                Color.White;

            int topCount = 5;

            switch (cmbPeriod.Text)
            {
                case "Daily":
                    topCount = 3;
                    break;

                case "Weekly":
                    topCount = 5;
                    break;

                case "Monthly":
                    topCount = 5;
                    break;

                case "Yearly":
                    topCount = 5;
                    break;

                case "All":
                    topCount = 5;
                    break;
            }

            string query = $@"
SELECT TOP {topCount}
    P.ProductName,
    SUM(OI.Quantity) AS Qty
FROM OrderItems OI
INNER JOIN Orders O
    ON OI.OrderID = O.OrderID
INNER JOIN Products P
    ON OI.ProductID = P.ProductID
WHERE {GetDateFilter()}
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

            chartLeastProducts.Legends[0].Enabled = false;

            chartLeastProducts.ChartAreas[0]
                .AxisX.MajorGrid.Enabled = false;

            chartLeastProducts.ChartAreas[0]
                .AxisY.MajorGrid.Enabled = false;

            chartLeastProducts.Series["Products"]
                ["PointWidth"] = "0.6";

            chartLeastProducts.BackColor =
                Color.White;

            int topCount = 5;

            switch (cmbPeriod.Text)
            {
                case "Daily":
                    topCount = 3;
                    break;

                case "Weekly":
                    topCount = 5;
                    break;

                case "Monthly":
                    topCount = 5;
                    break;

                case "Yearly":
                    topCount = 5;
                    break;

                case "All":
                    topCount = 5;
                    break;
            }

            string query = $@"
SELECT TOP {topCount}
    P.ProductName,
    SUM(OI.Quantity) AS Qty
FROM OrderItems OI
INNER JOIN Orders O
    ON OI.OrderID = O.OrderID
INNER JOIN Products P
    ON OI.ProductID = P.ProductID
WHERE {GetDateFilter()}
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
        private string GetDateFilter()
        {
            switch (cmbPeriod.Text)
            {
                case "Daily":
                    return "CAST(O.OrderDate AS DATE) = CAST(GETDATE() AS DATE)";

                case "Weekly":
                    return "O.OrderDate >= DATEADD(DAY,-7,GETDATE())";

                case "Monthly":
                    return @"MONTH(O.OrderDate)=MONTH(GETDATE())
                     AND YEAR(O.OrderDate)=YEAR(GETDATE())";

                case "Yearly":
                    return "YEAR(O.OrderDate)=YEAR(GETDATE())";

                default:
                    return "1=1";
            }
        }
    }
}
