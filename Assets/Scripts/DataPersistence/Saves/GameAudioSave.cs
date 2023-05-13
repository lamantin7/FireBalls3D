using System.Collections.Generic;
using Audio;
using DataPersistence.Files;
using IoC;
using UnityEngine;

namespace DataPersistence.Saves.Saves
{
	public class GameAudioSave : MonoBehaviour
	{
		[SerializeField] private SOFilePath _filePath;
	
		private readonly IAsyncFileService _fileService = new JsonNetFileService();

		private void OnApplicationQuit()
		{
			IEnumerable<AudioPreferences> audioPreferences = Container.InstanceOf<IAudioPreferencesProvider>().Preferences;
			_fileService.SaveAsync(audioPreferences, _filePath.Value);
		}
	}
}