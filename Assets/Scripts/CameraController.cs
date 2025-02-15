using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float drag = 0.08F;
    public Rigidbody2D target;

    void FixedUpdate()
    {
        Vector3 pos = Vector3.Lerp(transform.position, new Vector3(target.position.x, 0, -1), drag);
        pos.x = Mathf.Clamp(pos.x, 0, 1000);
        transform.position = pos;
    }
}
