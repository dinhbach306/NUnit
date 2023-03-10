using BusinessObject.Repository;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProducts : Form
    {
        private IProductRepository productRepository = new ProductRepository();
        private List<Product> products;
        private bool updateMode = false;
        private frmMain frmMain;
        private int id;
        public frmProducts(frmMain frmMain)
        {
            InitializeComponent();
            products = productRepository.GetAll();
            dgvProduct.DataSource = products;
            this.frmMain = frmMain;
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvProduct.SelectedCells[0].RowIndex;

            Product product = products[index];

            EnabledUpdateMode(product);
        }

        private void EnabledUpdateMode(Product product)
        {
            updateMode = true;
            txtCategoryID.Text = product.CategoryId.ToString();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.UnitPrice.ToString();
            txtProductID.Text = product.ProductId.ToString();
            txtProductID.Enabled = false;
            txtWeight.Text = product.Weight.ToString();
            txtUnislnStock.Text = product.UnislnStock.ToString();


            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;




        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Product product;

                int productID;
                if (!int.TryParse(txtProductID.Text, out productID))
                {
                    throw new Exception("Invalid productId");
                }
                if (txtName.Text == "")
                {
                    throw new Exception("productName must not be left empty");
                }
                product = new Product();
                product.ProductId = productID;
                product.ProductName = txtName.Text;
                product.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                product.UnislnStock = Convert.ToInt32(txtUnislnStock.Text);
                product.Weight = txtWeight.Text;
                Debug.WriteLine("frmProduct:btnNew_Click: Updating Product");

                productRepository.Update(product);
                MessageBox.Show("Product has been updated successfully");

                products.Insert(0, product);
                dgvProduct.DataSource = products;
                products = productRepository.GetAll();
                dgvProduct.DataSource = products;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error has occured while adding new Product" + ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this record?", "Delete Confirmation"
                , MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(txtProductID.Text);
                productRepository.Delete(product);

                products = productRepository.GetAll();
                dgvProduct.DataSource = products;
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (updateMode)
            {
                updateMode = false;
                txtCategoryID.Text = "";
                txtName.Text = "";
                txtProductID.Text = "";
                txtProductID.Enabled = true;
                txtPrice.Text = "";
                txtUnislnStock = null;
                txtWeight = null;


                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

            }
            else
            {
                try
                {
                    Product product;

                    int productID;
                    if (!int.TryParse(txtProductID.Text, out productID))
                    {
                        throw new Exception("Invalid productID");
                    }
                    product = new Product();
                    product.ProductId = Convert.ToInt32(txtProductID.Text);
                    product.CategoryId = Convert.ToInt32(txtCategoryID.Text);
                    product.ProductName = txtName.Text;
                    product.Weight = txtWeight.Text;
                    product.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                    product.UnislnStock = Convert.ToInt32(txtUnislnStock.Text);

                    Debug.WriteLine("frmProduct:btn_Add_Click: Adding a new product into database");
                    productRepository.Add(product);
                    MessageBox.Show("Add successfully");

                    products.Insert(0, product);
                    dgvProduct.DataSource = products;
                    products = productRepository.GetAll();
                    dgvProduct.DataSource = products;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtProductID.Text = string.Empty;
            txtUnislnStock.Text = string.Empty;
            txtWeight.Text = string.Empty;

        }
    }
}
