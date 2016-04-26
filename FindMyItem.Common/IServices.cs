//using System.ServiceModel;
//using System.ServiceModel.Web;

//using FindMyItem.Classes;

//namespace FindMyItem.IServices
//{
//    [ServiceContract(Namespace = "urn:findmyitem:searchservice",
//                     Name = "SearchService",
//                     ProtectionLevel = System.Net.Security.ProtectionLevel.None,
//                     SessionMode = System.ServiceModel.SessionMode.NotAllowed)]
//    public interface ISearch
//    {
//        [OperationContract]
//        [WebInvoke]
//        WebServiceResults.JSONReturnValue DoWork();
//    }
//}