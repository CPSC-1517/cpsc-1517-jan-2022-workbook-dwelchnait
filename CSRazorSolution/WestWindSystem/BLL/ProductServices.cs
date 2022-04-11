
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;  //for EntityEntry<>
#endregion


namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region setup of the context connection variable and class constructor

        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal ProductServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries
        //filter search returning all products of the requested category (categoryid)
        public List<Product> Product_CategoryProducts(int categoryid)
        {
            IEnumerable<Product> info = _context.Products
                                .Where(x => x.CategoryID == categoryid)
                                .OrderBy(x => x.ProductName);
            return info.ToList();
        }

        //for the CRUD you are maintaining a SINGLE row on the database
        //this row will be obtained by the pkey value of the row
        public Product Product_GetById(int productid)
        {
            //where is matching on the primary key field
            //Linq by default is expecting to return 0, 1 or more rows
            //WHEN your receive variable (product) expects ONLY a SINGLE
            //  instance of the class (Product), you will "tell" Linq
            //  to return the "first" instance found OR a "default" value
            //  of the variable data type (is a class thus it will be null
            //    for the object instance)

            Product product = _context.Products
                                .Where(x => x.ProductID == productid)
                                .FirstOrDefault();
            return product;
        }

        #endregion

        #region Add, Update, Delete

        //Adding a record to your database may require you to
        //   verify the data does not already exist on the database
        //This can be done using a Linq query and a given set of
        //  verification field.
        //Example: for this product insertion will will verify
        //  that this is no product record on the database with
        //  the same product name and quantity per unit from the
        //  same supplier. If so, throw an Exception

        //you MUST know whether the table has a identity pkey or not
        //if the table pkey is NOT an identity then you MUST ensure
        //  that the incoming instance of the row HAS a pkey value
        //If the table pkey is an identity then the database WILL
        //  generate that value and make it assessable to you AFTER
        //  the data has been committed.

        //Product pkey is an identity attribute
        //This method optionally sends the new identity value back to the
        //  web page (PageModel call statement)
        public int Product_AddProduct(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Product data is missing");
            }
            //this is an optional sample of validation of incoming data
            Product exists = _context.Products
                            .Where(x => x.ProductName.Equals(item.ProductName) &&
                                        x.QuantityPerUnit.Equals(item.QuantityPerUnit) &&
                                        x.SupplierID == item.SupplierID)
                            .FirstOrDefault();
            if (exists != null)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $" from the selected supplier is already on file");
            }

            //stage the data in local memory to be submitted to the database for 
            //  storage
            // a) what DbSet
            // b) the action
            // c) indicate the data involved.

            //IMPORTANT: the data is in LOCAL memory; it has NOT!!!!!!! yet been sent
            //          to the database.
            //          THEREFORE: at this time, there is NO!!!!! primary key value (except
            //              for the system default (numerics -> 0)
            _context.Products.Add(item);

            // commit the LOCAL data to the database

            //IF there are validation annotations on your Entity
            //  they will be executed during the SaveChanges
            _context.SaveChanges();

            //AFTER the commit, your pkey value will NOW be available to you
            return item.ProductID;
        }

        //update
        //update can also have design considerations for validation
        //update may request that you check the record of interest is still
        //  on the database
        
        public int Product_UpdateProduct(Product item)
        {
            //for an update, you MUST have the pkey value on your instance
            //if not, it will not work.

            // ***** WARNING ****** 
            // can cause PROBLEMS when being used with EntityEntry<t> processing

            //this technique returns an instance (object)
            //Product exists = _context.Products
            //                    .Where(x => x.ProductID == item.ProductID)
            //                    .FirstOrDefault();
            //if (exists == null)
            //{
            //    throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
            //    $" from the selected supplier is not on file");
            //}

            // ****** BETTER ************
            // this does NOT actually return an instance and thus has no
            //   CONFLICT with using EntityEntry<T>

            //this technique does the search BUT returns only a boolean of success
            bool exists = _context.Products.Any(x => x.ProductID == item.ProductID);  
            //if(!_context.Products.Any(x => x.ProductID == item.ProductID))
            if (!exists)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $" from the selected supplier is not on file");
            }

            //stage the update
            EntityEntry<Product> updating = _context.Entry(item);
            //flag the entity to be modified
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            //during the commit, SaveChanges() returns the number of rows affected
            return _context.SaveChanges();
        }

        public int Product_DeleteProduct(Product item)
        {
            //for an delete, you MUST have the pkey value on your instance
            //if not, it probably will not work as expected.

            //this technique returns an instance (object)
            //Product exists = _context.Products
            //                    .Where(x => x.ProductID == item.ProductID)
            //                    .FirstOrDefault();

            //this technique does the search BUT returns only a boolean of success
            bool exists = _context.Products.Any(x => x.ProductID == item.ProductID);

            //DEPENDING on which technique you use, your error test will be different
            //one:   if (exists == null) {....}
            if (!exists)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $" from the selected supplier is not on file");
            }

            //Removing a record from your database maybe a
            // a) phyiscal act
            //   OR
            // b) logical act

            // a) if you wish the record to be "phyiscally remove from the databae
            //    you will use the staging of .Deleted
            //    if the record being removed from the database is a "parent" record
            //      (referenced in a foreign key), the delete WILL FAIL in a relational
            //      database IF there are existing "children" or the record
            //    sql "parent records cannot be deleted if children exist"
            //    the decission to automatically remove "children" is a system design decission 

            //stage the phyiscal delete
            //EntityEntry<Product> deleting = _context.Entry(item);
            //flag the entity to be deleted
            //.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            // b) Locial delete
            //      this is where you do not or cannot phyiscally remove a record from
            //      the database.
            //      This decission is based on existing best practice business rules OR
            //          set by government regulations
            //      this type of delete is done so the "flagged" data is NOT used in
            //          daily processing
            //
            //   this type of delete will actually be an update the attribute (property) 
            //      of the record.
            //   Look for attributes such as Active, Discontinued, a special date ReleaseDate

            // Product is a logical delete (Discontinued = true;)

            //stage the logical delete
            item.Discontinued = true;
            EntityEntry<Product> updating = _context.Entry(item);
            //flag the entity to be deleted
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;



            //during the commit, SaveChanges() returns the number of rows affected
            return _context.SaveChanges();
        }

        #endregion
    }
}
