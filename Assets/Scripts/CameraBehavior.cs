using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    public float camLeft, camTop, camRight, camBottom;
    float camHorizontalFov, camVerticalFov;

    private void Start()
    {
        camVerticalFov = Camera.main.orthographicSize;
        camHorizontalFov = camVerticalFov * Screen.width / Screen.height;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, camLeft+camHorizontalFov, camRight-camHorizontalFov),Mathf.Clamp(transform.position.y, camBottom+camVerticalFov, camTop-camVerticalFov),transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector3(camLeft, camBottom), new Vector3(camRight, camBottom));
        Gizmos.DrawLine(new Vector3(camLeft, camTop), new Vector3(camLeft, camBottom));
        Gizmos.DrawLine(new Vector3(camLeft, camTop), new Vector3(camRight, camTop));
        Gizmos.DrawLine(new Vector3(camRight, camTop), new Vector3(camRight, camBottom));
    }
}
