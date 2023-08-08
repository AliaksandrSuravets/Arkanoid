using System;
using UnityEngine;

public class Walls : SingletonMonoBehaviour<Walls>
{
    #region Events

    public event Action OnCollisionBall;

    #endregion

    #region Unity lifecycle

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            OnCollisionBall?.Invoke();
        }
    }

    #endregion
}