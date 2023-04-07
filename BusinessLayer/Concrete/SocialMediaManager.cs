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
	public class SocialMediaManager : ISocialMediaService
	{
		ISocialMediaDal _socialmedia;

		public SocialMediaManager(ISocialMediaDal socialmedia)
		{
			_socialmedia = socialmedia;
		}

		public void Delete(SocialMedia t)
		{
			_socialmedia.Delete(t);
		}

		public SocialMedia getbyID(int ID)
		{
			return _socialmedia.getbyID(ID);
		}

		public List<SocialMedia> GetListAll()
		{
			return _socialmedia.GetListAll();
		}

		public void Insert(SocialMedia t)
		{
			_socialmedia.Insert(t);
		}

		public void Update(SocialMedia t)
		{
			_socialmedia?.Update(t);
		}
	}
}
