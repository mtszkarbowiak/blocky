using System.Collections.Generic;
using AuroraSeeker.Blocky.Shared.Serialization.Exceptions;

namespace AuroraSeeker.Blocky.Shared.Serialization.Buffers
{
    public class ResizableByteBuffer : IByteBuffer
    {
        private readonly List<byte> _buffer;
        private int _readerCounter;
        private bool _isWriting = false;

        public ResizableByteBuffer(int capacity = 8)
        {
            _buffer = new List<byte>(capacity);
        }

        public void RestartForWriting()
        {
            _buffer.Clear();
            _isWriting = true;
        }
        
        public void RestartForReading()
        {
            _readerCounter = 0;
            _isWriting = false;
        }
        
        public byte ReadNext()
        {
#if DEBUG
            if (_isWriting) throw new BufferNotResetException();
            if (_buffer.Count == _readerCounter) throw new BufferOutOfRangeException();
#endif
            
            return _buffer[_readerCounter++];
        }

        public void WriteNext(byte b)
        {
#if DEBUG
            if (_isWriting == false) throw new BufferNotResetException();
#endif
            
            _buffer.Add(b);
        }
    }
}