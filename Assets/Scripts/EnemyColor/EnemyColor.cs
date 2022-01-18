using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    [SerializeField] private Transform[] colorEnemyPosition;

    [SerializeField] private GameObject[] colorEnemyPrefabs;

    [SerializeField] private Transform colorEnemyParent;

    private List<Vector2> enemyDirection = new List<Vector2>();

    [SerializeField] private float speed;

    private GameObject colorEnemyPrefab;

    private void Start()
    {
        InvokeRepeating("EnemyColorAppear", 1f, 1f);

        InvokeRepeating("RandomRotate", 1f, 1f);
    }

    private void RandomRotate()
    {
        transform.Rotate(0f, 0f, -90f);
    }

    private void EnemyColorAppear()
    {
        enemyDirection.Insert(0, transform.up);

        enemyDirection.Insert(1, -transform.up);

        enemyDirection.Insert(2, transform.right);

        enemyDirection.Insert(3, -transform.right);

        for (int i = 0; i < colorEnemyPosition.Length; i++)
        {
            colorEnemyPrefab = Instantiate(colorEnemyPrefabs[i], colorEnemyPosition[i].position, Quaternion.identity, colorEnemyParent.transform);

            Rigidbody2D rigidbody = colorEnemyPrefab.GetComponent<Rigidbody2D>();

            rigidbody.velocity = enemyDirection[i] * speed;
        }
        
    }
}
