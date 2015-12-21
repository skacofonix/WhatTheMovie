﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Microsoft.Rest;
using WTM.RestApi.Client;

namespace WTM.RestApi.Client
{
    public partial interface IWTMRestApi : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri
        {
            get; set; 
        }
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        ServiceClientCredentials Credentials
        {
            get; set; 
        }
        
        IMovie Movie
        {
            get; 
        }
        
        IShot Shot
        {
            get; 
        }
        
        IUserOperations User
        {
            get; 
        }
    }
}
