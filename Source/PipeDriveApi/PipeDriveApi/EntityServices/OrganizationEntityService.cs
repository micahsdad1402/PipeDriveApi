using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipeDriveApi.EntityServices
{
    public class OrganizationEntityService<TOrganization> : PagingEntityService<TOrganization>
        where TOrganization : Organization

    {
        public OrganizationEntityService(IPipeDriveClient client) : base(client, "organizations")
        {
        }


        public async Task<Organization> GetByID(int OrgID)
        {
            var request = new RestRequest("organizations/{ID}", Method.GET);

            request.AddParameter("ID", OrgID.ToString(), ParameterType.UrlSegment);

            var response = await _client.ExecuteRequestAsync<Organization>(request);
            return response;
        }
    }
    public class OrganizationFoundEntityService<TOrganizationFound> : PagingEntityService<TOrganizationFound>
                where TOrganizationFound : OrganizationFound
    {
        public OrganizationFoundEntityService(IPipeDriveClient client) : base(client, "organizations/find")
        {
        }

    }
    public class PersonsInOrganizationEntityService<TOrganizationPerson> : PagingEntityService<TOrganizationPerson>
            where TOrganizationPerson : OrganizationPerson
    {
        public PersonsInOrganizationEntityService(IPipeDriveClient client) : base(client, "organizations/{Id}/persons")
        {
        }

    }
    public class OrganizationAddressEntityService<TAddressDetails> : PagingEntityService<TAddressDetails>
        where TAddressDetails : AddressDetails
    {
        public OrganizationAddressEntityService(IPipeDriveClient client) : base(client, "organizations/{Id}")
        {
        }
        public async Task<JObject> GetAddresses(int OrgId)
        {
            var request = new RestRequest("organizations/{Id}", Method.GET);

            request.AddParameter("Id", OrgId.ToString(), ParameterType.UrlSegment);

            string response = await _client.ExecuteRequestWithoutSerialize(request);
            JObject OrgData = JObject.Parse(response);
            return OrgData;
        }
    }
}
