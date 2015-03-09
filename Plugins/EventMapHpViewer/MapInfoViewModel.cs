﻿using System.Windows.Media;
using Livet;

namespace EventMapHpViewer
{
    public class MapInfoViewModel : ViewModel
    {

        #region MapNumber変更通知プロパティ
        private string _MapNumber;

        public string MapNumber
        {
            get
            { return this._MapNumber; }
            set
            {
                if (this._MapNumber == value)
                    return;
                this._MapNumber = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region Name変更通知プロパティ
        private string _Name;

        public string Name
        {
            get
            { return this._Name; }
            set
            { 
                if (this._Name == value)
                    return;
                this._Name = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region AreaName変更通知プロパティ
        private string _AreaName;

        public string AreaName
        {
            get
            { return this._AreaName; }
            set
            { 
                if (this._AreaName == value)
                    return;
                this._AreaName = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region Current変更通知プロパティ
        private int _Current;

        public int Current
        {
            get
            { return this._Current; }
            set
            { 
                if (this._Current == value)
                    return;
                this._Current = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region Max変更通知プロパティ
        private int _Max;

        public int Max
        {
            get
            { return this._Max; }
            set
            { 
                if (this._Max == value)
                    return;
                this._Max = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region RemainingCount変更通知プロパティ
        private int _RemainingCount;

        public int RemainingCount
        {
            get
            { return this._RemainingCount; }
            set
            { 
                if (this._RemainingCount == value)
                    return;
                this._RemainingCount = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region IsCleared変更通知プロパティ
        private bool _IsCleared;

        public bool IsCleared
        {
            get
            { return this._IsCleared; }
            set
            { 
                if (this._IsCleared == value)
                    return;
                this._IsCleared = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        #region GaugeColor変更通知プロパティ
        private SolidColorBrush _GaugeColor;

        public SolidColorBrush GaugeColor
        {
            get
            { return this._GaugeColor; }
            set
            { 
                if (this._GaugeColor == value)
                    return;
                this._GaugeColor = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion


        public MapInfoViewModel(MapInfo.Api_Data info)
        {
            this.MapNumber = info.MapNumber;
            this.Name = info.Name;
            this.AreaName = info.AreaName;
            this.Current = info.Current;
            this.Max = info.Max;
            this.RemainingCount = info.RemainingCount;
            this.IsCleared = info.api_cleared == 1;
            var color = this.RemainingCount < 2
                ? new SolidColorBrush(Color.FromRgb(255, 32, 32))
                : new SolidColorBrush(Color.FromRgb(64, 200, 32));
            color.Freeze();
            this.GaugeColor = color;
        }
    }
}
