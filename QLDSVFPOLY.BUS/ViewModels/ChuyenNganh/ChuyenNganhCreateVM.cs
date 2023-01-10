using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.ViewModels.ChuyenNganh
{
    public class ChuyenNganhCreateVM
    {
        [Required(ErrorMessage = "Mã chuyên ngành không được để trống")]
        [MaxLength(10, ErrorMessage = "Mã chuyên ngành không qua 10 tự")]
        public string Ma { get; set; }

        [Required(ErrorMessage = "Tên chuyên ngành không được để trống")]
        [MaxLength(50, ErrorMessage = "Tên chuyên ngành không qua 50 tự")]
        [RegularExpression(@"^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ ]+$", ErrorMessage = "Không điền các kí tự đặc biệt")]
        public string TenNganhHoc { get; set; }

        public string DuongDanAnh { get; set; }

        public DateTime NgayTao { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái")]
        public int TrangThai { get; set; }

        public Guid? IdChuyenNganh { get; set; }

        public Guid IdDaoTao { get; set; }
    }
}
