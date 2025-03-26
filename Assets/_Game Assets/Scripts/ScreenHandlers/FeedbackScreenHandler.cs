using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_Assets.Scripts.ScreenHandlers
{
    public class FeedbackScreenHandler : ScreenHandlerBase
    {
        [SerializeField] private Sprite positive, negative;
        [SerializeField] private Image feedback;
        
        public override IEnumerator Show(float duration, bool wonLastMicrogame, int newHealth, int newScore)
        {
            screenParent.SetActive(true);
            
            feedback.sprite = wonLastMicrogame ? positive : negative;
            yield return new WaitForSeconds(duration);
            
            screenParent.SetActive(false);
        }
    }
}