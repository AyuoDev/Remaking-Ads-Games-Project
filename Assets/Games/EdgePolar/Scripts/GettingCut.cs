using System.Net.Http.Headers;
using UnityEngine;

public class GettingCut : MonoBehaviour
{
    public GameObject Throw;
    private Vector3 DefaultPosition;
    private void Start()
    {
        DefaultPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CutPoint"))
        {
            Destroy(other.gameObject.GetComponent<Collider>());
            Vector3 newPos = new Vector3();
            Vector3 NewScale = transform.localScale;
            float WidthRemoved = (transform.position.z > other.gameObject.transform.position.z) ? transform.position.z - (other.gameObject.transform.position.z + (other.gameObject.transform.localScale.z / 2)) : (other.gameObject.transform.position.z - (other.gameObject.transform.localScale.z / 2)) - transform.position.z;
            if (transform.position.z > other.gameObject.transform.position.z)
                newPos = new(transform.position.x, transform.position.y, other.gameObject.transform.position.z + transform.localScale.y);
            else
                newPos = new(transform.position.x, transform.position.y, other.gameObject.transform.position.z - transform.localScale.y);

            Vector3 ThrowPosition = transform.position;
            ThrowPosition.z = (transform.position.z > other.gameObject.transform.position.z) ? ThrowPosition.z + WidthRemoved : ThrowPosition.z - WidthRemoved;
            GameObject NewThrow = Instantiate(Throw, ThrowPosition, gameObject.transform.rotation);
            NewThrow.transform.localScale = new Vector3(NewScale.x, WidthRemoved / 2, NewScale.z);
            NewScale.y -= WidthRemoved / 2;
            transform.localScale = NewScale;
            GetComponentInParent<PlayerController>().TargetScale = NewScale ;
            transform.position = newPos;
        }
    }
}
