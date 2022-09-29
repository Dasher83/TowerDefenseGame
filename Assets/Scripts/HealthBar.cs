using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private float _maximum;
    [SerializeField]
    private float _current;
    public Image mask;

    public float Current
    {
        get { return _current; }
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

    private void Start()
    {
        _maximum = Constants.HealthBar.DefaultMaximum;
        _current = _maximum;
    }

    private void Update()
    {
        SetFillAmount();
    }

    private void SetFillAmount()
    {
        float progress = _current / _maximum;
        mask.fillAmount = progress;
    }
}

