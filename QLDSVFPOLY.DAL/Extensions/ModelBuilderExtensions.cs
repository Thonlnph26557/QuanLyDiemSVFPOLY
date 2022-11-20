﻿using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DTO.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaoTao>().HasData(
                new DaoTao() { Id = Guid.Parse("d28934df-0ead-4691-a5ad-2b64830e7267"), Ma = "DTCT", DiaChi = "Cần Thơ", SoDienThoai = "0292730046", Email = "dtctfpoly.daotao@fpt.edu.vn", TenDangNhap = "dtctfpoly", MatKhau = "dtctfpoly", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new DaoTao() { Id = Guid.Parse("0dbcd959-56ef-4489-b57b-406734dc05c0"), Ma = "DTDN", DiaChi = "Đà Nẵng", SoDienThoai = "0236371099", Email = "dtdnfpoly.daotao@fpt.edu.vn", TenDangNhap = "dtdnfpoly", MatKhau = "dtdnfpoly", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new DaoTao() { Id = Guid.Parse("10e3933f-66a1-42be-9e5f-c88bd749e17a"), Ma = "DTTN", DiaChi = "Tây Nguyên", SoDienThoai = "0262355567", Email = "dttnfpoly.daotao@fpt.edu.vn", TenDangNhap = "dttnfpoly", MatKhau = "dttnfpoly", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new DaoTao() { Id = Guid.Parse("2e184780-4509-4a63-8a16-a4dcf504d922"), Ma = "DTHCM", DiaChi = "Hồ Chí Minh", SoDienThoai = "0283526879", Email = "dthcmfpoly.daotao@fpt.edu.vn", TenDangNhap = "dthcmfpoly", MatKhau = "dthcmfpoly", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new DaoTao() { Id = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ma = "DTHN", DiaChi = "Hà Nội", SoDienThoai = "0247300195", Email = "dthnfpoly.daotao@fpt.edu.vn", TenDangNhap = "dthnfpoly", MatKhau = "dthnfpoly", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new DaoTao() { Id = Guid.Parse("f4628131-caad-448f-806e-d70902a5a7c9"), Ma = "DTHP", DiaChi = "Hải Phòng", SoDienThoai = "0915431313", Email = "dthpfpoly.daotao@fpt.edu.vn", TenDangNhap = "dthpfpoly", MatKhau = "dthpfpoly", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 }
                );

            modelBuilder.Entity<ChuyenNganh>().HasData(
                new ChuyenNganh() { Id = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ma = "IT", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = null, TenNganhHoc = "Công Nghệ Thông Tin", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ma = "MK", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = null, TenNganhHoc = "Quản Trị Kinh Doanh", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ma = "GD", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = null, TenNganhHoc = "Thiết kế đồ họa", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("4df4af59-444f-4921-aa2a-21c189f700c2"), Ma = "IT", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), TenNganhHoc = "Phát Triển Phần Mềm", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("e51debdc-d0be-40ba-b437-9b0e0c5c50ca"), Ma = "IT", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), TenNganhHoc = "Ứng Dụng Phần Mềm", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("de0d9abe-5349-4401-ba0e-e98f76117ef3"), Ma = "MK", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), TenNganhHoc = "Marketing & Sales", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("f3bdac9e-c6b8-4183-9b2f-e865182ddad0"), Ma = "MK", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), TenNganhHoc = "Digital Marketing", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("5c06096c-1d21-4e9f-bff7-d3c41671a1cd"), Ma = "IT", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), TenNganhHoc = "Lập Trình Web", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("f7919643-c337-4694-8245-47cd4cdae3cc"), Ma = "MK", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), TenNganhHoc = "Quan hệ công chúng và tổ chức sự kiện", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new ChuyenNganh() { Id = Guid.Parse("de4bc992-f17e-488d-86a2-accaf195c8bc"), Ma = "MK", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), TenNganhHoc = "Quản Trị Khách Sạn", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 }
                );

            modelBuilder.Entity<MonHoc>().HasData(
                new MonHoc() { Id = Guid.Parse("7c156c3a-d43d-4f67-bbad-6a8fa50a0ae5"), Ma = "WEB1013", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Xây dựng trang Web", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("0c002904-6c65-4b92-8c4a-906b72858174"), Ma = "WEB1043", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình cơ sở với JavaScript", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("5e2bb84a-626a-410d-a74f-73dbbc06c80b"), Ma = "WEB2014", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình PHP 1", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("f96e05e4-7f76-4d02-a6ef-2c63ed69d592"), Ma = "DOM105", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ten = "Marketing mạng xã hội", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("d2f20dcc-e8f8-4895-8d81-d1b09d67df27"), Ma = "COM1014", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Tin học cơ sở", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("2203ff23-4ca1-4a58-bcc4-8f3eb9e20d2d"), Ma = "COM108", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Nhập môn lập trình", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("1b0d6966-8ebb-4c20-bd8a-9d285fe96d2d"), Ma = "COM2012", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Cơ sở dữ liệu", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("4707e6da-6a44-460c-94ff-1d38f0dd3bda"), Ma = "COM2034", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Quản trị CSDL với SQLServer", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("7a27a952-39a1-43e8-b8f2-3416b3cf0b2c"), Ma = "MAR207", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ten = "Truyền thông Marketing tích hợp", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("456c2909-e5e1-413e-b0db-14ba36208904"), Ma = "MOB1014", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình Java 1", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("3b750f14-44c2-425f-a0b4-77746d5ac419"), Ma = "MOB1022", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình Java 2", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("c81f2a17-bc9d-498e-98e8-6c9ae5c3f617"), Ma = "MOB1023", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình Java 3", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("97564321-81bd-47f8-9f6b-2dae32b6231d"), Ma = "MUL116", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ten = "Nhập môn đồ họa", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("08a2e857-27dc-4f3d-8d12-497825170745"), Ma = "MUL117", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ten = "Kỹ thuật nhiếp ảnh 1", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("3fc46130-4bae-4072-afbb-792498ce90df"), Ma = "MUL2123", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ten = "Kỹ thuật nhiếp ảnh 2", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("cb7640ee-86d5-4465-808a-b946803261f4"), Ma = "MUL2133", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ten = "Thiết kế bao bì", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("d7f7aaea-d272-42ad-8445-db912c3501e5"), Ma = "MUL215", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ten = "Nghệ thuật chữ", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("06f73ded-5236-4cd3-93f1-8904060b880f"), Ma = "NET101", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình Csharp 1", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("bd48c20a-a5fd-4b86-9a27-f97baf109b1b"), Ma = "NET102", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình Csharp 2", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new MonHoc() { Id = Guid.Parse("10bc0d05-7f32-40dc-a98b-874d230a1814"), Ma = "NET103", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ten = "Lập trình Csharp 3", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 }
                );

            modelBuilder.Entity<SinhVien>().HasData(
                new SinhVien() { Id = Guid.Parse("b2ac736c-2f26-44c6-b2a3-fcf7a979279a"), Ma = "PH00001", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ho = "Nguyễn", TenDem = "Văn", Ten = "Minh", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 11), DiaChi = "Cầu Giấy, Hà Nội", SoDienThoai = "0987123456", Email = "minhnvph00001@fpt.edu.vn", TenDangNhap = "minhnvph00001", MatKhau = "minhnvph00001", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("9bfa9ba8-7119-437b-8bd8-51002cc60e33"), Ma = "PH00002", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ho = "Nguyễn", TenDem = "Hữu", Ten = "Huy", GioiTinh = 0, NgaySinh = new DateTime(2003, 11, 12), DiaChi = "Hai Bà Trưng, Hà Nội", SoDienThoai = "0985632147", Email = "huynhph00002@fpt.edu.vn", TenDangNhap = "huynhph00002", MatKhau = "huynhph00002", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("3ea559a0-39bc-4286-b405-5d4b56b595a9"), Ma = "PH00003", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Nguyễn", TenDem = "Sỹ", Ten = "Đức", GioiTinh = 0, NgaySinh = new DateTime(2003, 11, 13), DiaChi = "Đống Đa, Hà Nội", SoDienThoai = "0986753421", Email = "ducnsph00003@fpt.edu.vn", TenDangNhap = "ducnsph00003", MatKhau = "ducnsph00003", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("ebdace96-3b00-4602-a96c-4302751419af"), Ma = "PH00004", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Nguyễn", TenDem = "Hồng", Ten = "Giang", GioiTinh = 1, NgaySinh = new DateTime(2003, 11, 14), DiaChi = "Hoàn Kiếm, Hà Nội", SoDienThoai = "0394162841", Email = "giangnhph00004@fpt.edu.vn", TenDangNhap = "giangnhph00004", MatKhau = "giangnhph00004", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("8fa873a1-64cf-4adc-a256-43b6fa74691c"), Ma = "PH00005", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ho = "Nguyễn", TenDem = "Văn ", Ten = "Sơn", GioiTinh = 0, NgaySinh = new DateTime(2003, 11, 15), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0799756855", Email = "sonnvph00005@fpt.edu.vn", TenDangNhap = "sonnvph00005", MatKhau = "sonnvph00005", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("f5c02259-46db-4c60-9fa9-3cf85c570f78"), Ma = "PH00006", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ho = "Nguyễn", TenDem = "Thu", Ten = "Thảo", GioiTinh = 1, NgaySinh = new DateTime(2003, 11, 16), DiaChi = "Cầu Giấy, Hà Nội", SoDienThoai = "0191174183", Email = "thaontph00006@fpt.edu.vn", TenDangNhap = "thaontph00006", MatKhau = "thaontph00006", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("3c382276-2d8a-4930-b629-7cd38ac00a8c"), Ma = "PH00007", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Võ", TenDem = "Vân", Ten = "Anh", GioiTinh = 1, NgaySinh = new DateTime(2003, 11, 17), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0561692767", Email = "anhvvph00007@fpt.edu.vn", TenDangNhap = "anhvvph00007", MatKhau = "anhvvph00007", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("cc6927d1-d366-45ba-8fac-ca9d54c95b47"), Ma = "PH00008", IdChuyenNganh = Guid.Parse("d26286ef-2fad-40b2-954d-4b629fce5e67"), Ho = "Võ", TenDem = "Văn", Ten = "Đức", GioiTinh = 0, NgaySinh = new DateTime(2003, 11, 18), DiaChi = "Bắc Từ Liêm, Hà Nội", SoDienThoai = "0395162847", Email = "ducvvph00008@fpt.edu.vn", TenDangNhap = "ducvvph00008", MatKhau = "ducvvph00008", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("03d718d2-c0b7-4700-b5fd-b070153185cc"), Ma = "PH00009", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Võ", TenDem = "Nhật", Ten = "Linh", GioiTinh = 1, NgaySinh = new DateTime(2003, 11, 19), DiaChi = "Hoàng Mai, Hà Nội", SoDienThoai = "0395142841", Email = "linhvnph00009@fpt.edu.vn", TenDangNhap = "linhvnph00009", MatKhau = "linhvnph00009", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("ac3a5185-556c-42a2-bd3b-88480d30e379"), Ma = "PH00010", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Võ", TenDem = "Văn", Ten = "Thịnh", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 10), DiaChi = "Long Biên, Hà Nội", SoDienThoai = "0479740124", Email = "thinhvvph00010@fpt.edu.vn", TenDangNhap = "thinhvvph00010", MatKhau = "thinhvvph00010", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("af1d5926-1d6b-4dfe-b228-ff1e62458850"), Ma = "PH00011", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ho = "Võ", TenDem = "Thị", Ten = "Hoài", GioiTinh = 1, NgaySinh = new DateTime(2003, 10, 11), DiaChi = "Hà Đông, Hà Nội", SoDienThoai = "0304162845", Email = "hoaivtph00011@fpt.edu.vn", TenDangNhap = "hoaivtph00011", MatKhau = "hoaivtph00011", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("fea1ac50-220d-4295-8471-600ad28c43ac"), Ma = "PH00012", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Bùi", TenDem = "Minh", Ten = "Quang", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 12), DiaChi = "Long Biên, Hà Nội", SoDienThoai = "0395162847", Email = "quangbmph00012@fpt.edu.vn", TenDangNhap = "quangbmph00012", MatKhau = "quangbmph00012", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new SinhVien() { Id = Guid.Parse("710160e5-1760-4b31-b0ef-34481b382215"), Ma = "PH00013", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Bùi", TenDem = "Văn", Ten = "Bảo", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 13), DiaChi = "Nam Từ Liêm, Hà Nội", SoDienThoai = "0380118275", Email = "baobvph00013@fpt.edu.vn", TenDangNhap = "baobvph00013", MatKhau = "baobvph00013", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("2f9da9d4-7bd7-4686-9a4d-e7970d6c4908"), Ma = "PH00014", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ho = "Bùi", TenDem = "Hà", Ten = "Trung", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 14), DiaChi = "Hoàn Kiếm, Hà Nội", SoDienThoai = "0374562531", Email = "trungbhph00014@fpt.edu.vn", TenDangNhap = "trungbhph00014", MatKhau = "trungbhph00014", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("a129290f-3410-440b-b25a-b121f3629adf"), Ma = "PH00015", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Bùi", TenDem = "Thị", Ten = "Thoa", GioiTinh = 1, NgaySinh = new DateTime(2003, 10, 15), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0305182872", Email = "thoabtph00015@fpt.edu.vn", TenDangNhap = "thoabtph00015", MatKhau = "thoabtph00015", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("73696c49-fabd-4d51-9af5-9689038e5b90"), Ma = "PH00016", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Bùi", TenDem = "Mạnh", Ten = "Quỳnh", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 16), DiaChi = "Cầu Giấy, Hà Nội", SoDienThoai = "0380118275", Email = "quynhbmph00016@fpt.edu.vn", TenDangNhap = "quynhbmph00016", MatKhau = "quynhbmph00016", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("4184e7d6-5f1d-4f9e-ab36-118f6d329cf5"), Ma = "PH00017", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ho = "Phạm", TenDem = "Nhật", Ten = "Vượng", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 17), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0595162841", Email = "vuongpnph00017@fpt.edu.vn", TenDangNhap = "vuongpnph00017", MatKhau = "vuongpnph00017", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("b7d8c2f5-d04e-4b2c-be54-916798b6bc9f"), Ma = "PH00018", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Phạm", TenDem = "Thu", Ten = "Hằng", GioiTinh = 1, NgaySinh = new DateTime(2003, 10, 18), DiaChi = "Bắc Từ Liêm, Hà Nội", SoDienThoai = "0968790553", Email = "hangptph00018@fpt.edu.vn", TenDangNhap = "hangptph00018", MatKhau = "hangptph00018", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("b88170d1-b02c-4ed6-b726-dbd83623c449"), Ma = "PH00019", IdChuyenNganh = Guid.Parse("38044b9b-b9bc-4407-b894-f91e0f4e529b"), Ho = "Phạm", TenDem = "Thị", Ten = "Hảo", GioiTinh = 1, NgaySinh = new DateTime(2003, 10, 19), DiaChi = "Hoàng Mai, Hà Nội", SoDienThoai = "0935142805", Email = "haoptph00019@fpt.edu.vn", TenDangNhap = "haoptph00019", MatKhau = "haoptph00019", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                 new SinhVien() { Id = Guid.Parse("15f79ff0-3f22-4e6c-adb4-ee9e97912226"), Ma = "PH00020", IdChuyenNganh = Guid.Parse("73dceef8-eb08-41ce-abdc-8276f0f4b2ca"), Ho = "Phạm", TenDem = "Thành", Ten = "Hưng", GioiTinh = 0, NgaySinh = new DateTime(2003, 10, 20), DiaChi = "Long Biên, Hà Nội", SoDienThoai = "0369392123", Email = "hungptph00020@fpt.edu.vn", TenDangNhap = "hungptph00020", MatKhau = "hungptph00020", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 }
                );

            modelBuilder.Entity<LopHoc>().HasData(
                new LopHoc() { Id = Guid.Parse("5e9c699e-9d6c-4d47-bc0c-11972bd1758e"), Ma = "CP18101", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("220b7ac4-2377-45da-811d-a0a986268c0a"), Ma = "CP18102", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("574cdfa1-2412-42c7-b5f6-fc54def7a955"), Ma = "CP18103", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("600355bd-3414-4717-b3dd-aa22aa7768c9"), Ma = "GD16202", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("0513167f-fda0-4c6e-90ee-34c812e3418e"), Ma = "GD16204", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("b43efe8e-42d3-4f92-999e-edd9dc004dd6"), Ma = "GD18101", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("bd72bae4-2c63-41b1-8f2c-597db132fa0e"), Ma = "GD18102", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("26772412-c951-433f-a1a4-65152284c545"), Ma = "GD18103", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("47fba348-fb28-481e-a9a8-c367c546f3b8"), Ma = "GD18202", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("82267733-abd6-49a1-8201-eb0ce11bec51"), Ma = "GD18203", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("a131a50b-c9e2-4caa-a579-4945a2b3357a"), Ma = "GD18204", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("f2391bb3-9b4e-4cf5-83c2-b3ce283e2231"), Ma = "IT17300", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("038315ba-163b-4631-aa68-ea3532c8274b"), Ma = "IT17301", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("6cad426a-c62e-4eb5-a22e-80766d42d446"), Ma = "IT17302", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("a83eb26b-f732-4229-9ba3-e37864bd2cda"), Ma = "IT17303", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("a867a100-358f-4895-8989-011df9acfd2b"), Ma = "IT17331", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("fbccaa8b-021e-446c-9241-aa0bfb94832e"), Ma = "IT18101", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("a4ccd2e5-e7ca-498d-a344-b0de68b7c487"), Ma = "IT18102", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("4d75cb6a-5e46-4fac-a33d-88680433fff6"), Ma = "IT18103", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("07c83707-1e3d-4b41-8b87-b8b2ea1362e4"), Ma = "MA15120", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("e930b8cd-b83e-4825-a859-9032e33c3181"), Ma = "MA15211", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("f33da4f8-0bc9-4bc7-af3c-c0ec8e4513ed"), Ma = "MA11200", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new LopHoc() { Id = Guid.Parse("f64d007a-ac0a-4a5a-8173-b8b7315f8989"), Ma = "MA17112", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 }
                );

            modelBuilder.Entity<GiangVien>().HasData(
                new GiangVien() { Id = Guid.Parse("b55770cf-e4cc-4952-a3e3-f7b54aff08e4"), Ma = "GV001", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Nguyễn", TenDem = "Văn", Ten = "Anh", GioiTinh = 0, NgaySinh = new DateTime(1990, 11, 12), DiaChi = "Cầu Giấy, Hà Nội", SoDienThoai = "0987123451", Email = "anhnv@fpt.edu.vn", TenDangNhap = "anhnv", MatKhau = "anhnv", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("3a72401d-e217-4060-90d3-082d71738fc7"), Ma = "GV002", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Nguyễn", TenDem = "Thị", Ten = "Anh", GioiTinh = 1, NgaySinh = new DateTime(1990, 11, 13), DiaChi = "Hai Bà Trưng, Hà Nội", SoDienThoai = "0987123452", Email = "anhnt@fpt.edu.vn", TenDangNhap = "anhnt", MatKhau = "anhnt", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("4e5d07d2-fd6e-4c7e-91f2-32bb76cae67f"), Ma = "GV003", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Trần", TenDem = "Văn", Ten = "Cường", GioiTinh = 0, NgaySinh = new DateTime(1990, 11, 14), DiaChi = "Đống Đa, Hà Nội", SoDienThoai = "0987123453", Email = "cuongtv@fpt.edu.vn", TenDangNhap = "cuongtv", MatKhau = "cuongtv", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("7c9dfd21-0c6f-41f0-8eb4-921d0c1c025f"), Ma = "GV004", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Trần", TenDem = "Văn", Ten = "Dương", GioiTinh = 0, NgaySinh = new DateTime(1990, 11, 15), DiaChi = "Hoàn Kiếm, Hà Nội", SoDienThoai = "0987123454", Email = "duongtv@fpt.edu.vn", TenDangNhap = "duongtv", MatKhau = "duongtv", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("b1d3409b-4be1-4ce4-80d6-8287fbf6aa41"), Ma = "GV005", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Lê ", TenDem = "Văn", Ten = "Hoàng", GioiTinh = 0, NgaySinh = new DateTime(1990, 11, 16), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0987123455", Email = "hoanglv@fpt.edu.vn", TenDangNhap = "hoanglv", MatKhau = "hoanglv", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("4ff32689-cd10-4fbc-853f-a17559b17b88"), Ma = "GV006", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Lê ", TenDem = "Thị", Ten = "Loan", GioiTinh = 1, NgaySinh = new DateTime(1990, 11, 17), DiaChi = "Cầu Giấy, Hà Nội", SoDienThoai = "0987123456", Email = "loanlt@fpt.edu.vn", TenDangNhap = "loanlt", MatKhau = "loanlt", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("1875d041-8480-428b-aaef-99354ecb99ca"), Ma = "GV007", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Hoàng", TenDem = "Văn", Ten = "Thịnh", GioiTinh = 0, NgaySinh = new DateTime(1990, 11, 18), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0987123457", Email = "thinhhv@fpt.edu.vn", TenDangNhap = "thinhhv", MatKhau = "thinhhv", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("3578e3c0-c339-4cf3-abd2-41cfa7303b5b"), Ma = "GV008", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Hoàng", TenDem = "Thị", Ten = "Thảo", GioiTinh = 1, NgaySinh = new DateTime(1990, 11, 19), DiaChi = "Bắc Từ Liêm, Hà Nội", SoDienThoai = "0987123458", Email = "thaoht@fpt.edu.vn", TenDangNhap = "thaoht", MatKhau = "thaoht", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("7c54aa70-9252-4453-9677-6a0793902e6e"), Ma = "GV009", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Lâm", TenDem = "Trọng", Ten = "Kiên", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 10), DiaChi = "Hoàng Mai, Hà Nội", SoDienThoai = "0987123459", Email = "kienlt@fpt.edu.vn", TenDangNhap = "kienlt", MatKhau = "kienlt", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("82522981-e9b6-4a5e-b68c-0c6d6b5e88c2"), Ma = "GV010", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Quách", TenDem = "Minh", Ten = "Tiến", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 11), DiaChi = "Long Biên, Hà Nội", SoDienThoai = "0987123460", Email = "tienqm@fpt.edu.vn", TenDangNhap = "tienqm", MatKhau = "tienqm", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("fcf1365a-765f-4481-b178-fedc263110a3"), Ma = "GV011", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Lưu", TenDem = "Xuân", Ten = "Thái", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 12), DiaChi = "Nam Từ Liêm, Hà Nội", SoDienThoai = "0987123461", Email = "thailx@fpt.edu.vn", TenDangNhap = "thailx", MatKhau = "thailx", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("3203c2bf-a0e4-472b-826a-83413339f97b"), Ma = "GV012", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Lê", TenDem = "Tuấn", Ten = "Long", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 13), DiaChi = "Hoàn Kiếm, Hà Nội", SoDienThoai = "0987123462", Email = "longlt@fpt.edu.vn", TenDangNhap = "longlt", MatKhau = "longlt", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("5784260a-6fd1-4d14-9ed1-fbabbb9582ac"), Ma = "GV013", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Trần", TenDem = "Minh", Ten = "Khuê", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 14), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0987123463", Email = "khuetm@fpt.edu.vn", TenDangNhap = "khuetm", MatKhau = "khuetm", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("6499d44e-6cf1-4794-883d-904626e16c46"), Ma = "GV014", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Phan", TenDem = "Cao", Ten = "Tiến", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 15), DiaChi = "Cầu Giấy, Hà Nội", SoDienThoai = "0987123464", Email = "tienpc@fpt.edu.vn", TenDangNhap = "tienpc", MatKhau = "tienpc", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("2ec9cc84-96fb-4de4-8c4f-3cfcb0a28c57"), Ma = "GV015", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Đinh", TenDem = "Trọng", Ten = "Dũng", GioiTinh = 0, NgaySinh = new DateTime(1988, 10, 16), DiaChi = "Ba Đình, Hà Nội", SoDienThoai = "0987123465", Email = "dungdt@fpt.edu.vn", TenDangNhap = "dungdt", MatKhau = "dungdt", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 },
                new GiangVien() { Id = Guid.Parse("6f01c544-92ff-49e5-be2f-32aee79ccb0e"), Ma = "GV016", IdDaoTao = Guid.Parse("9d01fb1f-6d12-4b11-9962-871c333e659b"), Ho = "Ngô ", TenDem = "Quang", Ten = "Linh", GioiTinh = 0, NgaySinh = new DateTime(2000, 12, 12), DiaChi = "Bắc Từ Liêm, Hà Nội", SoDienThoai = "0987123466", Email = "linhnq@fpt.edu.vn", TenDangNhap = "linhnq", MatKhau = "linhnq", DuongDanAnh = "default.png", NgayTao = new DateTime(2010, 07, 01), TrangThai = 1 }
                );
        }
    }
}
