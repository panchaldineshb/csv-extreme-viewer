using CSVXtremeLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CSVXtremeLoader.Structures;

namespace TestFilters
{


    /// <summary>
    ///This is a test class for TextFilterTest and is intended
    ///to contain all TextFilterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TextFilterTest
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
        public void IsLineValidTest_TextFilter_Null()
        {
            IFilter target = new TextFilter("bla", "columna", "texto"); // TODO: Initialize to an appropriate value
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
        public void IsLineValidTest_TextFilter_Equal()
        {
            IFilter target = new TextFilter("EQUALS", "column5", "data5"); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5, "column1,column2,column3,column4,column5", "text,text,text,text,text");
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
        public void IsLineValidTest_TextFilter_Equal_NotFound()
        {
            IFilter target = new TextFilter("EQUALS", "column5", "data1"); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5, "column1,column2,column3,column4,column5", "text,text,text,text,text");
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
        public void IsLineValidTest_TextFilter_StartsWith()
        {
            IFilter target = new TextFilter("STARTS WITH", "column3", "data"); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5, "column1,column2,column3,column4,column5", "text,text,text,text,text");
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
        public void IsLineValidTest_TextFilter_StartsWith_NotFound()
        {
            IFilter target = new TextFilter("STARTS WITH", "column4", "bla"); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5, "column1,column2,column3,column4,column5", "text,text,text,text,text");
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
        public void IsLineValidTest_TextFilter_InvalidSubType()
        {
            IFilter target = new TextFilter("bla", "column3", "data3"); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(5, "column1,column2,column3,column4,column5", "text,text,text,text,text");
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
        public void IsLineValidTest_TextFilter_MetadataLarger()
        {
            IFilter target = new TextFilter("EQUALS", "column6", "data6"); // TODO: Initialize to an appropriate value
            Line line = new Line(5); // TODO: Initialize to an appropriate value
            line.columns.SetValue("data1", 0);
            line.columns.SetValue("data2", 1);
            line.columns.SetValue("data3", 2);
            line.columns.SetValue("data4", 3);
            line.columns.SetValue("data5", 4);
            Metadata metadata = new Metadata(6, "column1,column2,column3,column4,column5,column6", "text,text,text,text,text,text");
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsLineValid(line, metadata);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
