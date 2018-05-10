using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour {
    [SerializeField]
    private CanvasGroup faderCanvasGroup;
    public bool isFading
    {
        private set;
        get;
    }

    public IEnumerator Fade(float finalAlpha, float fadeDuration, bool blockRaycast = true)
    {
        isFading = true;
        faderCanvasGroup.blocksRaycasts = blockRaycast;
        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha,
                fadeSpeed * Time.deltaTime);

            yield return null;
        }
        isFading = false;
    }
}
