using Cirrious.MvvmCross.ViewModels;
using System;
using System.Windows.Input;

namespace WTM.Mobile.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        { }

        public void Init()
        {
        }

        #region SaveCommand

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new MvxCommand(() =>
                    {
                        throw new NotImplementedException();
                    });
                }
                return saveCommand;
            }
        }
        private ICommand saveCommand;

        #endregion

        #region SaveCommand

        public ICommand ResetCommand
        {
            get
            {
                if (resetCommand == null)
                {
                    resetCommand = new MvxCommand(() =>
                    {
                        throw new NotImplementedException();
                    });
                }
                return resetCommand;
            }
        }
        private ICommand resetCommand;

        #endregion
    }
}