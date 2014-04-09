using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace BikeClient
{
    class Program
    {


        static void Main(string[] args)
        {

            ServiceReference.ServiceClient server = new ServiceReference.ServiceClient();
            string matriculation = server.GetMatriculation();
            int numberofbikes = server.GetNumberOfRecords();
            int totalweight = server.TottalWeight();




            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tomasz Daraszewicz. " + matriculation);
            Console.ResetColor();
            Console.WriteLine("");

            bool done = false;
            do
            {

                Console.WriteLine("Select one of the following:");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Display the number of bikes");
                Console.WriteLine("[2] Display total weight of bikes");
                Console.WriteLine("[3] Sell bike");
                Console.WriteLine("[4] Display all bikes in stock");
                Console.WriteLine("[5] Display all bikes in price range");
                Console.WriteLine("[6] Add bike");
                Console.WriteLine("[7] Delete bike");
                Console.WriteLine("[8] Update bike");
                Console.WriteLine("");
                Console.ResetColor();
                Console.Write("Enter Your selection (0 to exit): ");
                Console.WriteLine("");
                string strSelection = Console.ReadLine();
                int iSel;
                try
                {
                    iSel = int.Parse(strSelection);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\r\nWhat?\r\n");
                    continue;
                }

                switch (iSel)
                {
                    case 0:
                        done = true;
                        break;
                    case 1:
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(numberofbikes);
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(totalweight);
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.Write("Enter the ID of the bike: ");
                        string bikeid = Console.ReadLine();
                        int bikeintid;
                        bikeintid = int.Parse(bikeid);
                        Console.WriteLine(server.SellBike(bikeintid));
                        break;
                    case 4:


                        foreach (var obj in server.GetAllBikeStock())
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Bike ID: {0}", obj.BikeId);
                            Console.WriteLine("Bike type ID: {0} ", obj.BikeTypeId);
                            Console.WriteLine("Bike brand: {0}", obj.Brand);
                            Console.WriteLine("Bike colour ID: {0} ", obj.colorId);
                            Console.WriteLine("Bike data new: {0} ", obj.DataNew);
                            Console.WriteLine("Bike material: {0} ", obj.Material);
                            Console.WriteLine("Bike Metalic: {0} ", obj.Metallic);
                            Console.WriteLine("Bike price: {0} ", obj.Price);
                            Console.WriteLine("Bike sold: {0} ", obj.Sold);
                            Console.WriteLine("Bike stock entry date: {0}", obj.StockEntryDate);
                            Console.WriteLine("Bike weight: {0}", obj.Weight);
                            Console.WriteLine("Bike wheel type ID: {0}", obj.WheelTypeId);
                            Console.ResetColor();
                            Console.WriteLine("");
                        }


                        break;
                    case 5:
                        Console.Write("Enter the minimum price: ");

                        string max = Console.ReadLine();
                        decimal maxprice;
                        maxprice = decimal.Parse(max);

                        Console.Write("Enter the maximum price: ");

                        string min = Console.ReadLine();
                        decimal minprice;
                        minprice = decimal.Parse(min);

                        foreach (var obj in server.GetBikeByPrice(maxprice, minprice))
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Blue;

                            Console.WriteLine("Colour: {0}", obj.Colourname);
                            Console.WriteLine("Bike ID: {0}", obj.BikeId);
                            Console.WriteLine("Bike type ID: {0} ", obj.BikeTypeId);
                            Console.WriteLine("Bike brand: {0}", obj.Brand);
                            Console.WriteLine("Bike colour ID: {0} ", obj.colorId);
                            Console.WriteLine("Bike data new: {0} ", obj.DataNew);
                            Console.WriteLine("Bike material: {0} ", obj.Material);
                            Console.WriteLine("Bike Metalic: {0} ", obj.Metallic);
                            Console.WriteLine("Bike price: {0} ", obj.Price);
                            Console.WriteLine("Bike sold: {0} ", obj.Sold);
                            Console.WriteLine("Bike stock entry date: {0}", obj.StockEntryDate);
                            Console.WriteLine("Bike weight: {0}", obj.Weight);
                            Console.WriteLine("Bike wheel type ID: {0}", obj.WheelTypeId);
                            Console.ResetColor();
                            Console.WriteLine("");
                        }

                        break;
                    case 6:
                        Console.Write("Enter the type ID: ");

                        string TID = Console.ReadLine();
                        int typeid;
                        typeid = int.Parse(TID);

                        Console.Write("Enter the colour ID: ");

                        string CID = Console.ReadLine();
                        int cid;
                        cid = int.Parse(CID);

                        Console.Write("Enter the wheel type ID: ");

                        string WTID = Console.ReadLine();
                        int wheelid;
                        wheelid = int.Parse(WTID);

                        Console.Write("Enter brand: ");

                        string brand = Console.ReadLine();

                        Console.Write("Enter data new: ");

                        string DataNew = Console.ReadLine();
                        DateTime datanew;
                        datanew = DateTime.Parse(DataNew);

                        Console.Write("Enter the material: ");

                        string material = Console.ReadLine();


                        Console.Write("Enter the price: ");

                        string Price = Console.ReadLine();
                        decimal price;
                        price = decimal.Parse(Price);

                        Console.Write("Is it sold?: ");

                        string Sold = Console.ReadLine();
                        bool sold;
                        sold = bool.Parse(Sold);

                        Console.Write("Enter the weight: ");

                        string Weight = Console.ReadLine();
                        int weight;
                        weight = int.Parse(Weight);


                        Console.Write("Enter stock entry date: ");

                        string DataStock = Console.ReadLine();
                        DateTime datastock;
                        datastock = DateTime.Parse(DataStock);

                        server.AddBike(typeid, wheelid, cid, brand,
                        material, weight, datanew, datastock, price, sold);

                        break;

                    case 7:
                        Console.Write("Enter the ID of the bike: ");

                        string Bikeiddelete = Console.ReadLine();
                        int bikeintidelete;
                        bikeintidelete = int.Parse(Bikeiddelete);

                        Console.WriteLine(server.DeleteBike(bikeintidelete));


                        break;

                    case 8:

                        Console.Write("Enter the bike ID: ");

                        string BIDU = Console.ReadLine();
                        int bikeidU;
                        bikeidU = int.Parse(BIDU);

                        Console.Write("Enter the type ID: ");

                        string TIDU = Console.ReadLine();
                        int typeidU;
                        typeidU = int.Parse(TIDU);

                        Console.Write("Enter the colour ID: ");

                        string CIDU = Console.ReadLine();
                        int cidU;
                        cidU = int.Parse(CIDU);

                        Console.Write("Enter the wheel type ID: ");

                        string WTIDU = Console.ReadLine();
                        int wheelidU;
                        wheelidU = int.Parse(WTIDU);

                        Console.Write("Enter brand: ");

                        string brandU = Console.ReadLine();

                        Console.Write("Enter data new: ");

                        string DataNewU = Console.ReadLine();
                        DateTime datanewU;
                        datanewU = DateTime.Parse(DataNewU);

                        Console.Write("Enter the material: ");

                        string materialU = Console.ReadLine();


                        Console.Write("Enter the price: ");

                        string PriceU = Console.ReadLine();
                        decimal priceU;
                        priceU = decimal.Parse(PriceU);

                        Console.Write("Is it sold?: ");

                        string SoldU = Console.ReadLine();
                        bool soldU;
                        soldU = bool.Parse(SoldU);

                        Console.Write("Enter the weight: ");

                        string WeightU = Console.ReadLine();
                        int weightU;
                        weightU = int.Parse(WeightU);


                        Console.Write("Enter stock entry date: ");

                        string DataStockU = Console.ReadLine();
                        DateTime datastockU;
                        datastockU = DateTime.Parse(DataStockU);

                        server.UpdateBike(bikeidU, typeidU, wheelidU, cidU, brandU,
                        materialU, weightU, datanewU, datastockU, priceU, soldU);


                        break;
                    default:
                        Console.WriteLine("You selected an invalid number: {0}\r\n", iSel);
                        continue;
                }
                Console.WriteLine();
            } while (!done);

            Console.WriteLine("\nGoodbye!");
        }
    }


}








