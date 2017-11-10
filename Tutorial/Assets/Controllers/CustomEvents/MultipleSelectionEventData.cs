using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BrickWorld.EventSystems
{
    /// <summary>
    /// Describes an event that involves selecting an object.
    /// </summary>
    public class MultipleSelectionEventData : BaseEventData
    {
        /// <summary>
        /// The selected gameobject.
        /// </summary>
        public GameObject gameObject { get; private set; }

        public MultipleSelectionEventData(EventSystem eventSystem) : base(eventSystem)
        {
        }

        public void Initialize(GameObject gameObject)
        {
            Reset();
            this.gameObject = gameObject;
        }
    }
}