using DAL.EF;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepo
    {
        //private APINTireContext DbContext;
        // Create new category
        public static bool Create(Category c)
        {
            if (c.Name != null)
            {
                var DbContext = new APINTireContext();
                DbContext.Categories.Add(c);
                int chk = DbContext.SaveChanges();
                return chk > 0;
            }
            return false;
        }

        // get all category

        public static List<Category> GetAll()
        {
            var DbContext = new APINTireContext();
            return DbContext.Categories.ToList();
        }

        // get category by id
        public static Category Get(int id)
        {
            var DbContext = new APINTireContext();
            return DbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        // edit a category by obj
        public static bool Edit(Category c)
        {
            if (c.Id != 0 && c.Name != null)
            {
                var DbContext = new APINTireContext();
                var categoryInDb = DbContext.Categories.FirstOrDefault(C => C.Id == c.Id);
                if (categoryInDb != null)
                {
                    categoryInDb.Name = c.Name;
                    int chk = DbContext.SaveChanges();
                    return chk > 0;
                }
                return false;
            }
            return false;
        }
        // delete a category
        public static bool Delete(int id)
        {
            if (id != 0)
            {
                var DbContext = new APINTireContext();
                var categoryInDb = DbContext.Categories.FirstOrDefault(C => C.Id == id);
                if (categoryInDb != null)
                {
                    DbContext.Categories.Remove(categoryInDb);
                    int chk = DbContext.SaveChanges();
                    return (chk > 0);
                }
                return false;
            }
            return false;
        }
    }
}
