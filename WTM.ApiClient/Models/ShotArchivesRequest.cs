﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;

namespace WTM.ApiClient.Models
{
    public partial class ShotArchivesRequest
    {
        private DateTimeOffset? date;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        
        private int? limit;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Limit
        {
            get { return this.limit; }
            set { this.limit = value; }
        }
        
        private int? start;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Start
        {
            get { return this.start; }
            set { this.start = value; }
        }
        
        private string token;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ShotArchivesRequest class.
        /// </summary>
        public ShotArchivesRequest()
        {
        }
    }
}
