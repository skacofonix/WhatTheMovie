﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using WTM.RestApi.Client.Models;

namespace WTM.RestApi.Client.Models
{
    public partial class ShotRateResponse
    {
        private string _data;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Data
        {
            get { return this._data; }
            set { this._data = value; }
        }
        
        private Error _error;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Error Error
        {
            get { return this._error; }
            set { this._error = value; }
        }
        
        private Pagination _pagination;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Pagination Pagination
        {
            get { return this._pagination; }
            set { this._pagination = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ShotRateResponse class.
        /// </summary>
        public ShotRateResponse()
        {
        }
    }
}
