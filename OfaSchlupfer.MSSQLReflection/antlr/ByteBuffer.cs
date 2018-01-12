using System;
using System.IO;

namespace antlr
{
	internal class ByteBuffer : InputBuffer
	{
		private const int BUF_SIZE = 16;

		[NonSerialized]
		internal Stream input;

		private byte[] buf = new byte[16];

		public ByteBuffer(Stream input_)
		{
			this.input = input_;
		}

		public override void fill(int amount)
		{
			this.syncConsume();
			int num = amount + base.markerOffset - base.queue.Count;
			int num2;
			do
			{
				if (num <= 0)
				{
					return;
				}
				num2 = this.input.Read(this.buf, 0, 16);
				for (int i = 0; i < num2; i++)
				{
					base.queue.Add((char)this.buf[i]);
				}
				num -= num2;
			}
			while (num2 >= 16);
			while (num-- > 0)
			{
				base.queue.Add(CharScanner.EOF_CHAR);
			}
		}
	}
}
