using System;
using System.Collections;

namespace antlr.collections.impl
{
	internal class BitSet : ICloneable
	{
		protected internal const int BITS = 64;

		protected internal const int NIBBLE = 4;

		protected internal const int LOG_BITS = 6;

		protected internal static readonly int MOD_MASK = 63;

		protected internal long[] dataBits;

		public BitSet()
			: this(64)
		{
		}

		public BitSet(long[] bits_)
		{
			this.dataBits = bits_;
		}

		public BitSet(int nbits)
		{
			this.dataBits = new long[(nbits - 1 >> 6) + 1];
		}

		public virtual void add(int el)
		{
			int num = BitSet.wordNumber(el);
			if (num >= this.dataBits.Length)
			{
				this.growToInclude(el);
			}
			this.dataBits[num] |= BitSet.bitMask(el);
		}

		public virtual BitSet and(BitSet a)
		{
			BitSet bitSet = (BitSet)this.Clone();
			bitSet.andInPlace(a);
			return bitSet;
		}

		public virtual void andInPlace(BitSet a)
		{
			int num = Math.Min(this.dataBits.Length, a.dataBits.Length);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				this.dataBits[num2] &= a.dataBits[num2];
			}
			for (int i = num; i < this.dataBits.Length; i++)
			{
				this.dataBits[i] = 0L;
			}
		}

		private static long bitMask(int bitNumber)
		{
			int num = bitNumber & BitSet.MOD_MASK;
			return 1L << num;
		}

		public virtual void clear()
		{
			for (int num = this.dataBits.Length - 1; num >= 0; num--)
			{
				this.dataBits[num] = 0L;
			}
		}

		public virtual void clear(int el)
		{
			int num = BitSet.wordNumber(el);
			if (num >= this.dataBits.Length)
			{
				this.growToInclude(el);
			}
			this.dataBits[num] &= ~BitSet.bitMask(el);
		}

		public virtual object Clone()
		{
			BitSet bitSet = new BitSet();
			bitSet.dataBits = new long[this.dataBits.Length];
			Array.Copy(this.dataBits, 0, bitSet.dataBits, 0, this.dataBits.Length);
			return bitSet;
		}

