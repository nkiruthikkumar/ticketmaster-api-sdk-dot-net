﻿namespace Ticketmaster.Discovery.V2
{
    using System.Threading.Tasks;
    using Core;
    using Models;
    using RestSharp;

    /// <summary>
    ///     The IAttractionsClient interface.
    /// </summary>
    public interface IAttractionsClient
    {
        /// <summary>
        ///     Searches the attractions asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="SearchAttractionsRequest" /> request.</param>
        /// <returns>The <see cref="SearchAttractionsResponse" />.</returns>
        Task<SearchAttractionsResponse> SearchAttractionsAsync(SearchAttractionsRequest request);

        /// <summary>
        ///     Searches the attractions asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="SearchAttractionsResponse" />.</returns>
        Task<SearchAttractionsResponse> SearchAttractionsAsync(IApiRequest request);

        /// <summary>
        ///     Calls the search attractions asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="SearchAttractionsRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchAttractionsAsync(SearchAttractionsRequest request);

        /// <summary>
        ///     Calls the search attractions asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="IApiRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallSearchAttractionsAsync(IApiRequest request);

        /// <summary>
        ///     Gets the attraction details asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="Attraction" />.</returns>
        Task<Attraction> GetAttractionDetailsAsync(GetRequest request);

        /// <summary>
        ///     Gets the attraction details asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="Attraction" />.</returns>
        Task<Attraction> GetAttractionDetailsAsync(IApiGetRequest request);

        /// <summary>
        ///     Calls the get attraction details asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="GetRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetAttractionDetailsAsync(GetRequest request);

        /// <summary>
        ///     Calls the get attraction details asynchronous.
        /// </summary>
        /// <param name="request">The <see cref="IApiGetRequest" /> request.</param>
        /// <returns>The <see cref="IRestResponse" />.</returns>
        Task<IRestResponse> CallGetAttractionDetailsAsync(IApiGetRequest request);
    }
}