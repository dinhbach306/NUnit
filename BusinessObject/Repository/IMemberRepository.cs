using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IMemberRepository
    {
        Member checkLogin(string username, string password);
        List<Member> GetAllMember();
        Member getMemberById(int id);
        Member getMemberByEmail(string email);
        void AddMember(Member member);
        List<Member> SearchMember(string text);
        void UpdateMember(Member member);
        void RemoveMember(Member member);
    }
}
