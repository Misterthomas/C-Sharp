using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Coursework
{
    
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetMatriculation();

        [OperationContract]
        int GetNumberOfRecords();

        [OperationContract]
        string SellBike(int value);

        [OperationContract]
        List<CompositeType> GetAllBikeStock();

        [OperationContract]
        List<CompositeType> GetBikeByPrice(decimal minprice, decimal maxprice);

        [OperationContract]
        string DeleteBike(int BikeId);

        [OperationContract]
        int TottalWeight();

        [OperationContract]
        string AddBike(int biketype, int wheeltype, int colorid, string brand,
          string material, int weight, DateTime datanew, DateTime stockentrydate, decimal price, bool sold);

        [OperationContract]
        string UpdateBike(int BikeId, int biketype, int wheeltype, int colorid, string brand,
          string material, int weight, DateTime datanew, DateTime stockentrydate, decimal price, bool sold);
        
    }
}
