using UnityEngine;

public class SpawnThrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player").transform.position.z > transform.position.z)
        {
            transform.position += transform.right * Time.deltaTime * 5;
        }
        else
        {
            transform.position -= transform.right * Time.deltaTime * 5;
        }
    }
}
