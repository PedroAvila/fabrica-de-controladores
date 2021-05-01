using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FabricaDeControladores
{
    public class DefaultLogger : ILogger
    {
        public void Write(string data)
        {
            Debug.WriteLine(data, "DefaultLogger");
        }
    }
}