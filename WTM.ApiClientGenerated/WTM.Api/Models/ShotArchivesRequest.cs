﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;

namespace WTM.ApiClientGenerated.Models
{
    public partial class ShotArchivesRequest
    {
        private DateTimeOffset? _date;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? Date
        {
            get { return this._date; }
            set { this._date = value; }
        }
        
        private int? _limit;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Limit
        {
            get { return this._limit; }
            set { this._limit = value; }
        }
        
        private int? _start;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Start
        {
            get { return this._start; }
            set { this._start = value; }
        }
        
        private string _token;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Token
        {
            get { return this._token; }
            set { this._token = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ShotArchivesRequest class.
        /// </summary>
        public ShotArchivesRequest()
        {
        }
    }
}
