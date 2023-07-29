using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private bool _isFirstLevel;
    // Start is called before the first frame update
    #region Unity lifecycle

    private void Start()
    {
        if (_isFirstLevel)
        {
            ScoreSystem.StartScoreSystem();
        }
        else
        {
            ScoreSystem.Load();
        }
    }

    private void Update()
    {
        MoveWithMouse();
    }

    #endregion

    #region Private methods

    private void MoveWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        //Vector3 currentPosition = transform.position;
        //currentPosition.x = worldMousePosition.x;
        //transform.position = currentPosition;
        transform.position = new Vector3(Mathf.Clamp(worldMousePosition.x,-13,13) , transform.position.y , transform.position.z); 
    }

    #endregion
}
