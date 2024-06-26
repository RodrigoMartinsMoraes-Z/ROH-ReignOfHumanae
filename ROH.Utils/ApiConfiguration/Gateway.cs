﻿// Ignore Spelling: Utils

using Newtonsoft.Json;

using ROH.StandardModels.Response;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using static ROH.Utils.ApiConfiguration.ApiConfigReader;

namespace ROH.Utils.ApiConfiguration
{
    public class Gateway
    {
        private static readonly ApiConfigReader _apiConfig = new ApiConfigReader();

        private static readonly Dictionary<ApiUrl, Uri> _apiUrl = _apiConfig.GetApiUrl();

        private readonly Api _api = new Api();

        public enum Services
        {
            #region VERSION

            GetCurrentVersion,
            CreateNewVersion,
            GetAllVersionsPaginated,
            GetAllReleasedVersionsPaginated,
            GetVersionDetails,
            ReleaseVersion,

            #endregion VERSION

            #region VERSIONFILE

            UploadFile,
            GetAllVersionFiles,
            DownloadFile,

            #endregion VERSIONFILE

            #region ACCOUNT

            CreateNewUser,
            FindUserByEmail,
            FindUserByUserName,
            GetUserByGuid,
            GetAccountByUserGuid,
            UpdateAccount,

            #endregion ACCOUNT

            #region LOGIN

            Login

            #endregion LOGIN
        }

        private static readonly Dictionary<Services, Uri> _gatewayServiceUrl = new Dictionary<Services, Uri>
        {
            #region VERSION

            {Services.GetCurrentVersion, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Version/GetCurrentVersion" ) },
            {Services.CreateNewVersion, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Version/CreateNewVersion" ) },
            {Services.GetAllVersionsPaginated, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Version/GetAllVersionsPaginated" ) },
            {Services.GetAllReleasedVersionsPaginated, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Version/GetAllReleasedVersionsPaginated" ) },
            {Services.GetVersionDetails, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Version/GetVersionDetails" ) },
            {Services.ReleaseVersion, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Version/ReleaseVersion" ) },

            #endregion VERSION

            #region FILES

             {Services.UploadFile, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/VersionFile/UploadFile" ) },
             {Services.GetAllVersionFiles, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/VersionFile/GetAllVersionFiles" ) },
             {Services.DownloadFile, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/VersionFile/DownloadFile" ) },

            #endregion FILES

            #region ACCOUNT

             {Services.CreateNewUser, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/CreateNewUser" ) },
             {Services.FindUserByEmail, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/FindUserByEmail" ) },
             {Services.FindUserByUserName, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/FindUserByUserName" ) },
             {Services.GetUserByGuid, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/GetUserByGuid" ) },
             {Services.GetAccountByUserGuid, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/GetAccountByUserGuid" ) },
             {Services.UpdateAccount, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/UpdateAccount" ) },

            #endregion ACCOUNT

            #region LOGIN

             {Services.Login, new Uri(_apiUrl.GetValueOrDefault(ApiUrl.GateWay),"Api/Account/Login" ) },

            #endregion LOGIN
        };

        public async Task<DefaultResponse?> Get<T>(Services service, T parametersObject)
        {
            try
            {
                using HttpClient client = new HttpClient();

                string param = string.Empty;

                if (!Equals(parametersObject, default(T)))
                {
                    param = _api.GetParams(parametersObject!);
                }

                HttpResponseMessage response = await client.GetAsync(_gatewayServiceUrl.GetValueOrDefault(service) + param);

                if (response != null)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<DefaultResponse>(responseJson);
                }

                return new DefaultResponse(message: "Error, the connection has failed!");
            }
            catch (Exception e)
            {
                return new DefaultResponse(httpStatus: System.Net.HttpStatusCode.InternalServerError, message: e.Message);
            }
        }

        public async Task<DefaultResponse?> Post(Services service, object objectToSend)
        {
            using HttpClient client = new HttpClient();

            string jsonContent = JsonConvert.SerializeObject(objectToSend);
            StringContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(_gatewayServiceUrl.GetValueOrDefault(service), httpContent);

            if (response != null)
            {
                string responseJson = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DefaultResponse>(responseJson);
            }

            return new DefaultResponse(message: "Error, the connection has failed!");
        }

        public async Task<DefaultResponse?> Update(Services service, object objectToSend)
        {
            using HttpClient client = new HttpClient();

            string jsonContent = JsonConvert.SerializeObject(objectToSend);

            StringContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(_gatewayServiceUrl.GetValueOrDefault(service), httpContent);

            if (response != null)
            {
                string responseJson = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DefaultResponse>(responseJson);
            }

            return new DefaultResponse(message: "Error, the connection has failed!");
        }

        public async Task<DefaultResponse?> Delete<T>(Services service, T parametersObject)
        {
            using HttpClient client = new HttpClient();

            string param = string.Empty;

            if (!object.Equals(parametersObject, default(T)))
            {
                param = _api.GetParams(parametersObject!);
            }

            HttpResponseMessage response = await client.DeleteAsync(_gatewayServiceUrl.GetValueOrDefault(service) + param);

            if (response != null)
            {
                string responseJson = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DefaultResponse>(responseJson);
            }

            return new DefaultResponse(message: "Error, the connection has failed!");
        }
    }
}