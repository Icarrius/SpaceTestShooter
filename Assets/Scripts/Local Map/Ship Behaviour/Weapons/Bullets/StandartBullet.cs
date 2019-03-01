using UnityEngine;

public class StandartBullet : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float speed = 15;

    [SerializeField]
    private float lifeTime = 5;

    [SerializeField]
    private int damage;

    private Rigidbody rb;
    private Vector3 velocity, acceleration;
    #endregion

    #region Mono_Functions
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        acceleration = speed * 5 * transform.right;
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        velocity = Vector3.ClampMagnitude(velocity, speed);
        velocity += acceleration * Time.deltaTime;
        rb.position += velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<IDamageable>() != null)
        {
            collision.gameObject.GetComponent<IDamageable>().GetDamage(damage);
            ExplodeBullet();
        }
    }
    #endregion

    #region Public_Functions

    #endregion

    #region Private_Functions
    private void ExplodeBullet()
    {      
        Destroy(gameObject);
    }
    #endregion
}
