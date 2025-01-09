using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float MovSpeed;

    public Transform Width;
    private Vector3 DefPosition;
    public Vector3 TargetScale;

    private bool EnableSpeeding;

    private float StartZPoint;
    private void Start()
    {
        StartZPoint = transform.position.z;
        TargetScale = Width.localScale;
        DefPosition = Width.localPosition;
    }
    void Update()
    {
        float InputLeft = -Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * MovSpeed * Time.deltaTime;
        transform.Translate(0, 0, InputLeft * MovSpeed * Time.deltaTime);
        Vector3 NewCamLook = new(transform.position.x - 10, transform.position.y + 10, StartZPoint);
        Camera.main.gameObject.transform.position = Vector3.Slerp(Camera.main.transform.position, NewCamLook, MovSpeed);

        Width.localScale = Vector3.Slerp(Width.localScale, TargetScale, MovSpeed * Time.deltaTime);

        if (EnableSpeeding) MovSpeed += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WinPoint"))
        {
            EnableSpeeding = true;
        }
    }
}
