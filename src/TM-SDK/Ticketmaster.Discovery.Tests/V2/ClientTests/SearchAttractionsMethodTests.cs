﻿namespace Ticketmaster.Discovery.Tests.V2.ClientTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Discovery.V2;
    using Discovery.V2.Models;
    using NSubstitute;
    using Ploeh.AutoFixture;
    using RestSharp;
    using Xunit;

    public class SearchAttractionsMethodTests : MethodTest
    {
        public SearchAttractionsMethodTests()
        {
            _expectedResponse = Fixture.Create<SearchAttractionsResponse>();

            Client
                .ExecuteTaskAsync<SearchAttractionsResponse>(Arg.Any<IRestRequest>())
                .Returns(new RestResponse<SearchAttractionsResponse>
                {
                    Data = _expectedResponse,
                    StatusCode = HttpStatusCode.OK
                });
            _sut = new AttractionsClient(Client, Config);
        }

        private readonly AttractionsClient _sut;
        private readonly SearchAttractionsResponse _expectedResponse;

        [Theory]
        [InlineData(QueryParameters.size, "1")]
        [InlineData(QueryParameters.page, "1")]
        public async Task SearchAttractionsAsync_ShouldBuildRequestWithQueryParameters(QueryParameters key,
            string value)
        {
            var request = new SearchAttractionsRequest();


            request.AddQueryParameter(new KeyValuePair<QueryParameters, string>(key, value));

            await _sut.SearchAttractionsAsync(request);

            await Client
                .Received()
                .ExecuteTaskAsync<SearchAttractionsResponse>(
                    Arg.Is<RestRequest>(
                        restRequest => restRequest.Parameters.Any(
                            p => p.Name == key.ToString() && Equals(p.Value, value))));
        }


        [Theory]
        [InlineData(QueryParameters.size, "1")]
        [InlineData(QueryParameters.page, "1")]
        public async Task CallSearchAttractionsAsync_ShouldBuildRequestWithQueryParameters(QueryParameters key,
            string value)
        {
            var request = new SearchAttractionsRequest();
            request.AddQueryParameter(new KeyValuePair<QueryParameters, string>(key, value));

            await _sut.CallSearchAttractionsAsync(request);

            await Client
                .Received()
                .ExecuteTaskAsync(
                    Arg.Is<RestRequest>(
                        restRequest => restRequest.Parameters.Any(
                            p => p.Name == key.ToString() && Equals(p.Value, value))));
        }

        [Fact]
        public async Task SearchAttractionsAsync_ShouldReturnSearchAttractionsResponse()
        {
            var response = await _sut.SearchAttractionsAsync(new SearchAttractionsRequest());
            Assert.NotNull(response);
            Assert.Equal(_expectedResponse, response);
        }
    }
}