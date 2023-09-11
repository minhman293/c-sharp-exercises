using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP_KETHUA
{
    class NhanVienHopDong : NhanVien
    {
        private double mucluong;
        public double Mucluong
        {
            set { this.mucluong = value; }
            get { return this.mucluong; }
        }
        public NhanVienHopDong() : base() { }
        public NhanVienHopDong(string mnv, string ten, string gioi, DateTime dob, DateTime ngayvaocq, long scm, double mucluong) : base(mnv, ten, gioi, dob, ngayvaocq, scm)
        {
            this.mucluong = mucluong;
        }
        public override double tinhPhuCap()
        {
            if (base.tinhThamNien() >= 2)
                return this.mucluong * 0.1 + 200000;
            else
                return this.mucluong * 0.1 + 100000;
        }
        public override double tinhThucLinh()
        {
            return (base.luongcoban + this.mucluong) + this.tinhPhuCap();
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("nhap muc luong: ");
            this.mucluong = double.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("muc luong: " + this.mucluong);
            Console.WriteLine("phu cap: " + this.tinhPhuCap());
            Console.WriteLine("thuc linh: " + this.tinhThucLinh());
        }
    }
}
