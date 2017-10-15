using System.Text.RegularExpressions;

namespace Packt.CS7
{
    public static class MyExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            //입력된 문자열이 유효한 이메일 주소인지
            //간단한 정규 표현식을 써서 검증한다.
            return Regex.IsMatch(input,
              @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}
