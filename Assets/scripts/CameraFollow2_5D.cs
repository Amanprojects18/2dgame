using UnityEngine;

public class CameraFollow2_5D : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 3f, -10f);
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (!player) return;

        // Follow player only on X axis, keep fixed Y and Z
        Vector3 targetPos = new Vector3(player.position.x, offset.y, offset.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = smoothPos;
    }
}
