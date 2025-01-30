using UnityEngine;
using UnityEngine.Events;


public class MonoEventsBehavior : MonoBehaviour
{
   public UnityEvent startEvent, awakeEvent, disableEvent;
   
   private void Awake()
   {
      awakeEvent.Invoke();
   }

   private void Start()
   {
      startEvent.Invoke();
   }

   private void OnEnable()
   {
      startEvent.Invoke();
   }

   private void OnDisable()
   {
      disableEvent.Invoke();
   }

   
   private void getComponent<T>()
   {
      GetComponent<T>();
   }

}
