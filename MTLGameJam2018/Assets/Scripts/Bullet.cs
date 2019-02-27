using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float range;

    private float dist;
    private ShooterController sc;
    private Vector3 orig_player_pos;

    // Use this for initialization
    void Start()
    {
        orig_player_pos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        dist += Time.deltaTime * speed;
        if (dist >= range)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.Translate(0, 0, 934.0f);
            other.gameObject.transform.position = new Vector3(orig_player_pos.x + Random.Range(-80, 80), orig_player_pos.y + Random.Range(-50, 70), other.gameObject.transform.position.z);
            other.gameObject.SetActive(true);
            //sc.score = sc.score + 1;
            //sc.SetScoreText();
        }
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}