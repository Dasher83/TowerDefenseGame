using UnityEngine;

public class CoinCounterUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI label;
    
    [SerializeField]
    private uint _coins;

    public uint Coins 
    { 
        get 
        { 
            return _coins; 
        }
        
        set
        {
            _coins = value;
        }
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
