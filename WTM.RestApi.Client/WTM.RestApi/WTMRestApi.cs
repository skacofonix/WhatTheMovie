﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Rest;
using WTM.RestApi.Client;

namespace WTM.RestApi.Client
{
    public partial class WTMRestApi : ServiceClient<WTMRestApi>, IWTMRestApi
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }
        
        private ServiceClientCredentials _credentials;
        
        /// <summary>
        /// Credentials for authenticating with the service.
        /// </summary>
        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }
        
        private IMovie _movie;
        
        public virtual IMovie Movie
        {
            get { return this._movie; }
        }
        
        private IShot _shot;
        
        public virtual IShot Shot
        {
            get { return this._shot; }
        }
        
        private IUserOperations _user;
        
        public virtual IUserOperations User
        {
            get { return this._user; }
        }
        
        /// <summary>
        /// Initializes a new instance of the WTMRestApi class.
        /// </summary>
        public WTMRestApi()
            : base()
        {
            this._movie = new Movie(this);
            this._shot = new Shot(this);
            this._user = new UserOperations(this);
            this._baseUri = new Uri("http://localhost:19889");
        }
        
        /// <summary>
        /// Initializes a new instance of the WTMRestApi class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public WTMRestApi(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._movie = new Movie(this);
            this._shot = new Shot(this);
            this._user = new UserOperations(this);
            this._baseUri = new Uri("http://localhost:19889");
        }
        
        /// <summary>
        /// Initializes a new instance of the WTMRestApi class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public WTMRestApi(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._movie = new Movie(this);
            this._shot = new Shot(this);
            this._user = new UserOperations(this);
            this._baseUri = new Uri("http://localhost:19889");
        }
        
        /// <summary>
        /// Initializes a new instance of the WTMRestApi class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public WTMRestApi(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }
        
        /// <summary>
        /// Initializes a new instance of the WTMRestApi class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public WTMRestApi(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the WTMRestApi class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials for authenticating with the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public WTMRestApi(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;
            
            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }
    }
}