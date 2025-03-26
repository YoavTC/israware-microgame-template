using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Game_Assets.Scripts
{
    public class MicrogameInstance : MonoBehaviour
    {
        // private GameManager gameManager;
        [SerializeField, ReadOnly] private MicrogameScriptableObject microgame;

        [SerializeField, ReadOnly] private MicrogameSettingsStruct microgameSettings;
        private int negativeFeedbacksCount;
        private int positiveFeedbacksCount;

        [SerializeField] private float winFinishDelay;
        [SerializeField] private float LoseFinishDelay;

        private Timer timer;
        
        
        private void Start()
        {
            // gameManager = GameManager.Instance;
            
            // if (gameManager != null)
            // {
            //     Debug.Log("Manager is not null using it..");
            //     microgame = gameManager.CurrentMicrogame;
            // } else 
            
            LoadMicrogameScriptableObject();
            
            Cursor.visible = !microgameSettings.hideCursor;
            microgameSettings = microgame.GetSettings();
            
            timer = FindFirstObjectByType<Timer>();
            timer.OnMicrogameLoaded(microgame);
        }
        
        public void Feedback(bool positive)
        {
            Debug.Log($"Received {(positive ? "positive" : "negative")} feedback");
            if (positive) positiveFeedbacksCount++;
            else negativeFeedbacksCount++;

            // if (gameManager == null) return;
            if (microgameSettings.positiveFeedbacksToWin > 0 && positiveFeedbacksCount >= microgameSettings.positiveFeedbacksToWin)
            {
                StartCoroutine(Finish(true));
            }

            if (microgameSettings.negativeFeedbacksToLose > 0 && negativeFeedbacksCount >= microgameSettings.negativeFeedbacksToLose)
            {
                StartCoroutine(Finish(false));
            }
        }

        private IEnumerator Finish(bool win = false)
        {
            Debug.Log("Microgame finished!");
            // gameManager.Timer?.DisableTimer();
            timer.DisableTimer();

            yield return new WaitForSeconds(win ? winFinishDelay : LoseFinishDelay);
            Debug.Log("Exiting scene..");
            // gameManager?.StartCoroutine(gameManager.OnMicrogameFinished(win));
        }

        private void LoadMicrogameScriptableObject()
        {
            microgame = Resources.Load<MicrogameScriptableObject>($"Microgames/{SceneManager.GetActiveScene().name}");
            microgameSettings = microgame.GetSettings();
        }
        
        #if UNITY_EDITOR
        [Button]
        public void ValidateSettings()
        {
            LoadMicrogameScriptableObject();
        }
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.R))
            {
                EditorSceneManager.LoadSceneInPlayMode(SceneManager.GetActiveScene().path, new LoadSceneParameters(LoadSceneMode.Single));
            }
        }
        #endif
    }
}