
public class EventId
{
	public const int LoadingBegin = 0;
	public const int LoadingStep = 1;
	public const int LoadingEnd = 2;
	public const int ItemSelected = 3;
	public const int ItemUnselected = 4;
}

public class Event
{
	public int eventId;
}

public class EventSimpleInt : Event
{
	public int val;
}

public class EventSimpleFloat : Event
{
	public float val;
}

public class EventSimpleString : Event
{
	public string val;
}

public class EventItemSelected : Event
{
	public Item item;
}
