using RestSharp;

namespace RestApiExampleAutomatedTests.Framework
{
    public static class Rest
    {
        private static RestClient client;
        private static RestRequest request;

        /// <summary>
        /// Get the response for LookUp function (get the information for the code)
        /// </summary>
        /// <param name="system">CodeSystem or ValueSet</param>
        /// <param name="version">Version of the system</param>
        /// <param name="code">Code which we want to lookup in the system</param>
        /// <returns>IRestResponse instance</returns>
        public static IRestResponse LookUpResponse (string system, string version, string code)
        {
            client = new RestClient(Config.QaHost);
            request = new RestRequest($"/CodeSystem/$lookup?system={system}|{version}&code={code}");
            return client.Execute(request);
        }

        /// <summary>
        /// Get the response for Expand function (searching the codes by filter in the valueset)
        /// </summary>
        /// <param name="valueSetId">Id of Value Set</param>
        /// <param name="filter">Filter, as is.</param>
        /// <returns>IRestResponse instance</returns>
        public static IRestResponse ExpandResponse(string valueSetId, string filter)
        {
            client = new RestClient(Config.QaHost);
            request = new RestRequest($"/ValueSet/{valueSetId}/$expand?filter={filter}");
            return client.Execute(request);
        }

        /// <summary>
        /// Get the response for Subsumes function (checking the subsuming of two codes in the system)
        /// </summary>
        /// <param name="system">CodeSystem or ValueSet</param>
        /// <param name="firstCode">First code</param>
        /// <param name="secondCode">Second code</param>
        /// <returns>IRestResponse instance</returns>
        public static IRestResponse SubsumesResponse(string system, string firstCode, string secondCode)
        {
            client = new RestClient(Config.QaHost);
            request = new RestRequest($"/CodeSystem/$subsumes?system={system}&codeA={firstCode}&codeB={secondCode}");
            return client.Execute(request);
        }

        /// <summary>
        /// Get the response for Validation function (checking that the code with display name (optional) and language (optional) is valid for the value set and belongs to system) https://wiki-dev.helix.ru/display/TERMSERV/API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="system"></param>
        /// <param name="code"></param>
        /// <param name="display"></param>
        /// <param name="displayLanguage"></param>
        /// <returns></returns>
        public static IRestResponse SingleValidationResponse(string id, string system, string code, string display, string displayLanguage)
        {
            client = new RestClient(Config.QaHost);
            string query = $"/ValueSet/{id}/$validate-code?system={system}&code={code}";
            if (!string.IsNullOrEmpty(display)) query += $"&display={display}";
            if (!string.IsNullOrEmpty(displayLanguage)) query += $"&displayLanguage={displayLanguage}";
            request = new RestRequest(query);
            return client.Execute(request);
        }

        /// <summary>
        /// The same as Single validation but for multiple codes
        /// </summary>
        /// <param name="id">Id of value set</param>
        /// <param name="jsonBody">Set of codes in json format</param>
        /// <returns></returns>
        public static IRestResponse MultiValidationResponse(string id, string jsonBody)
        {
            client = new RestClient(Config.QaHost);
            request = new RestRequest($"/ValueSet/{id}/$validate-codes",Method.POST);
            request.AddParameter("application/json",jsonBody,ParameterType.RequestBody);
            return client.Execute(request);
        }
    }
}
