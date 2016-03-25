using ComicAdventureDTO;
using System.ServiceModel;

namespace WcfServiceLibrary2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service2 : IService2
    {
        public int GetMoneyFromImperium() {
            return randomGenerator.randNumber(3000, 5000);
        }
    }
}
