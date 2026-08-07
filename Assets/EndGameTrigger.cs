using UnityEngine;
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject endCanvas;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            endCanvas.SetActive(true);
            StartCoroutine(QuitGame());
        }
    }

    private IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(5f);

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}