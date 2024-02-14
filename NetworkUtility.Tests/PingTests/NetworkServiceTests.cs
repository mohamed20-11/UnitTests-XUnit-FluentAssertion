using FluentAssertions;
using FluentAssertions.Extensions;
using NetwrkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;

        public NetworkServiceTests()
        {
            _networkService = new NetworkService();
        }

        [Fact]
        public void NetworkService_SendingPing_ReturnString()
        {
            //Arrange

            //act
            var result = _networkService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_ReturnInt(int a, int b, int expected)
        {
            //Arrange


            //act
            var result = _networkService.PingTiemOut(a, b);

            //Assertion
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-1000, 0);
        }
        [Fact]
        public void NetworkService_ReturnsPingDate()
        {

            var result = _networkService.LastPingDate();

            //Assertion:
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(15.February(2024));
        }

        [Fact]
        public void NetworkService_ReturnsPingOptionsObject()
        {
            //Arrange 
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 2
            };
            var result = _networkService.GetPingOptions();
            // Assertion

            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Should().NotBeNull();
            result.Ttl.Should().Be(2);
        }


        [Fact]
        public void NetworkService_ReturnsGetPingOptionsListObject()
        {
            //Arrange 
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 2
            };
            var result = _networkService.GetPingOptionsList();
            // Assertion

            // result.Should().BeOfType<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            // result.Ttl.Should().Be(2);
            result.Should().Contain(x=>x.DontFragment==true);
            result.Should().Contain(t=>t.Ttl==2);
        }
    }
}
