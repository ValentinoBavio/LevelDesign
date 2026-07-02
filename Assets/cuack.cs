using UnityEngine;

public class cuack : MonoBehaviour
{
    [SerializeField] private float spacing = 3f;
    [SerializeField] private int columns = 5;

    [ContextMenu("Ordenar modelos en grilla")]
    private void ArrangeInGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            int x = i % columns;
            int z = i / columns;

            child.position = transform.position + new Vector3(x * spacing, 0f, z * spacing);
        }
    }
}