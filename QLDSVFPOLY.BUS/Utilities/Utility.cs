using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QLDSVFPOLY.BUS.Utilities
{
    public class Utility
    {
        //
        List<GiangVien> _listGiangViens;
        List<SinhVien> _listSinhViens;
        List<NhanVienDaoTao> _list;

        //Phương thức loại bỏ toàn bộ dấu trong tiếng việt
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

        ////
        //public bool CheckNull(string input)
        //{
        //    if (input.Length == 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


        //
        public bool CheckMa(string input)
        {
            Regex rgx = new Regex("^[A-Za-z0-9]+$"); //Chỉ chứa chữ và số
            if (!rgx.IsMatch(input)) return false;
            return true;
        }

        //
        public bool CheckName(string input)
        {
            Regex rgx = new Regex(@"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$"); //Chỉ chứa chữ và dấu cách
            if (!rgx.IsMatch(LoaiBoDauTiengViet(input))) return false;
            return true;
        }

        //
        public bool CheckDC(string input)
        {
            Regex rgx = new Regex("^[A-Za-z0-9 ]+[,]+[A-Za-z0-9 ]+$"); //Chỉ chứa chữ, số, dấu cách và ","
            if (!rgx.IsMatch(LoaiBoDauTiengViet(input))) return false;
            return true;
        }

        //
        public bool CheckSDT(string input)
        {
            Regex rgx = new Regex("(\\+84|0)\\d{9,10}"); //SDT chuẩn format VN
            if (!rgx.IsMatch(input)) return false;
            return true;
        }

        //
        public string ZenMaTuDong()
        {
            if (_listGiangViens.Count == 0) return "GV00000";
            if (_listSinhViens.Count == 0) return "SV00000";
            if (_list.Count == 0) return "NV00000";

            string middleMa = "";

            string lastMa1 = (_listGiangViens.Max(x => Convert.ToInt32(x.Ma.Substring(2, x.Ma.Length - 2))) + 1).ToString();
            string lastMa2 = (_listSinhViens.Max(x => Convert.ToInt32(x.Ma.Substring(2, x.Ma.Length - 2))) + 1).ToString();
            string lastMa3 = (_list.Max(x => Convert.ToInt32(x.Ma.Substring(2, x.Ma.Length - 2))) + 1).ToString();

            if (lastMa1.Length == 1) middleMa = "000";
            if (lastMa1.Length == 2) middleMa = "00";

            if (lastMa2.Length == 1) middleMa = "000";
            if (lastMa2.Length == 2) middleMa = "00";

            if (lastMa3.Length == 1) middleMa = "000";
            if (lastMa3.Length == 2) middleMa = "00";

            return "GV" + middleMa + lastMa1;
            return "SV" + middleMa + lastMa2;
            return "NV" + middleMa + lastMa3;
        }

        //Tạo Tên đăng nhập với Tên và Mã truyền vào
        public string GetTenDN(string ten, string ma)
        {
            var temp = LoaiBoDauTiengViet(ten);

            string[] nameParts = temp.Split(' ');
            string name = nameParts[nameParts.Length - 1];
            string afterName = null;

            for (int i = 0; i < nameParts.Length - 1; i++)
            {
                afterName += nameParts[i][0];
            }

            return (name + afterName + ma).ToLower();
        }

    }
}
