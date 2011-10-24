using CSVXtremeLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSVXtremeLoader.Structures;

namespace TestFilters
{


    /// <summary>
    ///This is a test class for NumberFilterTest and is intended
    ///to contain all NumberFilterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NumberFilterTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_Null()
        {
            IFilter target = new NumberFilter("bla", "columna", 2.0); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("column1", 0);
            line.columns.SetValue("column1", 1);
            line.columns.SetValue("column1", 2);
            line.columns.SetValue("column1", 3);
            line.columns.SetValue("column1", 4);
            Metadata metadata = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_Equal()
        {
            IFilter target = new NumberFilter("EQUALS", "column5", 3.1416); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("3.1416", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,text,text,num");
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_Equal_NotFound()
        {
            IFilter target = new NumberFilter("EQUALS", "column5", 3.1416); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("3.14", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,text,text,num");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_LessThan()
        {
            IFilter target = new NumberFilter("LESS THAN", "column3", 5.0); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("4.99", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,num,text,text");
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_MoreThan()
        {
            IFilter target = new NumberFilter("MORE THAN", "column3", -5.0); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("-4", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,num,text,text");
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_LessThan_NotFound()
        {
            IFilter target = new NumberFilter("LessThan", "column4", 5.0); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("5.01", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,text,num,text");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_InvalidSubType()
        {
            IFilter target = new NumberFilter("bla", "column3", 3.1416); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,text,text,text");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_MetadataLarger()
        {
            IFilter target = new NumberFilter("EQUALS", "column6", 2.0); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("2.0", 4);
            Metadata metadata = new Metadata(6,"column1,column2,column3,column4,column5,column6","text,text,text,text,text,num");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Filters.IFilter.IsLineValid
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Filters.exe")]
        public void IsLineValidTest_NumberFilter_Text()
        {
            IFilter target = new NumberFilter("EQUALS", "column5", 2.0); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("texto", 4);
            Metadata metadata = new Metadata(5,"column1,column2,column3,column4,column5","text,text,text,text,text");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
