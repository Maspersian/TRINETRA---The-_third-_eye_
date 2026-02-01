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
        StartFade(0f, false);
    }

    private void StartFade(float targetAlpha, bool interactable)
    {
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
