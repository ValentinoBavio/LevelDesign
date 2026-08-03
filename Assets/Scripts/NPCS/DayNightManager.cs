using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance;

    [Header("Lights")]
    public Light dayLight;
    public Light nightLight;
    public Material daySkybox;
    public Material nightSkybox;

    [Header("NPCs")]
    public GameObject[] dayNPCs;
    public GameObject[] nightNPCs;

    [Header("Transition")]
    public Image fadeImage;
    public TMP_Text transitionText;

    public float fadeTime = 1f;
    public float blackScreenTime = 2f;

    [Header("Cycle")]
    public float minutesPerCycle = 5f;

    private bool isDay = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetDay();
        SetAlpha(0);

        StartCoroutine(TimeCycle());
    }

    IEnumerator TimeCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(minutesPerCycle * 60f);

            yield return ChangeRoutine();
        }
    }

    IEnumerator ChangeRoutine()
    {
        transitionText.text = "Cambio de horario";

        yield return Fade(1);

        if (isDay)
            SetNight();
        else
            SetDay();

        yield return new WaitForSeconds(blackScreenTime);

        yield return Fade(0);
    }

    void SetDay()
    {
        isDay = true;

        dayLight.enabled = true;
        nightLight.enabled = false;

        RenderSettings.skybox = daySkybox;
        DynamicGI.UpdateEnvironment();

        RenderSettings.fog = false;

        foreach (GameObject npc in dayNPCs)
            npc.SetActive(true);

        foreach (GameObject npc in nightNPCs)
            npc.SetActive(false);
    }

    void SetNight()
    {
        isDay = false;

        dayLight.enabled = false;
        nightLight.enabled = true;

        RenderSettings.skybox = nightSkybox;
        DynamicGI.UpdateEnvironment();

        RenderSettings.fog = true;

        foreach (GameObject npc in dayNPCs)
            npc.SetActive(false);

        foreach (GameObject npc in nightNPCs)
            npc.SetActive(true);
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
        Color c = fadeImage.color;
        c.a = alpha;
        fadeImage.color = c;

        Color tc = transitionText.color;
        tc.a = alpha;
        transitionText.color = tc;
    }
}