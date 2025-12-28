using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerContoller = other.GetComponent<PlayerController>();

            if (playerContoller != null)
            {
                playerContoller.Hit();
                Destroy(gameObject);
            }
        }
    }

    // 경로 확인용
    //private List<Vector3> path = new List<Vector3>();

    //private void Update()
    //{
    //    path.Add(transform.position);
    //}

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    for (int i = 1; i < path.Count; i++)
    //    {
    //        Gizmos.DrawLine(path[i - 1], path[i]);
    //    }
    //}
}
