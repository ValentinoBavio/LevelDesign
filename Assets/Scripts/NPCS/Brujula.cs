using UnityEngine;
using UnityEngine.InputSystem;

public class Brujula : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private RectTransform arrow;
    [SerializeField] private GameObject timerCircle;

    private void Start()
    {
        arrow.gameObject.SetActive(false);
        timerCircle.SetActive(false);
    }

    private void Update()
    {
        if (!Keyboard.current.qKey.isPressed)
        {
            arrow.gameObject.SetActive(false);
            timerCircle.SetActive(false);
            return;
        }

        Transform target = StepManager.Instance.GetCurrentTarget();

        if (target == null)
        {
            arrow.gameObject.SetActive(false);
            timerCircle.SetActive(true);

            return;
        }

        arrow.gameObject.SetActive(true);
        timerCircle.SetActive(true);

        Vector3 dir = target.position - playerCamera.transform.position;

        dir.y = 0;

        float angle = Vector3.SignedAngle(playerCamera.transform.forward, dir, Vector3.up);

        arrow.localRotation = Quaternion.Euler(0, 0, -angle);
    }
}
