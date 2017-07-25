using Domain.Clients;
using Interfaces.Clients;
using Xunit;


namespace Unit.Tests.ServiceTests.ClientTest
{
    public class Create_Client
    {
        private readonly ClientService _clientService;
        public Create_Client()
        {
            _clientService = new ClientService();
        }

        [Fact]
        public void basictest() {
            var foo = 4;

            Assert.Equal(foo,4);
        }
    }
}
