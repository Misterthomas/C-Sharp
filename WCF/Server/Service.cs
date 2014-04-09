using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ConsoleApplication1;

namespace Coursework
{

    public class Service : IService
    {
        BikeSalesClassesDataContext db = new BikeSalesClassesDataContext();

        /// <summary>
        /// This method returns the matriculation number that has been hardcoded into the server.
        /// </summary>
        /// <returns>Matriculation</returns>
        public string GetMatriculation()
        {
            return string.Format(CompositeType.matriculation);
        }

        /// <summary>
        /// This method returns the number of records that are stored in the BikeStockItem table.
        /// </summary>
        /// <returns>Count</returns>
        public int GetNumberOfRecords()
        {
            int count =
            ((from c in db.BikeStockItems
              select c).Count());


            return count;
        }

        /// <summary>
        /// This method calculates the tottal weight of the all bikes that are stored in the database
        /// </summary>
        /// <returns>The weight of the all bikes. </returns>
        public int TottalWeight()
        {

            int totalweight =
        (from ord in db.BikeStockItems
         select ord.Weight)
        .Sum();
            return totalweight;
        }

        /// <summary>
        /// This method method records that bike has been sold
        /// </summary>
        /// <param name="BikeId">The id of the bike that is going through the selling proccess</param>
        /// <returns>Returns the string that the sell was sucesfully recorded in the database or returns an execption if the wrong id was provided</returns>
        public string SellBike(int BikeId)
        {


            try
            {
                BikeStockItem li = db.BikeStockItems.Single(c => c.BikeStockItemID == BikeId);
                li.IsSold = true;
                db.SubmitChanges();
                return string.Format("The bike has been successfully sold");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught. {0}", e);
                return string.Format("The error has occurred");
            }

        }

        /// <summary>
        /// This function provides the deatils of each bike that has been stored in the database
        /// </summary>
        /// <returns>Returns the content of the BikeStockItems table</returns>
        public List<CompositeType> GetAllBikeStock()
        {
            IEnumerable<CompositeType> l1 =
                from l in db.BikeStockItems
                select new CompositeType
                {
                    BikeId = l.BikeStockItemID,
                    Sold = l.IsSold,

                    BikeTypeId = l.BikeTypeID,
                    WheelTypeId = l.WheelTypeID,
                    colorId = l.ColourID,
                    Brand = l.Brand,
                    Material = l.Material,
                    Weight = l.Weight,
                    DataNew = l.DataNew,
                    StockEntryDate = l.StockEntryDate,
                    Price = l.Price,


                };
            List<CompositeType> listL1 = l1.ToList();
            return listL1;
        }

        /// <summary>
        /// This method gets the bikes that are in range of the prices provided by the user.
        /// It also combines the BikeStockItems table with the 
        /// Colour table.
        /// </summary>
        /// <param name="minprice">The min price of the bike</param>
        /// <param name="maxprice">The max price of the bike</param>
        /// <returns>List</returns>
        public List<CompositeType> GetBikeByPrice(decimal minprice, decimal maxprice)
        {

            IEnumerable<CompositeType> l1 =
             from l in db.BikeStockItems.Where(d => (decimal)d.Price >= minprice && (decimal)d.Price <= maxprice)
             join x in db.Colours on l.ColourID equals x.ColourID
             select new CompositeType

             {
                 BikeId = l.BikeStockItemID,
                 Sold = l.IsSold,

                 BikeTypeId = l.BikeTypeID,
                 WheelTypeId = l.WheelTypeID,
                 colorId = l.ColourID,
                 Brand = l.Brand,
                 Material = l.Material,
                 Weight = l.Weight,
                 DataNew = l.DataNew,
                 StockEntryDate = l.StockEntryDate,
                 Price = l.Price,
                 Colourname = x.ColourName,
                 Metallic = x.Metallic,

             };
            List<CompositeType> listL1 = l1.ToList();
            return listL1;

        }

        /// <summary>
        /// This method enables the user to delete bike form the database.
        /// </summary>
        /// <param name="BikeId">The id of the bike</param>
        /// <returns>Confirmation of the deletion of the row</returns>
        public string DeleteBike(int BikeId)
        {
            BikeStockItem li = db.BikeStockItems.Single(c => c.BikeStockItemID == BikeId);
            db.BikeStockItems.DeleteOnSubmit(li);
            db.SubmitChanges();

            return string.Format("The bike has been successfully deleted");

        }
        /// <summary>
        /// This method adds the bike to the BikeStockItem table
        /// </summary>
        /// <param name="biketype">ID of the bike type</param>
        /// <param name="wheeltype">ID of the wheel type</param>
        /// <param name="colorid">ID of the colour table</param>
        /// <param name="brand">The brand name</param>
        /// <param name="material">The name of the material</param>
        /// <param name="weight">The totall weight of the bike</param>
        /// <param name="datanew">New data</param>
        /// <param name="stockentrydate">Stock entry data</param>
        /// <param name="price">The price of bike</param>
        /// <param name="sold">If the bike has been sold or not</param>
        /// <returns>The id of the new entry that has been entered</returns>
        public string AddBike(int biketype, int wheeltype, int colorid, string brand,
            string material, int weight, DateTime datanew, DateTime stockentrydate, decimal price, bool sold)
        {
            BikeStockItem record = new BikeStockItem();
            record.BikeTypeID = biketype;
            record.WheelTypeID = wheeltype;
            record.ColourID = colorid;
            record.Brand = brand;
            record.Material = material;
            record.Weight = weight;
            record.DataNew = datanew;
            record.StockEntryDate = stockentrydate;
            record.Price = price;
            record.IsSold = sold;

            db.BikeStockItems.InsertOnSubmit(record);
            db.SubmitChanges();
            return string.Format("Record inserted as ID : {0}", record.BikeStockItemID);



        }
        /// <summary>
        /// This method allows the BikeStockItems table to be updated. 
        /// </summary>
        /// <param name="BikeId">The id of the bike that will be updated</param>
        /// <param name="biketype">ID of the bike type</param>
        /// <param name="wheeltype">ID of the wheel type</param>
        /// <param name="colorid">ID of the colour table</param>
        /// <param name="brand">The brand name</param>
        /// <param name="material">The name of the material</param>
        /// <param name="weight">The totall weight of the bike</param>
        /// <param name="datanew">New data</param>
        /// <param name="stockentrydate">Stock entry data</param>
        /// <param name="price">The price of bike</param>
        /// <param name="sold">If the bike has been sold or not</param>
        /// <returns>The confirmation that row was updated</returns>
        public string UpdateBike(int BikeId, int biketype, int wheeltype, int colorid, string brand,
          string material, int weight, DateTime datanew, DateTime stockentrydate, decimal price, bool sold)
        {
            BikeStockItem record = db.BikeStockItems.Single(c => c.BikeStockItemID == BikeId);

            record.BikeTypeID = biketype;
            record.WheelTypeID = wheeltype;
            record.ColourID = colorid;
            record.Brand = brand;
            record.Material = material;
            record.Weight = weight;
            record.DataNew = datanew;
            record.StockEntryDate = stockentrydate;
            record.Price = price;
            record.IsSold = sold;
            db.SubmitChanges();
            return string.Format("The bike has been successfully updated");
        }

    }
}

