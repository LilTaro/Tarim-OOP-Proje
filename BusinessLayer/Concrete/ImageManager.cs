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
    public class ImageManager : IImageService
    {
        private readonly IImageDal _ImageDal;

        public ImageManager(IImageDal ImageDal)
        {
            _ImageDal = ImageDal;
        }

        public void Delete(Image t)
        {
            _ImageDal.Delete(t);
        }

        public Image getbyID(int ID)
        {
            return _ImageDal.getbyID(ID);
        }

        public List<Image> GetListAll()
        {
            return _ImageDal.GetListAll();
        }

        public void Insert(Image t)
        {
            _ImageDal.Insert(t);
        }

        public void Update(Image t)
        {
            _ImageDal.Update(t);
        }
    }
}
