using System.Collections.Generic;
using UnityEngine;


public class StepManager : MonoBehaviour
{
    public static StepManager Instance;

    public int currentStep = 0;

    [Header("Objetivos")]
    public List<Transform> stepTargets;

    [SerializeField] private GameObject objectiveLightPrefab;
    [SerializeField] private float heightOffset = 2f;

    private GameObject currentLight;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        currentLight = Instantiate(objectiveLightPrefab);

        UpdateObjectiveLight();
    }

    private void UpdateObjectiveLight()
    {
        Transform target = GetCurrentTarget();

        if (target == null)
        {
            currentLight.SetActive(false);
            return;
        }

        currentLight.SetActive(true);
        currentLight.transform.position = target.position + Vector3.up * heightOffset;
    }

    public bool IsCurrentStep(int step)
    {
        return currentStep == step;
    }

    public void CompleteStep(int step)
    {
        if (currentStep != step)
            return;
        Debug.Log("Paso actual: " + currentStep);

        currentStep++;
        UpdateObjectiveLight();
    }

    public Transform GetCurrentTarget()
    {
        if (currentStep >= stepTargets.Count)
            return null;

        return stepTargets[currentStep];
    }
}
