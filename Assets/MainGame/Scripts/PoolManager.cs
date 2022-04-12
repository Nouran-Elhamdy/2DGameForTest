using System.Collections;
using UnityEngine;

namespace Test.Manager
{
    public class PoolManager : Manager
    {
        #region Public Variables
        public Transform ballItemParentL;
        public BallItem ballItemPrefab;
        public Transform ballItemParentR;
        public SpriteRenderer spriteRenderer;
        public ObjectPool m_ObjectPool;
        public Vector3 temp;
        #endregion

        #region Unity Calls
        public override void Awake()
        {
            base.Awake();
        }
        #endregion

        #region Public Methods
        public BallItem InitItem()
        {
            if (!spriteRenderer.flipX)
                temp = ballItemParentR.position;
            else
                temp = ballItemParentL.position;
            var item = Instantiate(ballItemPrefab, temp, Quaternion.identity);
            
            return item;
        }

        public void DeActivateItem(BallItem item)
        {
            StartCoroutine(DeactivateBall(item));
            IEnumerator DeactivateBall(BallItem ballItem)
            {
                yield return new WaitForSeconds(ballItem.currentBallConfig.lifeTime);
                Destroy(ballItem.gameObject, ballItem.currentBallConfig.lifeTime);
            }
        }
        #endregion
    }
}
