using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.linearVelocity = transform.forward * 50f;
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletTarget target = other.GetComponent<BulletTarget>();

        if (target != null)
        {
            target.RecibirDanio(damage);
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
