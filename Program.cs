using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Please Selcet an option: ");
            Console.WriteLine("[1] Generate random numbers\t\t [2] Generate random string");
            int _selectedOption = int.Parse(Console.ReadLine());
            if (_selectedOption == 1)
            {
                Console.WriteLine("Enter your rnage: ");
                Console.Write("Min value: ");
                int _minValue = int.Parse(Console.ReadLine());
                Console.Write("Max value: ");
                int _maxValue = int.Parse(Console.ReadLine());
                Console.WriteLine($"Random Number: {GenerateRandomNumber(_minValue, _maxValue)}");
            }
            else
            {
                Console.WriteLine("Enter the length of the string: ");
                int _stringLength = int.Parse(Console.ReadLine());
                Console.WriteLine("Select Buffer Options: ");
                string _needed;
                bool _needCapital = false, _needSmall = false, _needNumber = false, _needSpecial = false;

                Console.WriteLine("[1] Include capital letters? (yes/no)");
                _needed = Console.ReadLine();
                if (CheckCase(_needed))
                    _needCapital = true; 

                Console.WriteLine("[2] Include small letters? (yes/no)");
                _needed = Console.ReadLine();
                if (CheckCase(_needed))
                    _needSmall = true;

                Console.WriteLine("[3] Include numbers? (yes/no)");
                _needed = Console.ReadLine();
                if (CheckCase(_needed))
                    _needNumber = true;

                Console.WriteLine("[4] Include symbols? (yes/no)");
                _needed = Console.ReadLine();
                if (CheckCase(_needed))
                    _needSpecial = true;
                Console.WriteLine($"Random String: {GenerateRandomString(_stringLength, _needCapital, _needSmall, _needNumber, _needSpecial)}");
            }
            Console.WriteLine("===========================================");
        }
    }
    static int GenerateRandomNumber(int _min, int _max)
    {
        var _rnd = new Random();
        int _value = _rnd.Next(_min, _max);
        return _value;
    }
    private const string Buffer1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Buffer2 = "abcdefghijklmnopqrstuvwxyz";
    private const string Buffer3 = "123456789";
    private const string Buffer4 = "~!@#$%^&*()";
    static string GenerateRandomString(int _length, bool _needCapital, bool _needSmall, bool _needNumber, bool _needSpecial)
    {
        var _finalString = new StringBuilder();
        if (_needCapital)
            _finalString.Append(Buffer1); 
        if (_needSmall)
            _finalString.Append(Buffer2);
        if (_needNumber)
            _finalString.Append(Buffer3);
        if (_needSpecial)
            _finalString.Append(Buffer4);
        Random _rnd = new Random();
        StringBuilder _stringBuilder = new StringBuilder();
        while(_stringBuilder.Length < _length)
        {
            int _index = _rnd.Next(0, _finalString.Length - 1);
            _stringBuilder.Append(_finalString[_index]);
        }
        return _stringBuilder.ToString();
    }
    static bool CheckCase(string _input)
    {
        _input = _input.ToLower();
        return (_input == "yes");
    }
}
