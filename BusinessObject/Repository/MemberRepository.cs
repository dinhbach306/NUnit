using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public Member checkLogin(string email, string password)  => MemberDAO.Instance.Check(email, password);
        public void AddMember(Member member)
        {
            MemberDAO.Instance.AddMember(member);
        }
        public List<Member> GetAllMember()
        {
            return MemberDAO.Instance.GetAllMember();
        }

        public Member getMemberByEmail(string email)
        {
            return MemberDAO.Instance.getMemberByEmail(email);
        }

        public Member getMemberById(int id)
        {
            return MemberDAO.Instance.getMemberById(id);
        }

        public void RemoveMember(Member member)
        {
            MemberDAO.Instance.RemoveMember(member);
        }

        public List<Member> SearchMember(string text)
        {
            return MemberDAO.Instance.SearchMember(text);
        }

        public void UpdateMember(Member member)
        {
            MemberDAO.Instance.UpdateMember(member);
        }
    }

}
