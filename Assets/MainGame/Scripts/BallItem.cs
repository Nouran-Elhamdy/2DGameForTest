using Platformer.Mechanics;
using UnityEngine;
using Test.Manager;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
    #endregion

    #region Private Variables
    Vector3 rocketPosition;
    SpriteRenderer spriteRenderer;
    bool isRight;
    float newX;
    float newY;
    #endregion

    #region Public Methods
    public void GetBallConfigData(BallConfig ballConfig)
    {
        currentBallConfig = ballConfig;
    }
    #endregion

    #region Unity Calls
    private void Start()
    {
        Manager.BowManager.SetProjectileConfigurationForBall(Manager.BowManager.bowConfig.curveHeight, Manager.BowManager.bowConfig.curveWidth);
        spriteRenderer = FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>();
        isRight = !spriteRenderer.flipX;
        transform.localScale = new Vector3(0.1f, 0.1f, 0);

        if (currentBallConfig.ballType == BallType.EnergyBall)
        {
            if (isRight)
                GetComponent<Rigidbody2D>().velocity = transform.right * currentBallConfig.thrust;

            else
                GetComponent<Rigidbody2D>().velocity = -transform.right * currentBallConfig.thrust;
        }

        else
        {
            if (isRight)
                transform.localPosition = Manager.BallPoolManager.ballItemParentR.position;

            else
                transform.localPosition = Manager.BallPoolManager.ballItemParentL.position;

            rocketPosition = new Vector3();
        }
    }

    void Update()
    {
        if (currentBallConfig.ballType != BallType.EnergyBall)
        {
            if (isRight)
            {
                newX = rocketPosition.x + Manager.BowManager.bowConfig.speed;
                newY = GetY(newX, true);
                rocketPosition = new Vector3(newX, newY, 0);

                transform.localPosition = new Vector3(rocketPosition.x + Manager.BallPoolManager.ballItemParentR.position.x
                    , rocketPosition.y + Manager.BallPoolManager.ballItemParentR.position.y, rocketPosition.z);
            }
            else
            {
                newX = rocketPosition.x - Manager.BowManager.bowConfig.speed;
                newY = GetY(newX, false);
                rocketPosition = new Vector3(newX, newY, 0);
                transform.localPosition = new Vector3(rocketPosition.x + Manager.BallPoolManager.ballItemParentL.position.x
                    , rocketPosition.y + Manager.BallPoolManager.ballItemParentL.position.y, rocketPosition.z);
            }
        }
    }
    #endregion

    #region Private Methods
    float GetY(float x, bool isFlipped)
    {
        if (isFlipped)
            return (Manager.BowManager.PointA * Mathf.Pow(x, 2)) + Manager.BowManager.PointB * x;
        else
            return (Manager.BowManager.PointA * Mathf.Pow(x, 2)) - Manager.BowManager.PointB * x;
    }


    #endregion
}
