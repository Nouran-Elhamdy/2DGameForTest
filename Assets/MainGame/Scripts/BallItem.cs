using UnityEngine;
public class BallItem : MonoBehaviour
{
    #region Public Variables
    public BallConfig currentBallConfig;
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
        transform.localScale = new Vector3(1, 1, 0);
        GetComponent<Rigidbody2D>().velocity = transform.right * 15;
    }
    #endregion
}
