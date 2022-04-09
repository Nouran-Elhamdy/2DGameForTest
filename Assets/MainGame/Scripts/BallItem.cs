using Platformer.Mechanics;
using System.Collections;
using UnityEngine;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
    #endregion
    float timeChanged;
    public float maxDuration;
    SpriteRenderer spriteRenderer;
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
        timeChanged = 0;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void Update()
    {
        if (timeChanged < maxDuration)
        {
            timeChanged += Time.deltaTime;

            if (!spriteRenderer.flipX)
                GetComponent<Rigidbody2D>().AddForce(timeChanged * new Vector2(1.2f,1f));

            else
                GetComponent<Rigidbody2D>().AddForce(timeChanged * new Vector2(-1.2f, 1f));
        }
        else
        GetComponent<Rigidbody2D>().gravityScale = 1;

    }

    #endregion
}
