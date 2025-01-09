using UnityEngine;
using TMPro;
public class Barrel : MonoBehaviour
{
    public int Health;
    public int MaxHealthRange = 100;

    public GameObject barrel;
    public float MovSpeed;
    public float RotateSpeed;

    private TextMeshProUGUI HealthDisplay;
    void Start()
    {
        HealthDisplay = GetComponentInChildren<TextMeshProUGUI>();
        Health = Random.Range(0, MaxHealthRange + (int)GameObject.FindWithTag("Player").GetComponent<SoldierPlayerController>().Timer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -Vector3.forward * MovSpeed * Time.deltaTime;

        HealthDisplay.text = Health.ToString();

        barrel.transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);

        if (Health <= 0) Destroy(this.gameObject);
    }
}
