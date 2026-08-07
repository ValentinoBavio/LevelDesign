using UnityEngine;

public class StepObjectActivator : MonoBehaviour
{
    [System.Serializable]
    public class StepObject
    {
        public int requiredStep;

        public bool activate;

        public GameObject[] objects;
    }

    [SerializeField] private StepObject[] stepObjects;

    private int lastStep = -1;

    private void Start()
    {
        UpdateObjects();
    }

    private void Update()
    {
        int currentStep = StepManager.Instance.currentStep;

        if (currentStep == lastStep)
            return;

        lastStep = currentStep;

        UpdateObjects();
    }

    private void UpdateObjects()
    {
        int currentStep = StepManager.Instance.currentStep;

        foreach (StepObject stepObject in stepObjects)
        {
            if (currentStep >= stepObject.requiredStep)
            {
                foreach (GameObject obj in stepObject.objects)
                {
                    if (obj != null)
                        obj.SetActive(stepObject.activate);
                }
            }
        }
    }
}