using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundShow
{
    /// <summary>
    /// 温度发布者
    /// </summary>
    interface ITemperaturePublisher
    {
        void RegistShow(BaseShow show);
        void RemoveShow(BaseShow show);
        void PublishTemperature(int temp);
    }
    class TemperaturePublisher: ITemperaturePublisher
    {
        private List<BaseShow> Observers = new List<BaseShow>();
        public void RegistShow(BaseShow show)
        {
            Observers.Add(show);
        }
        public void RemoveShow(BaseShow show)
        {
            Observers.Remove(show);
        }
        public void PublishTemperature(int temp)
        {
            LogHelper.LogAndConsole($"************{temp}度****************");
            foreach(BaseShow Observer in Observers)
            {
                Observer.TemperatureChange(temp);
            }
        }
    }
}
