using UnityEngine;

public class PickUps : MonoBehaviour
{
    [Header("Mission")]
    public int missionStep = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Si forma parte de una misión y todavía no corresponde, no se puede recoger.
        if (missionStep != -1 && !StepManager.Instance.IsCurrentStep(missionStep))
            return;

        // Avisar al StepManager
        if (missionStep != -1)
            StepManager.Instance.CompleteStep(missionStep);

        // Acá después podés agregar inventario, sonido, etc.

        Destroy(gameObject);
    }
}
