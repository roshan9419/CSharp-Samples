using Xunit;

namespace VIEditor.FileManager.Tests
{
    public class DirectoryHandlerTest
    {
        [Fact]
        [Trait("Category", "Directory")]
        public void CheckExistDirectoryTest()
        {
            var dirHandler = new DirectoryHandler("C:VIEditor");
            Assert.True(dirHandler.IsExists());
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CheckNotExistDirectoryTest()
        {
            var dirHandler = new DirectoryHandler("C:DummyDirectory");
            Assert.False(dirHandler.IsExists());
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CreateValidDirectoryTest()
        {
            var dirHandler = new DirectoryHandler("C:VIEditor");
            Assert.True(dirHandler.CreateDirectory());
        }

        [Fact]
        [Trait("Category", "Directory")]
        public void CreateNonValidDirectoryTest()
        {
            var dirHandler = new DirectoryHandler("TestDrive:VIEditor");
            Assert.False(dirHandler.CreateDirectory());
        }
    }
}
