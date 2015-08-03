// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace uFrame.ExampleProject {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.Serialization;
    
    
    public class MainMenuSceneBase : uFrame.Kernel.Scene {
        
        public override string DefaultKernelScene {
            get {
                return "ExampleProjectKernelScene";
            }
        }
        
        public virtual MainMenuSceneSettings Settings {
            get {
                return _SettingsObject as MainMenuSceneSettings;
            }
            set {
                _SettingsObject = value;
            }
        }
    }
    
    public class MainMenuSceneLoaderBase : SceneLoader<MainMenuScene> {
        
        protected override IEnumerator LoadScene(MainMenuScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(MainMenuScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
    
    public class LevelSceneBase : uFrame.Kernel.Scene {
        
        public override string DefaultKernelScene {
            get {
                return "ExampleProjectKernelScene";
            }
        }
        
        public virtual LevelSceneSettings Settings {
            get {
                return _SettingsObject as LevelSceneSettings;
            }
            set {
                _SettingsObject = value;
            }
        }
    }
    
    public class LevelSceneLoaderBase : SceneLoader<LevelScene> {
        
        protected override IEnumerator LoadScene(LevelScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(LevelScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
    
    public class IntroSceneBase : uFrame.Kernel.Scene {
        
        public override string DefaultKernelScene {
            get {
                return "ExampleProjectKernelScene";
            }
        }
        
        public virtual IntroSceneSettings Settings {
            get {
                return _SettingsObject as IntroSceneSettings;
            }
            set {
                _SettingsObject = value;
            }
        }
    }
    
    public class IntroSceneLoaderBase : SceneLoader<IntroScene> {
        
        protected override IEnumerator LoadScene(IntroScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(IntroScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
    
    public class AssetsLoadingSceneBase : uFrame.Kernel.Scene {
        
        public override string DefaultKernelScene {
            get {
                return "ExampleProjectKernelScene";
            }
        }
        
        public virtual AssetsLoadingSceneSettings Settings {
            get {
                return _SettingsObject as AssetsLoadingSceneSettings;
            }
            set {
                _SettingsObject = value;
            }
        }
    }
    
    public class AssetsLoadingSceneLoaderBase : SceneLoader<AssetsLoadingScene> {
        
        protected override IEnumerator LoadScene(AssetsLoadingScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
        
        protected override IEnumerator UnloadScene(AssetsLoadingScene scene, Action<float, string> progressDelegate) {
            yield break;
        }
    }
}
