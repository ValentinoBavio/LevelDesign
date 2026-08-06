using UnityEngine;
using UnityEngine.InputSystem;

public class Brujula : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private RectTransform arrow;

    private void Start()
    {
        arrow.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!Keyboard.current.qKey.isPressed)
        {
            arrow.gameObject.SetActive(false);
            return;
        }

        Transform target = StepManager.Instance.GetCurrentTarget();

        if (target == null)
        {
            arrow.gameObject.SetActive(false);
            return;
        }

        arrow.gameObject.SetActive(true);

        Vector3 dir = target.position - playerCamera.transform.position;

        dir.y = 0;

        float angle = Vector3.SignedAngle(playerCamera.transform.forward, dir, Vector3.up);

        arrow.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
