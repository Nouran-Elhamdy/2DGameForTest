using Platformer.Mechanics;
using UnityEngine;
using Test.Manager;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
   // public float speed = 0.07f;
    #endregion

    #region Private Variables
    //Vector3 rocketPosition;
    SpriteRenderer spriteRenderer;
    bool isRight;
    //float newX;
    //float newY;
    float timeChanged;
    public float maxDuration;
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
        timeChanged = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        //else
        //{
        //    rocketPosition = new Vector3();
        //}
    }

    void Update()
    {

        if (currentBallConfig.ballType != BallType.EnergyBall)
        {
            if (timeChanged < maxDuration)
            {
                timeChanged += Time.deltaTime;

                if (isRight)
                    GetComponent<Rigidbody2D>().AddForce(timeChanged * new Vector2(1f, 1f));

                else
                    GetComponent<Rigidbody2D>().AddForce(timeChanged * new Vector2(-1f, 1f));
            }
            else
                GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        //if (currentBallConfig.ballType != BallType.EnergyBall)
        //{
        //    if (isRight)
        //    {
        //        newX = rocketPosition.x + speed;
        //        newY = GetY(newX, true);
        //    }
        //    else
        //    {
        //        newX = rocketPosition.x - speed;
        //        newY = GetY(newX, false);
        //    }
        //    rocketPosition = new Vector3(newX, newY, 0);
        //    transform.localPosition = rocketPosition;
        //    transform.localPosition = new Vector3(rocketPosition.x + 4, rocketPosition.y, rocketPosition.z);
        //}
    }
    #endregion

    #region Private Methods
    float GetY(float x, bool isFlipped)
    {
        if (isFlipped)
            return (-0.08f * Mathf.Pow(x, 2)) + (0.8f * x);
        else
            return (-0.08f * Mathf.Pow(x, 2)) - 0.8f * x;
    }
    #endregion
}
