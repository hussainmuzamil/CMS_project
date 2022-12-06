using System;
using System.Collections.Generic;
using System.Linq;
using CMS.Models;

namespace CMS.Data
{
    public class SQLComplaintsRepo:ICMSRepo
    {
        private readonly CMSContext _context;
        public SQLComplaintsRepo(CMSContext context)
        {
            _context = context;

        }

        public void CreateComplaint(Complaint cmp)
        {
            if (cmp == null)
            {
                throw new ArgumentNullException(nameof(cmp));

            }
            _context.Complaints.Add(cmp);
        }

        public void CreateUser(User usr)
        {
            if (usr == null)
            {
                throw new ArgumentNullException(nameof(usr));

            }
            _context.Users.Add(usr);
        }

        public void DeleteComplaint(Complaint cmp)
        {
            if(cmp == null)
            {
                throw new ArgumentNullException(nameof(cmp));

            }
            _context.Complaints.Remove(cmp);
        }

        public IEnumerable<User> GetAllUserIDs()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<Complaint> GetAllComplaints()
        {
            return _context.Complaints.ToList();
        }

        public IEnumerable<Complaint> GetComplaintByDept(string dept)
        {
            return _context.Complaints.Where(p => p.category == dept && p.status == "Forwarded");
        }

        public Complaint GetComplaintByID(int id)
        {

            return _context.Complaints.FirstOrDefault(p => p.complaintID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateComplaint(Complaint cmp)
        {
            //Nothing
        }

        public void UpdateUser(User usr)
        {
            //Nothing
        }

        public IEnumerable<Complaint> GetComplaintByUserID(string uid)
        {
            return _context.Complaints.Where(p => p.userID == uid);
        }
    }
}
