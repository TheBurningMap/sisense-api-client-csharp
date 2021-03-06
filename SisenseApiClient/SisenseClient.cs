﻿using SisenseApiClient.Authenticators;
using SisenseApiClient.Services.Application;
using SisenseApiClient.Services.Authentication;
using SisenseApiClient.Services.ElastiCubes;
using SisenseApiClient.Services.Jaql;
using SisenseApiClient.Services.SqlRunner;
using SisenseApiClient.Utils.HttpClient;

namespace SisenseApiClient
{
    public class SisenseClient
    {
        public AuthenticationService Authentication { get; }
        public ElastiCubesService ElastiCubes { get; }
        public JaqlRunnerService JaqlRunnerService { get; }
        public SqlRunnerService SqlRunnerService { get; }
        public ApplicationService ApplicationService { get; }

        public SisenseClient(string serverUrl, IAuthenticator authenticator, IHttpClient httpClient)
        {
            authenticator.ServerUrl = serverUrl;
            Authentication = new AuthenticationService(serverUrl, httpClient, authenticator);
            ElastiCubes = new ElastiCubesService(serverUrl, httpClient, authenticator);
            JaqlRunnerService = new JaqlRunnerService(serverUrl, httpClient, authenticator);
            SqlRunnerService = new SqlRunnerService(serverUrl, httpClient, authenticator);
            ApplicationService = new ApplicationService(serverUrl, httpClient, authenticator);
        }

        public SisenseClient(string serverUrl, IAuthenticator authenticator)
            : this(serverUrl, authenticator, new HttpClient())
        {
        }
    }
}
