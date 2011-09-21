using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestGoogleCharsNGraphsControls
{
    // NOTE: If you change the interface name "IWCFTestService" here, you must also update the reference to "IWCFTestService" in Web.config.
    [ServiceContract]
    public interface IWCFTestService
    {
        [OperationContract]
        void DoWork();
    }

    public class Foo : IWCFTestService
    {
        #region IWCFTestService Members

        public void DoWork()
        {
            
            throw new NotImplementedException();
        }

        #endregion
    }
}
