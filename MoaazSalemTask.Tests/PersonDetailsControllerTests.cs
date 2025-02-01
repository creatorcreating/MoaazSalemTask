using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;


namespace MoaazSalemTask.Tests.Integration
{
    public class PersonDetailsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        public readonly HttpClient _client;

        public PersonDetailsControllerTests(WebApplicationFactory<Program> factory) // Use fully qualified name
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetPersonDetailsFromCSV_ShouldReturnOk()
        {
            // Arrange
            var name = "rana"; // from csv file
            var telephoneNumber = "4444";

            // Act
            var response = await _client.GetAsync($"/PersonDetails?Name={name}&TelephoneNumber={telephoneNumber}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Rana", responseString);
        }

        [Fact]
        public async Task GetPersonDetailsFromDB_ShouldReturnOk()
        {
            // Arrange
            var name = "mona"; // from csv file
            var telephoneNumber = "444";

            // Act
            var response = await _client.GetAsync($"/PersonDetails?Name={name}&TelephoneNumber={telephoneNumber}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Mona", responseString);
        }


        [Fact]
        public async Task GetPersonDetailsFromAll_ShouldReturnOk()
        {
            // Arrange
            var name = "ana"; // from csv file
            var telephoneNumber = "";

            // Act
            var response = await _client.GetAsync($"/PersonDetails?Name={name}&TelephoneNumber={telephoneNumber}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Rana", responseString);
        }


        [Fact]
        public async Task GetPersonDetails_ShouldReturnEmptyForNonExistingPerson()
        {
            // Arrange
            var name = "NonExistingName";
            var telephoneNumber = "000-000";

            // Act
            var response = await _client.GetAsync($"/PersonDetails?Name={name}&TelephoneNumber={telephoneNumber}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.DoesNotContain("NonExistingName", responseString);
        }
    }
}

 
