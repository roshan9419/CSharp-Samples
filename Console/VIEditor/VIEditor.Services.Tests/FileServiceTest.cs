using System;
using System.IO;
using VIEditor.Models;
using Xunit;

namespace VIEditor.Services.Tests
{
    public class FileServiceTest
    {
        private readonly FileService _fileService = FileService.GetInstance;

        [Fact]
        [Trait("Playlist", "FileService")]
        public void CreateValidFileItemTest()
        {
            FileItem validItem = new FileItem("test.txt", "C:VIEditor", "Test content", DateTime.Now);
            _fileService.CreateFileItem(validItem);
        }

        [Fact]
        public void CreateInvalidFileItemTest()
        {
            FileItem invalidItem = new FileItem("test.txt", "D:NotAccessibleFolder", "Test content", DateTime.Now);
            Assert.Throws<Exception>(() => _fileService.CreateFileItem(invalidItem));
        }

        [Fact]
        public void UpdateNotExistFileItemTest()
        {
            FileItem item = new FileItem("test.txt", "C:VIEditor/not-exist.txt", "Test updated content", DateTime.Now);
            Assert.Throws<FileNotFoundException>(() => _fileService.UpdateFileItem(item));
        }

        [Fact]
        [Trait("Playlist", "FileService")]
        public void UpdateExistFileItemTest()
        {
            FileItem updateItem = new FileItem("test.txt", "C:VIEditor", "Updated Test content", DateTime.Now);
            _fileService.UpdateFileItem(updateItem);
        }

        [Fact]
        [Trait("Playlist", "FileService")]
        public void GetExistFileItemTest()
        {
            string filePath = @"C:VIEditor/test.txt";
            var fileItem = _fileService.GetFileItem(filePath);

            Assert.NotNull(fileItem);
        }

        [Fact]
        public void GetNonExistFileItemTest()
        {
            string filePath = @$"C:VIEditor/{DateTime.Now}.txt";
            Assert.Throws<FileNotFoundException>(() => _fileService.GetFileItem(filePath));
        }
    }
}
