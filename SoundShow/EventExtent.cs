using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;//nuget Newtonsoft
using System.IO;

namespace SoundShow
{
    /// <summary>
    /// 使用配置文件扩展事件
    /// </summary>
    class EventExtent
    {
        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T ToObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
        public static List<string> GetEventExtent(string  ShowType,string EventType)
        {
            //ShowItem tsst = new ShowItem()
            //{
            //    ShowName = "CenterShow",
            //    Events = new List<EventItem>()
            //    {
            //        new EventItem()
            //        {
            //            EventName = "FireHandlerEvent",
            //            EventList = new List<string>()
            //            {
            //                "aa","bb"
            //            }
            //        }
            //    }
            //};
            //List<ShowItem> items = new List<ShowItem>() { tsst };
            //string sre = JsonConvert.SerializeObject(items);
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config","eventExtent.config");
            
            if (!File.Exists(path))
                throw new Exception("事件扩展配置文件不存在");
            using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fStream);
                string txt = sr.ReadToEnd();
                List<ShowItem> pList = JsonConvert.DeserializeObject<List<ShowItem>>(txt);
                if (pList == null)
                    return new List<string>();
                return (from showItem in pList
                       where showItem.ShowName == ShowType
                       from eventItem in showItem.Events
                       where eventItem.EventName == EventType
                       select eventItem.EventList).FirstOrDefault().ToList();

            }
            
        }
    }
    class ShowItem
    {
        public string ShowName { get; set; }
        public List<EventItem>  Events{get;set;}
    }
    class EventItem
    {
        public string EventName { get; set; }
        public List<string> EventList { get; set; }
    }
}
