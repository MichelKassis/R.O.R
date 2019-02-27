using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDroneBulletScript : MonoBehaviour
{
    public float speed;
    public float timeoutBullet = 10f;
    public float launch_speed;
    public Vector3 direction;
    private float time;
    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * (speed + launch_speed));
        time += Time.deltaTime;
        if (time >= timeoutBullet)
        {
            Destroy(gameObject);
        }

        //timeoutGameOver -= Time.deltaTime;

        
    }
    


}

