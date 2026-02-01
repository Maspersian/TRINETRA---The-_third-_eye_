using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHeads : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int pieceID;

    private RectTransform rect;
    private Canvas canvas;
    private Vector3 startPos;
    private static bool gameFinished = false;

    private HeadSnapPoint snapPoint;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        startPos = rect.position;
    }

    void Start()
    {
        snapPoint = FindObjectOfType<HeadSnapPoint>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameFinished) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameFinished) return;

        Vector3 worldPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            rect,
            eventData.position,
            eventData.pressEventCamera,
            out worldPos
        );

        rect.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameFinished) return;

        TrySnap();
    }

    void TrySnap()
    {
        float dist = Vector2.Distance(rect.position, snapPoint.transform.position);

        // ❌ Wrong head OR too far
        if (pieceID != snapPoint.correctBodyID || dist > DragManager.Instance.snapDistance)
        {
            rect.position = startPos;
            return;
        }

        // ✅ Correct head
        rect.position = snapPoint.transform.position;
        gameFinished = true;

        DragManager.Instance.PlaySnapSound();
        FinishGame();
    }

    void FinishGame()
    {
        Debug.Log("GAME FINISHED 🎉");
        StartigScript.instance.timer.SetActive(false);
        StartigScript.instance.descriptionPanal.SetActive(true);


        // Optional:
        // StartigScript.instance.animator.enabled = true;
        // Show win panel
        // Disable other UI
    }
    public IEnumerator WinnerDelay()
    {
        yield return new WaitForSecondsRealtime(4f);
        StartigScript.instance.winnerPanel.SetActive(true);

    }
}
