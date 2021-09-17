using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _gold = 0;
    [SerializeField] private int _energy = 100;

    public int Gold => _gold;
    public int Energy => _energy;

    public void GoldAdd(int Amount)
    {
        print($"gold added {Amount}");
        _gold += Amount;
    }
    public void GoldWithdraw(int Amount)
    {
        _gold -= Amount;
    }
    public void EnergyAdd(int Amount)
    {
        _energy += Amount;
    }
    public void EnergySpend(int Amount)
    {
        _energy -= Amount;
    }
}
