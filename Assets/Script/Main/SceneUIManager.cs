using UnityEngine;

public class SceneUIManager : MonoBehaviour
{
    [Header("Main Menu Panel")]
    [SerializeField] private UIPanel mainMenuPanel;
    [SerializeField] private UIPanel CollectionPanel;
    [Header("Game Play Panel")]
    [SerializeField] private UIPanel Round1Panel;
    [SerializeField] private UIPanel Round2Panel;

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
       //HandleState(GameFlowManager.Instance.CurrentState);
    }

    private void HandleState(GameState state)
    {
        mainMenuPanel?.Hide();
        Round1Panel?.Hide();
        Round2Panel?.Hide();
        pausePanel?.Hide();
        gameOverPanel?.Hide();
        CollectionPanel?.Hide();


        switch (state)
        {
            case GameState.MainMenu:
                mainMenuPanel?.Show();
                break;

            case GameState.Playing:
                Round1Panel?.Show();
                break;

            case GameState.Paused:
                Round1Panel?.Show();
                pausePanel?.Show();
                break;

            case GameState.GameOver:
                gameOverPanel?.Show();
                break;
            case GameState.collection:
                CollectionPanel?.Show();
                break;
            case GameState.Round1Panel:
                Round1Panel?.Show();
                break;
            case GameState.Round2Panel:
                Round2Panel?.Show();
                break;
            default:
                break;
        }
    }
    // Shortcuts
    public void Pause() => GameFlowManager.Instance.ChangeState(GameState.Paused);
    public void Playing() => GameFlowManager.Instance.ChangeState(GameState.Playing);
    public void GameOver() => GameFlowManager.Instance.ChangeState(GameState.GameOver);
    public void MainMenu() => GameFlowManager.Instance.ChangeState(GameState.MainMenu);
    public void Collection() => GameFlowManager.Instance.ChangeState(GameState.collection);
    public void Round1() => GameFlowManager.Instance.ChangeState(GameState.Round1Panel);
    public void Round2() => GameFlowManager.Instance.ChangeState(GameState.Round2Panel);
}
