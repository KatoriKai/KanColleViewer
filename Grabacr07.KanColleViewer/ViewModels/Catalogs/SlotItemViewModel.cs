﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Grabacr07.KanColleViewer.Properties;
using Livet;

namespace Grabacr07.KanColleViewer.ViewModels.Catalogs
{
    public class SlotItemViewModel : ViewModel
    {
        public ShipSlot Slot { get; set; }
        public SlotItemInfo Info { get; set; }
        
        public SlotItemViewModel()
        {
        }

        public SlotItemViewModel(ShipSlot item)
        {
            this.Slot = item;
            this.Info = Slot.Item.Info;
        }

        public bool IsHasDetail {
            get {
                return Detail != "";
            }
        }

        public string Detail
        {
            get
            {
                List<string> details = new List<string>();

                if (this.Info.Firepower != 0) details.Add(StatFormat(this.Info.Firepower, Resources.Stats_Firepower));
                if (this.Info.AA != 0) details.Add(StatFormat(this.Info.AA, Resources.Stats_AntiAir));
                if (this.Info.Torpedo != 0) details.Add(StatFormat(this.Info.Torpedo, Resources.Stats_Torpedo));
                if (this.Info.AntiSub != 0) details.Add(StatFormat(this.Info.AntiSub, Resources.Stats_AntiSub));
                if (this.Info.SightRange != 0) details.Add(StatFormat(this.Info.SightRange, Resources.Stats_SightRange));
                if (this.Info.Speed != 0) details.Add(StatFormat(this.Info.Speed, Resources.Stats_Speed));
                if (this.Info.Armor != 0) details.Add(StatFormat(this.Info.Armor, Resources.Stats_Armor));
                if (this.Info.Health != 0) details.Add(StatFormat(this.Info.Health, Resources.Stats_Health));
                if (this.Info.Luck != 0) details.Add(StatFormat(this.Info.Luck, Resources.Stats_Luck));
                if (this.Info.Evasion != 0) details.Add(StatFormat(this.Info.Evasion, Resources.Stats_Evasion));
                if (this.Info.Accuracy != 0) details.Add(StatFormat(this.Info.Accuracy, Resources.Stats_Accuracy));
                if (this.Info.DiveBomb != 0) details.Add(StatFormat(this.Info.DiveBomb, Resources.Stats_DiveBomb));
                if (this.Info.AttackRange > 0) details.Add(String.Format(" {1}({0})", this.Info.AttackRange, Resources.Stats_AttackRange));
                //if (this.Info.RawData.api_raik > 0) AddDetail += (AddDetail != "" ? "\n" : "") + " +" + this.Info.RawData.api_raik + " api_raik";
                //if (this.Info.RawData.api_raim > 0) AddDetail += (AddDetail != "" ? "\n" : "") + " +" + this.Info.RawData.api_raim + " api_raim";
                //if (this.Info.RawData.api_sakb > 0) AddDetail += (AddDetail != "" ? "\n" : "") + " +" + this.Info.RawData.api_sakb + " api_sakb";
                //if (this.Info.RawData.api_atap > 0) AddDetail += (AddDetail != "" ? "\n" : "") + " +" + this.Info.RawData.api_atap + " api_atap";
                //if (this.Info.RawData.api_rare > 0) AddDetail += (AddDetail != "" ? "\n" : "") + " +" + this.Info.RawData.api_rare + " api_rare";
                //if (this.Info.RawData.api_bakk > 0) AddDetail += (AddDetail != "" ? "\n" : "") + " +" + this.Info.RawData.api_bakk + " api_bakk";

                return String.Join("\n", details);
            }
        }

        private string StatFormat(int stat, string name)
        {
            return String.Format(" {0:+#;-#} {1}", stat, name);
        }
    }
}
