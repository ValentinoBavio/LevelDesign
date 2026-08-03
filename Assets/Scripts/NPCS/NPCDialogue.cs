using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [TextArea]
    public string dialogue;

    [SerializeField] private GameObject bubble;
    [SerializeField] private TMP_Text dialogueText;

    private void Start()
    {
        bubble.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueText.text = dialogue;
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