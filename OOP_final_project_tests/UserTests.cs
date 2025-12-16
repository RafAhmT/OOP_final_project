using System;
using Xunit;
using OOP_final_project;

namespace OOP_final_project_tests
{
    public class UserTests
    {
        [Fact]
        public void CreateAdmin_ShouldSetNameCorrectly()
        {
            // Arrange
            var name = "test admin";

            // Act
            var admin = new Admin
            {
                Name = name
            };

            // Assert
            Assert.Equal(name, admin.Name);
        }

        [Fact]
        public void NewAdmin_ShouldGenerateNonEmptyId()
        {
            // Act
            var admin = new Admin();

            // Assert
            Assert.NotEqual(Guid.Empty, admin.Id);
        }

        [Fact]
        public void CreateAdmin_ShouldSetDepartmentAndAccessLevelCorrectly()
        {
            // Arrange
            var department = "IT";
            var accessLevel = 5;

            // Act
            var admin = new Admin
            {
                Department = department,
                AccessLevel = accessLevel
            };

            // Assert
            Assert.Equal(department, admin.Department);
            Assert.Equal(accessLevel, admin.AccessLevel);
        }
    }
}
