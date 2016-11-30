using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace ThaiWood.Models
{
    public abstract class AbstractProductViewModel 
    {
        protected ProductModel pm;
        public DataSet ds;
        public abstract void LoadViewModel(int id);
        public abstract AbstractProductViewModel Load(int id);
    }

    public class MasterViewModel : AbstractProductViewModel
    {
        
        public override void LoadViewModel(int id)
        {
            pm = new ProductModel();
            ds = pm.GetMaster();
        }

        public override AbstractProductViewModel Load(int id)
        {
            LoadViewModel(id);
            return this;
        }
    }

    public class ProductViewModel: AbstractProductViewModel
    {

        public override void LoadViewModel(int id)
        {
            pm = new ProductModel();
            ds = pm.GetProduct();
        }

        public override AbstractProductViewModel Load(int id)
        {
            LoadViewModel(id);
            return this;
        }
    }

    public class ProductFromCategoryViewModel: AbstractProductViewModel 
    {
        public override void LoadViewModel(int id)
        {
            pm = new ProductModel();
            ds = pm.GetProductFromCategory(id);
            
        }

        public override AbstractProductViewModel Load(int id)
        {
            LoadViewModel(id);
            return this;
        }
    }
    
    public class ProductFromBrandViewModel : AbstractProductViewModel
    {
        public override void LoadViewModel(int id)
        {
            pm = new ProductModel();
            ds = pm.GetProductFromBrand(id);

        }

        public override AbstractProductViewModel Load(int id)
        {
            LoadViewModel(id);
            return this;
        }
    }

    public class TypeFromProductViewModel : AbstractProductViewModel
    {
        public override void LoadViewModel(int id)
        {
            pm = new ProductModel();
            ds = pm.GetTypeFromProductId(id);

        }

        public override AbstractProductViewModel Load(int id)
        {
            LoadViewModel(id);
            return this;
        }
    }

    public class ProductFromProductIdViewModel : AbstractProductViewModel 
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public string productBrand { get; set; }
        public string productCategory { get; set; }
        public string productPrice { get; set; }
        public string productCount { get; set; }
        

        public override void LoadViewModel(int id)
        {
            pm = new ProductModel();
            ds = pm.GetProductFromProductId(id);

            if (ds.Tables["ProductDetail"].Rows.Count > 0) 
            {
                DataRow dr = ds.Tables["ProductDetail"].Rows[0];
                productId = dr[0].ToString();
                productName = dr[1].ToString();
                productCategory = pm.ConvertCategory(int.Parse(dr[2].ToString()));
                productBrand = pm.ConvertBrand(int.Parse(dr[3].ToString()));
                productPrice = dr[4].ToString();
                productCount = dr[5].ToString();
            }
        }

        public override AbstractProductViewModel Load(int id)
        {
            LoadViewModel(id);
            return this;
        }
    }

    public class ProductHelper 
    {
        public static int HelperIncreaseProductCount (int id)
        {
            ProductModel pm = new ProductModel();
            return pm.IncreaseProductCount(id);
        }
    }

    public class ProductModel
    {
        DataSet ds = new DataSet();

        public DataSet GetMaster() 
        {
            ds.Clear();
            LoadProductCategory();
            LoadProductBrand();

            return ds;
        }

        public DataSet GetProduct()
        {
            ds.Clear();
            LoadProduct();

            return ds;
        }

        public DataSet GetProductFromCategory(int id)
        {
            ds.Clear();
            LoadProductFromCategory(id);

            return ds;
        }

        public DataSet GetProductFromBrand(int id)
        {
            ds.Clear();
            LoadProductFromBrand(id);

            return ds;
        }

        public DataSet GetProductFromProductId(int id) 
        {
            ds.Clear();
            LoadProductFromProductId(id);

            return ds;
        }

        public DataSet GetTypeFromProductId(int id)
        {
            ds.Clear();
            LoadTypeFromProductId(id);

            return ds;
        }

        public int IncreaseProductCount(int productId) 
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 1 * FROM [Sheet1$] WHERE [Product id] = " + productId;
            string pathname = HttpContext.Current.Server.MapPath("~/Data/Product.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(dt);
            }

            int count = 0;

            if (dt.Rows.Count > 0) 
            {
                count = int.Parse(dt.Rows[0][5].ToString());
                count++;

                String excelConnection2 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
                OleDbConnection objConn = new OleDbConnection(excelConnection2);
                objConn.Open();
                
                sql = "UPDATE [Sheet1$] SET [Product Count] = " + count + " WHERE [Product Id] = " + productId;
                OleDbCommand objCmdSelect = new OleDbCommand(sql, objConn);
                objCmdSelect.ExecuteNonQuery();
                
                return count;
            }


            return -1;
        }

        public DataTable LoadProductFromProductId(int productId) 
        {
            
            string sql = "SELECT TOP 1 * FROM [Sheet1$] WHERE [Product id] = " + productId;
            string pathname = HttpContext.Current.Server.MapPath("~/Data/Product.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "ProductDetail");
            }

            return ds.Tables["ProductDetail"];
        }

        public DataTable LoadTypeFromProductId(int productId)
        {

            string sql = "SELECT * FROM [Sheet1$]";
            string pathname = HttpContext.Current.Server.MapPath("~/Data/Type.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "Type");
            }

            return ds.Tables["Type"];
        }

        public DataTable LoadProductFromBrand(int productBrandId)
        {            
            string sql = "SELECT * FROM [Sheet1$] WHERE [Product Brand] = " + productBrandId;
            string pathname = HttpContext.Current.Server.MapPath("~/Data/Product.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "Product");
            }

            return ds.Tables["Product"];
        } 

        public DataTable LoadProductFromCategory(int productCategoryId) 
        {   
            string sql = "SELECT * FROM [Sheet1$] WHERE [Product Category] = " + productCategoryId;
            string pathname = HttpContext.Current.Server.MapPath("~/Data/Product.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "Product");
            }

            return ds.Tables["Product"];
        } 

        public DataTable LoadProduct()
        {
            string sql = "SELECT * FROM [Sheet1$]";
            string pathname = HttpContext.Current.Server.MapPath("~/Data/Product.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";
            
            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "Product");
            }

            return ds.Tables["Product"];
        }

        public DataTable LoadProductCategory() 
        {
            string sql = "SELECT * FROM [Sheet1$]";
            string pathname = HttpContext.Current.Server.MapPath("~/Data/ProductCategory.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "ProductCategory");
            }

            return ds.Tables["ProductCategory"];
        }

        public DataTable LoadProductBrand() 
        {
            string sql = "SELECT * FROM [Sheet1$]";
            string pathname = HttpContext.Current.Server.MapPath("~/Data/ProductBrand.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "ProductBrand");
            }

            return ds.Tables["ProductBrand"];
        }

        public string ConvertBrand(int id) 
        {
            string sql = "SELECT * FROM [Sheet1$]";
            string pathname = HttpContext.Current.Server.MapPath("~/Data/ProductBrand.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "ProductBrand");
            }
            string result = "";
            foreach (DataRow dr in ds.Tables["ProductBrand"].Rows) 
            {
                if (int.Parse(dr[0].ToString()) == id) 
                {
                    result = dr[1].ToString();
                    return result;
                }
            }

            return null;            
        }

        public string ConvertCategory(int id)
        {
            string sql = "SELECT * FROM [Sheet1$]";
            string pathname = HttpContext.Current.Server.MapPath("~/Data/ProductCategory.xls");
            string excelConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathname + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"";

            using (OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, excelConnection))
            {
                adaptor.Fill(ds, "ProductCategory");
            }
            string result = "";
            foreach (DataRow dr in ds.Tables["ProductCategory"].Rows)
            {
                if (int.Parse(dr[0].ToString()) == id)
                {
                    result = dr[1].ToString();
                    return result;
                }
            }

            return null;
        }
    }
}