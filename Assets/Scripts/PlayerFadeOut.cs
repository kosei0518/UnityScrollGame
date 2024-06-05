using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFadeOut : MonoBehaviour
{
    public float fadeDuration = 0.01f; // フェードアウトの時間（秒）
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


    }
    public void FadeOutPlayer()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        float startAlpha = spriteRenderer.color.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = spriteRenderer.color;
            tmpColor.a = Mathf.Lerp(startAlpha, 0, progress);
            spriteRenderer.color = tmpColor;

            progress += rate * Time.deltaTime;
            yield return null;
        }

        // 最後に完全に透明にする
        Color finalColor = spriteRenderer.color;
        finalColor.a = 0;
        spriteRenderer.color = finalColor;
    }
}
