using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DataPersistence
{
    [CreateAssetMenu(fileName = "FilePat", menuName = "ScriptableObjects/Data/FilePat")]
    public class SOFilePath:ScriptableObject
    {
        [SerializeField] private string _fileName;

        public string Value => Path.Combine(DirectoryPath, _fileName);

        private string DirectoryPath => Application.isEditor
            ? Application.streamingAssetsPath
            : Application.persistentDataPath;

        private void OnEnable()
        {
            EnsureCreated();
        }

        private void EnsureCreated()
        {
            if (File.Exists(Value) == false)
            {
                using FileStream fileStream = File.Create(Value);
            }
        }
    }
}
