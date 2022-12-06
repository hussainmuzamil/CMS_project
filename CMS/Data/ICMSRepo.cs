using System;
using CMS.Models;
using System.Collections.Generic;


namespace CMS.Data
{
    public interface ICMSRepo
    {
        bool SaveChanges();

        IEnumerable<Complaint> GetAllComplaints();

        Complaint GetComplaintByID(int id);

        void CreateComplaint(Complaint cmp);

        void UpdateComplaint(Complaint cmp);

        void DeleteComplaint(Complaint cmp);

        void CreateUser(User usr);

        void UpdateUser(User usr);

        IEnumerable<Complaint> GetComplaintByDept(string dept);

        IEnumerable<User> GetAllUserIDs();

        IEnumerable<Complaint> GetComplaintByUserID(string uid);



    }
}
