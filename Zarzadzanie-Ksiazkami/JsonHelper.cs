using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Zarzadzanie_Ksiazkami
{
    public static class JsonHelper
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions 
        {
            WriteIndented = true,
            Converters = {new JsonStringEnumConverter()},
        };
    }
}
