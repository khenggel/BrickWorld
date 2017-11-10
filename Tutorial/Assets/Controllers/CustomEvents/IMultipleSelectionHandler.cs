using UnityEngine.EventSystems;

namespace BrickWorld.EventSystems
{
    /// <summary>
    /// Interface to implement to react to the event of a game object having been added to the multiple selection.
    /// </summary>
    public interface IMultipleSelectionHandler : IEventSystemHandler
    {
        void OnMultipleSelected(MultipleSelectionEventData eventData);
    }
}