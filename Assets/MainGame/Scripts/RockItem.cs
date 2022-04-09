using UnityEngine;
using Test.Manager;
public class RockItem : MonoBehaviour
{
    #region Unity Calls
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<BallItem>())
        {
            if (collision.gameObject.GetComponent<BallItem>().currentBallConfig.ballType == BallType.FireBall)
            {
                GetComponent<SpriteRenderer>().sprite = Manager.BowManager.bowConfig.fireBallConfig.sprite;
            }
            else if (collision.gameObject.GetComponent<BallItem>().currentBallConfig.ballType == BallType.IceBall)
            {
                GetComponent<SpriteRenderer>().sprite = Manager.BowManager.bowConfig.iceBallConfig.sprite;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = Manager.BowManager.bowConfig.energyBallConfig.sprite;
            }
        }
     
    }
    #endregion
}
