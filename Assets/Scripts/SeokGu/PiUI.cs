using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class PiUI : MonoBehaviour
{
    public int pieceCount = 4;
    public GameObject piPiece;
    private List<PiPiece> piPieces = new List<PiPiece>();
    
    public PiData defaultData;
    public PiData[] piDatas;
    
    [HideInInspector]
    public int currentPieceNum = 0;

    void Start()
    {
        Init();
    }

    void Update()
    {
        for(int i = 0; i < piPieces.Count; i++)
        {
            piPieces[i].MouserPosUpdate();
            if (piPieces[i].IsSelected())
                currentPieceNum = i;
        }
    }

    void Init()
    {
        for (int i = 0; i < pieceCount; i++)
        {
            float z = 360.0f / pieceCount * i;
            PiPiece piece = piPiece.GetComponent<PiPiece>();
            piece = Instantiate(piece, transform);

            piece.SetUIRotation(new Vector3(0, 0, z));
            piece.SetAngleRange(360.0f / pieceCount);

            float amount = 1.0f / pieceCount;
            piece.SetImageFillAmount(amount);
            piPieces.Add(piece);

            if (i < piDatas.Length)
                piece.SetData(piDatas[i]);
            else
                piece.SetData(defaultData);
        }

        transform.localScale = new Vector3(4, 4, 4);
    }

    public void SelectItem()
    {
        SelectPiece(currentPieceNum);
    }

    void SelectPiece(int InPiPieceNum)
    {
        piPieces[InPiPieceNum].OnClicked();
    }
}
