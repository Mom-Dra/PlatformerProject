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
        if (Input.GetKey(KeyCode.Tab))  piUIPrefab.SetActive(true);
        else                            piUIPrefab.SetActive(false);

    }

    [System.Serializable]
    public class PiData
    {
        public Sprite imageSprite;
        public Color imageColor = new Color(1, 1, 1, 1);
    }
}
