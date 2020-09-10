using System;
using System.Collections.Generic;
using System.Text;

namespace ControlCenterServices.Application.Impl
{
   

    public class FristJsonService : ControlCenterServicesApplicationServiceBase, IFristJsonService
    {
        public string FristJson()
        {
            return "Hello World-------------------";
        }
    }
}
