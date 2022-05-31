namespace SimpleSleep
{
    partial class SimpleSleepMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OptionTimeMeasurement = new System.Windows.Forms.Panel();
            this.OptionTimeMeasurementCountHour = new System.Windows.Forms.RadioButton();
            this.OptionTimeMeasurementTimer = new System.Windows.Forms.RadioButton();
            this.InfoShow = new System.Windows.Forms.Panel();
            this.StartTimer = new System.Windows.Forms.Button();
            this.InfoShowRemainingTime = new System.Windows.Forms.Label();
            this.InfoShowLabel = new System.Windows.Forms.Label();
            this.OptionsTypeEvent = new System.Windows.Forms.Panel();
            this.OptionTypeEventHibernate = new System.Windows.Forms.RadioButton();
            this.OptionTypeEventShutdown = new System.Windows.Forms.RadioButton();
            this.OptionTime = new System.Windows.Forms.DateTimePicker();
            this.OptionTimeMeasurement.SuspendLayout();
            this.InfoShow.SuspendLayout();
            this.OptionsTypeEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionTimeMeasurement
            // 
            this.OptionTimeMeasurement.Controls.Add(this.OptionTimeMeasurementCountHour);
            this.OptionTimeMeasurement.Controls.Add(this.OptionTimeMeasurementTimer);
            this.OptionTimeMeasurement.Location = new System.Drawing.Point(12, 51);
            this.OptionTimeMeasurement.Name = "OptionTimeMeasurement";
            this.OptionTimeMeasurement.Size = new System.Drawing.Size(260, 32);
            this.OptionTimeMeasurement.TabIndex = 1;
            // 
            // OptionTimeMeasurementCountHour
            // 
            this.OptionTimeMeasurementCountHour.AutoSize = true;
            this.OptionTimeMeasurementCountHour.Checked = true;
            this.OptionTimeMeasurementCountHour.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OptionTimeMeasurementCountHour.Location = new System.Drawing.Point(3, 3);
            this.OptionTimeMeasurementCountHour.Name = "OptionTimeMeasurementCountHour";
            this.OptionTimeMeasurementCountHour.Size = new System.Drawing.Size(107, 25);
            this.OptionTimeMeasurementCountHour.TabIndex = 1;
            this.OptionTimeMeasurementCountHour.TabStop = true;
            this.OptionTimeMeasurementCountHour.Text = "Count hour";
            this.OptionTimeMeasurementCountHour.UseVisualStyleBackColor = true;
            this.OptionTimeMeasurementCountHour.CheckedChanged += new System.EventHandler(this.OptionTimeMeasurementCountHour_CheckedChanged);
            // 
            // OptionTimeMeasurementTimer
            // 
            this.OptionTimeMeasurementTimer.AutoSize = true;
            this.OptionTimeMeasurementTimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OptionTimeMeasurementTimer.Location = new System.Drawing.Point(116, 3);
            this.OptionTimeMeasurementTimer.Name = "OptionTimeMeasurementTimer";
            this.OptionTimeMeasurementTimer.Size = new System.Drawing.Size(68, 25);
            this.OptionTimeMeasurementTimer.TabIndex = 0;
            this.OptionTimeMeasurementTimer.Text = "Timer";
            this.OptionTimeMeasurementTimer.UseVisualStyleBackColor = true;
            this.OptionTimeMeasurementTimer.CheckedChanged += new System.EventHandler(this.OptionTimeMeasurementTimer_CheckedChanged);
            // 
            // InfoShow
            // 
            this.InfoShow.Controls.Add(this.StartTimer);
            this.InfoShow.Controls.Add(this.InfoShowRemainingTime);
            this.InfoShow.Controls.Add(this.InfoShowLabel);
            this.InfoShow.Location = new System.Drawing.Point(12, 125);
            this.InfoShow.Name = "InfoShow";
            this.InfoShow.Size = new System.Drawing.Size(260, 130);
            this.InfoShow.TabIndex = 2;
            // 
            // StartTimer
            // 
            this.StartTimer.Location = new System.Drawing.Point(88, 101);
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.Size = new System.Drawing.Size(75, 23);
            this.StartTimer.TabIndex = 2;
            this.StartTimer.Text = "Start";
            this.StartTimer.UseVisualStyleBackColor = true;
            this.StartTimer.Click += new System.EventHandler(this.StartTimer_Click);
            // 
            // InfoShowRemainingTime
            // 
            this.InfoShowRemainingTime.AutoSize = true;
            this.InfoShowRemainingTime.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InfoShowRemainingTime.Location = new System.Drawing.Point(15, 21);
            this.InfoShowRemainingTime.Name = "InfoShowRemainingTime";
            this.InfoShowRemainingTime.Size = new System.Drawing.Size(228, 72);
            this.InfoShowRemainingTime.TabIndex = 1;
            this.InfoShowRemainingTime.Text = "00:00:00";
            // 
            // InfoShowLabel
            // 
            this.InfoShowLabel.AutoSize = true;
            this.InfoShowLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InfoShowLabel.Location = new System.Drawing.Point(42, 0);
            this.InfoShowLabel.Name = "InfoShowLabel";
            this.InfoShowLabel.Size = new System.Drawing.Size(163, 21);
            this.InfoShowLabel.TabIndex = 0;
            this.InfoShowLabel.Text = "Time before execution";
            // 
            // OptionsTypeEvent
            // 
            this.OptionsTypeEvent.Controls.Add(this.OptionTypeEventHibernate);
            this.OptionsTypeEvent.Controls.Add(this.OptionTypeEventShutdown);
            this.OptionsTypeEvent.Location = new System.Drawing.Point(12, 12);
            this.OptionsTypeEvent.Name = "OptionsTypeEvent";
            this.OptionsTypeEvent.Size = new System.Drawing.Size(260, 33);
            this.OptionsTypeEvent.TabIndex = 2;
            // 
            // OptionTypeEventHibernate
            // 
            this.OptionTypeEventHibernate.AutoSize = true;
            this.OptionTypeEventHibernate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OptionTypeEventHibernate.Location = new System.Drawing.Point(108, 3);
            this.OptionTypeEventHibernate.Name = "OptionTypeEventHibernate";
            this.OptionTypeEventHibernate.Size = new System.Drawing.Size(96, 25);
            this.OptionTypeEventHibernate.TabIndex = 1;
            this.OptionTypeEventHibernate.TabStop = true;
            this.OptionTypeEventHibernate.Text = "Hibernate";
            this.OptionTypeEventHibernate.UseVisualStyleBackColor = true;
            this.OptionTypeEventHibernate.CheckedChanged += new System.EventHandler(this.OptionTypeEventHibernate_CheckedChanged);
            // 
            // OptionTypeEventShutdown
            // 
            this.OptionTypeEventShutdown.AutoSize = true;
            this.OptionTypeEventShutdown.Checked = true;
            this.OptionTypeEventShutdown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OptionTypeEventShutdown.Location = new System.Drawing.Point(3, 3);
            this.OptionTypeEventShutdown.Name = "OptionTypeEventShutdown";
            this.OptionTypeEventShutdown.Size = new System.Drawing.Size(99, 25);
            this.OptionTypeEventShutdown.TabIndex = 0;
            this.OptionTypeEventShutdown.TabStop = true;
            this.OptionTypeEventShutdown.Text = "Shutdown";
            this.OptionTypeEventShutdown.UseVisualStyleBackColor = true;
            this.OptionTypeEventShutdown.CheckedChanged += new System.EventHandler(this.OptionTypeEventShutdown_CheckedChanged);
            // 
            // OptionTime
            // 
            this.OptionTime.CustomFormat = "\"hh:mm tt\"";
            this.OptionTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OptionTime.Location = new System.Drawing.Point(12, 90);
            this.OptionTime.Name = "OptionTime";
            this.OptionTime.Size = new System.Drawing.Size(260, 29);
            this.OptionTime.TabIndex = 0;
            this.OptionTime.ValueChanged += new System.EventHandler(this.OptionTime_ValueChanged);
            // 
            // SimpleSleepMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.OptionsTypeEvent);
            this.Controls.Add(this.InfoShow);
            this.Controls.Add(this.OptionTimeMeasurement);
            this.Controls.Add(this.OptionTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SimpleSleepMain";
            this.Text = "SimpleSleep";
            this.OptionTimeMeasurement.ResumeLayout(false);
            this.OptionTimeMeasurement.PerformLayout();
            this.InfoShow.ResumeLayout(false);
            this.InfoShow.PerformLayout();
            this.OptionsTypeEvent.ResumeLayout(false);
            this.OptionsTypeEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel OptionTimeMeasurement;
        private RadioButton OptionTimeMeasurementCountHour;
        private RadioButton OptionTimeMeasurementTimer;
        private Panel InfoShow;
        private Label InfoShowLabel;
        private Panel OptionsTypeEvent;
        private RadioButton OptionTypeEventHibernate;
        private RadioButton OptionTypeEventShutdown;
        private Label InfoShowRemainingTime;
        private DateTimePicker OptionTime;
        private Button StartTimer;
    }
}