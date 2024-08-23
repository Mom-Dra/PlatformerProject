using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject piUIPrefab;
    // Start is called before the first frame update
    void Start()
    {
        piUIPrefab = GameObject.Find("PiUI");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPiUI(bool bActive)
    {
        piUIPrefab.SetActive(bActive);
    }

    public enum ItemList
    {
        None,
        Stone,
        Gun
    }

    [System.Serializable]
    public class PiData
    {
        public Sprite imageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
        public ItemList item;
    }
}
