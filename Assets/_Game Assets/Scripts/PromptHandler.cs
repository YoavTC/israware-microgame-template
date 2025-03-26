using System;
using DG.Tweening;
using External_Packages.Extra_Components;
using External_Packages.MonoBehaviour_Extensions;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace _Game_Assets.Scripts
{
    public enum Language
    {
        ENGLISH, HEBREW
    }
    
    public class PromptHandler : Singleton<PromptHandler>
    {
        [SerializeField] private Language language;
        
        [Header("Settings")]
        [SerializeField] private float defaultPromptDuration;
        [SerializeField] private Vector2 inOutFadeDuration;
        [SerializeField] private TMP_Text promptDisplay;
        [SerializeField] private TweenScaleEffect tweenScaleEffect;

        [Button] public void T() => ShowPrompt("Lorem Ipsum");
        [Button] public void TT() => ShowPrompt("Lorem Ipsum", Color.red);

        private void Start()
        {
            UpdateLanguagePreference(language);
        }
        
        public void UpdateLanguagePreference(Language newLanguage)
        {
            promptDisplay.isRightToLeftText = (newLanguage == Language.HEBREW);
            language = newLanguage;
        }

        public void ShowPrompt(MicrogameScriptableObject microgame)
        {
            ShowPrompt((language == Language.ENGLISH) ? microgame.ENGLISH_PROMPT : microgame.HEBREW_PROMPT);
        }
        
        private void ShowPrompt(string text) => ShowPrompt(text, Color.white);
        private void ShowPrompt(string text, Color color)
        {
            promptDisplay.color = color;
            promptDisplay.text = text;
            promptDisplay.alpha = 0f;
            promptDisplay.enabled = true;

            promptDisplay.DOFade(1f, inOutFadeDuration.x);
            
            tweenScaleEffect.DoEffect();

            promptDisplay.DOFade(0f, inOutFadeDuration.y).SetDelay(defaultPromptDuration).OnComplete(HidePrompt);
        }

        private void HidePrompt()
        {
            promptDisplay.enabled = false;
            promptDisplay.text = String.Empty;
            promptDisplay.alpha = 1f;
            promptDisplay.transform.localScale = Vector3.one;
        }

        public void KillPrompt()
        {
            Debug.Log("Hiding prompt");
            tweenScaleEffect.DOKill(true);
            promptDisplay.DOKill(true);
            HidePrompt();
        }
    }
}