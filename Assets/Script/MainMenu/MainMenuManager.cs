using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenuManager : MonoBehaviour
{
    private Coroutine SceneCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneChanging(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void On_Click_LoadMainmenu()
    {
        if (SceneCoroutine != null)
        {
            StopCoroutine(SceneCoroutine);
            SceneCoroutine = null;
        }
        SceneCoroutine = StartCoroutine(LoadGameplayRoutine());
    }
    IEnumerator LoadGameplayRoutine()
    {
        GameFlowManager.Instance.ChangeState(GameState.Playing);
        yield return null; // wait one frame
        SceneManager.LoadSceneAsync("Gameplay");
        Debug.Log("mainmenuLoaded");
    }
}
