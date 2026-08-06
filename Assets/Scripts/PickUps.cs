using UnityEngine;

public class PickUps : MonoBehaviour
{
    public int missionStep = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (missionStep != -1 && !StepManager.Instance.IsCurrentStep(missionStep))
            return;

        if (missionStep != -1)
            StepManager.Instance.CompleteStep(missionStep);

        Torch torch = other.GetComponent<Torch>();

        if (torch != null)
            torch.UnlockTorch();

        Destroy(gameObject);
    }
}
