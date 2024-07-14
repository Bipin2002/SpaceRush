using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageLoader : MonoBehaviour
{
   public GameObject Inventory;
   public GameObject Home;
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }


    public void LoadHome()
    {
        Home.SetActive(true);
        Inventory.SetActive(false);
    }

    public void LoadInventory()
    {
        Home.SetActive(false);
        Inventory.SetActive(true);
    }
}
