using System.Threading.Tasks;
using System;
using BlazorSite.Services;
using Xunit;
using Moq;

namespace Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public void GenerateSeedTest()
        {
            var mockLocalService = new Mock<ILocalStorageService>();
            var accountService = new AccountService(mockLocalService.Object);
            var seed = accountService.GenerateRandomSeed().Result;
            Console.WriteLine(seed);
            Assert.NotEmpty(seed);
        } 

        [Fact]       
        public void GetSeedTest(){
            var mockLocalService = new Mock<ILocalStorageService>();
            var expectedSeed = "apple sun signals dapple pinacle car dream all world latino strike roggers";

            mockLocalService.Setup(x => x.GetItem<string>(It.IsAny<string>()))
                .Returns(Task.FromResult<string>(expectedSeed));

            var accountService = new AccountService(mockLocalService.Object);
            var seed = accountService.GetSeed().Result;
            Assert.Equal(expectedSeed, seed);
        }
        
    }
}