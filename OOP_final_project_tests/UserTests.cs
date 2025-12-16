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
            var name = "test admin";

            var admin = new Admin
            {
                Name = name
            };

            Assert.Equal(name, admin.Name);
        }

        [Fact]
        public void NewAdmin_ShouldGenerateNonEmptyId()
        {
            var admin = new Admin();

            Assert.NotEqual(Guid.Empty, admin.Id);
        }

        [Fact]
        public void CreateAdmin_ShouldSetDepartmentAndAccessLevelCorrectly()
        {
            var department = "IT";
            var accessLevel = 5;

            var admin = new Admin
            {
                Department = department,
                AccessLevel = accessLevel
            };

            Assert.Equal(department, admin.Department);
            Assert.Equal(accessLevel, admin.AccessLevel);
        }
        [Fact]
        public void Nurse_should_not_be_empty()
        {
            var name = "test nurse";

            var admin = new Nurse
            {
                Name = name
            };

            Assert.Equal(name, admin.Name);
        }
        [Fact]
        public void NewNurse_ShouldGenerateNonEmptyId()
        {
            var admin = new Nurse();
            Assert.NotEqual(Guid.Empty, admin.Id);
        }

        [Fact]
        public void CreateNurse_ShouldSetWorkAreaCorrectly()
        {
            // Arrange
            var workarea = "1";

            var nurse = new Nurse
            {
                WorkArea = workarea
            };

            Assert.Equal(workarea, nurse.WorkArea);
        }
        public void Doctor_should_not_be_empty()
        {
            var name = "test doctor";

            var admin = new Doctor
            {
                Name = name
            };

            Assert.Equal(name, admin.Name);
        }
        [Fact]
        public void NewDoctor_ShouldGenerateNonEmptyId()
        {
            var admin = new Doctor();

            Assert.NotEqual(Guid.Empty, admin.Id);
        }

        [Fact]
        public void CreateDoctor_ShouldSetFieldsCorrectly()
        {
             Arrange
            var workroom = "1";
            var specialty = "general doctor";

            var doctor = new Doctor
            {
                Specialty = specialty,
                WorkRoom= workroom
            };

            Assert.Equal(specialty, doctor.Specialty);
            Assert.Equal(workroom, doctor.WorkRoom);

        }

    }
}
