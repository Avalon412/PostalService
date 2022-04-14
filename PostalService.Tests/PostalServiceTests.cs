using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using PostalService.Services.Services;

namespace PostalService.Tests
{
    public class PostalServiceTests
    {
        [Fact]
        public void OnCreatingPackage_PackageIsNull_ThrowsNullReferenceException()
        {
            //Arange
            PackageModel package = null;
            var packageService = A.Fake<PackageService>();
            //Act
            Func<Task> func = async() => await packageService.Create(package);
            //Assert
            Assert.ThrowsAsync<NullReferenceException>(func);
        }
    }
}
