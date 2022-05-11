using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.MessagePack
{
	public class MsgPackEnum : IEnumerator
	{
		public MsgPackEnum(List<MsgPack> obj)
		{
			this.children = obj;
		}

		object IEnumerator.Current
		{
			get
			{
				return this.children[this.position];
			}
		}

		bool IEnumerator.MoveNext()
		{
			this.position++;
			return this.position < this.children.Count;
		}

		void IEnumerator.Reset()
		{
			this.position = -1;
		}

		private List<MsgPack> children;

		private int position = -1;
	}
}
