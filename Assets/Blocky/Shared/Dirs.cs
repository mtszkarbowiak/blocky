namespace AuroraSeeker.Blocky.Shared
{
    /// <summary>
    /// <para>Set of Axis-Aligned directions flags.</para>
    /// <para>Bit scheme: [in][-x][+x][-y][+y][-z][+z]</para>
    /// </summary>
    [System.Flags]
    public enum Dirs : byte
    {
        None    = 0b_0_00_00_00,
        
        All     = 0b_1_11_11_11,
        Out     = 0b_0_11_11_11,
        In      = 0b_1_00_00_00,
        
        Left    = 0b_0_10_00_00,
        Right   = 0b_0_01_00_00,
        
        Down    = 0b_0_00_10_00,
        Up      = 0b_0_00_01_00,
        
        Back    = 0b_0_00_00_10,
        Front   = 0b_0_00_00_01,
        
        
        AxisXe  = 0b_0_11_00_00,
        AxisYe  = 0b_0_00_11_00,
        AxisZe  = 0b_0_00_00_11,
        
        AxisXi  = 0b_0_11_00_00,
        AxisYi  = 0b_0_00_11_00,
        AxisZi  = 0b_0_00_00_11,
        
        PlaneXYe = 0b_0_11_11_00,
        PlaneXZe = 0b_0_11_00_11,
        PlaneYZe = 0b_0_00_11_11,
        
        PlaneXYi = 0b_1_11_11_00,
        PlaneXZi = 0b_1_11_00_11,
        PlaneYZi = 0b_1_00_11_11,
    }
}