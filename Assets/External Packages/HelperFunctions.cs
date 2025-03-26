using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using R = System.Random;

//    ███╗   ███╗ █████╗ ██████╗ ███████╗    ██████╗ ██╗   ██╗
//    ████╗ ████║██╔══██╗██╔══██╗██╔════╝    ██╔══██╗╚██╗ ██╔╝
//    ██╔████╔██║███████║██║  ██║█████╗      ██████╔╝ ╚████╔╝ 
//    ██║╚██╔╝██║██╔══██║██║  ██║██╔══╝      ██╔══██╗  ╚██╔╝  
//    ██║ ╚═╝ ██║██║  ██║██████╔╝███████╗    ██████╔╝   ██║   
//    ╚═╝     ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝    ╚═════╝    ╚═╝   
//                                                        
//    ██╗   ██╗ ██████╗  █████╗ ██╗   ██╗    ████████╗ ██████╗
//    ╚██╗ ██╔╝██╔═══██╗██╔══██╗██║   ██║    ╚══██╔══╝██╔════╝
//    ╚████╔╝ ██║   ██║███████║██║   ██║       ██║   ██║     
//    ╚██╔╝  ██║   ██║██╔══██║╚██╗ ██╔╝       ██║   ██║     
//    ██║   ╚██████╔╝██║  ██║ ╚████╔╝        ██║   ╚██████╗
//    ╚═╝    ╚═════╝ ╚═╝  ╚═╝  ╚═══╝         ╚═╝    ╚═════╝
//
// You're welcome to change anything here and modify it for your personal use! Cheers!

namespace External_Packages
{
    public class HelperFunctions : MonoBehaviour
    {
        #region Unity Runtime Related

        private static PointerEventData eventDataCurrentPos;
        private static List<RaycastResult> results;

        /// <summary>
        /// Check if the mouse is over a UI element
        /// </summary>
        public static bool IsOverUI()
        {
            eventDataCurrentPos = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPos, results);
            return results.Count > 0;
        }
    
        private static Dictionary<float, WaitForSeconds> waitDictionary = new Dictionary<float, WaitForSeconds>();
        /// <summary>
        /// Returns a new WaitForSeconds if one has already been made, if not, creates new one
        /// </summary>
        /// <param name="time"></param>
        public static WaitForSeconds GetWait(float time)
        {
            if (waitDictionary.TryGetValue(time, out var wait)) return wait;

            waitDictionary[time] = new WaitForSeconds(time);
            return waitDictionary[time];
        }
    
        private static Dictionary<float, WaitForSecondsRealtime> waitDictionaryRT = new Dictionary<float, WaitForSecondsRealtime>();
        public static WaitForSecondsRealtime GetWaitRealTime(float time)
        {
            if (waitDictionaryRT.TryGetValue(time, out var wait)) return wait;

            waitDictionaryRT[time] = new WaitForSecondsRealtime(time);
            return waitDictionaryRT[time];
        }

        public static Transform GetRandomObject(List<Transform> list, Transform avoidedObject = null)
        {
            Transform randomObject = list[UnityEngine.Random.Range(0, list.Count)];

            if (avoidedObject != null && randomObject == avoidedObject)
            {
                return GetRandomObject(list, avoidedObject);
            }

            return randomObject;
        }

        #endregion

        #region Children Related

