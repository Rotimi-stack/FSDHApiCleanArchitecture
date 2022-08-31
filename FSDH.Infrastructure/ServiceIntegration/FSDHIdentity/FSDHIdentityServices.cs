using FSDH.Application.Common.Interfaces;
using FSDH.Application.Common.Models.FSDHIDENTITY;
using FSDH.Domain.Enums.FSDH360;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using NLog;
using System.Threading.Tasks;
using FSDH.Application.FSDHIdentity.FSDHIdentityQuery.ValidateOTP;
using FSDH.Shared.LogService;
using System.Net;

namespace FSDH.Infrastructure.ServiceIntegration.FSDHIdentity
{
    public class FSDHIdentityServices : IFSDHIdentity
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogWritter _logger;

        private static Logger log = LogManager.GetCurrentClassLogger();
        public FSDHIdentityServices(IHttpClientFactory httpClientFactory, IConfiguration config, ILogWritter logger)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient();
            _config = config;
          

        }

        public async Task<GetSingleBVNResponse> GetDetailedInfoforABVN(GetSingleBVNResources uae)
        {
            var data = new GetSingleBVNRequest
            {
                bvn = uae.bvn
            };
            return await SendAsync<GetSingleBVNRequest, GetSingleBVNResponse>(
                data, $"/api/GetSingleBVN", FSDH360HttpMethodType.Post
                );
        }

        public async Task<GetDetailedInfoforAListofBVNResponse> GetDetailedInfoMultipleBVN(GetMultipleBVNResources var)
        {
            var data = new GetMultipleBVNRequest
            {
                bvns = var.bvns,
                requestReference = var.requestReference
            };
            return await SendAsync<GetMultipleBVNRequest, GetDetailedInfoforAListofBVNResponse>(
                data, $"/api/GetMultipleBVN", FSDH360HttpMethodType.Post
                );
        }

        public async Task<GetSingleBVNbyDAteResponses> GetSingleBVNbyDate(GetSingleBVNByDateResources vae)
        {
            var data = new GetSingleBVNbyDateRequest
            {
                bvn = vae.bvn,
                birthDate = vae.birthDate
                
            };
            return await SendAsync<GetSingleBVNbyDateRequest, GetSingleBVNbyDAteResponses>(
                data, $"/api/GetSingleBVN/date", FSDH360HttpMethodType.Post
                );
        }

        public async Task<GetSingleBVNbyOTPResponses> GetSingleBVNbyOTPs(GetBVNInfoSendOTPResources add)
        {
            var data = new GetBVNInfoSendOTPRequest
            {
                bvn = add.bvn,
                

            };
            return await SendAsync<GetBVNInfoSendOTPRequest, GetSingleBVNbyOTPResponses>(
                data, $"/api/GetSingleBVN/otp", FSDH360HttpMethodType.Post
                );
        }

        public async Task<IsBVNWatchListedResponses> IsBVNWatchListed(IsBVNWatchlistedResources vadd)
        {
            var data = new IsBVNWatchlistedRequest
            {
                bvn = vadd.bvn,

            };
            return await SendAsync<IsBVNWatchlistedRequest, IsBVNWatchListedResponses>(
                data, $"/api/IsBVNWatchlisted", FSDH360HttpMethodType.Post
                );
        }

        public async Task<ValidateOTPResponses> ValidateanOTP(string RecordReference, string OTP)
        {
            return await SendAsync<ValidateOTPQuery, ValidateOTPResponses>(
                new ValidateOTPQuery(), $"", FSDH360HttpMethodType.Get
                );
        }

        public async Task<VerifyMultipleBVNResponses> VerifyMultipleBVN(VerifyMultipleBVNResources com)
        {
            var data = new VerifyMultipleBVNRequest
            {
                bvns = com.bvns,
                requestReference = com.requestReference
            };
            return await SendAsync<VerifyMultipleBVNRequest, VerifyMultipleBVNResponses>(
                data, $"/api/VerifyMultipleBVN", FSDH360HttpMethodType.Post
                );
        }

        public async Task<VerifySingleBVN> VerifySingleBVN(VerifySingleBVNResources art)
        {
            var data = new VerifySingleBVNRequest
            {
                bvn = art.bvn
            };
            return await SendAsync<VerifySingleBVNRequest, VerifySingleBVN>(
                data, $"/api/VerifySingleBVN", FSDH360HttpMethodType.Post
                );
        }

        public async Task<VerifySingleBVNbyDate> verifySingleBVNbyDate(VerifyBVNbyDateResources bdr)
        {
            var data = new VerifyBVNbyDateRequest
            {
                bvn = bdr.bvn,
                birthDate = bdr.birthDate
            };
            return await SendAsync<VerifyBVNbyDateRequest, VerifySingleBVNbyDate>(
                data, $"/api/VerifySingleBVN/date", FSDH360HttpMethodType.Post
                );
        }




        public async Task<U> SendAsync<T, U>(T payload, string relativePath, FSDH360HttpMethodType httpMethod)
        {
            var baseaddress = _config.GetSection("BaseAddressIdentity").Value.ToString();
            var testkey = _config.GetSection("TestApiKey").Value.ToString();

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {testkey}");
            _client.DefaultRequestHeaders.Add("X-Version", "1.0");

            var message = new StringContent(System.Text.Json.JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpResponseMessage response = new HttpResponseMessage();
            string content;
            switch (httpMethod)
            {
                case FSDH360HttpMethodType.Post:
                    var resp = await _client.PostAsync($"{baseaddress}{relativePath}", message);
                    content = await resp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resp.StatusCode == HttpStatusCode.BadGateway || (resp.StatusCode == HttpStatusCode.Unauthorized) || resp.StatusCode == HttpStatusCode.BadRequest || resp.StatusCode == HttpStatusCode.ServiceUnavailable || resp.StatusCode == HttpStatusCode.InternalServerError || resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return JsonSerializer.Deserialize<U>(content);

                case FSDH360HttpMethodType.Delete:
                    var resssp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await resssp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (resssp.StatusCode == HttpStatusCode.BadGateway || (resssp.StatusCode == HttpStatusCode.Unauthorized) || resssp.StatusCode == HttpStatusCode.BadRequest || resssp.StatusCode == HttpStatusCode.ServiceUnavailable || resssp.StatusCode == HttpStatusCode.InternalServerError || resssp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return JsonSerializer.Deserialize<U>(content);

                default:

                    var ressp = await _client.GetAsync($"{baseaddress}{relativePath}");
                    content = await ressp.Content.ReadAsStringAsync();
                    log.Info("Message: " + content + Environment.NewLine + Environment.NewLine + "Endpoint: " + baseaddress + relativePath + Environment.NewLine + payload + Environment.NewLine + Environment.NewLine + "ApiKey: " + testkey + Environment.NewLine + _client.Timeout + Environment.NewLine + DateTime.Now);

                    if (ressp.StatusCode == HttpStatusCode.BadGateway || (ressp.StatusCode == HttpStatusCode.Unauthorized) || ressp.StatusCode == HttpStatusCode.BadRequest || ressp.StatusCode == HttpStatusCode.ServiceUnavailable || ressp.StatusCode == HttpStatusCode.InternalServerError || ressp.StatusCode == HttpStatusCode.NotFound)
                    {
                        return JsonSerializer.Deserialize<U>(content);

                    }

                    return JsonSerializer.Deserialize<U>(content);


            }

        }
    }
}
