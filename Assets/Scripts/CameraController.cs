using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float drag = 0.08F;
    public float max = 1000;
    public Rigidbody2D target;

    void FixedUpdate()
    {
        Vector3 pos = Vector3.Lerp(transform.position, new Vector3(target.position.x, 0, -1), drag);
        pos.x = Mathf.Clamp(pos.x, -4, max);
        transform.position = pos;
    }
}
