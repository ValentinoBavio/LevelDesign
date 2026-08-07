using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Monster : MonoBehaviour
{
    public Torch torch;

    [Header("Player")]
    public Transform player;
    public Transform safePoint;

    [Header("Monster")]
    public float killTime = 60f;

    [Header("Death Fade")]
    public Image fadeImage;
    public TMP_Text fadeText;
    public float fadeTime = 1f;

    private float timer;
    private bool playerKilled = false;

    private void Start()
    {
        SetAlpha(0);
    }

    void Update()
    {
        if (playerKilled)
            return;

        if (!DayNightManager.Instance.IsNight())
        {
            timer = 0;
            return;
        }

        if (!TownArea.Instance.isOutsideTown)
        {
            timer = 0;
            return;
        }

        if (torch.torchEquipped)
        {
            timer = 0;
            return;
        }

        timer += Time.deltaTime;

        if (timer >= killTime)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        playerKilled = true;

        StartCoroutine(TeleportPlayer());
    }

    IEnumerator TeleportPlayer()
    {        
        yield return Fade(1);

        player.position = safePoint.position;
        player.rotation = safePoint.rotation;

        yield return new WaitForSeconds(1f);

        yield return Fade(0);

        timer = 0;
        playerKilled = false;
    }

    IEnumerator Fade(float target)
    {
        float start = fadeImage.color.a;
        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            float alpha = Mathf.Lerp(start, target, t / fadeTime);

            SetAlpha(alpha);

            yield return null;
        }

        SetAlpha(target);
    }

    void SetAlpha(float alpha)
    {
        Color imageColor = fadeImage.color;
        imageColor.a = alpha;
        fadeImage.color = imageColor;

        Color textColor = fadeText.color;
        textColor.a = alpha;
        fadeText.color = textColor;
    }
}