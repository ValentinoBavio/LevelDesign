using UnityEngine;
using UnityEngine.InputSystem;

public class Torch : MonoBehaviour
{
    public GameObject torchModel;

    public bool hasTorch = false;
    public bool torchEquipped = false;

    void Start()
    {
        torchModel.SetActive(false);
    }

    void Update()
    {
        if (!hasTorch)
            return;

        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            torchEquipped = !torchEquipped;
            torchModel.SetActive(torchEquipped);
        }
    }

    public void UnlockTorch()
    {
        hasTorch = true;
    }
}
