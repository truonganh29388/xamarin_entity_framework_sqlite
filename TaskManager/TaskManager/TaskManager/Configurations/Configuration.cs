using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Configurations
{
    public class Configuration : IConfiguration
    {
        [JsonConstructor]
        public Configuration()
        {

        }

        public string ApiBaseAddress { get; set; }
    }
}
