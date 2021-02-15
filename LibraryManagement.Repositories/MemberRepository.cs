using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class MemberRepository
    {
        public MemberRepository()
        {
            Database = new List<Member>();
        }

        public List<Member> Database { get; set; }

        // Save the Object into Database
        public void Create(Member newMember)
        {
            Database.Add(newMember);
        }

        // Delete the Object from Database
        public void Delete(Member selectedMember)
        {
            Database.Remove(selectedMember);
        }
    }
}
