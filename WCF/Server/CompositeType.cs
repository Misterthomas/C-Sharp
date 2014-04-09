using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Coursework
{
    [DataContract]
    public class CompositeType
    {

        public static string matriculation = "S0905279";

        int bikeId = 0;
        int biketype = 0;
        int wheeltype = 0;
        int colorid = 0;
        string brand = "";
        string material = "";
        int weight = 0;
        DateTime datanew;
        DateTime stockentrydate;
        decimal price;
        bool sold;
        string colourname;
        bool metallic;


        [DataMember]
        public int BikeId
        {
            get { return bikeId; }
            set { bikeId = value; }
        }

         [DataMember]
        public int BikeTypeId
        {
            get { return biketype; }
            set { biketype = value; }
        }

         [DataMember]
        public int WheelTypeId
        {
            get { return wheeltype; }
            set { wheeltype = value; }
        }

         [DataMember]
        public int colorId
        {
            get { return colorid; }
            set { colorid = value; }
        }

         [DataMember]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

          [DataMember]
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        [DataMember]
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

         [DataMember]
        public DateTime DataNew
        {
            get { return datanew; }
            set { datanew = value; }
        }

          [DataMember]
        public DateTime StockEntryDate
        {
            get { return stockentrydate; }
            set { stockentrydate = value; }
        }

         [DataMember]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        [DataMember]
        public string Colourname
        {
            get { return colourname; }
            set { colourname = value; }
        }

        [DataMember]
        public bool Metallic
        {
            get { return metallic; }
            set { metallic = value; }
        }
    }
}
