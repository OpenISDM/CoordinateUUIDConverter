using System;

namespace CoordinateUUIDConverter
{
    public static class Converter
    {
        public static string ToUUID(this Coordinate coordinate)
        {
            byte[] lonBytes = BitConverter.GetBytes(coordinate.Longitude);
            byte[] latBytes = BitConverter.GetBytes(coordinate.Latitude);
            byte[] floorByte = BitConverter.GetBytes(coordinate.Floor);

            string[] buffer = new string[4];

            for (int i = 0; i < 2; i++)
            {
                string lonHex = Convert.ToString(lonBytes[i * 2], 16).PadLeft(2, '0') + Convert.ToString(lonBytes[i * 2 + 1], 16).PadLeft(2, '0');
                string latHex = Convert.ToString(latBytes[i * 2], 16).PadLeft(2, '0') + Convert.ToString(latBytes[i * 2 + 1], 16).PadLeft(2, '0');
                buffer[i + 2] = lonHex;
                buffer[i] = latHex;
            }

            string floorHex = Convert.ToString(floorByte[0], 16).PadLeft(2,'0') + 
                Convert.ToString(floorByte[1], 16).PadLeft(2, '0') + 
                Convert.ToString(floorByte[2], 16).PadLeft(2, '0') + 
                Convert.ToString(floorByte[3], 16).PadLeft(2, '0');

            return floorHex + "-0000-" + buffer[0] + "-" + buffer[1] + "-0000" + buffer[2] + buffer[3];
        }

        public static Coordinate ToCoordinate(this Guid Id)
        {
            string[] idShards = Id.ToString().Split('-');
            string latHexStr = idShards[2] + idShards[3];
            string lonHexStr = idShards[4].Substring(4, 8);
            string floorHexStr = idShards[0];

            return new Coordinate (
                HexToFloat(latHexStr),
                HexToFloat(lonHexStr),
                HexToFloat(floorHexStr)
            );
        }

        /// <summary>
        /// Convert hex string content to a float.
        /// 0xff20f342 -> 121.564445f
        /// </summary>
        /// <param name="Hex"></param>
        /// <returns></returns>
        private static float HexToFloat(string Hex)
        {
            // Hex string content to a byte array.
            byte[] Bytes = new byte[4];
            Bytes[0] = Convert.ToByte(Hex.Substring(0, 2), 16);
            Bytes[1] = Convert.ToByte(Hex.Substring(2, 2), 16);
            Bytes[2] = Convert.ToByte(Hex.Substring(4, 2), 16);
            Bytes[3] = Convert.ToByte(Hex.Substring(6, 2), 16);

            // byte array to a float.
            return BitConverter.ToSingle(Bytes, 0);
        }
    }

    public class Coordinate
    {
        public float Longitude { get; }
        public float Latitude { get; }
        public float Floor { get; }

        public Coordinate(float latitude, float longitude, float floor)
        {
            if (latitude < 0 || latitude > 90)
                throw new Exception("0 <= Latitude >= 90");

            if (longitude < -180 || longitude > 180)
                throw new Exception("-180 <= Longitude >= 180");

            Longitude = longitude;
            Latitude = latitude;
            Floor = floor;
        }
    }
}
