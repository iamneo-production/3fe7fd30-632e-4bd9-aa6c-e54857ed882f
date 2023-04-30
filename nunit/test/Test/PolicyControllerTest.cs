using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApp.Controllers;
using WebApp.Infrastructure;
using WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
 
namespace WebAppTest
{
    public class PolicyControllerTest
    {
        [Fact]
        public void Test_GET_AllPolicies()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.Policies).Returns(Multiple());
            var controller = new PolicyController(mockRepo.Object);
 
            // Act
            var result = controller.Get();
 
            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Policy>>(result);
            Assert.Equal(3, model.Count());
        }
 
        private static IEnumerable<Policy> Multiple()
        {
            var r = new List<Policy>();
            r.Add(new Policy()
            {
                policyId = 01,
                policytype = "ABC",
                applicantName = "ABC",
                applicantAddress = "chennai",
                applicantMobile = "9876543210",
                applicantEmail = "abc@gmail.com",
                VehicleModel = "356484"
            });
            r.Add(new Policy()
            {
                policyId = 02,
                policytype = "DEF",
                applicantName = "DEF",
                applicantAddress = "chennai",
                applicantMobile = "9876543210",
                applicantEmail = "abc@gmail.com",
                VehicleModel = "356484"
            });
            r.Add(new Policy()
            {
                policyId = 03,
                policytype = "GHI",
                applicantName = "GHI",
                applicantAddress = "chennai",
                applicantMobile = "9876543210",
                applicantEmail = "abc@gmail.com",
                VehicleModel = "356484"
            });
            return r;
        }

        [Fact]
        public void Test_POST_AddPolicy()
        {
            // Arrange
            Policy r = new Policy()
            {
                policyId = 04,
                policytype = "JKL",
                applicantName = "JKL",
                applicantAddress = "cbe",
                applicantMobile = "9876543211",
                applicantEmail = "jkl@gmail.com",
                VehicleModel = "356485"
            };
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.AddPolicy(It.IsAny<Policy>())).Returns(r);
            var controller = new PolicyController(mockRepo.Object);
        
            // Act
            var result = controller.Post(r);
        
            // Assert
            var policy = Assert.IsType<Policy>(result);
            Assert.Equal(04, policy.policyId);
            Assert.Equal("JKL", policy.policytype);
            Assert.Equal("JKL", policy.applicantName);
            Assert.Equal("cbe", policy.applicantAddress);
            Assert.Equal("9876543211", policy.applicantMobile);
            Assert.Equal("jkl@gmail.com", policy.applicantEmail);
            Assert.Equal("356485", policy.VehicleModel);

        }

        [Fact]
        public void Test_PUT_UpdatePolicy()
        {
            // Arrange
            Policy r = new Policy()
            {
                policyId = 01,
                policytype = "ABC",
                applicantName = "new ABC",
                applicantAddress = "chennai",
                applicantMobile = "9876543210",
                applicantEmail = "abc@gmail.com",
                VehicleModel = "356484"
            };
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.UpdatePolicy(It.IsAny<Policy>())).Returns(r);
            var controller = new PolicyController(mockRepo.Object);
        
            // Act
            var result = controller.Put(r);
        
            // Assert
            var policy = Assert.IsType<Policy>(result);
            Assert.Equal(01, policy.policyId);
            Assert.Equal("ABC", policy.policytype);
            Assert.Equal("new ABC", policy.applicantName);
            Assert.Equal("chennai", policy.applicantAddress);
            Assert.Equal("9876543210", policy.applicantMobile);
            Assert.Equal("abc@gmail.com", policy.applicantEmail);
            Assert.Equal("356484", policy.VehicleModel);
        }

        [Fact]
        public void Test_DELETE_Policy()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.DeletePolicy(It.IsAny<int>())).Verifiable();
            var controller = new policyController(mockRepo.Object);
        
            // Act
            controller.Delete(3);
        
            // Assert
            mockRepo.Verify();
        }
    }
}