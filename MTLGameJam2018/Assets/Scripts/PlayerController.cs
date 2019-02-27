using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    public GameObject bulletPrefab;
    public AudioClip alarm;
    public int score;
    public Text scoreText;


    public float boostMultiplier = 2.0f;

    private AudioSource source;

    private Rigidbody rb;
    private Collider cd;
    public float RotationSpeed = 100.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<Collider>();
        source = GetComponent<AudioSource>();
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

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);

        transform.Translate(movement * movementSpeed * Time.deltaTime * speedModifier);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);

        }




        //Turn(moveHorizontal);
        PitchRollYaw();
    }

    void PitchRollYaw()
    {

        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
       // roll = Input.GetAxis("RollRight") * (Time.fixedDeltaTime * RotationSpeed);
        roll = Input.GetAxis("RollLeft") * (Time.fixedDeltaTime * RotationSpeed);
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
        if (coll.gameObject.tag == "enemy")
        {
            //(other.gameobject);

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ring"))
        {
            //enter = true;

            other.gameObject.SetActive(false);
            
                score = score + 1;
                SetScoreText();
        }

    }

    void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();

    }
}