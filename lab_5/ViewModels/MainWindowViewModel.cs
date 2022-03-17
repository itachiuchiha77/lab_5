using System;
using System.Collections.Generic;
using System.Text;
using lab_5.Views;
using ReactiveUI;
using lab_5.ViewModels;
using lab_5.Models;

namespace lab_5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _textString = "";

        private string _regexString = "";

        private string _resultString = "";

        public string Text
        {
            get => _textString;
            set => this.RaiseAndSetIfChanged(ref _textString, value);
        }

        public string RegilarString
        {
            get
            {
                return _regexString;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _regexString, value);
            }
        }

        public string Result
        {
            get
            {
                return _resultString;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _resultString, value);
            }
        }

        public string FindRegex() => RegexLogic.FindRegexInText(_textString, _regexString);
    }
}
