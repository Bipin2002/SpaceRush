using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] ships;
    public Transform spawnPoint;

    void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("carIndex", 0);

        GameObject selectedShip = Instantiate(ships[selectedIndex], spawnPoint.position, spawnPoint.rotation);
        selectedShip.SetActive(true);
    }
}
