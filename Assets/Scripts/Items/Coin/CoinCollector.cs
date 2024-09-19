using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake() => 
        _wallet = new Wallet();

    public void AddCoins(int numberOfCoins) => 
        _wallet.AddCoins(numberOfCoins);
}