using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource music1Source;
    public AudioSource music2Source;
    public AudioSource music3Source;

    private HealthController healthController; // Reference to HealthController script

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        music1Source.Play();
    }

    private void Update()
    {
        if (healthController != null)
        {
            float healthVolume = 1f - (healthController.currentHealth / 100f);
            music3Source.volume = Mathf.Clamp01(healthVolume);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainScene")
        {
            healthController = FindObjectOfType<HealthController>();
            SwitchToMainScene();
        }
        else
        {
            SwitchToAnotherScene();
        }
    }

    public void SwitchToMainScene()
    {
        music1Source.Stop();
        music2Source.Play();
        music3Source.Play();

    }

    public void SwitchToAnotherScene()
    {
        music2Source.Stop();
        music3Source.Stop();
        music1Source.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the event
    }
}
