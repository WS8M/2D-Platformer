using System;

public class Wallet
{
    public int Coins { get; private set; }

    public void AddCoins(int numberOfCoins)
    {
        if (numberOfCoins < 0)
            throw new ArgumentOutOfRangeException(nameof(numberOfCoins));
        
        Coins += numberOfCoins;
    }
}