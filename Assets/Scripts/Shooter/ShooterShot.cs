using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShot : MonoBehaviour
{
    [SerializeField] Transform[] shootPositon;

    [SerializeField] private GameObject[] bulletPrefabs;

    [SerializeField] private float bulletSpeed;

    [SerializeField] private Transform BulletsParent;

    private List<Vector2> shootDirection = new List<Vector2>();

    private ShooterInput shooterInput;

    private float time;

    private float timer = 0.1f;

    private void Awake()
    {
        shooterInput = GetComponent<ShooterInput>();
    }

    private void Update()
    {
        if (shooterInput.LeftMouse() && time > timer)
        {
            Shoot();
            time = 0f;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void Shoot()
    {
        shootDirection.Insert(0, transform.up);

        shootDirection.Insert(1, -transform.up);

        shootDirection.Insert(2, transform.right);

        shootDirection.Insert(3, -transform.right);

        for (int i = 0; i < bulletPrefabs.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefabs[i], shootPositon[i].position, Quaternion.identity, BulletsParent.transform);

            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

            rigidbody.velocity = shootDirection[i] * bulletSpeed;

        }        

    }

}
