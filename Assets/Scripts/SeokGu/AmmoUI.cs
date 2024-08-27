using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    private int maxAmmo = 6;
    public int currentAmmo = 6;
    private TextMeshProUGUI thisText;
    void Start()
    {
        thisText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateAmmo();
    }

    public void UpdateAmmo()
    {
        thisText.text = string.Format("{0:00} / {1:00}", currentAmmo, maxAmmo);
    }
}
