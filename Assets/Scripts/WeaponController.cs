using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform projectileShootPos;
    [SerializeField] private Transform projectile;

    SpriteRenderer SR_Player;
    SpriteRenderer SR;
    float localOffset = 0.5f;

    void Start()
    {
        SR_Player = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 localPos = transform.localPosition;
        float shootPosOffset;
        if (SR_Player.flipX == true)
        {
            SR.flipX = true;
            localPos.x = -localOffset;
            shootPosOffset = -Mathf.Abs(projectileShootPos.transform.localPosition.x);
            projectileShootPos.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y+180, transform.rotation.z);
            transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.left, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
        }
        else
        {
            SR.flipX = false;
            localPos.x = localOffset;
            shootPosOffset = Mathf.Abs(projectileShootPos.transform.localPosition.x);
            projectileShootPos.localRotation = Quaternion.Euler(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
        }
        transform.localPosition = localPos;
        projectileShootPos.localPosition = new Vector3(shootPosOffset,projectileShootPos.localPosition.y,projectileShootPos.localPosition.z);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile,projectileShootPos.position,projectileShootPos.rotation);
        }
    }
}