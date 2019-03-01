using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    #region Fields  
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int maxShields;

    [SerializeField]
    private GameObject particleExplosionPrefab;

    private int currentHealth;
    private int currentShields;
    #endregion

    #region Mono_Functions
    private void Start()
    {
        currentShields = maxShields;
        currentHealth = maxHealth;
    }
    #endregion

    #region Public_Functions
    public void GetDamage(int damage)
    {
        if (currentShields > 0) GetDamageOnShields(damage);
        else GetDamageOnHealth(damage);
    }
    #endregion

    #region Private_Functions
    private void GetDamageOnHealth(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            DestroyObject();
        }
    }

    private void GetDamageOnShields(int damage)
    {
        if(currentShields - damage < 0)
        {
            int hDamage = Mathf.Abs(currentShields - damage);
            currentShields = 0;
            GetDamageOnHealth(hDamage);
        }
        else
        {
            currentShields -= damage;
        }
    }

    private void DestroyObject()
    {
        if(particleExplosionPrefab != null)
        {
            Destroy(Instantiate(particleExplosionPrefab, transform.position, Quaternion.identity), 1);
        }
        Destroy(gameObject);
    }
    #endregion
}
