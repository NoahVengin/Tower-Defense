using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int costToBuild = 25; 
    public int CostToBuild { get { return costToBuild; }}

    static Bank bank;

    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        if(!bank) { bank = FindObjectOfType<Bank>(); }
        
        if(bank.CurrentBalance > costToBuild)
        {
            bank.Withdraw(costToBuild);
            Instantiate(towerPrefab, position, Quaternion.identity);
            return true;
        }

        return false;
    }
}
