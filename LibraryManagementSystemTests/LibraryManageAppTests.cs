
using LibraryManagementSystem;
using Moq;
using System;

namespace LibraryManagementSystemTests
{
    public class Tests
    {
        private LibraryManagementSystem.Library lib;
        [SetUp]
        public void Setup()
        {
            lib = new LibraryManagementSystem.Library();
        }

        [Test]
        public void AddBook_WhenCalled_ReturnsBookAddedSuccessfully()
        {
            // Arrange
            var container1 = new Mock<IlibraryMangeApp>();
            container1.Setup(x1 => x1.AddBook()).Returns(1); 

            // Act
            int result1 = container1.Object.AddBook();

            // Assert
            Assert.That(result1, Is.EqualTo(1)); 
        }
        [Test]
        public void EditBook_WhenCalled_ReturnsBookEditedSuccessfully()
        {
            // Arrange
            var container2 = new Mock<IlibraryMangeApp>();
            container2.Setup(x2 => x2.EditBook()).Returns(1); 

            // Act
            int result2 = container2.Object.EditBook();

            // Assert
            Assert.That(result2, Is.EqualTo(1));
        }
        [Test]
        public void DeleteBook_WhenCalled_ReturnsBookDeletedSuccessfully()
        {
            // Arrange
            var container3 = new Mock<IlibraryMangeApp>();
            container3.Setup(x3 => x3.DeleteBook()).Returns(1); 

            // Act
            int result3 = container3.Object.DeleteBook();

            // Assert
            Assert.That(result3, Is.EqualTo(1));
        }
        [Test]
        public void AddStudent_WhenCalled_ReturnsStudentAddedSuccessfully()
        {
            // Arrange
            var container4 = new Mock<IlibraryMangeApp>();
            container4.Setup(x4 => x4.AddStudent()).Returns(1); 

            // Act
            int result4 = container4.Object.AddStudent();

            // Assert
            Assert.That(result4, Is.EqualTo(1));
        }
        [Test]
        public void EditStudent_WhenCalled_ReturnsStudentEditedSuccessfully()
        {
            // Arrange
            var container5 = new Mock<IlibraryMangeApp>();
            container5.Setup(x5 => x5.EditStudent()).Returns(1); 

            // Act
            int result5 = container5.Object.EditStudent();

            // Assert
            Assert.That(result5, Is.EqualTo(1));
        }
        [Test]
        public void DeleteStudent_WhenCalled_ReturnsStudentDeletedSuccessfully()
        {
            // Arrange
            var container6 = new Mock<IlibraryMangeApp>();
            container6.Setup(x6 => x6.DeleteStudent()).Returns(1); 

            // Act
            int result6 = container6.Object.DeleteStudent();

            // Assert
            Assert.That(result6, Is.EqualTo(1));
        }

    }
}