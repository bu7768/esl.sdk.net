using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK.Services
{
    public class AccountService
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient restClient;

        public AccountService(RestClient restClient, string baseUrl)
        {
            this.restClient = restClient;
            template = new UrlTemplate (baseUrl);

            settings = new JsonSerializerSettings ();
            settings.NullValueHandling = NullValueHandling.Ignore;
        }

        public void InviteUser( AccountMember accountMember ) {
            string path = template.UrlFor (UrlTemplate.ACCOUNT_INVITE_MEMBER_PATH)
                .Build ();
            try {
                User user = new AccountMemberConverter( accountMember ).ToAPIUser();
                string json = JsonConvert.SerializeObject (user, settings);
                restClient.Post(path, json);              
            } catch (Exception e) {
                throw new EslException ("Failed to invite new account member." + " Exception: " + e.Message);
            }
        }
    }
}

