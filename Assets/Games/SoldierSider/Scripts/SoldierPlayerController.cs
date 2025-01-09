using UnityEngine;

public class SoldierPlayerController : MonoBehaviour
{
    public float Timer;
    public float MaxDistance;
    public Vector3 Center;

    public float SideWalkSpeed;

    public float AttackSpeed;
    private float _AtkSpd;

    public int Damage;
    public GameObject Bullet;
    public Transform SpawnPoint;
    void Start()
    {
        _AtkSpd = AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        float MovSpeed = Input.GetAxis("Horizontal");

        Vector3 NewPos = transform.position + (Vector3.right * MovSpeed * SideWalkSpeed);


        Vector3 offset = NewPos - Center;
        transform.position = Center + Vector3.ClampMagnitude(offset, MaxDistance);

        _AtkSpd -= Time.deltaTime;
        if(_AtkSpd <= 0)
        {
            Instantiate(Bullet, SpawnPoint.transform.position, transform.rotation);
            _AtkSpd = AttackSpeed;
        }
    }
}
