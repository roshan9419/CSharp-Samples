using System;
using System.IO;
using Xunit;

namespace VIEditor.FileManager.Tests
{
    public class FileOperationsTest
    {
        private readonly FileWriter _fileWriter;
        private readonly FileReader _fileReader;

        public FileOperationsTest()
        {
            _fileWriter = new FileWriter();
            _fileReader = new FileReader();
        }

        [Fact]
        [Trait("Category", "FileWrite")]
        public void CreateFileUsingValidPathTest()
        {
            string filePath = @"C:VIEditor/test.txt";

            _fileWriter.CreateFile(filePath, "This is test content");
        }

        [Fact]
        [Trait("Category", "FileWrite")]
        public void CreateFileUsingInvalidPathTest()
        {
            string filePath = @"TestDisk:VIEditor/test.txt";

            Assert.Throws<Exception>(() => _fileWriter.CreateFile(filePath, "This is test content"));
        }

        [Fact]
        [Trait("Category", "FileWrite")]
        public void UpdateNonExistingFileTest()
        {
            string nonExistFilePath = @"C:VIEditor/test-non-exist.txt";

            Assert.Throws<FileNotFoundException>(() => _fileWriter.UpdateFile(nonExistFilePath, "This is test content"));
        }

        [Fact]
        [Trait("Category", "FileWrite")]
        public void UpdateExistingFileTest()
        {
            string filePath = @"C:VIEditor/exist-file.txt";

            _fileWriter.CreateFile(filePath, "Test content");

            _fileWriter.UpdateFile(filePath, "Updated test content");
        }

        [Fact]
        [Trait("Category", "FileRead")]
        public void GetExistFileItemTest()
        {
            string existFilePath = "C:VIEditor/test.txt";

            var fileItem = _fileReader.GetFile(existFilePath);

            Assert.Equal("test.txt", fileItem.FileName);
        }

        [Fact]
        [Trait("Category", "FileRead")]
        public void GetNotExistFileItemTest()
        {
            string notExistFilePath = @"C:Random/test.txt";

            Assert.Throws<FileNotFoundException>(() => _fileReader.GetFile(notExistFilePath));
        }
    }
}
