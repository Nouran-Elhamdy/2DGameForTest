using System.Collections;
using UnityEngine;

namespace Test.Manager
{
    public class BallPoolManager : Manager
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
           // item.gameObject.SetActive(false);
          
           // item.gameObject.GetComponent<Transform>().position = ballItemParentR.position;
           // Debug.Log(item.gameObject.GetComponent<Transform>().position);

            //else
            //{
            //    item.gameObject.GetComponent<Transform>().position = ballItemParentL.position;
            //}
         //   item.gameObject.SetActive(true);
            return item;
        }

        public void DeActivateItem(BallItem item)
        {
            StartCoroutine(DeactivateBall(item));
            IEnumerator DeactivateBall(BallItem ballItem)
            {
                yield return new WaitForSeconds(ballItem.currentBallConfig.lifeTime);
                //   ballItem.gameObject.SetActive(false);
                Destroy(ballItem.gameObject, ballItem.currentBallConfig.lifeTime);
            }
        }
        #endregion
    }
}
