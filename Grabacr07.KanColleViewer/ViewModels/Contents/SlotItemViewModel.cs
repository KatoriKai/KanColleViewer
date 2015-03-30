using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper.Models;
using Grabacr07.KanColleViewer.Properties;
using Livet;

namespace Grabacr07.KanColleViewer.ViewModels.Contents
{
	public class SlotItemViewModel : ViewModel
	{
        public ShipSlot Slot { get; set; }
		public SlotItemInfo Info{ get; set; }

        public SlotItemViewModel(ShipSlot item)
		{
            this.Slot = item;
            this.Info = Slot.Item.Info;
		}

        public bool IsHasDetail
        {
            get
            {
                return Detail != "";
            }
        }

        private string SignedStr(int Value)
        {
            return Value.ToString("+#;-#;#");
        }

        public string Detail
        {
            get
            {
                string AddDetail = "";

                if (this.Info.Firepower != 0) AddDetail += Resources.Stats_Firepower + " " + SignedStr(this.Info.Firepower);
                if (this.Info.AA != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_AntiAir + " " + SignedStr(this.Info.AA);
                if (this.Info.Torpedo != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Torpedo + " " + SignedStr(this.Info.Torpedo);
                if (this.Info.AntiSub != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_AntiSub + " " + SignedStr(this.Info.AntiSub);
                if (this.Info.SightRange != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_SightRange + " " + SignedStr(this.Info.SightRange);
                if (this.Info.Speed != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Speed + " " + SignedStr(this.Info.Speed);
                if (this.Info.Armor != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Armor + " " + SignedStr(this.Info.Armor);
                if (this.Info.Health != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Health + " " + SignedStr(this.Info.Health);
                if (this.Info.Luck != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Luck + " " + SignedStr(this.Info.Luck);
                if (this.Info.Accuracy != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Accuracy + " " + SignedStr(this.Info.Accuracy);
                if (this.Info.Evasion != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Evasion + " " + SignedStr(this.Info.Evasion);
                if (this.Info.DiveBomb != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_DiveBomb + " " + SignedStr(this.Info.DiveBomb);
                if (this.Info.AttackRange > 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_AttackRange + " (" + this.Info.AttackRange + ")";

                return AddDetail;
            }
        }
	}
}
