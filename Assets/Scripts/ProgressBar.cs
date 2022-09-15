using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float maximum;
    public float current;
    public Image mask;

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
