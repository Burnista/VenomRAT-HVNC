using System;

namespace Server.MessagePack
{
	public enum MsgPackType
	{
		Unknown,
		Null,
		Map,
		Array,
		String,
		Integer,
		UInt64,
		Boolean,
		Float,
		Single,
		DateTime,
		Binary
	}
}
