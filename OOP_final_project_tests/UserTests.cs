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
    }
}
