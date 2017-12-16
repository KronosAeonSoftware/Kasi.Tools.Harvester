using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasi.Tools.Harvester.Domain.Concrete.Repository;
using System.Linq;
using System.IO;
using log4net;
using System.Reflection;
using Kasi.Tools.Harvester.Domain.Tests.Utility.Extensions;
using log4net.Config;

namespace Kasi.Tools.Harvester.Domain.Tests.Concrete.Repository
{
    [TestClass]
    public class FileSystemRepoTest
    {
        private static ILog log => LogManager.GetLogger(MethodBase.GetCurrentMethod().Name);

        [TestInitialize]
        public void LoggingTests()
        {
            XmlConfigurator.Configure();
        }

        [TestMethod]
        public void Can_CreateNew_WithCompleteConstructor_Success()
        {
            var props = new { root = @"", pattern = "", options = System.IO.SearchOption.AllDirectories };
            var actual = new FileSystemRepo(props.root, props.pattern, props.options);

            Assert.IsNotNull(actual);

            Assert.AreEqual(props.root, actual.SearchDirectory);
            Assert.AreEqual(props.pattern, actual.SearchPattern);
            Assert.AreEqual(props.options, actual.SearchOptions);
        }
        [TestMethod]
        public void Can_GetAll_Success()
        {
            var props = new { root = @"C:\Repositories\Kasi.Tools.Harvester\test\Kasi.Tools.Harvester.Domain.Tests\Concrete\Repository", pattern = "FileSystemRepoTest.cs", options = System.IO.SearchOption.TopDirectoryOnly };
            var repo = new FileSystemRepo(props.root, props.pattern, props.options);
            var actual = repo.GetAll();
            var testfile = actual.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(Path.Combine(props.root, props.pattern), testfile.FullFilePath);
        }
        [TestMethod]
        public void Can_GetAll_WithHugeNumbers_Success()
        {
            var props = new { root = @"C:\tmp", pattern = "*.*", options = System.IO.SearchOption.AllDirectories };
            var repo = new FileSystemRepo(props.root, props.pattern, props.options);
            var actual = repo.GetAll();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 10000);

            log.Variable("actual.Count()", actual.Count());
        }
    }
}
