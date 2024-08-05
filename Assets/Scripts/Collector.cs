using UnityEngine;

public class Collector : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coins money))
        {
            _wallet.AddCoins(money.Value);
            money.Collect();
        }
    }
}
