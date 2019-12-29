using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener
{

}

public class EventManager : Singleton<EventManager>
{
	public delegate void EventCallback(Event evt);
	private Dictionary<int, Dictionary<IEventListener, EventCallback>> _listeners = new Dictionary<int, Dictionary<IEventListener, EventCallback>>();

	public void Add(int eventId, IEventListener lt, EventCallback cb)
	{
		Debug.Assert(lt != null, "CHECK");
		Debug.Assert(cb != null, "CHECK");

		if (!_listeners.ContainsKey(eventId))
			_listeners.Add(eventId, new Dictionary<IEventListener, EventCallback>());

		_listeners[eventId].Add(lt, cb);
	}

	public void Remove(int eventId, IEventListener lt)
	{
		Debug.Assert(lt != null, "CHECK");

		if (_listeners.ContainsKey(eventId))
		{
			_listeners[eventId].Remove(lt);
		}
		else
		{
			Debug.LogWarning("failed to remove " + eventId + ", because cant find.");
		}
	}

	public void RemoveAll(IEventListener lt)
	{
		Debug.Assert(lt != null, "CHECK");
		
		foreach (var kv in _listeners)
		{
			if (kv.Value.ContainsKey(lt))
			{
				kv.Value.Remove(lt);
			}
		}
	}

	public void Dispatch(int eventId)
	{
		Event evt = new Event();
		evt.eventId = eventId;
		Dispatch(evt);
	}

	public void Dispatch(int eventId, int val)
	{
		EventSimpleInt evt = new EventSimpleInt();
		evt.eventId = eventId;
		evt.val = val;
		Dispatch(evt);
	}

	public void Dispatch(int eventId, float val)
	{
		EventSimpleFloat evt = new EventSimpleFloat();
		evt.eventId = eventId;
		evt.val = val;
		Dispatch(evt);
	}

	public void Dispatch(int eventId, string val)
	{
		EventSimpleString evt = new EventSimpleString();
		evt.eventId = eventId;
		evt.val = val;
		Dispatch(evt);
	}

	public void Dispatch(Event evt)
	{
		Debug.Assert(evt != null, "CHECK");

		if (_listeners.ContainsKey(evt.eventId) == false)
		{
			Debug.LogWarning("failed to Dispatch event " + evt.eventId + ", because no listener.");
			return;
		}

		foreach (var kv in _listeners[evt.eventId])
		{
			kv.Value.Invoke(evt);
		}
	}
}