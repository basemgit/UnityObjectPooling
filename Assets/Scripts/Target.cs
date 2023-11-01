using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 10.2f;
    private float maxSpeed = 16f;
    private float xRange = 1.5f;
    private float ySpawnPos = -2;
    private Rigidbody targetRB;

    // Start is called before the first frame update
    void OnEnable()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    private void OnDisable()
    {
        targetRB.velocity = Vector3.zero;
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        // intstead of destroying the object when it enter the dead zone
        // we deactivate it
        gameObject.SetActive(false);

    }


}
