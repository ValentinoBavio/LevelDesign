using UnityEngine;

public class TownArea : MonoBehaviour
{
    public static TownArea Instance;

    public bool isOutsideTown;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isOutsideTown = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isOutsideTown = false;
    }
}