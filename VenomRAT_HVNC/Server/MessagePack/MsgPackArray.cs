using System;
using System.Collections.Generic;

namespace Server.MessagePack
{
	public class MsgPackArray
	{
		public MsgPackArray(MsgPack msgpackObj, List<MsgPack> listObj)
		{
			this.owner = msgpackObj;
			this.children = listObj;
		}

		public MsgPack Add()
		{
			return this.owner.AddArrayChild();
		}

		public MsgPack Add(string value)
		{
			MsgPack msgPack = this.owner.AddArrayChild();
			msgPack.AsString = value;
			return msgPack;
		}

		public MsgPack Add(long value)
		{
			MsgPack msgPack = this.owner.AddArrayChild();
			msgPack.SetAsInteger(value);
			return msgPack;
		}

		public MsgPack Add(double value)
		{
			MsgPack msgPack = this.owner.AddArrayChild();
			msgPack.SetAsFloat(value);
			return msgPack;
		}

		public MsgPack this[int index]
		{
			get
			{
				return this.children[index];
			}
		}

		public int Length
		{
			get
			{
				return this.children.Count;
			}
		}

		private List<MsgPack> children;

		private MsgPack owner;
	}
}
