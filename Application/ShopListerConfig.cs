using System;

namespace ShopLister.App
{
    public interface IAppConfig
    {
        string SqlServerConnectionString { get; set;}
    }

    public class ShopListerConfig : IAppConfig
    {
        public string SqlServerConnectionString { get; set; }
    }
}
