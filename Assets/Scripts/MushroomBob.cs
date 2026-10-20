
using UnityEngine;

public class MushroomBob : MonoBehaviour
{
    public float bobHeight = 0.2f;
    public float bobSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * bobSpeed)
                     * bobHeight;

        transform.localPosition = startPosition
                                + new Vector3(0f, newY, 0f);
    }
}
