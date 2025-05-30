using MarkForTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Grade_ShouldBe_Excellent()
        {
            int a = 10, b = 50, c = 30, d = 10;
            var result = GradeCalculator.CalculateGrade(a, b, c, d);
            Assert.AreEqual(100, result.totalScore);
            Assert.AreEqual("5 (Отлично)", result.grade);
        }

        [TestMethod]
        public void Grade_ShouldBe_Good()
        {
            int a = 8, b = 40, c = 20, d = 5;
            var result = GradeCalculator.CalculateGrade(a, b, c, d);
            Assert.AreEqual(73, result.totalScore);
            Assert.AreEqual("5 (Отлично)", result.grade);
        }

        [TestMethod]
        public void Grade_ShouldBe_Satisfactory()
        {
            int a = 5, b = 30, c = 15, d = 5;
            var result = GradeCalculator.CalculateGrade(a, b, c, d);
            Assert.AreEqual(55, result.totalScore);
            Assert.AreEqual("4 (Хорошо)", result.grade);
        }

        [TestMethod]
        public void Grade_ShouldBe_Fail()
        {
            int a = 3, b = 10, c = 5, d = 1;
            var result = GradeCalculator.CalculateGrade(a, b, c, d);
            Assert.AreEqual(19, result.totalScore);
            Assert.AreEqual("2 (Неудовлетворительно)", result.grade);
        }
    }
}
