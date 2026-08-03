using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    

    [SerializeField] private GameObject bubble;    

    private void Start()
    {
        bubble.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            bubble.SetActive(true);
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