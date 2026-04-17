using System;
using Xunit;
using cs330_proj1;
using System.Collections.Generic;
using Moq;
using System.Linq;


namespace CourseProject.Tests
{
    public class CourseServicesTests
    {
        [Fact]
        public void GetCourseOfferingsBySemester_OneMatch_ReturnsOffering()
        {
            var course = GetTestCourses().First();

            var offerings = new List<CourseOffering>() {
                new CourseOffering {
                    Semester = "Fall 2020",
                    Section = "1",
                    TheCourse = course
                }
            };

            var mockRepository = new Mock<ICourseRepository>();
            mockRepository.Setup(m => m.Offerings).Returns(offerings);

            var service = new CourseServices(mockRepository.Object);

            var result = service.getCourseOfferingsBySemester("Fall 2020");

            Assert.Single(result);
        }

        [Fact]
        public void GetCourseOfferingsBySemester_NoMatch_ReturnsEmpty()
        {
            var mockRepository = new Mock<ICourseRepository>();
            mockRepository.Setup(m => m.Offerings).Returns(new List<CourseOffering>());

            var service = new CourseServices(mockRepository.Object);

            var result = service.getCourseOfferingsBySemester("Spring 2025");

            Assert.Empty(result);
        }
        private List<Course> GetTestCourses()
        {
            return new List<Course>() {
                new Course() {
                    Name="ARTD 201",
                    Title="graphic design",
                    Credits=3.0,
                    Description="graphic design descr"
                },
                new Course() {
                    Name="ARTS 101",
                    Title="art studio",
                    Credits=3.0,
                    Description="studio descr"
                }
            };
        }
    }
}