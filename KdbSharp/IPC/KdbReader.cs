using KdbSharp.Data;
using System;
using System.IO;
using System.Text;

namespace KdbSharp.IPC
{
    public class KdbReader
    {
        private readonly Stream _stream;
        private readonly BinaryReader _reader;

        private int _index;

        public KdbReader(Stream stream)
        {
            _stream = stream;
            _reader = new BinaryReader(stream);
        }

        public IKdbType Read()
        {
            var header = _reader.ReadBytes(4);
            var messageType = (KdbMessageType)header[1];
            if (messageType != KdbMessageType.Response)
            {
                throw new NotImplementedException();
            }
            var compressed = header[2] == 1;
            var messageSize = _reader.ReadInt32();
            var dataSize = Math.Max(messageSize - 8, 0);
            var data = (compressed ? Decompress(_reader.ReadBytes(dataSize)) : _reader.ReadBytes(dataSize)).AsSpan();

            _index = 0;
            return ParseObject(data);
        }

        private byte[] Decompress(byte[] data)
        {
            var decompressedSize = BitConverter.ToInt32(data, 0) - 8;
            var decompressed = new byte[decompressedSize];
            var buffer = new int[256];
            short i = 0;
            var n = 0;
            var f = 0;
            var s = 0;
            var p = 0;
            var d = 4;

            while (s < decompressedSize)
            {
                if (i == 0)
                {
                    f = 0xff & data[d++];
                    i = 1;
                }
                if ((f & i) != 0)
                {
                    var r = buffer[0xff & data[d++]];
                    decompressed[s++] = decompressed[r++];
                    decompressed[s++] = decompressed[r++];
                    n = 0xff & data[d++];
                    for (var m = 0; m < n; m++)
                    {
                        decompressed[s + m] = decompressed[r + m];
                    }
                }
                else
                {
                    decompressed[s++] = data[d++];
                }

                while (p < s - 1)
                {
                    buffer[(0xff & decompressed[p]) ^ (0xff & decompressed[p + 1])] = p++;
                }

                if ((f & i) != 0)
                {
                    p = s += n;
                }
                i *= 2;

                if (i == 256)
                {
                    i = 0;
                }
            }

            return decompressed;
        }

