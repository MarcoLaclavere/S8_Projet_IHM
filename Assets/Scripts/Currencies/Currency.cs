
public enum Currency
{
    Money,
    Friends
}

[System.Serializable]
public class CurrencyAmount
{
    public Currency currency;
    public int amount;

    public CurrencyAmount(Currency currency, int amount)
    {
        this.currency = currency;
        this.amount = amount;
    }
}