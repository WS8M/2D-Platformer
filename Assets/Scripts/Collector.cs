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
        if (other.gameObject.TryGetComponent(out Money money))
        {
            _wallet.AddMoney(money.CoinQuantity);
            money.Collect();
        }
    }
}
