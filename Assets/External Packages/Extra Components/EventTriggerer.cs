using System;
using UnityEngine;
using UnityEngine.Events;

namespace External_Packages.Extra_Components
{
    public class EventTriggerer : MonoBehaviour
    {
        [SerializeField] private TriggerType type = TriggerType.MANUAL;
    
        [SerializeField] private CollisionTriggerDimensionsFilter dimensionsFilter;
        [SerializeField] private string tagFilter = "";
        [SerializeField] private string layerFilter = "";

        #region Event Triggering
        public void TriggerManually() => InvokeEvent(TriggerType.MANUAL);
    
        private void Awake() => InvokeEvent(TriggerType.AWAKE);
        private void Start() => InvokeEvent(TriggerType.START);
    
        private void OnEnable() => InvokeEvent(TriggerType.ON_ENABLE);
        private void OnDisable() => InvokeEvent(TriggerType.ON_DISABLE);

        #region Collision
        private void OnCollisionEnter(Collision other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.THREE || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_COLLISION_ENTER, other.gameObject);
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.THREE || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_COLLISION_EXIT, other.gameObject);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.TWO || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_COLLISION_ENTER, other.gameObject);
                }
            }
        }
    
        private void OnCollisionExit2D(Collision2D other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.TWO || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_COLLISION_EXIT, other.gameObject);
                }
            }
        }
        #endregion

        #region Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.THREE || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_TRIGGER_ENTER, other.gameObject);
                }
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.THREE || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_TRIGGER_EXIT, other.gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.TWO || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_TRIGGER_ENTER, other.gameObject);
                }
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (dimensionsFilter == CollisionTriggerDimensionsFilter.TWO || dimensionsFilter == CollisionTriggerDimensionsFilter.BOTH)
            {
                if ((String.IsNullOrEmpty(tagFilter) || other.gameObject.CompareTag(tagFilter)) &&
                    (String.IsNullOrEmpty(layerFilter) || other.gameObject.layer == LayerMask.GetMask(layerFilter)))
                {
                    InvokeEvent(TriggerType.ON_TRIGGER_EXIT, other.gameObject);
                }
            }
        }
        #endregion
    
        #endregion

        private void InvokeEvent(TriggerType triggerType) => InvokeEvent(triggerType, gameObject);
        private void InvokeEvent(TriggerType triggerType, GameObject data)
        {
            if (triggerType == type) Event?.Invoke(data);
        }
    
        public UnityEvent<GameObject> Event;
    }

    enum TriggerType
    {
        MANUAL,
        
        AWAKE,
        START,
        ON_ENABLE,
        ON_DISABLE,
        
        ON_COLLISION_ENTER,
        ON_COLLISION_EXIT,
        ON_TRIGGER_ENTER,
        ON_TRIGGER_EXIT,
    }

    enum CollisionTriggerDimensionsFilter
    {
        TWO,
        THREE,
        BOTH
    }
}