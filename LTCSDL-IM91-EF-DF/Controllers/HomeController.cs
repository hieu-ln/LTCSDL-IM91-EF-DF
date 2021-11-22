using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTCSDL_IM91_EF_DF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            /* // Them
            Category c = new Category();
            c.CategoryName = "EF";
            c.Description = "Entity Framework";
            var cat = AddNewCategory(c);
            */
            /* //Xoa
            var res = DeleteCategory(12);
            */

            //Update
            Category c = new Category();
            c.CategoryID = 11;
            c.Description = "Lap Trinh CSDL voi EF";
            var res = UpdateCategory(c);
            List<Category> lst = LoadCategory().ToList();
            return View(lst);
        }

        public IList<Category> LoadCategory()
        {
            IList<Category> lst = new List<Category>();
            using (var db = new NorthwindEntities())
            {
                var cate = from c in db.Categories
                           select c;
                lst = cate.ToList();
            }
            return lst;
        }
        public Category AddNewCategory(Category c)
        {
            using (var db = new NorthwindEntities())
            {
                db.Categories.Add(c);
                db.SaveChanges();
            }
            return c;
        }

        public bool DeleteCategory(int id)
        {
            bool res = false;
            using (var db = new NorthwindEntities())
            {
                Category c = db.Categories.First(x => x.CategoryID == id);
                db.Categories.Remove(c);
                db.SaveChanges();
                res = true;
            }
            return res;
        }

        public bool UpdateCategory(Category c)
        {
            bool res = false;
            using (var db = new NorthwindEntities())
            {
                Category cat = db.Categories.First(x => x.CategoryID == c.CategoryID);
                if(string.IsNullOrEmpty(c.CategoryName)==false)
                    cat.CategoryName = c.CategoryName;
                if (string.IsNullOrEmpty(c.Description) == false)
                    cat.Description = c.Description;
                db.SaveChanges();
                res = true;
            }
            return res;
        }
    }
}
