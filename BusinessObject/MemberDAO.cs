using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MemberDAO
    {
        //------------------------------------------------------------------
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                }
                return instance;
            }
        }
        //-----------------------------------------------------------------

        public Member Check(string email, string password)
        {
            var MB = new Member();
            try
            {
                using var context = new FstoreContext();
                MB = context.Members.SingleOrDefault(c => c.Email == email && c.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return MB;
        }

        //Get All Member
        public List<Member> GetAllMember()
        {
            using var context = new FstoreContext();
            List<Member> list = context.Members.ToList();

            return list;
        }
        //---
        public Member getMemberById(int id)
        {
            using var context = new FstoreContext();
            Member member = context.Members.FirstOrDefault(p => p.MemberId == id);
            return member;
        }
        //---
        public Member getMemberByEmail(string email)
        {
            using var context = new FstoreContext();
            Member member = context.Members.FirstOrDefault(p => p.Email.Equals(email));
            return member;
        }
        //---
        public void AddMember(Member member)
        {
            using var context = new FstoreContext();
            context.Members.Add(member);
            context.SaveChanges();
        }
        //---
        public List<Member> SearchMember(String text)
        {
            using var context = new FstoreContext();
            List<Member> members = context.Members.Where(p => p.MemberId.ToString().Contains(text)
            || p.Country.Contains(text)
            || p.City.Contains(text)
            || p.CompanyName.Contains(text)
            || p.Email.Contains(text))
                .ToList();
            return members;
        }
        //---
        public void UpdateMember(Member member)
        {
            using var context = new FstoreContext();

            Member oldMember = context.Members.FirstOrDefault(p => p.MemberId == member.MemberId);

            oldMember.Email = member.Email;
            oldMember.Country = member.Country;
            oldMember.City = member.City;
            oldMember.CompanyName = member.CompanyName;
            oldMember.Password = member.Password;

            context.Update(oldMember);
            context.SaveChanges();
        }

        public void RemoveMember(Member member)
        {
            using var context = new FstoreContext();

            Member oldMember = context.Members.FirstOrDefault(p => p.MemberId == member.MemberId);

            context.Remove(oldMember);
            context.SaveChanges();
        }
    }
}
