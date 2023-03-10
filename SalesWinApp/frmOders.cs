using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessObject.Repository;
using BusinessObject.RD;

namespace SalesWinApp
{
    public partial class frmOders : Form
    {
        private frmMain frmMain;
        public frmOders(frmMain frmMain)
        {
            InitializeComponent();

            numOrderId.Controls.RemoveAt(0);
            numOrderId.Maximum = 9999;

            numFreight.Controls.RemoveAt(0);
            numFreight.Maximum = decimal.MaxValue;

            numUnitPrice.Controls.RemoveAt(0);
            numUnitPrice.Maximum = decimal.MaxValue;

            numQuantity.Maximum = decimal.MaxValue;

            numDiscount.Controls.RemoveAt(0);
            numDiscount.Maximum = 100;

            LoadComboxData();
            this.frmMain = frmMain;
        }

        private void frmOders_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.Show();
            this.Hide();
        }

        private void LoadComboxData()
        {

            var memberRepo = new MemberRepository();
            memberComboBox.DisplayMember = "CompanyName";
            memberComboBox.ValueMember = "MemberId";
            memberComboBox.DataSource = memberRepo.GetAllMember().Where(member => !member.Email.Contains("admin@fstore.com")).ToList();

            var productRepo = new ProductRepository();
            productComboBox.DisplayMember = "ProductName";
            productComboBox.ValueMember = "ProductId";
            productComboBox.DataSource = productRepo.GetAll();
        }

        private void LoadData()
        {
            var orderRepo = new OrderRepository();
            dataGridView.DataSource = orderRepo.GetAll();
        }

        private void Search()
        {
            var orderRepo = new OrderRepository();
            if (txtSearchBox.Text == "Enter your order id")
            {
                return;
            }
            var searchOrder = orderRepo.GetAll().FindAll(order => Convert.ToString(order.OrderId).Contains(txtSearchBox.Text)).ToList();

            dataGridView.DataSource = searchOrder;
        }

        private void frmOders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var orderRepo = new OrderRepository();
            var orderDetailRepo = new OrderDetailRepository();

            var orderId = dataGridView.SelectedRows[0].Cells[0].Value.ToString();

            var order = orderRepo.GetAll().FirstOrDefault(order => order.OrderId == int.Parse(orderId));
            numOrderId.Value = order.OrderId;
            memberComboBox.SelectedValue = order.MemberId;
            orderDatePicker.Value = order.OrderDate;
            requiredDatePicker.Value = order.RequiredDate;
            shippedDatePicker.Value = order.ShipperDate;
            numFreight.Value = order.Freight;

            var orderDetail = orderDetailRepo.GetAll().FirstOrDefault(orderDetail => orderDetail.OrderId == int.Parse(orderId));
            productComboBox.SelectedValue = orderDetail.ProductId;
            numUnitPrice.Value = orderDetail.UnitPrice;
            numQuantity.Value = orderDetail.Quantity;
            numDiscount.Value = (decimal)orderDetail.Discount * 100;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMain.Show();
            this.Hide();
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            var productRepo = new ProductRepository();
            int productId = 0;

            try
            {
                productId = Convert.ToInt32(productComboBox.SelectedValue);
            }
            catch (Exception)
            {
                return;
            }
            var product = productRepo.GetAll().FirstOrDefault(product => product.ProductId == productId);
            numUnitPrice.Value = product.UnitPrice;
            if (numQuantity.Value == 0)
            {
                numQuantity.Value = 1;
            }