        private IKdbType ParseObject(ReadOnlySpan<byte> data)
        {
            var type = (KdbType)(sbyte)GetByte(data);
            return type switch
            {
                KdbType.List => ParseList(data, type),
                KdbType.BoolAtom => ParseAtom(data, type),
                KdbType.BoolVector => ParseVector(data, type),
                KdbType.GuidAtom => ParseAtom(data, type),
                KdbType.GuidVector => ParseVector(data, type),
                KdbType.ByteAtom => ParseAtom(data, type),
                KdbType.ByteVector => ParseVector(data, type),
                KdbType.ShortAtom => ParseAtom(data, type),
                KdbType.ShortVector => ParseVector(data, type),
                KdbType.IntAtom => ParseAtom(data, type),
                KdbType.IntVector => ParseVector(data, type),
                KdbType.LongAtom => ParseAtom(data, type),
                KdbType.LongVector => ParseVector(data, type),
                KdbType.RealAtom => ParseAtom(data, type),
                KdbType.RealVector => ParseVector(data, type),
                KdbType.FloatAtom => ParseAtom(data, type),
                KdbType.FloatVector => ParseVector(data, type),
                KdbType.CharAtom => ParseAtom(data, type),
                KdbType.CharVector => ParseVector(data, type),
                KdbType.SymbolAtom => ParseAtom(data, type),
                KdbType.SymbolVector => ParseVector(data, type),
                KdbType.TimestampAtom => ParseAtom(data, type),
                KdbType.TimestampVector => ParseVector(data, type),
                KdbType.MonthAtom => ParseAtom(data, type),
                KdbType.MonthVector => ParseVector(data, type),
                KdbType.DateAtom => ParseAtom(data, type),
                KdbType.DateVector => ParseVector(data, type),
                KdbType.DatetimeAtom => ParseAtom(data, type),
                KdbType.DatetimeVector => ParseVector(data, type),
                KdbType.TimespanAtom => ParseAtom(data, type),
                KdbType.TimespanVector => ParseVector(data, type),
                KdbType.MinuteAtom => ParseAtom(data, type),
                KdbType.MinuteVector => ParseVector(data, type),
                KdbType.SecondAtom => ParseAtom(data, type),
                KdbType.SecondVector => ParseVector(data, type),
                KdbType.TimeAtom => ParseAtom(data, type),
                KdbType.TimeVector => ParseVector(data, type),
                KdbType.Table => throw new NotImplementedException(),
                KdbType.Dictionary => throw new NotImplementedException(),
                KdbType.Lambda => throw new NotImplementedException(),
                KdbType.UnaryPrimitive => throw new NotImplementedException(),
                KdbType.Operator => throw new NotImplementedException(),
                KdbType.Iterator => throw new NotImplementedException(),
                KdbType.Projection => throw new NotImplementedException(),
                KdbType.Composition => throw new NotImplementedException(),
                KdbType.MapEach => throw new NotImplementedException(),
                KdbType.AccumulatorOver => throw new NotImplementedException(),
                KdbType.AccumulatorScan => throw new NotImplementedException(),
                KdbType.MapEachPrior => throw new NotImplementedException(),
                KdbType.MapEachRight => throw new NotImplementedException(),
                KdbType.MapEachLeft => throw new NotImplementedException(),
                KdbType.Exception => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseList(ReadOnlySpan<byte> data, KdbType type)
        {
            var attribute = (KdbAttribute)GetByte(data);
            var length = GetInt(data);

            var value = new IKdbType[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = ParseObject(data);
            }

            return type switch
            {
                KdbType.List => new KdbList(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            return type switch
            {
                KdbType.BoolAtom => ParseByteAtom(data, type),
                KdbType.GuidAtom => ParseGuidAtom(data, type),
                KdbType.ByteAtom => ParseByteAtom(data, type),
                KdbType.ShortAtom => ParseShortAtom(data, type),
                KdbType.IntAtom => ParseIntAtom(data, type),
                KdbType.LongAtom => ParseLongAtom(data, type),
                KdbType.RealAtom => ParseFloatAtom(data, type),
                KdbType.FloatAtom => ParseDoubleAtom(data, type),
                KdbType.CharAtom => ParseCharAtom(data, type),
                KdbType.SymbolAtom => ParseStringAtom(data, type),
                KdbType.TimestampAtom => ParseLongAtom(data, type),
                KdbType.MonthAtom => ParseIntAtom(data, type),
                KdbType.DateAtom => ParseIntAtom(data, type),
                KdbType.DatetimeAtom => ParseDoubleAtom(data, type),
                KdbType.TimespanAtom => ParseLongAtom(data, type),
                KdbType.MinuteAtom => ParseIntAtom(data, type),
                KdbType.SecondAtom => ParseIntAtom(data, type),
                KdbType.TimeAtom => ParseIntAtom(data, type),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseByteAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetByte(data);

            return type switch
            {
                KdbType.BoolAtom => new KdbBoolAtom(value),
                KdbType.ByteAtom => new KdbByteAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseGuidAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetGuid(data);

            return type switch
            {
                KdbType.GuidAtom => new KdbGuidAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseShortAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetShort(data);

            return type switch
            {
                KdbType.ShortAtom => new KdbShortAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseIntAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetInt(data);

            return type switch
            {
                KdbType.IntAtom => new KdbIntAtom(value),
                KdbType.MonthAtom => new KdbMonthAtom(value),
                KdbType.DateAtom => new KdbDateAtom(value),
                KdbType.MinuteAtom => new KdbMinuteAtom(value),
                KdbType.SecondAtom => new KdbSecondAtom(value),
                KdbType.TimeAtom => new KdbTimeAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseLongAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetLong(data);

            return type switch
            {
                KdbType.LongAtom => new KdbLongAtom(value),
                KdbType.TimestampAtom => new KdbTimestampAtom(value),
                KdbType.TimespanAtom => new KdbTimespanAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseFloatAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetFloat(data);

            return type switch
            {
                KdbType.RealAtom => new KdbRealAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseDoubleAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetDouble(data);

            return type switch
            {
                KdbType.FloatAtom => new KdbFloatAtom(value),
                KdbType.DatetimeAtom => new KdbDatetimeAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseCharAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var value = GetChar(data);

            return type switch
            {
                KdbType.CharAtom => new KdbCharAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseStringAtom(ReadOnlySpan<byte> data, KdbType type)
        {
            var stringBuilder = new StringBuilder();
            char c;
            while ((c = GetChar(data)) != 0)
            {
                stringBuilder.Append(c);
            }
            var value = stringBuilder.ToString();

            return type switch
            {
                KdbType.SymbolAtom => new KdbSymbolAtom(value),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseVector(ReadOnlySpan<byte> data, KdbType type)
        {
            var attribute = (KdbAttribute)GetByte(data);
            var length = GetInt(data);

            return type switch
            {
                KdbType.BoolVector => ParseByteVector(data, type, attribute, length),
                KdbType.GuidVector => ParseGuidVector(data, type, attribute, length),
                KdbType.ByteVector => ParseByteVector(data, type, attribute, length),
                KdbType.ShortVector => ParseShortVector(data, type, attribute, length),
                KdbType.IntVector => ParseIntVector(data, type, attribute, length),
                KdbType.LongVector => ParseLongVector(data, type, attribute, length),
                KdbType.RealVector => ParseFloatVector(data, type, attribute, length),
                KdbType.FloatVector => ParseDoubleVector(data, type, attribute, length),
                KdbType.CharVector => ParseCharVector(data, type, attribute, length),
                KdbType.SymbolVector => ParseStringVector(data, type, attribute, length),
                KdbType.TimestampVector => ParseLongVector(data, type, attribute, length),
                KdbType.MonthVector => ParseIntVector(data, type, attribute, length),
                KdbType.DateVector => ParseIntVector(data, type, attribute, length),
                KdbType.DatetimeVector => ParseDoubleVector(data, type, attribute, length),
                KdbType.TimespanVector => ParseLongVector(data, type, attribute, length),
                KdbType.MinuteVector => ParseIntVector(data, type, attribute, length),
                KdbType.SecondVector => ParseIntVector(data, type, attribute, length),
                KdbType.TimeVector => ParseIntVector(data, type, attribute, length),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseByteVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = GetBytes(data, length);

            return type switch
            {
                KdbType.BoolVector => new KdbBoolVector(value, attribute),
                KdbType.ByteVector => new KdbByteVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseGuidVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new Guid[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetGuid(data);
            }

            return type switch
            {
                KdbType.GuidVector => new KdbGuidVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseShortVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new short[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetShort(data);
            }

            return type switch
            {
                KdbType.ShortVector => new KdbShortVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseIntVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new int[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetInt(data);
            }

            return type switch
            {
                KdbType.IntVector => new KdbIntVector(value, attribute),
                KdbType.MonthVector => new KdbMonthVector(value, attribute),
                KdbType.DateVector => new KdbDateVector(value, attribute),
                KdbType.MinuteVector => new KdbMinuteVector(value, attribute),
                KdbType.SecondVector => new KdbSecondVector(value, attribute),
                KdbType.TimeVector => new KdbTimeVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseLongVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new long[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetLong(data);
            }

            return type switch
            {
                KdbType.LongVector => new KdbLongVector(value, attribute),
                KdbType.TimestampVector => new KdbTimestampVector(value, attribute),
                KdbType.TimespanVector => new KdbTimespanVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseFloatVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new float[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetFloat(data);
            }

            return type switch
            {
                KdbType.RealVector => new KdbRealVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseDoubleVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new double[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetDouble(data);
            }

            return type switch
            {
                KdbType.FloatVector => new KdbFloatVector(value, attribute),
                KdbType.DatetimeVector => new KdbDatetimeVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseCharVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new char[length];
            for (var i = 0; i < length; i++)
            {
                value[i] = GetChar(data);
            }

            return type switch
            {
                KdbType.CharVector => new KdbCharVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private IKdbType ParseStringVector(ReadOnlySpan<byte> data, KdbType type, KdbAttribute attribute, int length)
        {
            var value = new string[length];
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                char c;
                while ((c = GetChar(data)) != 0)
                {
                    stringBuilder.Append(c);
                }
                value[i] = stringBuilder.ToString();
                stringBuilder.Clear();
            }

            return type switch
            {
                KdbType.SymbolVector => new KdbSymbolVector(value, attribute),
                _ => throw new NotImplementedException(),
            };
        }

        private byte GetByte(ReadOnlySpan<byte> data) => data[_index++];
        private byte[] GetBytes(ReadOnlySpan<byte> data, int length)
        {
            var value = data[_index..(_index + length)].ToArray();
            _index += length;
            return value;
        }
        private Guid GetGuid(ReadOnlySpan<byte> data)
        {
            var value = data[_index..].FromKdbGuidBytes();
            _index += 16;
            return value;
        }
        private short GetShort(ReadOnlySpan<byte> data)
        {
            var value = BitConverter.ToInt16(data[_index..]);
            _index += sizeof(short);
            return value;
        }
        private int GetInt(ReadOnlySpan<byte> data)
        {
            var value = BitConverter.ToInt32(data[_index..]);
            _index += sizeof(int);
            return value;
        }
        private long GetLong(ReadOnlySpan<byte> data)
        {
            var value = BitConverter.ToInt64(data[_index..]);
            _index += sizeof(long);
            return value;
        }
        private float GetFloat(ReadOnlySpan<byte> data)
        {
            var value = BitConverter.ToSingle(data[_index..]);
            _index += sizeof(float);
            return value;
        }
        private double GetDouble(ReadOnlySpan<byte> data)
        {
            var value = BitConverter.ToDouble(data[_index..]);
            _index += sizeof(double);
            return value;
        }
        private char GetChar(ReadOnlySpan<byte> data) => (char)data[_index++];
    }
}
