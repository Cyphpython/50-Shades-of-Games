using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditorInternal;
using Fungus;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [Header("Fade Settings")]
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private Color fadeColor = Color.black;

    [Header("Player")]
    [SerializeField] private GameObject Player;

    private string pendingSpawnID;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (fadeImage != null)
        {
            fadeColor.a = 0f;
            fadeImage.color = fadeColor;
        }
    }


    public void LoadScene(string sceneName, string spawnID = null)
    {
        pendingSpawnID = spawnID;
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        yield return StartCoroutine(FadeOut());

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if (!string.IsNullOrEmpty(pendingSpawnID))
        {
            SpawnPoint[] points = Object.FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);
            foreach (var point in points)
            {
                if (point.spawnID == pendingSpawnID)
                {
                    if (Player != null)
                    {
                        Player.transform.position = point.transform.position;
                        break;
                    }
                }
            }
        }
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        if (fadeImage == null) yield break;

        fadeColor.a = 0f;
        fadeImage.color = fadeColor;
        fadeImage.raycastTarget = true;

        while (fadeImage.color.a < 1)
        {
            fadeColor.a += Time.deltaTime * fadeSpeed;
            fadeImage.color = fadeColor;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        if (fadeImage == null) yield break;

        while (fadeImage.color.a > 0f)
        {
            fadeColor.a -= Time.deltaTime * fadeSpeed;
            fadeImage.color = fadeColor;
            yield return null;
        }
        fadeImage.raycastTarget = false;
    }
}
