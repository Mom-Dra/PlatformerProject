using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class StageUI : MonoBehaviour
{
    private int pieceNum = 3;
    private List<StagePiece> stagePieces = new List<StagePiece>();

    public GameObject stagePiecePrefab;

    void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < pieceNum; i++)
        {
            stagePiecePrefab = Instantiate(stagePiecePrefab, transform);
            Vector3 pos = new Vector3(1500 * (i - 1), 0, 0);
            stagePiecePrefab.transform.SetLocalPositionAndRotation(pos, Quaternion.identity);

            StagePiece piece = stagePiecePrefab.GetComponent<StagePiece>();
            stagePieces.Add(piece);
            


            //if (i < piDatas.Length)
            //    piece.SetData(piDatas[i]);
            //else
            //    piece.SetData(defaultData);
        }
    }

    void Update()
    {
        
    }
}
