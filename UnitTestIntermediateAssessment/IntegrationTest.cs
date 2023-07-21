using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Newtonsoft.Json;
using EFAssessment.Services;
using EFAssessment.Entities;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace UnitTestIntermediateAssessment;

public class IntegrationTest : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly IFixture _fixture = new Fixture();
    public IntegrationTest(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }
    [Fact]
    public async Task Patients_POST()
    {
        // Arrange
        var patient = _fixture
            .Build<Patient>()
            .Create();

        var patientPayload = new StringContent(
            JsonSerializer.Serialize(patient),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        // Act
        var response = await _client.PostAsync("/patients", patientPayload);
        // Asset
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }


}
