using System;
using UnityEngine;

public class ShipLoader : MonoBehaviour
{
    public GameObject[] ships;

    void OnEnable()
    {
        int selectedIndex = PlayerPrefs.GetInt("shipIndex", 0);

        for (int i = 0; i < ships.Length; i++)
        {
            ships[i].SetActive(i == selectedIndex);
        }
    }

}
