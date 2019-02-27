using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCollider : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 orig_player_pos;

    void Start()
    {
        orig_player_pos = GameObject.Find("Player").transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = desiredPosition;

        transform.LookAt(target);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        { 

            other.gameObject.SetActive(false);
            other.gameObject.transform.Translate(0, 0, 934.0f);
            other.gameObject.transform.position = new Vector3(orig_player_pos.x + Random.Range(-80, 80), orig_player_pos.y + Random.Range(-50, 70), other.gameObject.transform.position.z);
            other.gameObject.SetActive(true);
        }
        

    }
}
