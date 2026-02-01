using UnityEngine;

public class DragManager : MonoBehaviour
{
    [Header("Drag Settings")]
    public float snapDistance = 2.0f;
    public float dragZ = 0f;
    public bool useOffset = true;

    [Header("ASMR Audio")]
    public AudioSource audioSource;   // ONE AudioSource
    public AudioClip snapClip;
    [Range(0f, 1f)]
    public float snapVolume = 0.3f;

    public static DragManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlaySnapSound()
    {
        if (audioSource == null) return;
        if (snapClip == null) return;

        audioSource.PlayOneShot(snapClip, snapVolume);
    }
}
