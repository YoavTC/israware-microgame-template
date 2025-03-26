using UnityEngine;

namespace External_Packages.MonoBehaviour_Extensions
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();

                    // if (_instance == null)
                    // {
                    //     GameObject singletonObject = new GameObject(typeof(T).Name);
                    //     _instance = singletonObject.AddComponent<T>();
                    // }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                // If an instance already exists, destroy this new instance
                Destroy(gameObject);
                return;
            }

            // This is the first instance or the assigned instance, don't destroy it on scene load
            _instance = this as T;
            //DontDestroyOnLoad(gameObject);
        }
    }
}