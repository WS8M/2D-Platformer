using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out ICollectable collectable))
        {
            switch (collectable)
            {
                case Coin coin:
                    _wallet.AddCoins(coin.Value);
                    break;
                case Medicine medicine:
                    _health.TakeHealing(medicine.Value);
                    break;
            }

            collectable.Collect();
        }
    }
}