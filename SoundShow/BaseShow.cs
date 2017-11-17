using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundShow
{
    interface ICharge
    {
        void charge();
    }
    public abstract class BaseShow
    {
        public event Action FireHandlerEvent;
        public int MaxTemperature = 400;
        public void TemperatureChange(int temp)
        {
            LogHelper.LogAndConsole($"{this.GetType()}");
            if (temp < MaxTemperature)
                LogHelper.LogAndConsole("(～﹃～)~zZ（呼呼大睡）");
            else
                FireHandlerEvent.Invoke();
            LogHelper.LogAndConsole("");
        }
        public string Actor { get; set; }
        public string Desktop { get; set; }
        public string Chair { get; set; }
        /// <summary>
        /// 扇
        /// </summary>
        public string Fan { get; set; }
        public string Ruler { get; set; }
        public void Start()
        {
            LogHelper.LogAndConsole("表演开始了");
        }
        public abstract void DogBark();
        public abstract void PeopelTalk();
        public abstract void WindBlow();
        public virtual void OpenRemark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:欢迎收听口技表演！");
        }
        public virtual void EndRemark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:谢谢大家的收听！");
        }
    }
    /// <summary>
    /// 南派口技表演，绝活变魔术，魔术毯，有个小助理
    /// </summary>
    public class SouthShow : BaseShow, ICharge
    {
        /// <summary>
        /// 助理
        /// </summary>
        public string Assistant { get; set; }
        /// <summary>
        /// 魔术毯
        /// </summary>
        public string MagicCarpet;
        public void MagicShow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:用{this.MagicCarpet}遮住{this.Assistant}，拉开{this.MagicCarpet}，{this.Assistant}变成了小兔子。");
        }
        public override void DogBark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:汪汪汪，汪汪汪，汪汪汪汪汪汪汪");
        }
        public override void PeopelTalk()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:妇人惊觉欠伸，其夫呓语。既而儿醒，大啼。夫亦醒。妇抚儿乳，儿含乳啼，妇拍而呜之");
        }
        public override void WindBlow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 呼呼~~~~~~");

        }
        public override void OpenRemark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:好高兴见到大家，希望大家钟意我的表演！");
        }
        public void charge()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 一块两块也是爱，十块八块的都很帅");
        }
    }
    /// <summary>
    /// 北派口技表演，绝活二人转，手帕，有个小徒弟
    /// </summary>
    public class NorthShow : BaseShow, ICharge
    {
        /// <summary>
        /// 徒弟
        /// </summary>
        public string Apprentice { get; set; }
        /// <summary>
        /// 手帕
        /// </summary>
        public string Handkerchief;
        public void ErRenZhuan()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:{this.Actor}：“挖个坑、埋点土、数个一二三四五”。{this.Apprentice}：“自己的土自己的地、种啥都长人民币”，转起{this.Handkerchief}");
        }
        public override void DogBark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:汪，汪汪，汪，汪汪汪汪汪汪汪");
        }
        public override void PeopelTalk()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:妇人惊觉欠伸，其夫呓语。既而儿醒，大啼。夫亦醒。妇抚儿乳，儿含乳啼，妇拍而呜之");
        }
        public override void WindBlow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 嗖嗖~~~~~~");

        }
        public override void EndRemark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:谢谢各位老铁的掌声！");
        }

        public void charge()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 有钱的捧个钱场，没钱的捧个人场！");
        }
    }
    /// <summary>
    /// 西派口技表演，绝活唱山歌，头巾，有个搭档
    /// </summary>
    public class WestShow : BaseShow, ICharge
    {
        /// <summary>
        /// 搭档
        /// </summary>
        public string Partner { get; set; }
        /// <summary>
        /// 头巾
        /// </summary>
        public string Headkerchief;
        public void SingMountSong()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:{this.Actor}裹着{this.Headkerchief}唱到：“山丹丹的那个开花呦”。{this.Partner}：“红艳艳~~~,红艳艳~~~”");
        }
        public override void DogBark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:汪汪汪汪汪汪汪");
        }
        public override void PeopelTalk()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:妇人惊觉欠伸，其夫呓语。既而儿醒，大啼。夫亦醒。妇抚儿乳，儿含乳啼，妇拍而呜之");
        }
        public override void WindBlow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 哗哗~~~~~~");

        }
        public override void EndRemark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:额的表演就是这，希望大家伙儿喜欢！");
        }
        public override void OpenRemark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:能在这里给大伙表演，额高兴滴很！");
        }

        public void charge()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:在家靠父母，出门靠朋友，走南闯北不容易，大伙多鼓励");
        }
    }
    /// <summary>
    /// 东派口技表演，绝活脱口秀，西装，有个秘书
    /// </summary>
    public class EastShow : BaseShow, ICharge
    {
        /// <summary>
        /// 秘书
        /// </summary>
        public string Secretary { get; set; }
        /// <summary>
        /// 西装
        /// </summary>
        public string suit;
        public void TalkShow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:{this.Actor}穿着{this.suit}说到：“说金钱是罪恶，都在捞；说美女是祸水，都想要；说高处不胜寒，都在爬；说烟酒伤身体，都不戒；说天堂最美好，都不去！ ”");
        }
        public override void DogBark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:汪汪，嗷呜~~~~~");
        }
        public override void PeopelTalk()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:妇人惊觉欠伸，其夫呓语。既而儿醒，大啼。夫亦醒。妇抚儿乳，儿含乳啼，妇拍而呜之");
        }
        public override void WindBlow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 沙沙~~~~~~");

        }
        public void charge()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:一块两块，你买不了烟，也买不了酒，却能买个好心情，请大家多多支持！");
        }

    }


    public class CenterShow : BaseShow, ICharge
    {
        public event Action BeginHandleEvent;
        public event Action WaveHandleEvent;
        public event Action EndHandleEvent;
        public override void DogBark()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:嗷呜~~~~~嗷呜~~~~~嗷呜~~~~~");
        }
        public override void PeopelTalk()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:妇人惊觉欠伸，其夫呓语。既而儿醒，大啼。夫亦醒。妇抚儿乳，儿含乳啼，妇拍而呜之");
        }
        public override void WindBlow()
        {
            LogHelper.LogAndConsole($"{this.GetType()}: 呜~~~呼~~~~~~");

        }
        public void charge()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:听正宗口技，来中派表演，谢谢大家支持！");
        }
        public void Raokouling()
        {
            LogHelper.LogAndConsole($"{this.GetType()}:哥哥弟弟坡前坐，坡上卧着一只鹅，坡下流着一条河，哥哥说：宽宽的河，弟弟说：白白的鹅。");
            LogHelper.LogAndConsole("                   鹅要过河，河要渡鹅。不知是鹅过河，还是河渡鹅。");
        }
        public void Show()
        {
            Start();
            OpenRemark();
            BeginHandleEvent.Invoke();
            DogBark();
            PeopelTalk();
            WindBlow();
            Raokouling();
            WaveHandleEvent();
            EndRemark();
            charge();
            EndHandleEvent();
        }
    }
}
