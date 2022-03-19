using System.Text.Json;

namespace BlazorApp1.Data
{
    public class PersonApiService
    {
        private HttpClient client;


        public PersonApiService()
        {
            client = new HttpClient();
        }
        public async Task<Person[]> GetPeopleAsync()
        {

          
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://randomuser.me/api/?results=20&?nat=gb&inc=gender,name,email"),
               
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStreamAsync();
            var personApiResponse = await JsonSerializer.DeserializeAsync<PersonApiResponse>(body);

            return personApiResponse.results;
        }
    }
}
