using UnityEngine;
using System.Collections;

public class ScreamerController : MonoBehaviour
{
    [Header("Refs")]
    public AudioSource screamSound;
    public GameObject screamerImageUI;

    [Header("Sozlamalar")]
    public float screamerDuration = 0.4f; // rasm necha soniya ko'rinadi

    public void TriggerScreamer(int attemptCount)
    {
        StopAllCoroutines(); // bir vaqtda ikkita screamer chiqmasin
        StartCoroutine(ScreamerSequence(attemptCount));
    }

    IEnumerator ScreamerSequence(int attemptCount)
    {
        if (attemptCount == 1)
        {
            if (screamSound != null) screamSound.Play();
            yield break;
        }

        if (screamerImageUI != null) screamerImageUI.SetActive(true);
        if (screamSound != null) screamSound.Play();

        // Kichik "flash" effekti — rasm o'lchamini bir oz kattalashtirib chiqarish
        if (screamerImageUI != null)
        {
            screamerImageUI.transform.localScale = Vector3.one * 1.3f;
            yield return new WaitForSecondsRealtime(0.1f);
            screamerImageUI.transform.localScale = Vector3.one;
        }

        yield return new WaitForSecondsRealtime(screamerDuration - 0.1f);

        if (screamerImageUI != null) screamerImageUI.SetActive(false);
    }
}
