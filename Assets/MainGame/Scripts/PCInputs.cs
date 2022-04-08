using Test.Manager;
using UnityEngine;

public class PCInputs : MonoBehaviour
{
    #region Unity Calls
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Manager.BowManager.CurrentBallType = BallType.FireBall;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            Manager.BowManager.CurrentBallType = BallType.IceBall;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Manager.BowManager.CurrentBallType = BallType.EnergyBall;
        }
    }
    #endregion
}
