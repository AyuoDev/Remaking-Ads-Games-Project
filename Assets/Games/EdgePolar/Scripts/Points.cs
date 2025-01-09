using UnityEngine;

public class Points : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TargetScale.y += 0.25f;
            Destroy(this.gameObject);
        }
    }
}
