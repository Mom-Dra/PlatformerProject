using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public int pieceCount = 3;
    public float currentHealth = 3;
    public float distance = 120.0f;
    public bool bDebug = true;

    public GameObject healthPiece;

    private float maxHealth = 3;
    private List<HealthPiece> healthPieces = new List<HealthPiece>();

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(bDebug == true)
            UpdateCurrentHealth();
    }

    void Init()
    {
        for (int i = 0; i < pieceCount; i++)
        {
            float z = 360.0f / pieceCount * i;
            HealthPiece piece = healthPiece.GetComponent<HealthPiece>();
            piece = Instantiate(piece);
            piece.transform.SetParent(transform);
            piece.SetUIPosition(new Vector3(distance * i, 0, 0));
            piece.SetImageFillAmount(1.0f);

            healthPieces.Add(piece);
        }
    }

    void UpdateCurrentHealth()
    {
        float current = Mathf.Clamp(currentHealth, 0, maxHealth);
        for (int i = 0; i < pieceCount; i++)
        {
            current -= 1;
            if(current >= 0)
            {
                healthPieces[i].SetImageFillAmount(1.0f);
            }
            else
            {
                if (current < -0.5f)
                    healthPieces[i].SetImageFillAmount(0);
                else if (current < 0)
                    healthPieces[i].SetImageFillAmount(0.5f);
            }
        }
    }
}