        /// <summary>
        /// Destroy all children under a given Transform parent, if tag given,
        /// only children with tag will be destroyed. If the destroyWithoutTag parameter is true,
        /// all children WITHOUT said tag will get destroyed
        /// </summary>
        /// <param name="parent"></param>
        public static void DestroyChildren(Transform parent)
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                Destroy(parent.GetChild(i).gameObject);
            }
        }
    
        public static void DestroyChildren(Transform parent, string tag, bool destroyWithoutTag = false)
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                GameObject child = parent.GetChild(i).gameObject;
                bool hasTag = child.CompareTag(tag);

                if ((!destroyWithoutTag && hasTag) || (destroyWithoutTag && !hasTag) || tag == "")
                {
                    Destroy(child);
                }
            }
        }

        /// <summary>
        /// Returns the first Transform child with a certain tag
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tag"></param>
        public static Transform GetFirstChildWithTag(Transform parent, string tag)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).CompareTag(tag)) return parent.GetChild(i);
            }

            return null;
        }
    
        /// <summary>
        /// Returns the first child with a certain component in a recursive manner
        /// </summary>
        /// <param name="parent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetFirstChildWithComponent<T>(Transform parent) where T : Component
        {
            Transform fittingChild = RecursiveFindChildWithComponent<T>(parent);
            return fittingChild != null ? fittingChild.GetComponent<T>() : null;
        }

        private static Transform RecursiveFindChildWithComponent<T>(Transform parent) where T : Component
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);

                if (child.GetComponent<T>() != null)
                {
                    return child;
                }

                if (child.childCount > 0)
                {
                    Transform found = RecursiveFindChildWithComponent<T>(child);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a List of Transform children from a parent
        /// </summary>
        /// <param name="parent"></param>
        public static List<Transform> GetChildren(Transform parent)
        {
            List<Transform> newList = new List<Transform>();
            for (int i = 0; i < parent.childCount; i++)
            {
                newList.Add(parent.GetChild(i));
            }

            return newList;
        }

        /// <summary>
        /// Returns a List of transform children with a certain tag from a List of Transform objects
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tag"></param>
        public static List<Transform> GetTransformsWithTag(List<Transform> list, string tag)
        {
            List<Transform> newList = new List<Transform>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTag(tag)) newList.Add(list[i]);
            }

            return newList;
        }
    
        /// <summary>
        /// Returns a List of transform children with a certain tag from a Transform parent
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="tag"></param>
        public static List<Transform> GetChildrenWithTag(Transform parent, string tag)
        {
            List<Transform> newList = new List<Transform>();
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).CompareTag(tag)) newList.Add(parent.GetChild(i));
            }

            return newList;
        }
    
        /// <summary>
        /// Returns a List of Transform objects with a certain component attached to them, from a List of Transform objects
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static List<Transform> GetTransformsWithComponent<T>(List<Transform> list) where T : Component
        {
            List<Transform> newList = new List<Transform>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetComponent<T>())
                {
                    newList.Add(list[i]);
                }
            }

            return newList;
        }
    
        /// <summary>
        /// Returns a List of Transform CHILD objects with a certain component attached to them, from a singular parent
        /// </summary>
        /// <param name="parent"></param>
        /// <typeparam name="T"></typeparam>
        public static List<Transform> GetChildrenWithComponent<T>(Transform parent) where T : Component
        {
            List<Transform> newList = new List<Transform>();
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).GetComponent<T>())
                {
                    newList.Add(parent.GetChild(i));
                }
            }

            return newList;
        }
        
        public static List<T> GetAllComponentsInChildren<T>(Transform parent, bool includeParent = true) where T : Component
        {
            List<T> components = new List<T>();

            if (includeParent)
            {
                FindComponentsRecursive(parent, components);
            }
            else
            {
                foreach (Transform child in parent)
                {
                    FindComponentsRecursive(child, components);
                }
            }

            return components;
        }

        private static void FindComponentsRecursive<T>(Transform current, List<T> result) where T : Component
        {
            T component = current.GetComponent<T>();
            if (component != null)
            {
                result.Add(component);
            }

            foreach (Transform child in current)
            {
                FindComponentsRecursive(child, result);
            }
        }

        #endregion
    
        #region Math & Time Related

        /// <summary>
        /// Converts 1 -> 1st
        /// 2 -> 2nd
        /// 3 -> 3rd
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertToOrdinal(int number)
        {
            if (number <= 0) return number.ToString();

            string suffix = "th";
            int lastTwoDigits = number % 100;
        
            if (lastTwoDigits < 11 || lastTwoDigits > 13)
            {
                switch (number % 10)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                }
            }

            return number + suffix;
        }

        /// <summary>
        /// Get a brand unique new ID
        /// </summary>
        public static string GetUUID()
        {
            Guid uuid = Guid.NewGuid();
            return uuid.ToString();
        }
    
        /// <summary>
        /// Get offset unix time stamp, if empty returns current
        /// </summary>
        /// <param name="hoursOffset"></param>
        public static long GetUnixTime(float hoursOffset = 0f)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            DateTimeOffset future = now.AddHours(hoursOffset);
            return future.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Returns a given Quaternion's reversed counterpart
        /// </summary>
        /// <param name="quaternion"></param>
        public static Quaternion ReverseQuaternion(Quaternion quaternion)
        {
            return new Quaternion(-quaternion.x, -quaternion.y, -quaternion.z, quaternion.w);
        }

        #endregion

        #region UI Related

        public static Color HexToColor(string hex)
        {
            if (hex.Length < 6)
            {
                Debug.LogError("Invalid hex string. It should be at least 6 characters long.");
                return Color.white; // Default to white in case of an error
            }

            if (hex[0] == '#')
            {
                hex = hex.Substring(1);
            }

            if (hex.Length != 6)
            {
                Debug.LogError("Invalid hex string. It should be exactly 6 characters long.");
                return Color.white; // Default to white in case of an error
            }

            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            return new Color32(r, g, b, 255);
        }

        #endregion
        
        /// <summary>
        /// Combines multiple enum flags into a single flag set.
        /// </summary>
        /// <typeparam name="T">An enum type with the [Flags] attribute.</typeparam>
        /// <param name="values">An array of enum values to combine.</param>
        /// <returns>A single enum value representing the combined flags.</returns>
        public static T GetCombinedFlags<T>(T[] values) where T : Enum
        {
            int result = 0;
            foreach (T value in values)
            {
                result |= Convert.ToInt32(value);
            }
            return (T)Enum.ToObject(typeof(T), result);
        }
    }
    
    public static class Random
    {
        public static int RandomIntSign()
        {
            return new R().Next(2) == 0 ? -1 : 1;
        }
        
        public static bool RandomBool()
        {
            return new R().Next(2) == 1;
        }
    }
}