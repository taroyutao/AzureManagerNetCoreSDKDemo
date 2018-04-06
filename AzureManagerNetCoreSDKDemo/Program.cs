using System;
using System.Collections.Generic;
using AUTH;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace AzureManagerNetCoreSDKDemo
{
    class Program
    {
        //参数定义

        public static string resourceGroupName = "yuvmtest";
        public static string storageAccountName = "yustorageaccount";


        static void Main(string[] args)
        {
            AUTHClass authClass = new AUTHClass();

            IAzure azure = authClass.azure;

            IEnumerable<IResourceGroup>  resourceLsits = azure.ResourceGroups.List();

            //输出全部资源组信息
            foreach (IResourceGroup rs in resourceLsits)
            {
                Console.WriteLine("资源组信息：" + rs.Name);
            }


            azure.StorageAccounts.Define(storageAccountName)
                .WithRegion(Region.ChinaNorth)
                .WithExistingResourceGroup(resourceGroupName)
                .WithTag("key", "value")
                .WithSku(StorageAccountSkuType.Standard_LRS)
                .Create();

            
            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }
    }
}
