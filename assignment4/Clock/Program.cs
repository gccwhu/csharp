using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace assignment4
{
    // 闹钟类
    public class AlarmClock
    {
        private DateTime _alarmTime;
        private bool _isAlarmTriggered;

        // 定义事件委托
        public event EventHandler Tick;
        public event EventHandler Alarm;

        // 闹钟时间属性
        public DateTime AlarmTime
        {
            get => _alarmTime;
            set
            {
                _alarmTime = value;
                _isAlarmTriggered = false; // 重置触发状态
            }
        }

        // 当前模拟时间
        public DateTime CurrentTime { get; private set; }

        // 启动闹钟
        public void Start()
        {
            CurrentTime = DateTime.Now;
            Console.WriteLine($"闹钟启动，当前时间：{CurrentTime:HH:mm:ss}");

            while (true)
            {
                // 模拟每秒前进一次
                Thread.Sleep(1000);
                CurrentTime = CurrentTime.AddSeconds(1);

                // 触发嘀嗒事件
                OnTick();

                // 检查是否到达闹钟时间
                if (!_isAlarmTriggered && CurrentTime >= AlarmTime)
                {
                    OnAlarm();
                    _isAlarmTriggered = true;
                }
            }
        }

        // 触发Tick事件
        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }

        // 触发Alarm事件
        protected virtual void OnAlarm()
        {
            Alarm?.Invoke(this, EventArgs.Empty);
        }
    }

    class clock
    {
        static void Main()
        {
            var alarmClock = new AlarmClock();

            // 设置5秒后响铃
            alarmClock.AlarmTime = DateTime.Now.AddSeconds(5);

            // 订阅嘀嗒事件
            alarmClock.Tick += (sender, e) =>
            {
                Console.WriteLine($"[滴答] 当前时间：{alarmClock.CurrentTime:HH:mm:ss}");
            };
            // 订阅响铃事件
            alarmClock.Alarm += (sender, e) =>
            {
                Console.WriteLine("[铃声] 叮铃铃！！！");
            };

            // 启动闹钟
            alarmClock.Start();
        }
    }
}

