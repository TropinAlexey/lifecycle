using System;

namespace TestUtils
{
    public static class TestDataGenerators
    {
        private static Random _rnd = new Random();
        private static string _validNameChars = "DFGHJKLNPRSTXYZ";

        /// <summary>
        /// Generate random Name.
        /// </summary>
        /*public static string GenerateRandomName()
        {
            int type = _rnd.Next(1, 9);
            string Name = null;
            switch (type)
            {
                case 1: // 99-AA-99
                    Name = string.Format("{0:00}-{1}-{2:00}", _rnd.Next(1, 99), GenerateRandomCharacters(2), _rnd.Next(1, 99));
                    break;
                case 2: // AA-99-AA
                    Name = string.Format("{0}-{1:00}-{2}", GenerateRandomCharacters(2), _rnd.Next(1, 99), GenerateRandomCharacters(2));
                    break;
                case 3: // AA-AA-99
                    Name = string.Format("{0}-{1}-{2:00}", GenerateRandomCharacters(2), GenerateRandomCharacters(2), _rnd.Next(1, 99));
                    break;
                case 4: // 99-AA-AA
                    Name = string.Format("{0:00}-{1}-{2}", _rnd.Next(1, 99), GenerateRandomCharacters(2), GenerateRandomCharacters(2));
                    break;
                case 5: // 99-AAA-9
                    Name = string.Format("{0:00}-{1}-{2}", _rnd.Next(1, 99), GenerateRandomCharacters(3), _rnd.Next(1, 10));
                    break;
                case 6: // 9-AAA-99
                    Name = string.Format("{0}-{1}-{2:00}", _rnd.Next(1, 9), GenerateRandomCharacters(3), _rnd.Next(1, 10));
                    break;
                case 7: // AA-999-A
                    Name = string.Format("{0}-{1:000}-{2}", GenerateRandomCharacters(2), _rnd.Next(1, 999), GenerateRandomCharacters(1));
                    break;
                case 8: // A-999-AA
                    Name = string.Format("{0}-{1:000}-{2}", GenerateRandomCharacters(1), _rnd.Next(1, 999), GenerateRandomCharacters(2));
                    break;
            }

            return Name;
        }

        private static string GenerateRandomCharacters(int amount)
        {
            char[] chars = new char[amount];
            for (int i = 0; i < amount; i++)
            {
                chars[i] = _validNameChars[_rnd.Next(_validNameChars.Length - 1)];
            }
            return new string(chars);
        }*/
    }
}
