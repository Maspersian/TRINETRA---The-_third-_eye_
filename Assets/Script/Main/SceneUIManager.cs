using UnityEngine;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField] private UIPanel mainMenuPanel;
    [SerializeField] private UIPanel gameplayPanel;
    [SerializeField] private UIPanel pausePanel;
    [SerializeField] private UIPanel gameOverPanel;

    private void OnEnable()
    {
        GameFlowManager.OnGameStateChanged += HandleState;
    }

    private void OnDisable()
    {
        GameFlowManager.OnGameStateChanged -= HandleState;
    }

    private void Start()
    {
        // 🔥 Sync UI immediately after scene load
        HandleState(GameFlowManager.Instance.CurrentState);
    }

    private void HandleState(GameState state)
    {
        mainMenuPanel?.Hide();
        gameplayPanel?.Hide();
        pausePanel?.Hide();
        gameOverPanel?.Hide();

        switch (state)
        {
            case GameState.MainMenu:
                mainMenuPanel?.Show();
                break;

            case GameState.Playing:
                gameplayPanel?.Show();
                break;

            case GameState.Paused:
                gameplayPanel?.Show();
                pausePanel?.Show();
                break;

            case GameState.GameOver:
                gameOverPanel?.Show();
                break;
        }
    }
    // Shortcuts
    public void Pause() => GameFlowManager.Instance.ChangeState(GameState.Paused);
    public void Playing() =>  GameFlowManager.Instance.ChangeState(GameState.Playing);
    public void GameOver() =>  GameFlowManager.Instance.ChangeState(GameState.GameOver);
    public void MainMenu() =>  GameFlowManager.Instance.ChangeState(GameState.MainMenu);
}
