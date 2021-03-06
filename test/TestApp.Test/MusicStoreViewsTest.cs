﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MvcBenchmarks.InMemory
{
    public class MusicStoreViewsTest : IClassFixture<TestAppFixture<MusicStoreViews.Startup>>
    {
        private readonly HttpClient _client;

        public MusicStoreViewsTest(TestAppFixture<MusicStoreViews.Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Theory]
        [InlineData("AddressAndPayment")]
        [InlineData("Create")]
        [InlineData("Register")]
        public async Task MusicStoreViews_ViewsAreSuccessful(string actionName)
        {
            // Arrange & Act
            var response = await _client.GetAsync($"/Home/{actionName}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
