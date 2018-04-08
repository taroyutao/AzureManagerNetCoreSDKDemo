using System;
using System.Collections;
using System.Collections.Generic;
using AUTH;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;

namespace AzureManagerNetCoreSDKDemo
{
    class Program
    {
        //参数定义
        public static string resourceGroupName = "armtest";
        private static string password = "dahaiyu@198222";

        //public static string storageAccountName = "yustorageaccount";


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

            //创建存储账户
            //string storageAccountName = "yustorageaccount"
            //azure.StorageAccounts.Define(storageAccountName)
            //    .WithRegion(Region.ChinaNorth)
            //    .WithExistingResourceGroup(resourceGroupName)
            //    .WithTag("key", "value")
            //    .WithSku(StorageAccountSkuType.Standard_LRS)
            //    .Create();



            //创建服务总线命名空间
            //string servicebusNamespace = "yuservicebusnamespace";
            //azure.ServiceBusNamespaces.Define(servicebusNamespace)
            //    .WithRegion(Region.ChinaNorth)
            //    .WithNewResourceGroup(resourceGroupName)
            //    .WithTag("key", "value")
            //    .WithSku(NamespaceSku.Standard)
            //    .Create();


            //删除资源组下服务总线的命名空间
            //IEnumerable<IServiceBusNamespace> namespaces = azure.ServiceBusNamespaces.ListByResourceGroup(resourceGroupName);
            //string serviceNamespaceId = null;

            //foreach (IServiceBusNamespace i in namespaces)
            //{
            //    Console.WriteLine(i.Id);
            //    serviceNamespaceId = i.Id;
            //    if (serviceNamespaceId != null)
            //    {
            //        //删除命名空间
            //        //azure.ServiceBusNamespaces.DeleteById(serviceNamespaceId);
            //        //Console.WriteLine("Delete service bus namespace success!");

            //        //删除具体的queue
            //        IQueues queues = i.Queues;
            //        IEnumerable<IQueue> listQueue = queues.List();
            //        foreach (IQueue queue in listQueue)
            //        {
            //            queues.DeleteByName(queue.Name);
            //        }
            //    }
            //}


            //azure.ServiceBusNamespaces.Define(servicebusNamespace)
            //    .WithRegion(Region.ChinaNorth)
            //    .WithExistingResourceGroup(resourceGroupName)
            //    .WithNewQueue("yuqueuetest", 1024)
            //    .WithSku(NamespaceSku.Basic)
            //    .Create();



            Console.WriteLine("Creating a Windows VM");

            var windowsVM = azure.VirtualMachines.Define("myWindowsVM")
                .WithRegion(Region.ChinaNorth)
                .WithNewResourceGroup(resourceGroupName)
                .WithNewPrimaryNetwork("10.0.0.0/28")
                .WithPrimaryPrivateIPAddressDynamic()
                .WithNewPrimaryPublicIPAddress("yutest1")
                .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                .WithAdminUsername("tirekicker")
                .WithAdminPassword(password)
                .WithSize(VirtualMachineSizeTypes.BasicA0)
                .Create();

            Console.WriteLine("Created a Windows VM: " + windowsVM.Id);


            Console.WriteLine("Hello World!");

            Console.ReadKey(true);

        }
    }

}
