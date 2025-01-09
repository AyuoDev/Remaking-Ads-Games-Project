using UnityEngine;

public class CuttingEdge : MonoBehaviour
{
    public float RotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -RotateSpeed * Time.deltaTime);
    }
}
