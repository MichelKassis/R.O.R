using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShooterController : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    public GameObject bulletPrefab;
    public AudioClip alarm;
    public int score;
    public Text scoreText;
    public float AmbientSpeed;
    public float timeoutGameOver = 3f;
    public bool gameOverBool = false;
    public Text gameOverText;

    public float boostMultiplier = 2.0f;

    private AudioSource source;

    private Rigidbody rb;
    private Collider cd;
    public float RotationSpeed = 100.0f;
    private Vector3 orig_player_pos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        source = GetComponent<AudioSource>();
        //road = GameObject.Find("CUPIC_ROAD");
        orig_player_pos = GameObject.Find("Player").transform.position;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float speedModifier = 1.0f;

        if (Input.GetButton("Boost"))
        {
            speedModifier = boostMultiplier;
        }

        

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, AmbientSpeed);

        transform.Translate(movement * movementSpeed * Time.deltaTime * speedModifier);

        




        //Turn(moveHorizontal);
        //PitchRollYaw();
    }

    void PitchRollYaw()
    {

        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Mouse Y") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxis("Mouse X") * (Time.fixedDeltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        rb.rotation *= AddRot;

    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            source.PlayOneShot(alarm);

        }

        if (gameOverBool)
        {
            timeoutGameOver -= Time.deltaTime;
            setGameOverText();
            if (timeoutGameOver < 0)
            {
                // .. then reload the currently loaded level.
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }

    private void Turn(float input)
    {
        //Quaternion q = transform.rotation;
        //q.eulerAngles = new Vector3(0, q.eulerAngles.y, 0);
        // transform.rotation = q;
        transform.Rotate(0, input * rotationSpeed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "projectile")
        {
            //other.gameObject.SetActive(false);
            gameOverBool = true;
            
           
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            //enter = true;

            other.gameObject.SetActive(false);
            other.gameObject.transform.Translate(0, 0, 934.0f);
            other.gameObject.transform.position = new Vector3(orig_player_pos.x + Random.Range(-80,80), orig_player_pos.y + Random.Range(-50,70), other.gameObject.transform.position.z);
            other.gameObject.SetActive(true);
            score = score + 1;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("pool"))
        {

            GameObject.Find("CUPIC_ROAD_1").transform.Translate(0.0f, 0.0f, 934.0f);
            GameObject.Find("CUPIC_ROAD_2").transform.Translate(0.0f, 0.0f, 934.0f);
            GameObject.Find("CUPIC_ROAD_3").transform.Translate(0.0f, 0.0f, 934.0f);
        }

    }

    public void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();

    }

    

    public void setGameOverText()
    {
        gameOverText.text = " GameOver :( ";

    }


}

