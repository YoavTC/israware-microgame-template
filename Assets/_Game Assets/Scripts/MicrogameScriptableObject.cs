using System;
using UnityEngine;

namespace _Game_Assets.Scripts
{
    [CreateAssetMenu(menuName = "New Microgame Asset", fileName = "Microgame Asset")]
    public class MicrogameScriptableObject : ScriptableObject
    {
        [Header("Meta")]
        public string id;
        public string ENGLISH_PROMPT;
        public string HEBREW_PROMPT;
        
        public bool hideCursor;

        public int positiveFeedbacksToWin;
        public int negativeFeedbacksToLose;
        public float maxMicrogameTime;
        public bool winAtTimerFinish;

        public MicrogameSettingsStruct GetSettings()
        {
            return new MicrogameSettingsStruct(positiveFeedbacksToWin, negativeFeedbacksToLose, maxMicrogameTime, winAtTimerFinish, hideCursor);
        }
    }

    [Serializable]
    public struct MicrogameSettingsStruct
    {
        public int positiveFeedbacksToWin;
        public int negativeFeedbacksToLose;
        public float maxMicrogameTime;
        public bool winAtTimerFinish;
        public bool hideCursor;

        public MicrogameSettingsStruct(int positiveFeedbacksToWin, int negativeFeedbacksToLose, float maxMicrogameTime, bool winAtTimerFinish, bool hideCursor)
        {
            this.positiveFeedbacksToWin = positiveFeedbacksToWin;
            this.negativeFeedbacksToLose = negativeFeedbacksToLose;
            this.maxMicrogameTime = maxMicrogameTime;
            this.winAtTimerFinish = winAtTimerFinish;
            this.hideCursor = hideCursor;
        }
    }

    public enum MicrogameFinishType
    {
        MANUAL,
        FAIL, 
        TIME,
    }
}