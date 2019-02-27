using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rb;
    private float firing_timeout = 0.0f;

    public Transform bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = GameObject.Find("Player").transform.position;
        Vector3 direction = player_pos - rb.position;
        float z_distance = -direction.z;
        if (z_distance < 0)
        {
            Destroy(this.gameObject);
        } else if (z_distance <= 30)
        {
            rb.velocity = Vector3.Normalize(direction) * speed;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            rb.position = new Vector3(rb.position.x, rb.position.y, player_pos.z + 30);
            if (firing_timeout == 0)
            {
                var bulletTransform = Instantiate(bulletPrefab) as Transform;
                bulletTransform.position = transform.position;

                EnemyDroneBulletScript bullet = bulletTransform.gameObject.GetComponent<EnemyDroneBulletScript>();
                if (bullet)
                {
                    bullet.direction = Vector3.Normalize(direction);
                    bulletTransform.Rotate(transform.eulerAngles);
                    //bullet.launch_speed = rb.velocity.magnitude;
                }
                firing_timeout = 2.0f;
            }
        } else
        {
            rb.velocity = Vector3.Normalize(direction) * speed;
        }

        firing_timeout -= Time.deltaTime;
        firing_timeout = Mathf.Max(0.0f, firing_timeout);


    }
}
