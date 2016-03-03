﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using WTM.ApiClientGenerated;
using WTM.ApiClientGenerated.Models;

namespace WTM.ApiClientGenerated
{
    public static partial class UsersExtensions
    {
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='username'>
        /// Required.
        /// </param>
        public static UserResponse Get(this IUsers operations, string username)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IUsers)s).GetAsync(username);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='username'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<UserResponse> GetAsync(this IUsers operations, string username, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<WTM.ApiClientGenerated.Models.UserResponse> result = await operations.GetWithOperationResponseAsync(username, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        public static UserLoginResponse Login(this IUsers operations, UserLoginRequest request)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IUsers)s).LoginAsync(request);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<UserLoginResponse> LoginAsync(this IUsers operations, UserLoginRequest request, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<WTM.ApiClientGenerated.Models.UserLoginResponse> result = await operations.LoginWithOperationResponseAsync(request, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        public static string Logout(this IUsers operations, UserLogoutRequest request)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IUsers)s).LogoutAsync(request);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='request'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<string> LogoutAsync(this IUsers operations, UserLogoutRequest request, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<string> result = await operations.LogoutWithOperationResponseAsync(request, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        public static UserSearchResponse Search(this IUsers operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IUsers)s).SearchAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the WTM.ApiClientGenerated.IUsers.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<UserSearchResponse> SearchAsync(this IUsers operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<WTM.ApiClientGenerated.Models.UserSearchResponse> result = await operations.SearchWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}