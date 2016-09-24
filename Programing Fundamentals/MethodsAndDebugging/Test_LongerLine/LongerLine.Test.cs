namespace LongerLine.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void GetDistanceToCentre_ShouldReturn_DistanceToCentre()
        {
            //Arrange
            Point point = new Point(5,12);

            //Act
            double distanceToCentre = point.GetDistanceToCentre();
            int expectedDistance = 13;

            //Assert
            Assert.AreEqual(expectedDistance, distanceToCentre, "Point.GetDistanceToCentre() returns wrong distance");
        }
    }

    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void CompareTo_ShouldReturn_secondLine()
        {
            //Arrange
            Line firstLine = new Line(new Point(1,1),new Point(2,2));
            Line secondLine = new Line(new Point(1, 1), new Point(3, 3));

            //Act
            int smaller = -1;
            int expectedCompareResult = smaller;
            int compareResult = firstLine.CompareTo(secondLine);

            //Assert
            Assert.AreEqual(expectedCompareResult, compareResult, "Line.CompareTo() returns the wrong result");
        }

        [TestMethod]
        public void GetLenght_ShouldReturn_Lenght()
        {
            //Arrange
            Line line = new Line(new Point(0, 0), new Point(5, 12));

            //Act
            double expectedLenght = 13;
            double resultLenght = line.GetLenght();

            //Assert
            Assert.AreEqual(expectedLenght, resultLenght, "Line.GetLenghto() returns the wrong result");
        }
    }
}
