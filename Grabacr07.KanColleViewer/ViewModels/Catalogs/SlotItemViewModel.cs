using System;
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
		private int count;
		public List<Counter> Ships { get; private set; }

		public class Counter
		{
			public Ship Ship { get; set; }
			public int Count { get; set; }

			public string ShipName
			{
			    get { return this.Ship.Info.Name; }
			}

		    public string ShipLevel
		    {
		        get { return "Lv." + this.Ship.Level; }
		    }

		    public string CountString
		    {
		        get { return this.Count == 1 ? "" : " x " + this.Count + " "; }
		    }

            public string EquipStar { get; set; }

			public string StatsToolTip
			{
				get
				{
					string AddDetail = "";

					foreach (ShipSlot s in this.Ship.EquippedSlots) {
                        AddDetail += String.Format("{0}{1}\n", s.Item.Info.Name, s.Item.Level >= 10 ? " ★max" : s.Item.Level >= 1 ? (" ★+" + s.Item.Level) : "");
                        //AddDetail += String.Format("{0}{1}\n", s.Item.Info.Name, s.Item.Level > 0 ? " ★+" + s.Item.Level : "");
					}

					return AddDetail.TrimEnd('\n');
				}
			}
		}


		public SlotItemInfo SlotItem { get; set; }
		public int Level { get; set; }

		public int Count
		{
			get { return this.count; }
			set { this.count = this.Remainder = value; }
		}

		public int Remainder { get; set; }


		public SlotItemViewModel()
		{
			this.Ships = new List<Counter>();
		}

		public SlotItemViewModel(SlotItemInfo item)
		{
			this.Ships = new List<Counter>();
			this.SlotItem = item;
			this.Level = 0;
		}

        public void AddShip(Ship ship, bool InEnhanceEquipment)
		{
			var target = this.Ships.FirstOrDefault(x => x.Ship.Id == ship.Id);
			if (target == null)
			{
				 if (InEnhanceEquipment)
                     this.Ships.Add(new Counter { Ship = ship, Count = 1, EquipStar = "★" });
                else
                     this.Ships.Add(new Counter { Ship = ship, Count = 1 }); ;
			}
			else
			{
				target.Count++;
			}

			this.Remainder--;
		}

		public string DetailedToolTip
		{
			get
			{
				string _Detail = this.Detail;
				return this.SlotItem.Name + (this.Level >= 10 ? " max" : this.Level >= 1 ? (" ★+" + this.Level) : "") + (_Detail != "" ? "\n" + _Detail : "");
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

				if (this.SlotItem.Firepower != 0) AddDetail += Resources.Stats_Firepower + " " + SignedStr(this.SlotItem.Firepower);
                if (this.SlotItem.AA != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_AntiAir + " " + SignedStr(this.SlotItem.AA);
                if (this.SlotItem.Torpedo != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Torpedo + " " + SignedStr(this.SlotItem.Torpedo);
                if (this.SlotItem.AntiSub != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_AntiSub + " " + SignedStr(this.SlotItem.AntiSub);
                if (this.SlotItem.SightRange != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_SightRange + " " + SignedStr(this.SlotItem.SightRange);
                if (this.SlotItem.Speed != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Speed + " " + SignedStr(this.SlotItem.Speed);
                if (this.SlotItem.Armor != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Armor + " " + SignedStr(this.SlotItem.Armor);
                if (this.SlotItem.Health != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Health + " " + SignedStr(this.SlotItem.Health);
                if (this.SlotItem.Luck != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Luck + " " + SignedStr(this.SlotItem.Luck);
                if (this.SlotItem.Accuracy != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Accuracy + " " + SignedStr(this.SlotItem.Accuracy);
                if (this.SlotItem.Evasion != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_Evasion + " " + SignedStr(this.SlotItem.Evasion);
                if (this.SlotItem.DiveBomb != 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_DiveBomb + " " + SignedStr(this.SlotItem.DiveBomb);
 				if (this.SlotItem.AttackRange > 0) AddDetail += (AddDetail != "" ? "\n" : "") + Resources.Stats_AttackRange + " (" + this.SlotItem.AttackRange + ")";

				return AddDetail;
			}
		}
	}
}
