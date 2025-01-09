using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    public float CurrentSpeed;
    public float MaxSpeed;

    public float Turbo;

    public float RotateSpeed;
    public float CamSmoothness;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        Camera.main.transform.position = new Vector3(transform.position.x, 25, transform.position.z - 15);
    }

    public void Update()
    {
        float Vert = Input.GetAxis("Vertical");
        float Hori = Input.GetAxis("Horizontal");

        rb.AddForce(transform.forward * CurrentSpeed * Vert,ForceMode.Force);

        if(Input.GetKey(KeyCode.LeftShift)) rb.AddForce(transform.forward * Turbo * Vert ,ForceMode.Acceleration);

        transform.Rotate(Vector3.up * Hori * RotateSpeed);
        Vector3 CamSpot = new Vector3(transform.position.x, 25, transform.position.z - 15);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, CamSpot, CamSmoothness * Time.deltaTime);
        
    }
}
