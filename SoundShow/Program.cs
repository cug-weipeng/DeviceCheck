using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoundShow
{
    class Program
    {
        static string  spliter = "****************************************************************************";
        static string shortSpliter = "*****************************";
        static void Main(string[] args)
        {
            BaseShow baseShow;
            NorthShow northShow = new NorthShow()
            {
                Actor = "赵大山",
                Desktop = "八仙桌",
                Chair = "太师椅",
                Ruler = "扶尺",
                Fan = "折扇",
                Apprentice = "沈小阳",
                Handkerchief = "红手帕"
            };
            SouthShow southShow = new SouthShow()
            {
                Actor = "刘大谦",
                Desktop = "魔术桌",
                Chair = "魔术椅",
                Ruler = "扶尺",
                Fan = "折扇",
                Assistant = "董小卿",
                MagicCarpet = "黑色魔毯"
            };
            EastShow eastShow = new EastShow()
            {
                Actor = "周大波",
                Desktop = "办工桌",
                Chair = "办公椅",
                Ruler = "扶尺",
                Fan = "折扇",
                suit = "黑西服",
                Secretary = "美女秘书"
            };
            WestShow westShow = new WestShow()
            {
                Actor = "阿大宝",
                Desktop = "课桌",
                Chair = "板凳",
                Ruler = "扶尺",
                Fan = "折扇",
                Partner = "王小妮",
                Headkerchief = "白头巾"
            };

            Console.WriteLine("自我介绍");
            ShowDetail(northShow);
            ShowDetail(southShow);
            ShowDetail(eastShow);
            ShowDetail(westShow);
            Console.WriteLine(spliter);
            Console.WriteLine("");

            Console.WriteLine("开始表演");
            play(southShow);
            play(northShow);
            play(westShow);
            play(eastShow);
            Console.WriteLine(spliter);
            Console.WriteLine("");
            
            //绝活表演
            JueHuo(southShow.MagicShow);
            JueHuo(northShow.ErRenZhuan);
            JueHuo(westShow.SingMountSong);
            JueHuo(eastShow.TalkShow);
            Console.WriteLine(spliter);
            Console.WriteLine("");

            //火起事件
            southShow.FireHandlerEvent += () => { Console.WriteLine("夫起大户：快起来呀，着火了！"); };
            southShow.FireHandlerEvent += () => { Console.WriteLine("妇亦起大呼：哎呀，天哪，怎么着火了！"); };
            southShow.FireHandlerEvent += () => { Console.WriteLine("两儿齐哭：哇啊~~，妈妈，妈妈"); };
            southShow.FireHandlerEvent += () => { Console.WriteLine("百千人大呼：起火了，大家快来救火呀！"); };
            southShow.FireHandlerEvent += () => { Console.WriteLine("百千儿哭：呜哇！呜哇！呜哇呜哇！"); };
            southShow.FireHandlerEvent += () => { Console.WriteLine("百千犬吠：汪汪汪汪汪汪汪汪汪汪汪汪汪汪！"); };

            northShow.FireHandlerEvent += () => { Console.WriteLine("夫起大户:老婆，着火了！！"); };
            northShow.FireHandlerEvent += () => { Console.WriteLine("妇亦起大呼:哎呀妈呀，好吓人呀！！"); };

            westShow.FireHandlerEvent += () => { Console.WriteLine("夫起大户:老婆快起来，又着火了！！"); };
            westShow.FireHandlerEvent += () => { Console.WriteLine("妇亦起大呼:快抱着孩子跑呀！！"); };
            westShow.FireHandlerEvent += () => { Console.WriteLine("两儿齐哭:妈妈，好怕！！"); };

            eastShow.FireHandlerEvent += () => { Console.WriteLine("夫起大户:了不得了起大火了，老婆！！"); };
            eastShow.FireHandlerEvent += () => { Console.WriteLine("妇亦起大呼:别傻叫了，快跑！！"); };


            Console.ReadLine();

        }

        private static void SouthShow_TemperChangeHandlerEvent()
        {
            throw new NotImplementedException();
        }

        public static void play<T>(T show)
            where T:BaseShow,ICharge
        {
            show.Start();
            show.OpenRemark();
            show.DogBark();
            show.PeopelTalk();
            show.WindBlow();
            show.EndRemark();
            show.charge();
            Console.WriteLine("");
        }
        public static void JueHuo(Action action)
        {
            Console.WriteLine("绝活马上开始了。。。");
            action.Invoke();
            Console.WriteLine("绝活表演结束，大家鼓掌！！");
            Console.WriteLine(shortSpliter);
        }
        public static void ShowDetail<T>(T show)
            where T : BaseShow
        {

            Type t = typeof(T);
            PropertyInfo[] memberInfos = t.GetProperties( );
            Console.WriteLine($"{t.Name}");
            string txt = "  属性：  ";
            foreach (PropertyInfo memberInfo in memberInfos)
                txt += $"{memberInfo.Name}:{memberInfo.GetValue(show)};    ";
            Console.WriteLine(txt.TrimEnd());
            FieldInfo[] fielfInfos = t.GetFields();
            
            txt = "  字段：  ";
            foreach (FieldInfo info in fielfInfos)
            { 

                txt += $"{info.Name}:{info.GetValue(show)};    ";
            }
            Console.WriteLine(txt);
        //    Console.WriteLine(spliter);
        }
    }
}
