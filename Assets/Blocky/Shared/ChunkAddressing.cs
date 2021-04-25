using System;
using System.Runtime.CompilerServices;

namespace AuroraSeeker.Blocky.Shared
{
    public static class ChunkAddressing
    {
        public const int ChunkSizeBitShift = 5;

        public const int ChunkSize1D = 1 << ChunkSizeBitShift * 1;
        public const int ChunkSize2D = 1 << ChunkSizeBitShift * 2;
        public const int ChunkSize3D = 1 << ChunkSizeBitShift * 3;
        
        private const ushort XMask = ~(~0 << ChunkSizeBitShift * 3); 
        private const ushort YMask = ~(~0 << ChunkSizeBitShift * 2); 
        private const ushort ZMask = ~(~0 << ChunkSizeBitShift); 
        private const ushort IndexMask = XMask | YMask | ZMask;
        
        
        private static bool IsValidCoord(this int i) => i == (i & ZMask);
        private static bool IsValidIndex(this int i) => i == (i & IndexMask);
        
        private static bool IsValidCoord(this ushort i) => i == (i & ZMask);
        private static bool IsValidIndex(this ushort i) => i == (i & IndexMask);
        
        
        public static ushort UnpackX(this ushort u) => UnpackX((int) u);
        public static ushort UnpackY(this ushort u) => UnpackY((int) u);
        public static ushort UnpackZ(this ushort u) => UnpackZ((int) u);
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort UnpackX(this int i)
        {
#if DEBUG
            if (!IsValidIndex(i)) throw new ArgumentException("Invalid index.");
#endif
            
            return (ushort) ((i & XMask) >> ChunkSizeBitShift * 2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort UnpackY(this int i)
        {
#if DEBUG
            if (!IsValidIndex(i)) throw new ArgumentException("Invalid index.");
#endif
            
            return (ushort) ((i & YMask) >> ChunkSizeBitShift);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort UnpackZ(this int i)
        {
#if DEBUG
            if (!IsValidIndex(i)) throw new ArgumentException("Invalid index.");
#endif
            
            return (ushort) ((i & ZMask) >> 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort PackAddress(ushort x, ushort y, ushort z)
        {
#if DEBUG
            if (!IsValidCoord(x)) throw new ArgumentException("Invalid X coord.");
            if (!IsValidCoord(y)) throw new ArgumentException("Invalid Y coord.");
            if (!IsValidCoord(z)) throw new ArgumentException("Invalid Z coord.");
#endif
            
            var index = x;
            
            index <<= ChunkSizeBitShift;
            index |= y;
            index <<= ChunkSizeBitShift;
            index |= z;

            return index;
        }
    }
}