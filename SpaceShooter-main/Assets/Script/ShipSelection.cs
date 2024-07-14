using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShipSelection : MonoBehaviour
{
    public GameObject[] ships;
    public Button next;
    public Button prev;
    public Button selectButton;
    public TextMeshProUGUI selectButtonText;
    int index = 0;

    void Start()
    {
        index = PlayerPrefs.GetInt("shipIndex", 0);

        for (int i = 0; i < ships.Length; i++)
        {
            ships[i].SetActive(i == index);
        }

        selectButton.onClick.AddListener(() =>
        {
            SelectShip();
        });

        UpdateUI();
    }

    void Update()
    {
        next.interactable = index < ships.Length - 1;
        prev.interactable = index > 0;
    }

    public void Next()
    {
        SetShipActive(index, false);
        index++;
        SetShipActive(index, true);

        UpdateUI();
    }

    public void Prev()
    {
        SetShipActive(index, false);
        index--;
        SetShipActive(index, true);


        UpdateUI();
    }

    public void SelectShip()
    {
        SaveSelection();
        UpdateUI();
    }

    private void SetShipActive(int shipIndex, bool isActive)
    {
        ships[shipIndex].SetActive(isActive);
    }

    private void SaveSelection()
    {
        Debug.Log("Curetn index is :" + index);
        PlayerPrefs.SetInt("shipIndex", index);
        PlayerPrefs.Save();
    }

    private void UpdateUI()
    {
        int selectedIndex = PlayerPrefs.GetInt("shipIndex", 0);
        bool isSelected = selectedIndex == index;
        if (isSelected)
        {
            selectButtonText.text = "Selected";
            selectButton.interactable = false;
        }
        else
        {
            selectButtonText.text = "Select";
            selectButton.interactable = true;
        }


        /*for (int i = 0; i < ships.Length; i++)
        {
            if (i == selectedIndex)
            {
                selectButtonText.text = "Selected";
                selectButton.interactable = false;
            }
            else
            {
                selectButtonText.text = "Select";
                selectButton.interactable = true;
            }
        }*/
    }
}
