using Platformer.Mechanics;
using UnityEngine;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
    public float speed = 0.07f;
    #endregion

    #region Private Variables
    Vector3 rocketPosition;
    SpriteRenderer spriteRenderer;
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
        transform.localPosition = new Vector3();
        rocketPosition = new Vector3();
    }
    void Update()
    {
        if (!spriteRenderer.flipX)
        {
            newX = rocketPosition.x + speed;
            newY = GetY(newX, !spriteRenderer.flipX);
        }
        else 
        { 
            newX = rocketPosition.x - speed;
            newY = GetY(newX, false);
        }

        rocketPosition = new Vector3(newX, newY, 0);
        transform.localPosition = rocketPosition;
    }
    #endregion

    #region Private Methods
    float GetY(float x, bool isFlipped)
    {
        if(isFlipped) 
            return (-0.08f * Mathf.Pow(x, 2)) + 0.8f * x;
        else 
            return (-0.08f * Mathf.Pow(x, 2)) - 0.8f * x;
    }
    #endregion
}
