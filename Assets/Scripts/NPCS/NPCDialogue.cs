using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private GameObject bubble;

    public int missionStep = -1;

    private void Start()
    {
        bubble.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            bubble.SetActive(true);

            if (missionStep != -1)
                StepManager.Instance.CompleteStep(missionStep);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bubble.SetActive(false);
        }
    }
}