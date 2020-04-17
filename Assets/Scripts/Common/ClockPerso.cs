using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common
{
    class ClockPerso
    {
        private float __gWaitSystem;
        public void tappedWaitForSecondsOrTap()
        {
            __gWaitSystem = 0.0f;
        }
        public IEnumerator WaitForSecondsOrTap(float seconds)
        {
            __gWaitSystem = seconds;
            while (__gWaitSystem>0.0 )
            {
                __gWaitSystem -= UnityEngine.Time.deltaTime;
                yield return __gWaitSystem;
            }
        }
    }
}
