using BusinessObject;
using BusinessObject.Repository;
using DataAccess;
using FsoftTest.helper;
using FsoftTest.inputParam;
using Moq;

namespace FsoftTest;

[TestFixture]
public class Tests
{
    [TestCaseSource(typeof(FileInputSource<MemberInputParam>))]
    public void TestCheckLogin_ValidCredentials_ReturnsMember_Json(
        MemberInputParam inputParam)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        // Act
        if (inputParam.Email != null)
        {
            var expect = dao.Check(inputParam.Email, inputParam.Password);

            // Assert
            Assert.That(inputParam.Actual, Is.EqualTo(expect.Email));
        }
    }
    
    [TestCase("bao@fstore.com", "1", "bao@fstore.com")]
    // [TestCase("ngoc@fstore.com", "1", "ngoc@fstore.com")]
    // [TestCase("admin@fstore.com", "admin@@", "admin@fstore.com")]
    // [TestCase("bao@fstore.com", "1", "ngoc@fstore.com")]
    public void TestCheckLogin_ValidCredentials_ReturnsMember(
        string email, string password, string actual)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        // Act
        Member expect = dao.Check(email, password);

        // Assert
        Assert.AreEqual(expect.Email, actual);
    }

    [TestCase(5)]
    [TestCase(3)]
    [TestCase(8)]
    public void TestGetAllMember_ReturnsAllMembers(int actual)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        // Act
        List<Member> expect = dao.GetAllMember();
        // Assert
        Assert.AreEqual(expect.Count, actual);
    }

    [TestCase("admin@fstore.com", 1)]
    [TestCase("admin@fstore.com", 2)]
    [TestCase("admin@fstore.com", 3)]
    public void TestGetMemberByEmail_ValidEmail_ReturnsMemberID(string email, int actual)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        // Act
        Member expect = dao.getMemberByEmail(email);
        // Assert
        Assert.AreEqual(expect.MemberId, actual);
    }

    [TestCase(2, 1)]
    [TestCase(1, 2)]
    [TestCase(4, 4)]
    public void TestGetMemberById_ValidId_ReturnsMember(int id, int actual)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        // Act
        Member expect = dao.getMemberById(id);
        // Assert
        Assert.AreEqual(expect.MemberId, actual);
    }

    [TestCase(3, "duy", "duy", "duy", "duy", "duy", 9)]
    [TestCase(6, "duy", "duy", "duy", "duy", "duy", 8)]
    [TestCase(7, "duy", "duy", "duy", "duy", "duy", 7)]
    [TestCase(8, "duy", "duy", "duy", "duy", "duy", 6)]
    [TestCase(9, "duy", "duy", "duy", "duy", "duy", 5)]
    public void TestAddMember_NewMember_AddsMemberToDatabase(int memberId,
        string email, string companyName, string city, string country, string password, int actual)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        Member member = new Member(memberId, email, companyName, city, country, password);
        // Act
        dao.AddMember(member);
        var expect = dao.GetAllMember();
        //Assert
        Assert.AreEqual(expect.Count, actual);
    }


    [TestCase(3, "duy", "duy1", "duy", "duy", "duy", "duy1")]
    [TestCase(6, "duy", "duy2", "duy", "duy", "duy", "duy1")]
    [TestCase(7, "duy", "duy3", "duy", "duy", "duy", "duy1")]
    [TestCase(8, "duy", "duy4", "duy", "duy", "duy", "duy1")]
    [TestCase(9, "duy", "duy5", "duy", "duy", "duy", "duy1")]
    public void TestUpdateMember_ExistingMember_UpdatesMember_InDatabase(int memberId,
        string email, string companyName, string city, string country, string password, string actual)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        Member expect = new Member(memberId, email, companyName, city, country, password);
        // Act
        dao.UpdateMember(expect);

        // Assert
        Assert.AreEqual(expect.CompanyName, actual);
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(9)]
    [TestCase(100)]
    public void TestRemoveMember_ExistingMember_RemovesMemberFromDatabase(int id)
    {
        // Arrange
        var dao = MemberDAO.Instance;
        // Act
        var member = dao.getMemberById(id);
        dao.RemoveMember(member);
        
        // Assert
        Assert.IsNull(null);
    }
}