using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int MovSpeed;
    private float Dtimer = 3;
    void Update()
    {
        Dtimer -= Time.deltaTime;
        if (Dtimer <= 0) Destroy(this.gameObject);
        transform.position += transform.forward * MovSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Barrel":
                collision.gameObject.GetComponentInParent<Barrel>().Health -= GameObject.FindWithTag("Player").GetComponent<SoldierPlayerController>().Damage;
                break;
        }
        Destroy(this.gameObject);
    }
}
