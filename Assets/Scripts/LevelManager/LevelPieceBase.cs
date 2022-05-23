using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPieceBase : MonoBehaviour
{
    public Transform endPiece;
    public GameObject currentArt;

    public void ChangePiece(GameObject piece)
    {
        if (currentArt != null) Destroy(currentArt);

        currentArt = Instantiate(piece, transform);
        currentArt.transform.localPosition = Vector3.zero;
    }
}
