using UnityEngine;
using R3;

public class CameraRayCaster : MonoBehaviour
{
    // Make Stream (send gameObject when select object) 
    private Subject<GameObject> onSelectObjectStream = new Subject<GameObject>();
    public Observable<GameObject> OnSelectObjectAsObservable => this.onSelectObjectStream.AsObservable();

    private void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ =>
            {
                if (Camera.main == null)
                {
                    return;
                }
                
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out var hit))
                {
                    return;
                }
                    
                var clickedObject = hit.collider.gameObject;
                this.onSelectObjectStream.OnNext(clickedObject);
            });
    }
}
