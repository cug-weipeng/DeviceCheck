using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundShow
{
    public abstract class BaseShow
    {
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
            Console.Write("表演开始了");
        }
        public abstract void DogBark();
        public abstract void PeopelTalk();
        public abstract void WindBlow();
        public virtual void OpenRemark()
        {
            Console.Write($"{this.GetType()}:欢迎收听口技表演！");
        }
        public virtual void EndRemark()
        {
            Console.Write($"{this.GetType()}:谢谢大家的收听！");
        }
    }
    /// <summary>
    /// 南派口技表演，绝活变魔术，魔术毯，有个小助理
    /// </summary>
    public class SouthShow:BaseShow
    {
        public string Assistant { get; set; }
        /// <summary>
        /// 魔术毯
        /// </summary>
        public string MagicCarpet;
        public void MagicShow()
        {
            Console.Write($"{this.GetType()}:用{this.MagicCarpet}遮住{this.Assistant}，拉开{this.MagicCarpet}，{this.Assistant}变成了小兔子。");
        }
    }
}
