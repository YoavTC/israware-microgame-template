using DG.Tweening;
using UnityEngine;

namespace External_Packages.Extra_Components
{
    public class TweenScaleEffect : MonoBehaviour
    {
        [SerializeField] private float scaleFactor;
        [SerializeField] private float duration;
        [SerializeField] private int vibrato;
        [SerializeField] private float strength;
        [SerializeField] private bool loop;
        [SerializeField] private LoopType loopType;
        [SerializeField] private bool ignoreTimeScale;

        public void DoEffect()
        {
            if (transform != null)
            {
                transform.DOKill(true);
                transform.DOPunchScale(transform.localScale * scaleFactor, duration, vibrato, strength)
                    .SetLoops(loop ? -1 : 0, loopType)
                    .SetUpdate(ignoreTimeScale);
            }
        }
    }
}