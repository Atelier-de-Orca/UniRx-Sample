using UnityEngine;
using UnityEngine.UI;

namespace Samples.ObjectClick.Script
{
    public class InfoPresenter : MonoBehaviour
    {
        // [SerializeField]
        // private CameraRayCaster cameraRayCaster;

        // [SerializeField]
        private Text infoText; 

        private void Start() {
            // cameraRayCaster.OnSelectObjectAsObservable
            //     .Subscribe(x => {
            //         infoText.text = x.ToString();
            //         Debug.Log(x);
            //     });
        }
    }
}
