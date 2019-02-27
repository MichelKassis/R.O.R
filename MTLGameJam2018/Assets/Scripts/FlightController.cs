using UnityEngine;
using System.Collections;

public class FlightController : MonoBehaviour
{

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 100.0f;

    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        UpdateFunction();
    }

    void UpdateFunction()
    {

        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        roll = Input.GetAxis("Roll") * (Time.fixedDeltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.fixedDeltaTime * RotationSpeed);
        yaw = Input.GetAxis("Yaw") * (Time.fixedDeltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        rb.rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = rb.rotation * AddPos;
        rb.velocity = AddPos * (Time.fixedDeltaTime * AmbientSpeed);
    }
}
