namespace SimpleSleep
{
    using System.Diagnostics;
    using System.Timers;

    /*
     * todo:
     * - option pour réduire le volume en fonction du timer
     * - afficher une fenêtre d'avertissement quelques minutes avant l'extinsion
     * - afficher une icone dans le tray
     */

    public partial class SimpleSleepMain : Form
    {
        public const int TIME_UPDATE_REMAIN = 1000;
        public const int DEFAULT_TIME_HOURS_ADD = 1;
        public const int DEFAULT_TIME_MINUTES_ADD = 0;
        public const string TIMER_BUTTON_TEXT_START = "Start";
        public const string TIMER_BUTTON_TEXT_STOP = "Stop";

        private SimpleSleep SimpleSleepInstance { get; set; }
        private DateTime UserChoiceTimeTimer { get; set; }
        private DateTime UserChoiceTimeCountHour { get; set; }
        private CancellationTokenSource TimerCancellToken { get; set; }

        public SimpleSleepMain()
        {
            InitializeComponent();

            this.InitUserChoiceTimeTimer();
            this.InitUserChoiceTimeCountHour();
            this.InitOptionTime();
            this.InitSimpleSleep();
            this.TimerCancellToken = new CancellationTokenSource();
        }

        private void InitSimpleSleep()
        {
            this.SimpleSleepInstance = new SimpleSleep(
                hours: SimpleSleepMain.DEFAULT_TIME_HOURS_ADD,
                minutes: SimpleSleepMain.DEFAULT_TIME_MINUTES_ADD
            );

            this.OptionTime.Value = this.SimpleSleepInstance.ExecuteAt;
        }

        private void InitOptionTime()
        {
            this.OptionTime.CustomFormat = "HH:mm";
            this.OptionTime.Format = DateTimePickerFormat.Custom;
            this.OptionTime.ShowUpDown = true;
        }

        private void StartTimer_Click(object sender, EventArgs e)
        {
            if (this.IsTimerButtonConfigureToStart())
            {
                this.ConfigureSimpleSleepFromUserPref();
                this.SimpleSleepInstance.Start();
                this.UpdateTimeRemaningShowInBackground();
                this.ChangeButtonTimerToStop();
            }
            else
            {
                this.SimpleSleepInstance.Stop();
                this.ChangeButtonTimerToStart();
            }
            this.TriggerAllowUserOptionsEdit();

            //Debug.WriteLine(this.SimpleSleepInstance.GetTimeRemainingFormat());
        }

        private bool IsTimerButtonConfigureToStart()
        {
            return this.StartTimer.Text == SimpleSleepMain.TIMER_BUTTON_TEXT_START;
        }

        private void ChangeButtonTimerToStop()
        {
            this.StartTimer.Text = SimpleSleepMain.TIMER_BUTTON_TEXT_STOP;
        }

        private void ChangeButtonTimerToStart()
        {
            this.StartTimer.Text = SimpleSleepMain.TIMER_BUTTON_TEXT_START;
        }

        private void ConfigureSimpleSleepFromUserPref()
        {
            this.ConfigureSimpleSleepTypeAction();
            this.ConfigureSimpleSleepTimeType();
            this.ConfigureSimpleSleepTime();
        }

        private void ConfigureSimpleSleepTypeAction()
        {
            if (this.OptionTypeEventShutdown.Checked)
            {
                this.SimpleSleepInstance.SetActionShutdown();
            }
            else if (this.OptionTypeEventHibernate.Checked)
            {
                this.SimpleSleepInstance.SetActionHibernate();
            }
        }

        private void ConfigureSimpleSleepTimeType()
        {
            if (this.OptionTimeMeasurementTimer.Checked)
            {
                this.SimpleSleepInstance.SetTimeTimer();
            }
            else if (this.OptionTimeMeasurementCountHour.Checked)
            {
                this.SimpleSleepInstance.SetTimeCountHour();
            }
        }

        private void ConfigureSimpleSleepTime()
        {
            int hours = this.OptionTime.Value.Hour;
            int minutes = this.OptionTime.Value.Minute;

            this.SimpleSleepInstance.SetTime(hours, minutes);
        }

        private void OptionTimeMeasurementCountHour_CheckedChanged(object sender, EventArgs e)
        {
            if (this.OptionTimeMeasurementCountHour.Checked)
            {
                this.UserChoiceTimeTimer = this.OptionTime.Value;
                this.OptionTime.Value = this.UserChoiceTimeCountHour;
            }

            this.ConfigureSimpleSleepTimeType();
            this.UpdateTimeRemaningShow();
        }

        private void OptionTimeMeasurementTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.OptionTimeMeasurementTimer.Checked)
            {
                this.UserChoiceTimeCountHour = this.OptionTime.Value;
                this.OptionTime.Value = this.UserChoiceTimeTimer;
            }

            this.ConfigureSimpleSleepTimeType();
            this.UpdateTimeRemaningShow();
        }

        private void InitUserChoiceTimeTimer()
        {
            DateTime now = DateTime.Now;
            this.UserChoiceTimeTimer = new DateTime(
                now.Year,
                now.Month,
                now.Day,
                SimpleSleepMain.DEFAULT_TIME_HOURS_ADD,
                SimpleSleepMain.DEFAULT_TIME_MINUTES_ADD,
                0
            );
        }

        private void InitUserChoiceTimeCountHour()
        {
            DateTime userTime = DateTime.Now.AddHours(
                SimpleSleepMain.DEFAULT_TIME_HOURS_ADD
            );
            this.UserChoiceTimeCountHour = userTime.AddMinutes(
                SimpleSleepMain.DEFAULT_TIME_MINUTES_ADD
            );
        }

        private async void UpdateTimeRemaningShowInBackground()
        {
            try
            {
                while (!this.SimpleSleepInstance.IsFinished())
                {
                    this.UpdateTimeRemaningShow();
                    await Task.Delay(
                        SimpleSleepMain.TIME_UPDATE_REMAIN,
                        TimerCancellToken.Token
                    );
                }
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                this.ChangeButtonTimerToStart();
            }
            //this.InitSimpleSleep();
        }

        private void UpdateTimeRemaningShow()
        {
            this.InfoShowRemainingTime.Text = this.SimpleSleepInstance.GetTimeRemainingFormat();
        }

        private void OptionTime_ValueChanged(object sender, EventArgs e)
        {
            this.ConfigureSimpleSleepTime();
            this.UpdateTimeRemaningShow();
        }

        private void OptionTypeEventShutdown_CheckedChanged(object sender, EventArgs e)
        {
            this.ConfigureSimpleSleepTypeAction();
        }

        private void OptionTypeEventHibernate_CheckedChanged(object sender, EventArgs e)
        {
            this.ConfigureSimpleSleepTypeAction();
        }

        private void TriggerAllowUserOptionsEdit()
        {
            this.OptionTypeEventShutdown.Enabled = !this.OptionTypeEventShutdown.Enabled;
            this.OptionTypeEventHibernate.Enabled = !this.OptionTypeEventHibernate.Enabled;
            this.OptionTimeMeasurementCountHour.Enabled = !this.OptionTimeMeasurementCountHour.Enabled;
            this.OptionTimeMeasurementTimer.Enabled = !this.OptionTimeMeasurementTimer.Enabled;
            this.OptionTime.Enabled = !this.OptionTime.Enabled;

        }
    }
}