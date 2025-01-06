using System;
using R3;
using R3.Triggers;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.DragObject.Script
{
    public class DragInput : MonoBehaviour
    {

        public float rotationSpeed = 8000.0f;
        private readonly CancellationTokenSource _cancellationTokenSource = new ();
        
        private async void Start()
        {
            try
            {
                while (!this._cancellationTokenSource.IsCancellationRequested)
                {
                    await this.OnMouseDownAsObservable().FirstAsync(cancellationToken: this._cancellationTokenSource.Token);

                    await Observable.EveryUpdate()
                        .Select(_ => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")))
                        .TakeUntil(this.OnMouseUpAsObservable())
                        .ForEachAsync(
                            action: (move) =>
                            {
                                this.transform.rotation =
                                    Quaternion.AngleAxis(move.y * this.rotationSpeed * Time.deltaTime, Vector3.right)
                                    * Quaternion.AngleAxis(-move.x * this.rotationSpeed * Time.deltaTime, Vector3.up)
                                    * this.transform.rotation;
                            }, 
                            cancellationToken: this._cancellationTokenSource.Token);
                }
            }
            catch (TaskCanceledException e)
            {
                Debug.Log("Task cancellation was Success!!: " + e.Message);
            }
        }

        private void OnDestroy()
        {
            this._cancellationTokenSource.Cancel();
        }
    }
}
