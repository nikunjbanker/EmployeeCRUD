using EntityLibrary;
//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace WebApplication1
{
  public class MyDataService : DataService<EmployeeDBEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead | EntitySetRights.AllWrite);
            config.DataServiceBehavior.IncludeAssociationLinksInResponse = true;
            config.UseVerboseErrors = true;
        }

        /// <summary>
    /// Called before processing each request. For batch requests, it is called one time for the top batch request and one time for each operation in the batch.
    /// </summary>
    /// <param name="args">System.Data.Services.ProcessRequestArgs that contains information about the request.</param>
        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {

        }
    }
}
