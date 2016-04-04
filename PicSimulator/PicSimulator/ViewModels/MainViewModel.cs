using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace PicSimulator.ViewModels {
    class MainViewModel : Screen {
        #region fields
        private string _testButtonContent;


        #endregion //fields

        #region properties
        public string TestButtonContent {
            get {
                return _testButtonContent;
            }

            set {
                _testButtonContent = value;
                NotifyOfPropertyChange(() => TestButtonContent);
            }
        }
        #endregion //properties

        #region constructor
        public MainViewModel() {
            TestButtonContent = "test";
        }
        #endregion //constructur

        #region methods
        public void TestButton() {
            TestButtonContent = "stringneu";
        }
        #endregion //methods


    }
}
