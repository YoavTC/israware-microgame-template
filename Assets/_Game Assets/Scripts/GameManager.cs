using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Game_Assets.Scripts.ScreenHandlers;
using AYellowpaper.SerializedCollections;
using External_Packages.MonoBehaviour_Extensions;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _Game_Assets.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Managers")]
        [SerializeField] private Timer timer;
        public Timer Timer => timer;
        
        [Header("Screens")] 
        [SerializeField] private float defaultShowScreenDuration;
        [SerializeField] private SerializedDictionary<ScreenType, ScreenHandlerBase> screenHandlersDictionary;

        [Header("Game Variables")]
        [SerializeField] private bool gameActive;
        [SerializeField] private int health;
        [SerializeField] private int score;
        [SerializeField] private bool lastMicrogameResult;

        [Header("Events")] 
        [SerializeField] private UnityEvent<bool> finishedMicrogameUnityEvent;
        [SerializeField] private UnityEvent<MicrogameScriptableObject> loadedMicrogameUnityEvent;

        // Microgames
        private List<MicrogameScriptableObject> microgames;
        [ShowNativeProperty] public MicrogameScriptableObject CurrentMicrogame { get; private set; }
        
        private void InitializeGameManager()
        {
            DontDestroyOnLoad(this);
            var loadedMicrogames = Resources.LoadAll<MicrogameScriptableObject>($"Microgames/")
                .Where(mg => !mg.name.Contains("~")) // Filter out filenames containing '~'
                .ToList();

            microgames = loadedMicrogames;
        }
        
        private void Start()
        {
            InitializeGameManager();
            StartCoroutine(LoadMicrogame());

            lastMicrogameResult = false;
            health = 5;
            score = 0;
        }
        
        private IEnumerator LoadMicrogame()
        {
            // Get random microgame
            MicrogameScriptableObject microgame = GetRandomMicrogame();
            CurrentMicrogame = microgame;
            
            // Start loading the microgame scene
            var loadSceneAsync = SceneManager.LoadSceneAsync(microgame.id);
            if (loadSceneAsync == null) yield break;
            loadSceneAsync.allowSceneActivation = false;
            
            // Hide the status overlay when the scene finishes loading
            loadSceneAsync.completed += operation =>
            {
                HideScreen(ScreenType.HEALTH);
                HideScreen(ScreenType.STATUS);
            }; 

            StartCoroutine(ShowScreen(ScreenType.STATUS, -1f));
            
                
            // When the screen is finished animating, wait until the scene is fully loaded
            yield return new WaitUntil(() => loadSceneAsync.progress >= 0.9f);
            yield return new WaitForSeconds(defaultShowScreenDuration);
            
            PromptHandler.Instance.ShowPrompt(microgame);
            
            // Activate the scene
            gameActive = true;
            loadSceneAsync.allowSceneActivation = true;
            
            loadedMicrogameUnityEvent?.Invoke(microgame);
        }

        public void OnTimerFinished(bool win) => StartCoroutine(OnMicrogameFinished(win));
        public IEnumerator OnMicrogameFinished(bool win)
        {
            if (!gameActive) yield break;
            
            finishedMicrogameUnityEvent?.Invoke(win);

            gameActive = false;
            lastMicrogameResult = win;
            
            if (win) score++;
            bool dead = UpdateHealth(win);

            // Show the feedback overlay
            StartCoroutine(ShowScreen(ScreenType.HEALTH, -1f));
            yield return StartCoroutine(ShowScreen(win ? ScreenType.POSITIVE : ScreenType.NEGATIVE, defaultShowScreenDuration));

            if (dead)
            {
                StartCoroutine(ShowScreen(ScreenType.GAME_OVER, -1f));
            }
            else
            {
                StartCoroutine(LoadMicrogame());
            }
        }

        private bool UpdateHealth(bool win)
        {
            health += win ? 0 : -1;
            return health <= 0;
        }
        
        private MicrogameScriptableObject GetRandomMicrogame()
        {
            return microgames[Random.Range(0, microgames.Count)];
        }

        private IEnumerator ShowScreen(ScreenType screenType, float duration)
        {
            yield return StartCoroutine(screenHandlersDictionary[screenType].Show(duration, lastMicrogameResult, health, score));
        }

        private void HideScreen(ScreenType screenType)
        {
            screenHandlersDictionary[screenType]?.Hide();
        }
    }
}
