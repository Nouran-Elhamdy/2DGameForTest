using Platformer.Mechanics;
using UnityEngine;
using Test.Manager;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
    public float speed = 0.07f;
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
    private void OnEnable()
    {
        spriteRenderer = FindObjectOfType<PlayerController>().GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(0.5f, 0.5f, 0);
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
            rocketPosition = transform.localPosition;
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
            }
            else
            {
                newX = rocketPosition.x - speed;
                newY = GetY(newX, false);
            }
            transform.localPosition = rocketPosition;
            rocketPosition = new Vector3(newX, newY, 0);
        }
    }
    #endregion

    #region Private Methods
    float GetY(float x, bool isFlipped)
    {
        if (isFlipped)
            return (-0.08f * Mathf.Pow(x, 2)) + (1.76f * x) - 7.68f;
        else
            return (-0.08f * Mathf.Pow(x, 2)) - 0.8f * x;
    }
    #endregion
}
