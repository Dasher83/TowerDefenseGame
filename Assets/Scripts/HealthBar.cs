using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private float _maximum;
    [SerializeField]
    private float _current;
    private IDurable _target;

    public Image mask;
    public TextMeshProUGUI textLivesCounter;
    

    public float Current
    {
        get
        {
            if (_current < Constants.HealthBar.Minimum)
            {
                return Constants.HealthBar.Minimum;
            }
            if (_current > _maximum)
            {
                return _maximum;
            }

            return _current;
        }
        set
        {
            if (value < Constants.HealthBar.Minimum)
            {
                _current = Constants.HealthBar.Minimum;
                return;
            }
            if (value > _maximum)
            {
                _current = _maximum;
                return;
            }

            _current = value;
        }
    }
    public float Maximum { get { return _maximum; } set { _maximum = value; } }

    private void SetFillAmount()
    {
        float progress = _current / _maximum;
        mask.fillAmount = progress;
    }

    private void SetTextLivesCounter()
    {
        textLivesCounter.text = $"{Mathf.FloorToInt(Current)} / {Mathf.FloorToInt(Maximum)}";
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(Constants.Tags.Player).GetComponent<IDurable>();
        _maximum = Constants.HealthBar.DefaultMaximum;
        _current = _maximum;
        SetFillAmount();
        SetTextLivesCounter();
    }

    private void Update()
    {
        _current = _target.CurrentDurability;
        _maximum = _target.MaxDurability;
        SetFillAmount();
        SetTextLivesCounter();
    }
}

