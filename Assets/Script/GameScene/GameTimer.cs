using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f;   // Total time in seconds
    private float currentTime;

    public TextMeshProUGUI timerText;
    private Coroutine SceneCoroutine;
    public GameObject gameOverPanel;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            currentTime = 0;
            GameOver();
        }
    }

    void UpdateTimerUI()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = "Time : " + seconds;
    }

    void GameOver()
    {
       // Debug.Log("Game Over");

        // Stop the game
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

       StartCoroutine( On_Click_LoadMainmenu());


        // Show Game Over panel here
        // gameOverPanel.SetActive(true);
    }
    public  IEnumerator On_Click_LoadMainmenu()
    {
        Debug.Log("Start scene switching");
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("First case1");
        GameFlowManager.Instance.ChangeState(GameState.MainMenu);
        Debug.Log("second case");
       // yield return null; // wait one frame
        SceneManager.LoadSceneAsync("SampleScene");
        Debug.Log("mainmenuLoaded");
    }  
}