		public virtual int degree()
		{
			int num = 0;
			for (int num2 = this.dataBits.Length - 1; num2 >= 0; num2--)
			{
				long num3 = this.dataBits[num2];
				if (num3 != 0)
				{
					for (int num4 = 63; num4 >= 0; num4--)
					{
						if ((num3 & 1L << num4) != 0)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		public override int GetHashCode()
		{
			return this.dataBits.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj != null && obj is BitSet)
			{
				BitSet bitSet = (BitSet)obj;
				int num = Math.Min(this.dataBits.Length, bitSet.dataBits.Length);
				int num2 = num;
				while (num2-- > 0)
				{
					if (this.dataBits[num2] != bitSet.dataBits[num2])
					{
						return false;
					}
				}
				if (this.dataBits.Length > num)
				{
					int num4 = this.dataBits.Length;
					while (num4-- > num)
					{
						if (this.dataBits[num4] != 0)
						{
							return false;
						}
					}
				}
				else if (bitSet.dataBits.Length > num)
				{
					int num6 = bitSet.dataBits.Length;
					while (num6-- > num)
					{
						if (bitSet.dataBits[num6] != 0)
						{
							return false;
						}
					}
				}
				return true;
			}
			return false;
		}

		public virtual void growToInclude(int bit)
		{
			int num = Math.Max(this.dataBits.Length << 1, BitSet.numWordsToHold(bit));
			long[] destinationArray = new long[num];
			Array.Copy(this.dataBits, 0, destinationArray, 0, this.dataBits.Length);
			this.dataBits = destinationArray;
		}

		public virtual bool member(int el)
		{
			int num = BitSet.wordNumber(el);
			if (num >= this.dataBits.Length)
			{
				return false;
			}
			return (this.dataBits[num] & BitSet.bitMask(el)) != 0;
		}

		public virtual bool nil()
		{
			for (int num = this.dataBits.Length - 1; num >= 0; num--)
			{
				if (this.dataBits[num] != 0)
				{
					return false;
				}
			}
			return true;
		}

		public virtual BitSet not()
		{
			BitSet bitSet = (BitSet)this.Clone();
			bitSet.notInPlace();
			return bitSet;
		}

		public virtual void notInPlace()
		{
			for (int num = this.dataBits.Length - 1; num >= 0; num--)
			{
				this.dataBits[num] = ~this.dataBits[num];
			}
		}

		public virtual void notInPlace(int maxBit)
		{
			this.notInPlace(0, maxBit);
		}

		public virtual void notInPlace(int minBit, int maxBit)
		{
			this.growToInclude(maxBit);
			for (int i = minBit; i <= maxBit; i++)
			{
				int num = BitSet.wordNumber(i);
				this.dataBits[num] ^= BitSet.bitMask(i);
			}
		}

		private static int numWordsToHold(int el)
		{
			return (el >> 6) + 1;
		}

		public static BitSet of(int el)
		{
			BitSet bitSet = new BitSet(el + 1);
			bitSet.add(el);
			return bitSet;
		}

		public virtual BitSet or(BitSet a)
		{
			BitSet bitSet = (BitSet)this.Clone();
			bitSet.orInPlace(a);
			return bitSet;
		}

		public virtual void orInPlace(BitSet a)
		{
			if (a.dataBits.Length > this.dataBits.Length)
			{
				this.setSize(a.dataBits.Length);
			}
			int num = Math.Min(this.dataBits.Length, a.dataBits.Length);
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				this.dataBits[num2] |= a.dataBits[num2];
			}
		}

		public virtual void remove(int el)
		{
			int num = BitSet.wordNumber(el);
			if (num >= this.dataBits.Length)
			{
				this.growToInclude(el);
			}
			this.dataBits[num] &= ~BitSet.bitMask(el);
		}

		private void setSize(int nwords)
		{
			long[] destinationArray = new long[nwords];
			int length = Math.Min(nwords, this.dataBits.Length);
			Array.Copy(this.dataBits, 0, destinationArray, 0, length);
			this.dataBits = destinationArray;
		}

		public virtual int size()
		{
			return this.dataBits.Length << 6;
		}

		public virtual int lengthInLongWords()
		{
			return this.dataBits.Length;
		}

		public virtual bool subset(BitSet a)
		{
			if (a == null)
			{
				return false;
			}
			return this.and(a).Equals(this);
		}

		public virtual void subtractInPlace(BitSet a)
		{
			if (a != null)
			{
				for (int i = 0; i < this.dataBits.Length && i < a.dataBits.Length; i++)
				{
					this.dataBits[i] &= ~a.dataBits[i];
				}
			}
		}

		public virtual int[] toArray()
		{
			int[] array = new int[this.degree()];
			int num = 0;
			for (int i = 0; i < this.dataBits.Length << 6; i++)
			{
				if (this.member(i))
				{
					array[num++] = i;
				}
			}
			return array;
		}

		public virtual long[] toPackedArray()
		{
			return this.dataBits;
		}

		public override string ToString()
		{
			return this.ToString(",");
		}

		public virtual string ToString(string separator)
		{
			string text = "";
			for (int i = 0; i < this.dataBits.Length << 6; i++)
			{
				if (this.member(i))
				{
					if (text.Length > 0)
					{
						text += separator;
					}
					text += i;
				}
			}
			return text;
		}

		public virtual string ToString(string separator, ArrayList vocabulary)
		{
			if (vocabulary == null)
			{
				return this.ToString(separator);
			}
			string text = "";
			for (int i = 0; i < this.dataBits.Length << 6; i++)
			{
				if (this.member(i))
				{
					if (text.Length > 0)
					{
						text += separator;
					}
					if (i >= vocabulary.Count)
					{
						object obj = text;
						text = obj + "<bad element " + i + ">";
					}
					else if (vocabulary[i] == null)
					{
						object obj2 = text;
						text = obj2 + "<" + i + ">";
					}
					else
					{
						text += (string)vocabulary[i];
					}
				}
			}
			return text;
		}

		public virtual string toStringOfHalfWords()
		{
			string text = new string("".ToCharArray());
			for (int i = 0; i < this.dataBits.Length; i++)
			{
				if (i != 0)
				{
					text += ", ";
				}
				long num = this.dataBits[i];
				num &= 4294967295u;
				text = text + num + "UL";
				text += ", ";
				num = BitSet.URShift(this.dataBits[i], 32);
				num &= 4294967295u;
				text = text + num + "UL";
			}
			return text;
		}

		public virtual string toStringOfWords()
		{
			string text = new string("".ToCharArray());
			for (int i = 0; i < this.dataBits.Length; i++)
			{
				if (i != 0)
				{
					text += ", ";
				}
				text = text + this.dataBits[i] + "L";
			}
			return text;
		}

		private static int wordNumber(int bit)
		{
			return bit >> 6;
		}

		public static int URShift(int number, int bits)
		{
			if (number >= 0)
			{
				return number >> bits;
			}
			return (number >> bits) + (2 << ~bits);
		}

		public static int URShift(int number, long bits)
		{
			return BitSet.URShift(number, (int)bits);
		}

		public static long URShift(long number, int bits)
		{
			if (number >= 0)
			{
				return number >> bits;
			}
			return (number >> bits) + (2L << ~bits);
		}

		public static long URShift(long number, long bits)
		{
			return BitSet.URShift(number, (int)bits);
		}
	}
}
