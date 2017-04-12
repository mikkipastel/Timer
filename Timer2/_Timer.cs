
namespace Timer
{
    public class _Timer
    {
        #region Members
        int time_cnt;
        string time_now;
        #endregion

        #region Properties
        public string setTimer
        {
            get { return time_now; }
            set { time_now = value; }
        }
        public int getTimer
        {
            get { return time_cnt; }
            set { time_cnt = value; }
        }
        #endregion

    }
}
