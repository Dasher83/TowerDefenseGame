using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float maximum;
    private float current;
    public Image mask;

    public float Current { set { current = value; } }
    public float Maximum { set { maximum = value; } }

    private void Update()
    {
        SetFillAmount();
    }

    private void SetFillAmount()
    {
        float progress = current / maximum;
        mask.fillAmount = progress;
    }
}
