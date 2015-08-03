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
    using uFrame.MVVM;
    using uFrame.Kernel;
    using uFrame.IOC;
    using UniRx;
    using uFrame.Serialization;
    using uFrame.ExampleProject;
    
    
    public class UserControllerBase : uFrame.MVVM.Controller {
        
        private uFrame.MVVM.IViewModelManager _UserViewModelManager;
        
        private UserViewModel _LocalUser;
        
        [uFrame.IOC.InjectAttribute("User")]
        public uFrame.MVVM.IViewModelManager UserViewModelManager {
            get {
                return _UserViewModelManager;
            }
            set {
                _UserViewModelManager = value;
            }
        }
        
        [uFrame.IOC.InjectAttribute("LocalUser")]
        public UserViewModel LocalUser {
            get {
                return _LocalUser;
            }
            set {
                _LocalUser = value;
            }
        }
        
        public IEnumerable<UserViewModel> UserViewModels {
            get {
                return UserViewModelManager.OfType<UserViewModel>();
            }
        }
        
        public override void Setup() {
            base.Setup();
            // This is called when the controller is created
        }
        
        public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
            base.Initialize(viewModel);
            // This is called when a viewmodel is created
            this.InitializeUser(((UserViewModel)(viewModel)));
        }
        
        public virtual UserViewModel CreateUser() {
            return ((UserViewModel)(this.Create(Guid.NewGuid().ToString())));
        }
        
        public override uFrame.MVVM.ViewModel CreateEmpty() {
            return new UserViewModel(this.EventAggregator);
        }
        
        public virtual void InitializeUser(UserViewModel viewModel) {
            // This is called when a UserViewModel is created
            UserViewModelManager.Add(viewModel);
        }
        
        public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
            base.DisposingViewModel(viewModel);
            UserViewModelManager.Remove(viewModel);
        }
    }
}
