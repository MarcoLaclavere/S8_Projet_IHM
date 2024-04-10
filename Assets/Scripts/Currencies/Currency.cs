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
}