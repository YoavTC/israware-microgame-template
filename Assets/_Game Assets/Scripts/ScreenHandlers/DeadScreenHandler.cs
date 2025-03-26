using System.Collections;
using UnityEngine;

namespace _Game_Assets.Scripts.ScreenHandlers
{
    public class DeadScreenHandler : ScreenHandlerBase
    {
        public override IEnumerator Show(float duration, bool wonLastMicrogame, int newHealth, int newScore)
        {
            screenParent.SetActive(true);

            if (duration > 0)
            {
                yield return new WaitForSeconds(duration);
                screenParent.SetActive(false);
            }
        }
    }
}