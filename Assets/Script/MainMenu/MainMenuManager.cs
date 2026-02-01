using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenuManager : MonoBehaviour
{
    private Coroutine SceneCoroutine;
    [SerializeField] private Animator Redanimator;
    [SerializeField] private AnimationClip Redanim;

    void Awake()
    {
       if(Redanimator != null)
        Redanimator.enabled = false;
    }
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
    public void On_Click_LoadGameplay()
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
        if(Redanimator != null)
        {
            Redanimator.gameObject.SetActive(true);
            Redanimator.enabled = true;
            Redanimator?.Play(Redanim.name);
        }
        yield return new WaitForSeconds(Redanim.length);
    
        GameFlowManager.Instance.ChangeState(GameState.Playing);
        yield return null; // wait one frame
        SceneManager.LoadSceneAsync("Gameplay");
        Debug.Log("GamePlayLoaded");
    }
    public void On_Click_LoadMainmenu()
    {
        if (SceneCoroutine != null)
        {
            StopCoroutine(SceneCoroutine);
            SceneCoroutine = null;
        }
        SceneCoroutine = StartCoroutine(LoadMainmenuRoutine());
    }
    IEnumerator LoadMainmenuRoutine()
    {
        GameFlowManager.Instance.ChangeState(GameState.MainMenu);
        yield return null; // wait one frame
        SceneManager.LoadSceneAsync("Mainmenu");
        Debug.Log("LoadedAMinimenu");
    }
}
