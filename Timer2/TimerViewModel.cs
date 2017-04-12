using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

using System.Timers;
using System.Windows;
using System.Threading;
using System.Windows.Threading;

namespace Timer
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        #region Members
        //_Timer timer;
        private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        int time_count = 0;
        private Action _update;
        string _setTimer = string.Empty;
        System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        #endregion

        #region Properties
        //public _Timer Timer
        //{
        //    get { return timer; }
        //    set { timer = value;  }
        //}
        //set timer value
        public string setTimer
        {
            get { return _setTimer; }
            set
            {
                if (_setTimer != value)
                {
                    _setTimer = value;
                    RaisePropertyChanged("setTimer");
                }
            }
        }
        //get last timer value
        //public int getTimer
        //{
        //    get { return timer.getTimer; }
        //    set 
        //    { 
        //        if (timer.getTimer != value)
        //        {
        //            timer.getTimer = value;
        //        }
        //    }
        //}
        #endregion

        #region Constructors
        public TimerViewModel ()
        {
            _setTimer = "0";
            this.aTimer.Elapsed += OnTimedEvent;
        }
        #endregion

        #region Commands
        //start

        public void CountUp()
        {
            ++time_count;
            setTimer = time_count.ToString();
            //RaisePropertyChanged("setTimer");
        }


        void StartCountExecute()
        {
            this._update = new Action(this.CountUp);
            this.aTimer.Start();
            //aTimer.Start(); //Enable = true                  
            //setTimer = aTimer.ToString();
            //time_count = aTimer.GetHashCode();
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //try
            //{
            //    this._dispatcher.Invoke(this._update);
            //}
            //catch (Exception)
            //{
            //    // tbd
            //}
            CountUp();
        }
        bool CanStartCountExecute()
        {
            return true;
        }
        public ICommand Startcount { get { return new RelayCommand(StartCountExecute, CanStartCountExecute); } }
        //stop
        void StopCountExecute()
        {
            aTimer.Stop(); //Enable = false
            //aTimer.Dispose();
        }
        bool CanStopCountExecute()
        {
            return true;
        }
        public ICommand Stopcount { get { return new RelayCommand(StopCountExecute, CanStopCountExecute); } }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
