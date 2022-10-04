using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI label;
    
    [SerializeField]
    private uint _coins;

    public uint Coins 
    { 
        get 
        { 
            if( _coins < 0)
            {
                _coins = 0;
            }
            return _coins; 
        } 
    }

    public void AddCoins(uint coinsToAdd)
    {
        _coins += coinsToAdd;
    }

    private void SetText()
    {
        label.text = $"{Coins}";
    }

    private void Start()
    {
        _coins = 0;
        SetText();
    }

    private void Update()
    {
        SetText();
    }
}
