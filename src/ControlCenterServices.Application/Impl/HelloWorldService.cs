using System;
using System.Collections.Generic;
using System.Text;

namespace ControlCenterServices.Application.Impl
{
   

    public class HelloWorldService : ControlCenterServicesApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
