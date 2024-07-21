using System;

public class Wallet
{
    private int _coins;

    public int Coins => _coins;

    public void AddMoney(int numberOfMoney)
    {
        if (numberOfMoney < 0)
            throw new ArgumentOutOfRangeException(nameof(numberOfMoney));
        
        _coins += numberOfMoney;
    }
}