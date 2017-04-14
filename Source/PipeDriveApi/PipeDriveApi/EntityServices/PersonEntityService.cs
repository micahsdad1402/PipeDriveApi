using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipeDriveApi.EntityServices
{
    public class PersonEntityService<TPerson> : PagingEntityService<TPerson>
        where TPerson : Person
    {
        public PersonEntityService(IPipeDriveClient client) : base(client, "persons")
        {
        }
        public async Task<Person> GetByID(int PersonID)
        {
            var request = new RestRequest("persons/{Id}", Method.GET);

            request.AddParameter("Id", PersonID.ToString(), ParameterType.UrlSegment);

            var response = await _client.ExecuteRequestAsync<Person>(request);
            return response;
        }
        public async Task<JObject> GetJsonByID(int PersonId)
        {
            var request = new RestRequest("persons/{Id}", Method.GET);

            request.AddParameter("Id", PersonId.ToString(), ParameterType.UrlSegment);

            string response = await _client.ExecuteRequestWithoutSerialize(request);
            JObject PersonData = JObject.Parse(response);
            return PersonData;
        }
    }
    public class PersonFoundEntityService<TPersonFound> : PagingEntityService<TPersonFound>
        where TPersonFound : PersonFound
        {
            public PersonFoundEntityService(IPipeDriveClient client) : base(client, "persons")
            {
            }
            public async Task<IReadOnlyCollection<PersonFound>> FindPerson(string SearchTerm, bool SearchByEmail = false)
        {
            var request = new RestRequest("persons/find", Method.GET);

            request.SetQueryParameter("term", SearchTerm);
            if (SearchByEmail) { request.SetQueryParameter("search_by_email", "0"); }

            var response = await _client.ExecuteRequestAsync<List<PersonFound>>(request);

            if (response != null)
            {
                return response.AsReadOnly();
            }
            else
            {
                // Didn't find any match, so return a null list!

                return new List<PersonFound>();
            }

        }

    }
}
