using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void AnnouncementStatusFalse(int id)
        {
            _announcementDal.AnnouncementStatusFalse(id);
        }

        public void AnnouncementStatusTrue(int id)
        {
            _announcementDal.AnnouncementStatusTrue(id);
        }

        public void Delete(Announcement t)
        {
            _announcementDal.Delete(t);
        }

        public Announcement getbyID(int ID)
        {
            return _announcementDal.getbyID(ID);
        }

        public List<Announcement> GetListAll()
        {
            return _announcementDal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcementDal.Insert(t);
        }

        public void Update(Announcement t)
        {
            _announcementDal.Update(t);
        }
    }
}
