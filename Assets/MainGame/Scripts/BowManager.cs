using UnityEngine;

namespace Test.Manager
{
    public class BowManager : Manager
    {
        #region Public Variables
        public BowConfig bowConfig;
        #endregion

        #region Props
        private BallType m_CurrentBallType;
        public BallType CurrentBallType
        {
            get => m_CurrentBallType;
            set
            {
                m_CurrentBallType = value;
                SetBallConfiguration();
            }
        }
        #endregion

        #region Public Methods
        public void SetBallConfiguration()
        {
           var item = PoolManager.InitItem();
            switch (BowManager.CurrentBallType)
            {
                case BallType.FireBall:
                    item.GetBallConfigData(bowConfig.fireBallConfig);
                    item.name = bowConfig.fireBallConfig.ballType.ToString();
                    item.GetComponent<SpriteRenderer>().sprite = bowConfig.fireBallConfig.sprite;
                    item.GetComponent<Rigidbody2D>().sharedMaterial = bowConfig.fireBallConfig.physicsMaterial2;
                    break;
                case BallType.IceBall:
                    item.GetBallConfigData(bowConfig.iceBallConfig);
                    item.name = bowConfig.iceBallConfig.ballType.ToString();
                    item.GetComponent<SpriteRenderer>().sprite = bowConfig.iceBallConfig.sprite;
                    item.GetComponent<Rigidbody2D>().sharedMaterial = bowConfig.iceBallConfig.physicsMaterial2;
                    break;
                case BallType.EnergyBall:
                    item.GetBallConfigData(bowConfig.energyBallConfig);
                    item.name = bowConfig.energyBallConfig.ballType.ToString();
                    item.GetComponent<SpriteRenderer>().sprite = bowConfig.energyBallConfig.sprite;
                    item.GetComponent<Rigidbody2D>().sharedMaterial = bowConfig.energyBallConfig.physicsMaterial2;
                    break;
                default:
                    break;
            }
            PoolManager.DeActivateItem(item);
        }
        #endregion
    }
}
[System.Serializable]
public class ObjectConfig
{
    public ObjectState objectState;
    public float lifeTime;
}

public enum ObjectState
{
    None,
    OnFire,
    Bouncer,
    Freezed
}

[System.Serializable]
public class BallConfig
{
    public BallType ballType;
    public Sprite sprite;
    public PhysicsMaterial2D physicsMaterial2;
    public float damage;
    public float lifeTime;
}
public enum BallType
{
    None,
    FireBall,
    IceBall,
    EnergyBall
}

[System.Serializable]
public class BowConfig
{
    [Space(5)]
    [Header("Ball Configuration")]
    [Tooltip("Set Data Settings For Each Ball Config Type ")]
    public BallConfig fireBallConfig;
    public BallConfig iceBallConfig;
    public BallConfig energyBallConfig;

    [Space(5)]
    [Header("Object Configuration")]
    [Tooltip("Set Data Settings For Each Object Config Type ")]
    public ObjectConfig burningObjectConfig;
    public ObjectConfig freezingObjectConfig;
    public ObjectConfig bouncingObjectConfig;

    [Space(5)]
    [Header("Bow Settings")]
    [Tooltip("Set Data Settings For Bow Settings ")]
    public float speed;
    public float rate;
}
