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

                string dateFilter = "";

                switch (period)
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

            string query = @"
SELECT
CAST(OrderDate AS DATE) AS OrderDay,
SUM(TotalAmount) AS Revenue
FROM Orders
GROUP BY CAST(OrderDate AS DATE)
ORDER BY OrderDay";

            DataTable dt =
                DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                chartRevenue.Series["Revenue"]
                    .Points.AddXY(
                        Convert.ToDateTime(row["OrderDay"])
                        .ToString("dd/MM"),
                        row["Revenue"]);
            }
        }
        private void LoadTopProductsChart()
        {
            chartTopProducts.Series.Clear();

            chartTopProducts.Series.Add("Products");

            string query = @"
SELECT TOP 5
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
                        row["ProductName"].ToString(),
                        row["Qty"]);
            }
        }
        private void LoadLeastProductsChart()
        {
            chartLeastProducts.Series.Clear();

            chartLeastProducts.Series.Add("Products");

            string query = @"
SELECT TOP 5
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
                        row["ProductName"].ToString(),
                        row["Qty"]);
            }
        }
    }
}
