using System.Collections;
using UnityEngine;

namespace _Game_Assets.Scripts.ScreenHandlers
{
    public abstract class ScreenHandlerBase : MonoBehaviour
    {
        [SerializeField] protected GameObject screenParent;
        public abstract IEnumerator Show(float duration, bool wonLastMicrogame, int newHealth, int newScore);

        public void Hide()
        {
            if (this != null)
            {
                StopAllCoroutines();
                screenParent.SetActive(false);
            }
        }
    }
}