using System;
using System.Collections.Generic;
using System.Text;

namespace Softphone.SettingFolder
{
    interface ISettingsControl
    {
        bool ApplyOptions();
        bool IsChanged { get; set; }
       event SettingChanged OnChanged;
    }
}
