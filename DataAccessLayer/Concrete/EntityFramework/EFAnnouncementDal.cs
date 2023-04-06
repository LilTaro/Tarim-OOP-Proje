using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public void AnnouncementStatusFalse(int id)
        {
            using var context = new AgricultureContext();
            Announcement p = context.Announcements.Find(id);
            p.Status = false;
            context.SaveChanges();
        }

        public void AnnouncementStatusTrue(int id)
        {
            using var context = new AgricultureContext();
            Announcement p = context.Announcements.Find(id);
            p.Status = true;
            context.SaveChanges();
        }
    }
}
