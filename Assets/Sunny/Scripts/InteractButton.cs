
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NRKernal.NRExamples
{
    /// <summary> A cube interactive test. </summary>
    public class InteractButton : MonoBehaviour, IPointerClickHandler
    {
        /// <summary> The mesh render. </summary>
        //private MeshRenderer m_MeshRender;
        private Image img;

        /// <summary> Awakes this object. </summary>
        void Awake()
        {
            //m_MeshRender = GetComponent<MeshRenderer>();
            img = GetComponent<Image>();
        }

        void Start()
        {
            NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, () =>
            {
                Debug.Log("ResetWorldMatrix");
                var poseTracker = NRSessionManager.Instance.NRHMDPoseTracker;
                poseTracker.ResetWorldMatrix();
            });
        }


        /// <summary> when pointer click, set the cube color to random color. </summary>
        /// <param name="eventData"> Current event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(FadeImage());
        }

 
        IEnumerator FadeImage()
        {

            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
