using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPOS.Model;

namespace CPOS.Controller
{
    public class CategoryController
    {
        private CPOSContext context;
        public CategoryController()
        {
            this.context = DatabaseController.GetConnection();
            context.Categories.Load();
        }
        public void RegisterCategory(Category cat)
        {
            try
            {
                if (cat.Name != "")
                {
                    if (Helper.MessageHelper.AlertRegisterConfirmation() == DialogResult.Yes)
                    {
                        context.Categories.Add(cat);
                        context.SaveChanges();
                        Helper.MessageHelper.AlertRegisterSuccess();
                    }
                }
                else
                {
                    throw new Exception("Category Name Cannot be Empty.!");
                }
            }
            catch (Exception ex)
            {

                Helper.MessageHelper.AlertError(ex.Message);
            }
        }
        public void RemoveCategory(Category cat)
        {
            try
            {
                if (cat.Id.ToString() != "")
                {
                    if (Helper.MessageHelper.AlertRemoveConfirmation() == DialogResult.Yes)
                    {
                        context.Categories.Remove(cat);
                        context.SaveChanges();
                        Helper.MessageHelper.AlertRemoveSuccess();
                    }
                }
                else
                {
                    throw new Exception("Category Id Cannot Be Empty!");
                }
            }
            catch (Exception ex)
            {

                Helper.MessageHelper.AlertError(ex.Message);
            }
        }
        public void UpdateCategory(Category cat)
        {
            try
            {
                if (cat.Id.ToString() != "" && cat.Name != "")
                {
                    if (Helper.MessageHelper.AlertUpdateConfirmation() == DialogResult.Yes)
                    {
                        context.SaveChanges();
                        Helper.MessageHelper.AlertUpdateSuccess();
                    }
                }
                else
                {
                    throw new Exception("Category Id and Name Cannot Be Empty!");
                }
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
            }
        }
        public BindingList<Category> GetCategoryListForDataGrid()
        {
            context.Categories.Load();
            return context.Categories.Local.ToBindingList<Category>();
        }
        public List<Category> GetCategoryListForComboBox()
        {
            return context.Categories.ToList<Category>();
        }
        public Category GetCategory(int id)
        {
            try
            {
                var cat = context.Categories.FirstOrDefault(x => x.Id == id);
                return cat;
            }
            catch (Exception ex)
            {
                Helper.MessageHelper.AlertError(ex.Message);
                return null;
            }
        }
    }
}
