using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    # region -- Shooting attributes & properties--
    private float _independentShotDamage;
    private float _bulletDamage;
    private int _criticalFactor;
    private float OverallShotDamage => _independentShotDamage * _bulletDamage;
    public float IndependentShotDamage {
        set
        {
            if(value <= _independentShotDamage) {
                return;
            }

            _independentShotDamage = value;
        }
    }
    #endregion

    # region -- Economy attributes & properties
    private CoinCounterUI _coinCounterUI;
    private uint _coins;
    public uint Coins {
        get
        {
            return _coins;
        }
        set
        {
            _coins = value;
        }
    }
    # endregion

    private void Start()
    {
        if(instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }
        Time.timeScale = 1;
        _independentShotDamage = Constants.LevelManager.InitialIndependentShotDamage;
        _criticalFactor = Constants.LevelManager.InitialCriticalFactor;
        _bulletDamage = Constants.LevelManager.InitialBulletDamage;
        _coinCounterUI = GameObject.FindGameObjectWithTag(
            Constants.Tags.Wallet).GetComponent<CoinCounterUI>();
    }

    private void Update()
    {
        _coinCounterUI.Coins = Coins;
    }

    public float CalculateShotDamage()
    {
        int criticalFactor = Random.Range(0, 100);
        if (criticalFactor > (100 - _criticalFactor))
        {
            float criticalDamageMultiplier = Random.Range(
                Constants.LevelManager.CriticalDamageMultiplierMinimum,
                Constants.LevelManager.CriticalDamageMultiplierMaximum
                );
            return (OverallShotDamage * criticalDamageMultiplier);
        }
        return OverallShotDamage;
    }
}
