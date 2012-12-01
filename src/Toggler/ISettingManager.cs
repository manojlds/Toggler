using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toggler
{
    public interface ISettingManager
    {
        bool IsOn(string appSettingKeyForFeature);
        void TurnOn(string appSettingKeyForFeature);
        void TurnOff(string appSettingKeyForFeature);
    }
}
