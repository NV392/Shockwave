using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public enum GameState { Menu, Playing, GameOver }
    public GameState CurrentState { get; private set; }

    public bool gameIsRunning = false;

    private void Awake() {
        Time.timeScale = 0f;
        gameIsRunning = false;

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame() {
        CurrentState = GameState.Playing;
        UIManager.Instance.StartGameUI();

        Time.timeScale = 1f;
        gameIsRunning = true;
    }

    public void RestartGame() {
        UIManager.Instance.ShowStartMenu();
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver() {
        Time.timeScale = 0f;
        gameIsRunning = false;

        CurrentState = GameState.GameOver;
        
        UIManager.Instance.ShowGameOver();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
