using System.ServiceModel;

namespace WcfServiceLibrary2
{
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        int GetMoneyFromImperium();
    }
}
