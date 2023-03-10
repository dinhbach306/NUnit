using BusinessObject.Repository;
using BusinessObject.RD;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SalesWinApp
{
    public partial class frmUser : Form
    {
        IProductRepository productRepository = new ProductRepository();
        BindingSource source;
        public frmUser(Member member)
        {
            
            InitializeComponent();
            txtCity.Text = member.City;
            txtCompanyName.Text = member.CompanyName;
            txtCountry.Text = member.Country;
            txtEmail.Text = member.Email;
            txtMemberId.Text = Convert.ToString(member.MemberId);
            txtPassword.Text = Convert.ToString(member.Password);
            LoadListProduct();
            LoadListOrderDetail();
        }

        private void Clear()
        {
            txtCity.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMemberId.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        public void LoadListProduct()
        {
            var list = productRepository.GetAll();
            try
            {
                source = new BindingSource();
                source.DataSource = list;

                productDataGridView.DataSource = null;
                productDataGridView.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadListOrderDetail()
        {
            //hien thi orderID, productID, Productname, Thanh tien = quantity * unitprice.
            var orderRepo = new OrderRepository();
            var orderDetailRepo = new OrderDetailRepository();
            var productRepository = new ProductRepository();
            var listP = productRepository.GetAll();


            foreach (var order in orderRepo.GetAll())
            {
                if (order.MemberId == Convert.ToInt32(txtMemberId.Text))
                {
                    var orderDetail = orderDetailRepo.GetAll().FirstOrDefault(orderDetail => orderDetail.OrderId == order.OrderId);
                    if (orderDetail != null)
                    {
                        var product = productRepository.GetAll().FirstOrDefault(product => product.ProductId == orderDetail.ProductId);

                        dataGridView2.Rows.Add(order.OrderId, product.ProductId, product.ProductName, order.Freight);
                    }
                }
            }
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            var orderRepo = new OrderRepository();
            var orderDetailRepo = new OrderDetailRepository();
            var productRepo = new ProductRepository();

            decimal total = 0;
            var productId = productDataGridView.SelectedRows[0].Cells[0].Value;

            var product = productRepo.GetAll().FirstOrDefault(product => product.ProductId == (int)productId);
            if (numDiscount.Value == 0)
            {
                total = product.UnitPrice * numQuantity.Value;
            }
            else
            {
                total = (product.UnitPrice * numQuantity.Value) - (product.UnitPrice * numQuantity.Value * (numDiscount.Value / 100));
            }
            var order = new Order()
            {
                OrderId = Convert.ToInt32(RandomID.RandomInt(4)),
                MemberId = Convert.ToInt32(txtMemberId.Text),
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShipperDate = DateTime.Now,
                Freight = total
            };
            var orderDetail = new OrderDetail()
            {
                OrderId = order.OrderId,
                ProductId = product.ProductId,
                UnitPrice = product.UnitPrice,
                Quantity = Convert.ToInt32(numQuantity.Value),
                Discount = Convert.ToDouble(numDiscount.Value) / 100
            };

            if (product.UnislnStock - orderDetail.Quantity < 0)
            {
                MessageBox.Show("The quantity of " + product.ProductName + " only have " + product.UnislnStock + " product(s)! Please re-enter quantity");
                return;
            }
            product.UnislnStock -= orderDetail.Quantity;
            productRepo.Update(product);
            orderRepo.Add(order);
            orderDetailRepo.Add(orderDetail);
            dataGridView2.Rows.Clear();
            productDataGridView.Rows.Clear();
            LoadListProduct();
            LoadListOrderDetail();
        }
        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var memberRepo = new MemberRepository();
            var member = new Member()
            {
                MemberId = Convert.ToInt32(txtMemberId.Text),
                Email = txtEmail.Text,
                City = txtCity.Text,
                CompanyName = txtCompanyName.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text,
            };

            memberRepo.UpdateMember(member);
            MessageBox.Show("Update Successfull");
        }
    }
}
