using PostalService.DAL.Models;
using PostalService.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;
using PostalService.DAL.Contracts;
using PostalService.Services.Common;
using PostalService.Services.Services;
using Serilog;

namespace PostalService.Tests
{
    public class PostalServiceTests
    {
        private readonly ILogger _logger;
        private readonly IPackageRepository _packageRepo;
        private readonly IValidator _validator;
        private readonly IBusinessLogick _businessLogick;

        public PostalServiceTests()
        {
            _logger = A.Fake<ILogger>();
            _packageRepo = A.Fake<IPackageRepository>();
            _validator = A.Fake<IValidator>();
            _businessLogick = A.Fake<IBusinessLogick>();
        }

        private PackageService CreateTestedObject()
        {
            return new PackageService(_packageRepo, _logger, _validator, _businessLogick);
        }

        [Fact]
        public void Create_PackageIsNull_ThrowsNullReferenceException()
        {
            //Arange
            PackageModel package = null;

            var testedObject = CreateTestedObject();
            //Act
            Func<Task> func = async() => await testedObject.Create(package);
            //Assert
            Assert.ThrowsAsync<NullReferenceException>(func);
        }

        [Fact]
        public void Create_PackageIsValid_ReturnsValidPackage()
        {
            //Arange
            PackageModel package = new PackageModel();

            A.CallTo(() => _validator.Validate(package, _logger)).Returns(true);
            A.CallTo(() => _businessLogick.DoSomeAction()).DoesNothing();

            var testedObject = CreateTestedObject();
            var expectedResult = package;
            //Act
            var result = testedObject.Create(package).GetAwaiter().GetResult();
            //Assert
            Assert.Same(expectedResult, result);
        }

        [Fact]
        public void Create_PackageIsNotValid_ReturnsNull()
        {
            //Arange
            PackageModel package = new PackageModel();

            A.CallTo(() => _validator.Validate(package, _logger)).Returns(false);

            var testedObject = CreateTestedObject();
            //Act
            var result = testedObject.Create(package).GetAwaiter().GetResult();
            //Assert
            Assert.Null(result);
        }
    }
}
