using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class UIPanel : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 0.5f;

    private CanvasGroup canvasGroup;
    private Coroutine fadeRoutine;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        StartFade(1f, true);
    }

    public void Hide()
    {
        // Only start fade if the GameObject is active
        if (gameObject.activeInHierarchy)
        {
            StartFade(0f, false);
        }
        else
        {
            // If already inactive, just ensure it stays inactive
            gameObject.SetActive(false);
        }
    }

    private void StartFade(float targetAlpha, bool interactable)
    {
        // Ensure GameObject is active before starting coroutine
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }

        if (fadeRoutine != null)
            StopCoroutine(fadeRoutine);

        fadeRoutine = StartCoroutine(FadeRoutine(targetAlpha, interactable));
    }

    private IEnumerator FadeRoutine(float targetAlpha, bool interactable)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            Debug.Log("fadeRoutine");
            time += Time.unscaledDeltaTime; // 🔥 works when paused
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        canvasGroup.interactable = interactable;
        canvasGroup.blocksRaycasts = interactable;
        if(!interactable)
        gameObject.SetActive(interactable);
    }
}
