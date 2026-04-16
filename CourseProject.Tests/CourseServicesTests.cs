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
        public void GetCourses_ReturnsAllCourses()
        {
            var mockRepository = new Mock<ICourseRepository>();
            var courses = GetTestCourses();

            mockRepository.Setup(m => m.Courses).Returns(courses);
            mockRepository.Setup(m => m.Goals).Returns(new List<CoreGoal>());
            mockRepository.Setup(m => m.Offerings).Returns(new List<CourseOffering>());

            var service = new CourseServices(mockRepository.Object);

            var result = service.getCourses();

            Assert.Equal(courses.Count, result.Count);
        }

        [Fact]
        public void GetCourses_NoCourses_ReturnsEmptyList()
        {
            var mockRepository = new Mock<ICourseRepository>();

            mockRepository.Setup(m => m.Courses).Returns(new List<Course>());
            mockRepository.Setup(m => m.Goals).Returns(new List<CoreGoal>());
            mockRepository.Setup(m => m.Offerings).Returns(new List<CourseOffering>());

            var service = new CourseServices(mockRepository.Object);

            var result = service.getCourses();

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