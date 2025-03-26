using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Game_Assets.Scripts.ScreenHandlers
{
    public class HealthScreenHandler : ScreenHandlerBase
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private List<Image> hearts;
        
        [SerializeField] private int lastKnownHealth;

        public override IEnumerator Show(float duration, bool wonLastMicrogame, int newHealth, int newScore)
        {
            screenParent.SetActive(true);

            gridLayoutGroup.enabled = true;
            gridLayoutGroup.startCorner = gridLayoutGroup.transform.childCount % 2 == 0 ? GridLayoutGroup.Corner.UpperLeft : GridLayoutGroup.Corner.UpperRight;
            
            if (lastKnownHealth != newHealth && !wonLastMicrogame)
            {
                lastKnownHealth = newHealth;
                var heart = hearts[0];
                hearts.RemoveAt(0);

                yield return new WaitForSeconds(1f);
                
                heart.transform.DOPunchScale(Vector3.one, 0.2f).OnComplete(() =>
                {
                    Destroy(heart.gameObject);
                });
            }
            
            yield return new WaitForSeconds(.1f);
            
            gridLayoutGroup.enabled = false;
            
            if (duration > 0)
            {
                yield return new WaitForSeconds(duration);
                screenParent.SetActive(false);
            }
        }
    }
}