using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QLDSVFPOLY.Blazor.Utilities
{
    public class Utility
    {
        //Phương thức bỏ toàn bộ dấu trong tiếng việt
        public static string LoaiBoDauTiengViet(string str)
        {
            if (str != null)
            {
                string strFormD = str.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < strFormD.Length; i++)
                {
                    System.Globalization.UnicodeCategory uc =
                    System.Globalization.CharUnicodeInfo.GetUnicodeCategory(strFormD[i]);
                    if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(strFormD[i]);
                    }
                }
                sb = sb.Replace('Đ', 'D');
                sb = sb.Replace('đ', 'd');

                return (sb.ToString().Normalize(NormalizationForm.FormD));
            }

            return null;
        }

        public bool CheckNull(string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            return true;
        }

        public bool CheckMa(string input)
        {
            Regex rgx = new Regex("^[A-Za-z0-9]+$"); //Chỉ chứa chữ và số
            if (!rgx.IsMatch(input)) return false;
            return true;
        }

        public bool CheckName(string input)
        {
            Regex rgx = new Regex(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$"); //Chỉ chứa chữ và dấu cách
            if (!rgx.IsMatch(LoaiBoDauTiengViet(input))) return false;
            return true;
        }

        public bool CheckDC(string input)
        {
            Regex rgx = new Regex("^[A-Za-z0-9 ]+,+$"); //Chỉ chứa chữ, số, dấu cách và ","
            if (!rgx.IsMatch(LoaiBoDauTiengViet(input))) return false;
            return true;
        }

        public bool CheckSDT(string input)
        {
            Regex rgx = new Regex("(\\+84|0)\\d{9,10}"); //SDT chuẩn format VN
            if (!rgx.IsMatch(input)) return false;
            return true;
        }
    }
}
