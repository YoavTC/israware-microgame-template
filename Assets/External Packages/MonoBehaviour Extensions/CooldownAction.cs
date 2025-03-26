using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace External_Packages.MonoBehaviour_Extensions
{
    /// <summary>
    /// Inherit this class and set a <see cref="ActionCooldown"/>,
    /// to execute the <see cref="ExecuteAction"/> method every <see cref="ActionCooldown"/> seconds
    /// </summary>
    public abstract class CooldownAction : MonoBehaviour 
    {
        [ShowNativeProperty] protected bool ActionEnabled { get; set; }
        [ShowNativeProperty] protected float ActionCooldown { get; set; } = -1f;
        private float ElapsedTime { get; set; }
        
        protected virtual void Update()
        {
            TickAction();
        }

        private void TickAction()
        {
            if (!ActionEnabled || ActionCooldown < 0f) return;
        
            ElapsedTime += Time.deltaTime;
            if (ElapsedTime >= ActionCooldown) 
            {
                ElapsedTime = 0f;
                ExecuteAction();
            }
        }
    
        /// <summary>
        /// Called every <see cref="ActionCooldown"/> seconds
        /// </summary>
        protected abstract void ExecuteAction();
    }

    public abstract class CooldownActionWithEvent : CooldownAction
    {
        public UnityEvent ActionExecutedUnityEvent;
        protected override void ExecuteAction()
        {
            ActionExecutedUnityEvent?.Invoke();
        }
    }
}