            if (numDiscount.Value == 0)
            {
                numFreight.Value = numUnitPrice.Value * numQuantity.Value;
            }
            else
            {
                numFreight.Value = (numUnitPrice.Value * numQuantity.Value) - (numUnitPrice.Value * numQuantity.Value * (numDiscount.Value / 100));
            }
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (numDiscount.Value == 0)
            {
                numFreight.Value = numUnitPrice.Value * numQuantity.Value;
            }
            else
            {
                numFreight.Value = (numUnitPrice.Value * numQuantity.Value) - (numUnitPrice.Value * numQuantity.Value * (numDiscount.Value / 100));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var orderRepo = new OrderRepository();
            var orderDetailRepo = new OrderDetailRepository();

            var productRepo = new ProductRepository();

            numOrderId.Value = Convert.ToDecimal(RandomID.RandomInt(4));
            var order = new Order()
            {
                OrderId = (int)numOrderId.Value,
                MemberId = Convert.ToInt32(memberComboBox.SelectedValue.ToString()),
                OrderDate = orderDatePicker.Value,
                RequiredDate = requiredDatePicker.Value,
                ShipperDate = shippedDatePicker.Value,
                Freight = numFreight.Value,
            };

            var orderDetail = new OrderDetail()
            {
                OrderId = order.OrderId,
                ProductId = Convert.ToInt32(productComboBox.SelectedValue.ToString()),
                UnitPrice = numUnitPrice.Value,
                Quantity = (int)numQuantity.Value,
                Discount = (double)numDiscount.Value / 100
            };

            var product = productRepo.GetAll().FirstOrDefault(product => product.ProductId == orderDetail.ProductId);

            if (product.UnislnStock - orderDetail.Quantity < 0)
            {
                MessageBox.Show("The quantity of " + product.ProductName + " only have " + product.UnislnStock + " product(s)! Please re-enter quantity");
                return;
            }

            product.UnislnStock -= orderDetail.Quantity;
            orderRepo.Add(order);
            orderDetailRepo.Add(orderDetail);
            productRepo.Update(product);
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var orderRepo = new OrderRepository();
            var orderDetailRepo = new OrderDetailRepository();
            var productRepo = new ProductRepository();

            var order = orderRepo.GetAll().FirstOrDefault(order => order.OrderId == (int)numOrderId.Value);

            order.MemberId = Convert.ToInt32(memberComboBox.SelectedValue.ToString());
            order.OrderDate = orderDatePicker.Value;
            order.RequiredDate = requiredDatePicker.Value;
            order.ShipperDate = shippedDatePicker.Value;
            order.Freight = numFreight.Value;

            var quantityChange = 0;

            var orderDetail = orderDetailRepo.GetAll().FirstOrDefault(orderDetail => orderDetail.OrderId == order.OrderId);

            orderDetail.ProductId = Convert.ToInt32(productComboBox.SelectedValue.ToString());
            orderDetail.UnitPrice = numUnitPrice.Value;
            quantityChange = (int)numQuantity.Value - orderDetail.Quantity;
            orderDetail.Quantity = (int)numQuantity.Value;
            orderDetail.Discount = (double)numDiscount.Value / 100;

            var product = productRepo.GetAll().FirstOrDefault(product => product.ProductId == orderDetail.ProductId);

            if (product.UnislnStock - quantityChange < 0)
            {
                MessageBox.Show("The quantity of " + product.ProductName + " only have " + product.UnislnStock + " product(s)! Please re-enter quantity");
                return;
            }

            product.UnislnStock -= quantityChange;
            orderRepo.Update(order);
            orderDetailRepo.Update(orderDetail);
            productRepo.Update(product);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var orderRepo = new OrderRepository();
            var orderDetailRepo = new OrderDetailRepository();

            var orderId = dataGridView.Rows[0].Cells[0].Value;
            orderDetailRepo.Delete((int)orderId);
            orderRepo.Delete((int)orderId);

            LoadData();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "")
            {
                LoadData();
            }
        }

        private void txtSearchBox_Enter(object sender, EventArgs e)
        {
            if (txtSearchBox.Text.Equals("Enter your order id"))
            {
                txtSearchBox.Text = "";
                txtSearchBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void txtSearchBox_Leave(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "")
            {
                txtSearchBox.Text = "Enter your order id";
                txtSearchBox.ForeColor = SystemColors.WindowFrame;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (numDiscount.Value == 0)
            {
                numFreight.Value = numUnitPrice.Value * numQuantity.Value;
            }
            else
            {
                numFreight.Value = (numUnitPrice.Value * numQuantity.Value) - (numUnitPrice.Value * numQuantity.Value * (numDiscount.Value / 100));
            }
        }
    }
}
