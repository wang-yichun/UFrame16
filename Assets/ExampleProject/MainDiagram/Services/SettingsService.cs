using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.Kernel;
using uFrame.IOC;
using UniRx;
using UnityEngine;
using uFrame.MVVM;

namespace uFrame.ExampleProject
{
	public class SettingsService : SettingsServiceBase
	{
		public float DefaultVolume {
			get { return 0.6f; }
		}
		
		public ResolutionInformation DefaultResolution {
			get { return GetAvailableResolutions ().First (); }
		}

		//Simple property which works of PlayerPrefs
		public float Volume {
			get { return PlayerPrefs.GetFloat ("Settings_Volume", DefaultVolume); }
			set { PlayerPrefs.SetFloat ("Settings_Volume", value); }
		}

		//Advanced version of it, which works of PlayerPrefs, but uses string to 
		//store serialized version of the object
		//Please notice that by default, Simple Class does not have Serialize/Deserialize methods
		//This is generated due to the extension of SimpleClassTemplate.
		public ResolutionInformation Resolution {
			get {
				if (PlayerPrefs.HasKey ("Settings_Resolution")) {
					var resInfo = new ResolutionInformation ();
					//Deserialize into the new instance
					resInfo.Deserialize (PlayerPrefs.GetString ("Settings_Resolution"));
					return resInfo;
				} else {
					//return default value, if player never changed settings
//					return AvailableResolutions.First ();
					return DefaultResolution;
				}
			}
			set {
				//Serialize
				PlayerPrefs.SetString ("Settings_Resolution", value.Serialize ());
			}
		}

		private IEnumerable<ResolutionInformation> _availableResolutions;

		public IEnumerable<ResolutionInformation> AvailableResolutions {
			get { return _availableResolutions ?? (_availableResolutions = GetAvailableResolutions ()); }
			set { _availableResolutions = value; }
		}

		protected IEnumerable<ResolutionInformation> GetAvailableResolutions ()
		{
			yield return new ResolutionInformation () {Width = 800, Height = 600};
			yield return new ResolutionInformation () {Width = 1200, Height = 800};
			yield return new ResolutionInformation () {Width = 1600, Height = 1200};
		}

		private void OnApplicationQuit ()
		{
			PlayerPrefs.Save ();
		}


	}
}