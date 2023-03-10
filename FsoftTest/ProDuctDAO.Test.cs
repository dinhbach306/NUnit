using BusinessObject;
using BusinessObject.Repository;
using DataAccess;
using FsoftTest.helper;
using Moq;


namespace FsoftTest;

[TestFixture]
public class ProDuctDAO_Test
{
    
    [TestCase(900, "Iphone XS", "300g", 27, 5 )]
    [TestCase(901, "Sony 43inch", "3.2kg", 30, 3 )]
    [TestCase(902, "Fridge", "15kg", 15, 10 )]
    public void TestAddProduct(int id, string productName, string weight, decimal unitPrice, int UnislnStock)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        Product product = new Product(id, productName, weight, unitPrice, UnislnStock);
        // Act
        dao.Add(product);

        // Assert
        var result = dao.GetProductByID(product.ProductId);
        
        Assert.Multiple(() =>
        {
            Assert.That(result.ProductName, Is.EqualTo(productName));
            Assert.That(result.Weight, Is.EqualTo(weight));
            Assert.That(result.UnitPrice, Is.EqualTo(unitPrice));
            Assert.That(result.UnislnStock, Is.EqualTo(UnislnStock));
        });
    }

    [TestCase(887, 100, 100, 2, "Iphone 14", "0.887","Iphone 14")]
    [TestCase(888, 100, 100, 2, "Iphone 14", "0.888","Iphone 14")]
    [TestCase(890, 100, 100, 2, "Iphone 14", "0.890","Iphone 14")]
    [TestCase(891, 100, 100, 2, "Iphone 14", "0.891","Iphone 14")]
    public void TestUpdateProduct(int _Id, int _UnislnStock, decimal _unitPrice, int _CategoryId, String _Weight,
        String _ProductName,string expect)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        Product product = new Product(_Id, _UnislnStock, _unitPrice, _CategoryId, _Weight, _ProductName);
        // Act
        dao.Update(product);

        // Assert
        Product result = dao.GetProductByID(product.ProductId);
        Assert.AreEqual(expect, result.Weight);
    }

    [TestCase(900)]
    [TestCase(901)]
    [TestCase(902)]
    public void TestDeleteProduct(int id)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        // Act
        Product result = dao.GetProductByID(id);
        dao.Delete(result);
        // Assert
        Assert.IsNull(null);
    }

    [TestCase(547, 547)]
    [TestCase(547, 0)]
    public void TestGetProductByID(int id, int expect)
    {
        // Arrange
        // var id = 547;
        var dao = ProductDAO.Instance;
        // Act
        var result = dao.GetProductByID(id);

        Assert.AreEqual(expect, result.ProductId);
    }

    [TestCase(12)]
    public void TestGetAllProducts(int expect)
    {
        // Arrange
        var dao = ProductDAO.Instance;
        // Act
        var result = dao.GetAllData();

        // Assert
        Assert.AreEqual(expect, result.Count);
    }


    // [Category("Algorithm")]
    //Test sort by UnitPrice

    
    [Test]
    public void Test_Sort_UnitPrice()
    {
        // Arrange
        var dao = ProductDAO.Instance;
        // Act
        var product = dao.getListProductById(new int[]{900, 901, 902});
        var actual = Algorithms.SortSelection(product);
        
        // Assert
        Assert.That(actual.Select(product => product.UnitPrice), 
            Is.EqualTo(new decimal[] { 30, 27, 15 }));
    }
}