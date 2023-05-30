using DataPersistence.Files;
using IoC;
using Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataPersistence.Initialization
{
    public class LevelInitialization: AsyncInitialization
    {
        [SerializeField] private SOFilePath _filePath;
        private readonly IAsyncFileService _fileService=new JsonNetFileService();


        public override async Task InitializeAsync()
        {
            LevelNumber levelNumber=await _fileService.LoadAsync<LevelNumber>(_filePath.Value)?? EnsureCreated();
            Container.Register(levelNumber);
        }

        private LevelNumber EnsureCreated()=>new LevelNumber() { Value=1};
    }
}
