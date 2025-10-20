using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace J_Framework
{
    public static class EventTriggerEntryUtils
    {
        public static EventTrigger.Entry CreateEventTriggerEntry(EventTriggerType type, UnityAction<BaseEventData> callback)
        {
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = type;
            entry.callback.AddListener(callback);
            return entry;
        }
    }
}
