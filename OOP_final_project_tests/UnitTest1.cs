using OOP_final_project;
using Xunit;

namespace OOP_final_project.Tests
{
    public class GlobalUserAndDerivedTests
    {
        [Fact]
        public void New_User_Should_Have_NonEmpty_Id()
        {
            var doctor = new Doctor();
            Assert.NotEqual(Guid.Empty, doctor.Id);
        }
    }
}
