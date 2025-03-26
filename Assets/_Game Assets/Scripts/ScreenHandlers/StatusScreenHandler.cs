using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game_Assets.Scripts.ScreenHandlers 
{
    public class StatusScreenHandler : ScreenHandlerBase
    {
        [SerializeField] private TMP_Text levelDisplay;
        
        public override IEnumerator Show(float duration, bool wonLastMicrogame, int newHealth, int newScore)
        {
            screenParent.SetActive(true);
            if (wonLastMicrogame)
            {
                yield return new WaitForSeconds(0.5f);
                
                levelDisplay.text = newScore.ToString();
                levelDisplay.transform.DOPunchScale(Vector3.one, 0.2f);
            }

            if (duration > 0)
            {
                yield return new WaitForSeconds(duration);
                screenParent.SetActive(false);
            }
        }
    }
}