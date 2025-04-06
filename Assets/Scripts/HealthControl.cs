using UnityEngine;
using UnityEngine.Events;

public class Healthcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth;


    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }
    public UnityEvent OnDied;
    public UnityEvent OnHealthChanged;
    public GameOvER Manager;
    public void TakeDamega(float damega)
    {
        if (_currentHealth == 0)
        {
            return;
        }
        _currentHealth -= damega;

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;

        }
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDied.Invoke();

            if (Manager != null)
            {
                Debug.Log("Calling gameOver()...");
                Manager.gameOver();  // Ensure this is called
            }
        }
    }
    public void AddHealth(float amountToAdD)
    {
        if(_currentHealth == _maxHealth)
        {
            return ;
        }
        _currentHealth += amountToAdD;
        OnHealthChanged.Invoke();
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
    public void TakeDamaga(float damega)
    {
        if (_currentHealth == 0) return; // Don't apply damage if already dead

        _currentHealth -= damega;
        OnHealthChanged.Invoke();

        if (_currentHealth <= 0)  // Fix: Combine both checks into one
        {
            _currentHealth = 0;
            OnDied.Invoke();  // Call OnDied event first (if needed)
            Destroy(gameObject);  // Destroy the enemy
        }
    }

}
