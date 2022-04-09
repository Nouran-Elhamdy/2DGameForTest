using System.Collections;
using UnityEngine;

namespace Test.Manager
{
    public class BallPoolManager : Manager
    {
        #region Public Variables
        public Transform ballItemParentL;
        public Transform ballItemParentR;
        public SpriteRenderer spriteRenderer;
        public ObjectPool m_ObjectPool;
        #endregion

        #region Unity Calls
        public override void Awake()
        {
            base.Awake();
            m_ObjectPool.spawnManagerTransform = ballItemParentL;
            m_ObjectPool.StartPool();
        }
        #endregion

        #region Public Methods
        public BallItem InitItem()
        {
            var item = m_ObjectPool.GetPooledObject(typeof(BallItem));
            if(!spriteRenderer.flipX)
            item.gameObject.GetComponent<Transform>().position = ballItemParentR.position;
            else
            {
                item.gameObject.GetComponent<Transform>().position = ballItemParentL.position;
            }
            item.gameObject.SetActive(true);
            return item;
        }

        public void DeActivateItem(BallItem item)
        {
            StartCoroutine(DeactivateBall(item));
            IEnumerator DeactivateBall(BallItem ballItem)
            {
                yield return new WaitForSeconds(ballItem.currentBallConfig.lifeTime);
                ballItem.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}
