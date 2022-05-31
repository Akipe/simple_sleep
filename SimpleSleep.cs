using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSleep
{
    public class SimpleSleep
    {
        public const int DEFAULT_TIME_HOURS = 1;
        public const int DEFAULT_TIME_MINUTES = 0;

        public TimeAction TimeActionChoose { get; set; }
        public TimeType TimeTypeChoose { get; set; }
        public DateTime ExecuteAt { get; set; }
        public Boolean TimerStarted { get; set; }
        private CancellationTokenSource TimerCancellToken { get; set; }

        public SimpleSleep(
            TimeType timeTypeChoose = TimeType.Timer,
            int hours = SimpleSleep.DEFAULT_TIME_HOURS,
            int minutes = SimpleSleep.DEFAULT_TIME_MINUTES,
            TimeAction timeActionChoose = TimeAction.Shutdown
        ) {
            this.TimeTypeChoose = timeTypeChoose;
            this.SetTime(hours, minutes);
            this.TimeActionChoose = timeActionChoose;
            this.TimerStarted = false;
            this.TimerCancellToken = new CancellationTokenSource();
        }

        public void SetTimeTimer()
        {
            this.TimeTypeChoose = TimeType.Timer;
        }

        public void SetTimeCountHour()
        {
            this.TimeTypeChoose = TimeType.CountHour;
        }

        public void SetTime(int hours, int minutes)
        {
            switch(this.TimeTypeChoose)
            {
                case TimeType.Timer:
                    this.SetTimerTime(hours, minutes);
                    break;
                case TimeType.CountHour:
                    this.SetCountHourTime(hours, minutes);
                    break;
            }
        }

        private void SetTimerTime(int hours, int minutes)
        {
            DateTime endTimer;
            endTimer = DateTime.Now.AddHours(hours);
            endTimer = endTimer.AddMinutes(minutes);

            ExecuteAt = endTimer;
        }

        private void SetCountHourTime(int hours, int minutes)
        {
            DateTime finalDateTime = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                hours,
                minutes,
                0
            );

            if (finalDateTime < DateTime.Now)
            {
                finalDateTime = finalDateTime.AddDays(1);
            }

            ExecuteAt = finalDateTime;
        }

        public void SetActionShutdown()
        {
            this.TimeActionChoose = TimeAction.Shutdown;
        }

        public void SetActionHibernate()
        {
            this.TimeActionChoose = TimeAction.Hibernate;
        }

        public async void Start()
        {
            this.TimerStarted = true;

            try
            {
                await Task.Delay(
                    this.GetMilisecondsRemaining(),
                    this.TimerCancellToken.Token
                );

                this.TimerCancellToken
                    .Token
                    .ThrowIfCancellationRequested();

                switch(this.TimeActionChoose)
                {
                    case TimeAction.Shutdown:
                        this.ShutdownComputer();
                        break;
                    case TimeAction.Hibernate:
                        this.HibernateComputer();
                        break;
                }
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                this.TimerStarted = false;
                this.TimerCancellToken = new CancellationTokenSource();
            }
        }

        public void Stop(int resetToHours, int resetToMinutes)
        {
            this.TimerCancellToken.Cancel();
            this.TimerStarted = false;
            this.SetTime(resetToHours, resetToMinutes);
        }

        public void Stop()
        {
            this.Stop(0, 0);
        }

        public TimeSpan GetTimeSpanRemaining()
        {
            return this.ExecuteAt - DateTime.Now;
        }

        public string GetTimeRemainingFormat()
        {
            TimeSpan timeRemaining = this.GetTimeSpanRemaining();

            return 
                timeRemaining.Hours.ToString("D2") + ":" +
                timeRemaining.Minutes.ToString("D2") + ":" +
                timeRemaining.Seconds.ToString("D2")
            ;
        }

        public bool IsFinished()
        {
            return this.ExecuteAt <= DateTime.Now;
        }

        // todo: try catch dans le cas d'un dépassement de 4 milliard
        private int GetMilisecondsRemaining()
        {
            return (int) this.GetTimeSpanRemaining().TotalMilliseconds; 
        }

        private void ShutdownComputer()
        {
            var psi = new ProcessStartInfo(
                "shutdown",
                "/s /t 0"
                );
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        private void HibernateComputer()
        {
            Application.SetSuspendState(
                PowerState.Hibernate,
                true,
                true
            );
        }

        private void StandbyComputer()
        {
            Application.SetSuspendState(
                PowerState.Suspend,
                true,
                true
            );
        }

        private bool IsTimeIsPast(DateTime dateTime)
        {
            return dateTime < DateTime.Now;
        }
 
    }
}
