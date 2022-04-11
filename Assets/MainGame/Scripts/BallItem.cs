using Platformer.Mechanics;
using UnityEngine;
using Test.Manager;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
    public float speed = 0.001f;
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
        spriteRenderer = FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(0.1f, 0.1f, 0);
        isRight = !spriteRenderer.flipX;

        if (currentBallConfig.ballType == BallType.EnergyBall)
        {
            if (isRight)
                GetComponent<Rigidbody2D>().velocity = transform.right * 10;

            else
                GetComponent<Rigidbody2D>().velocity = -transform.right * 10;
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
                newX = rocketPosition.x + speed;
                newY = GetY(newX, true);
                rocketPosition = new Vector3(newX, newY, 0);

                transform.localPosition = new Vector3(rocketPosition.x + Manager.BallPoolManager.ballItemParentR.position.x
                    , rocketPosition.y + Manager.BallPoolManager.ballItemParentR.position.y, rocketPosition.z);
            }
            else
            {
                newX = rocketPosition.x - speed;
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
            return (-0.16f * Mathf.Pow(x, 2)) + (0.8f * x);
        else
            return (-0.16f * Mathf.Pow(x, 2)) - 0.8f * x;
    }
    #endregion
}
