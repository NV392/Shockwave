using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;

    public HUDController hudController;

    public GameObject startMenu;
    public GameObject optionsMenu;
    public GameObject gameOverMenu;
    public GameObject inGameHUD;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowOptions() {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ShowStartMenu() {
        startMenu.SetActive(true);
        optionsMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void ShowGameOver() {
        inGameHUD.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void StartGameUI() {
        startMenu.SetActive(false);
        inGameHUD.SetActive(true);
    }
}
